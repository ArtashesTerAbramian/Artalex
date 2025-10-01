using System.Collections.Concurrent;
using System.Diagnostics;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Artalex.BLL.Services.TaskService;

public abstract class TaskManager : BackgroundService, IDisposable
{
    protected readonly ILogger<TaskManager> _logger;
    protected readonly IServiceProvider _serviceProvider;
    private readonly ConcurrentDictionary<Guid, TaskState> _tasks;

    public TaskManager(ILogger<TaskManager> logger,
        IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
        _tasks = new ConcurrentDictionary<Guid, TaskState>();
    }

    protected event Action<Guid, Exception> _onException;

    public abstract Task ExecuteTasks(CancellationToken cancellationToken);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await ExecuteTasks(stoppingToken).ConfigureAwait(false);
    }

    protected Guid? AddTask(Func<Task> task, TimeSpan interval, Action<Guid>? onTaskRun = null)
    {
        var ts = new TaskState(interval, onTaskRun);
        var date = DateTime.UtcNow.Date;
        ts.Timer = new Timer(async x =>
        {
            var state = (TimerState)x!;

            try
            {
                _logger.LogInformation($"Begin invoking task with id: {state.TaskId}");
                var stopwatch = Stopwatch.StartNew();

                await task.Invoke();

                _logger.LogInformation(
                    $"End invoke task with id: {state.TaskId} in: {stopwatch.ElapsedMilliseconds}ms");

                try
                {
                    state.OnTaskRun?.Invoke(state.TaskId);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, $"Error while invoking OnTaskRun for task with id: {state.TaskId}");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error while invoking task with id: {state.TaskId}");

                if (_onException != null)
                {
                    foreach (var @delegate in _onException.GetInvocationList().Cast<Action<Guid, Exception>>())
                    {
                        try
                        {
                            @delegate.Invoke(state.TaskId, e);
                        }
                        catch
                        {
                            // ignored
                        }
                    }
                }
            }
        }, ts.TimerState, TimeSpan.Zero, interval);

        if (_tasks.TryAdd(ts.Id, ts))
        {
            return ts.Id;
        }

        ts.Dispose();
        return null;
    }

    private class TaskState : IDisposable
    {
        public TaskState(TimeSpan interval, Action<Guid>? onTaskRun)
        {
            Id = Guid.NewGuid();
            Interval = interval;

            TimerState = new TimerState(Id, onTaskRun)
            {
                OnTaskRun = guid => { onTaskRun?.Invoke(guid); }
            };
        }

        public Guid Id { get; }
        public TimerState TimerState { get; }
        public TimeSpan Interval { get; }
        public Timer Timer { get; set; }

        public void Dispose()
        {
            Timer?.Dispose();
        }
    }

    private class TimerState
    {
        public Action<Guid>? OnTaskRun;

        public TimerState(Guid taskId, Action<Guid>? onTaskRun)
        {
            TaskId = taskId;
            OnTaskRun = onTaskRun;
        }

        public Guid TaskId { get; }
    }
}