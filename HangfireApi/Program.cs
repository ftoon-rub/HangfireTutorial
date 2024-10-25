using Hangfire;
using HangfireBasicAuthenticationFilter;
using InfrastructureLayer.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container ------------------------------------------------

builder.Services.AddHangfireServices(builder.Configuration);
//-------------------------------------------------------------------------------
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure Hangfire dashboard and middleware
app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    //DashboardTitle = "Hangfire Tetorial",// Hangfire Dashboard
    DarkModeEnabled = false,
    DisplayStorageConnectionString = false, //SQL Server: .@HangfireTestV1 
    Authorization = new[] { new HangfireCustomBasicAuthenticationFilter
        {
            User = "test",
            Pass = "test"
        }
    } 
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
