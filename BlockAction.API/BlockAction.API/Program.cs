using BlockAction.API.Filter;
using BlockAction.Repository.Dtos.DataModel;
using BlockAction.Repository.Implement;
using BlockAction.Repository.Interface;
using BlockAction.Service.Implement;
using BlockAction.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog.Events;
using Serilog;
using System.Reflection;
using Serilog.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Logging

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.log",
        rollingInterval: RollingInterval.Hour, // 每小時一個檔案
        retainedFileCountLimit: 24 * 30 // 最多保留 30 天份的 Log 檔案
    )
    //.CreateLogger();
    .CreateBootstrapLogger();

//builder.Host.UseSerilog();
builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Services(services)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.Logger(loggerConfiguration => loggerConfiguration
        .Filter.ByExcluding(Matching.FromSource("WebApplicationSerilogTest.Controllers.UserController"))
        .WriteTo.File("logs/log-.log",
            rollingInterval: RollingInterval.Hour, // 每小時一個檔案
            retainedFileCountLimit: 24 * 30 // 最多保留 30 天份的 Log 檔案
        )
    )
    .WriteTo.Logger(loggerConfiguration => loggerConfiguration
        .Filter.ByIncludingOnly(Matching.FromSource("WebApplicationSerilogTest.Controllers.UserController"))
        .WriteTo.File("logs/api-.log",
            rollingInterval: RollingInterval.Hour, // 每小時一個檔案
            retainedFileCountLimit: 24 * 30 // 最多保留 30 天份的 Log 檔案
        )
    )
);

#endregion

#region Service

builder.Services.AddScoped<IUserService, UserService>();

#endregion

#region Repository

builder.Services.AddScoped<IUserRepository, UserRepository>();

#endregion

#region DB

builder.Services.AddDbContext<DemodbContext>(sp =>
{
    sp.UseNpgsql(builder.Configuration.GetConnectionString("PGContext"));
});

#endregion

#region Filter

builder.Services.AddControllersWithViews(sp =>
{
    sp.Filters.Add(typeof(ActionFilter));
    sp.Filters.Add(typeof(ResultFilter));
    sp.Filters.Add(typeof(ExceptionFilter));
});

#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( s =>
{
    // API 服務簡介
    s.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Demo API",
        Description = "Demo API 的範例",
        TermsOfService = new Uri("https://swagger.gkgstudio.com/#/"),
        Contact = new OpenApiContact
        {
            Name = "Miro",
            Url = new Uri("https://miro.com/app/board/uXjVNBVH6y0=/?moveToWidget=3458764573762013890&cot=14"),
        },
        License = new OpenApiLicense
        {
            Name = "jira",
            Url = new Uri("https://blockaction.atlassian.net/jira/software/projects/SCRUM/boards/1/backlog?atlOrigin=eyJwIjoiaiIsImkiOiJjZmI3OTgwMDJjOTQ0OWNmOTljY2ZkYWJhZjZkYjgzZCJ9&cloudId=94922263-5062-4f3c-b23f-e896ea05466c"),
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    s.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

Log.CloseAndFlush();
