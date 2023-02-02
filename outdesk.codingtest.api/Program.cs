using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using outdesk.codingtest.api.Extensions;
using outdesk.codingtest.api.Helpers;
using outdesk.codingtest.Infrastructure.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var configBuilder = new ConfigurationBuilder();
// add values from a json file
configBuilder.AddJsonFile("appsettings.json");

// create the IConfigurationRoot instance
IConfigurationRoot config = configBuilder.Build();
// Add services to the container.
builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddMediatR(typeof(Program).GetTypeInfo().Assembly);
builder.Services.AddControllers();
builder.Services.AddApplicationServices();
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

SeedDatabase();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void SeedDatabase() //can be placed at the very bottom under app.Run()
{
    using (var scope = app.Services.CreateScope())
    {
        var databaseInitializer = scope.ServiceProvider.GetRequiredService<IDatabaseInitializer>();
        databaseInitializer.SeedData().Wait();
    }
}