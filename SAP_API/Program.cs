using DotnetSdkUtilities.Factory.ResponseFactory;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;
using SAP_API.Common;
using SAP_API.Configuration;
using SAP_API.Middlewares;
using SAP_API.Utilities;
using System.Reflection;



// Early init of NLog to allow startup and exception logging, before host is built
var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("SAP_API start");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
        });
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
    {
        options.CustomSchemaIds(type => type.ToString());
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "SAP API",
            Description = "Convert SOAP api body from xml to json",
        });
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        options.DocumentFilter<CustomDocumentFilter>();
    });
    builder.Services.AddScoped<IApiResponseFactory, ApiResponseFactory>();
    builder.Services.AddScoped<IMyResponseFactory, MyResponseFactory>();

    builder.Services.AddOptions().Configure<Settings>(builder.Configuration.GetSection("Settings"));
    var app = builder.Build();

    app.UseMiddleware<ExceptionMiddleware>();
    app.UseMiddleware<ValidateHeaderMiddleware>();
    // Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();

    // app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}