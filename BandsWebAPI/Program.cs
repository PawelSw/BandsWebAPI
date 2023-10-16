using BandsWebAPI;
using BandsWebAPI.DbContexts;
using BandsWebAPI.Middleware;
using BandsWebAPI.Services;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using Serilog;
using System.Text.Json;
using System.Text.Json.Serialization;

//Log.Logger = new LoggerConfiguration()
//    .MinimumLevel.Debug()
//    .WriteTo.Console()
//    .WriteTo.File("logs/bandsinfo.txt", rollingInterval: RollingInterval.Day)
//    .CreateLogger();
var builder = WebApplication.CreateBuilder(args);
//builder.Host.UseSerilog();
// Add services to the container.
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();
builder.Services.AddControllers();
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddControllers()
//    .AddJsonOptions(options =>
//    {
//        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
//    });



builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IBandService,BandService>();
builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddDbContext<BandsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BandsDatabaseConnection")));
builder.Services.AddScoped<BandsSeeder>();
var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<BandsSeeder>();

seeder.Seed();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
