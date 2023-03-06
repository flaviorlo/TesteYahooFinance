using Domain.Model;
using Infraestructure;
using Infraestructure.Interfaces;
using Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;
using Service;
using Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
string cnnMysSql = builder.Configuration.GetConnectionString("AppDbMySql");


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration.GetConnectionString("ConnectionStrings");
builder.Services.AddSingleton<ICalcularService, CalcularService>();
builder.Services.AddSingleton<ICalcularRepository, CalcularRepository>();
builder.Services.AddTransient<DbConnection>();

builder.Services.AddCors();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(opcoes => opcoes.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseAuthorization();

app.MapControllers();

app.Run();
