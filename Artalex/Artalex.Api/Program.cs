using FluentValidation.AspNetCore;
using Artalex.BLL;
using Artalex.BLL.Helpers;
using Artalex.BLL.Middlewares;
//using Artalex.BLL.Validators.EmployeeValidators;
using Artalex.DAL;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;
using Artalex.BLL.Helpers;
using Artalex.BLL.Middlewares;
using Serilog.Events;

try
{
    var builder = WebApplication.CreateBuilder(args);

    Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .CreateBootstrapLogger();

    builder.Host.UseSerilog(Log.Logger);

    builder.Environment.WebRootPath = builder.Configuration.GetSection("FileSettings").GetSection("FilePath").Value;

    // Add services to the container.
    builder.Services.AddDbContext(builder.Configuration);

    builder.Services.AddWebServices(builder.Configuration);

    builder.Services.AddCors();
    builder.Services.AddRouting(options => options.LowercaseUrls = true);
    builder.Services.AddControllers().AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    }) /*.AddFluentValidation(options => options.RegisterValidatorsFromAssembly(typeof(ValidationModel).Assembly))*/;


    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    await app.DatabaseMigrate();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }


    app.UseCors(x =>
    {
        x.SetIsOriginAllowed(_ => true);
        x.AllowAnyMethod();
        x.AllowAnyHeader();
        x.AllowCredentials();
        x.WithExposedHeaders("Content-Disposition");
    });


    app.UseStaticFiles(new StaticFileOptions()
    {
        OnPrepareResponse = ctx =>
        {
            ctx.Context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
            ctx.Context.Response.Headers.Append("Access-Control-Allow-Headers",
                "Origin, X-Requested-With, Content-Type");
        },
        FileProvider =
            new PhysicalFileProvider(builder.Configuration.GetSection("FileSettings").GetSection("FilePath").Value)
    });

    app.UseSerilogRequestLogging();

    app.UseMiddleware<ErrorHandlingMiddleware>();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Logger.Error(ex, "Stopped program because of execution");
}