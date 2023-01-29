using Hermes.Application.Abstractions;
using Hermes.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

//Configure Database
builder.Services.AddDbContext<HermesContext>(options =>
    options.UseSqlite("Data Source=Hermes.db"));

//Create database if it doesn't exist
builder.Services.BuildServiceProvider().GetService<HermesContext>().Database.EnsureCreated();

//Dependency Injection
builder.Services.AddScoped<IRegistrationService, RegistrationService>();


var app = builder.Build();

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
