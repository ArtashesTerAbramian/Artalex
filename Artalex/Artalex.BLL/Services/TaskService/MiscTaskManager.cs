using Artalex.BLL.Services.MailService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Artalex.BLL.Services.TaskService;

public class MiscTaskManager : TaskManager
{
    public MiscTaskManager(ILogger<TaskManager> logger,
        IServiceProvider serviceProvider) : base(logger, serviceProvider)
    {
    }

    public override async Task ExecuteTasks(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Task manager running");

        var disablePeriodic = new TimeSpan(0, 0, 0, 0, -1);

        AddTask(async () =>
        {
            _logger.LogInformation("Mail Sender Started");
            
            using var scope = _serviceProvider.CreateScope();
            var service = scope.ServiceProvider.GetService<IMailSenderService>();
            if (service == null)
            {
                return;
            }

            await service.SendEmails();
            
            _logger.LogInformation("Mail Sender Ended");
        }, TimeSpan.FromMinutes(1));

        await Task.CompletedTask;
    }
}