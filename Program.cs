using microservices_customerapi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName =  Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword =  Environment.GetEnvironmentVariable("DB_SA_PASWORD");

var connectionString = builder.Configuration.GetValue<string>("ConnectionStrings:CustomerDbConnectionString")
   .Replace("YOURSERVERNAME", dbHost)
   .Replace("YOURDATABASENAME", dbName)
   .Replace("YOURUSERID", "sa")
   .Replace("YOURSQLPASSWORD", dbPassword);

Console.WriteLine($"connectionString = {connectionString}");

builder.Services.AddDbContext<CustomerDbContext>(x=>x.UseSqlServer(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
