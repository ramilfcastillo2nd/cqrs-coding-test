using Microsoft.EntityFrameworkCore;
using outdesk.codingtest.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);
var configBuilder = new ConfigurationBuilder();
// add values from a json file
configBuilder.AddJsonFile("appsettings.json");

// create the IConfigurationRoot instance
IConfigurationRoot config = configBuilder.Build();
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<OutDeskContext>(options =>
{
    options.UseSqlServer(config.GetSection("ConnectionStrings:DefaultConnection").Value, b => b.MigrationsAssembly("outdesk.codingtest.Infrastructure"));
}, ServiceLifetime.Scoped);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
