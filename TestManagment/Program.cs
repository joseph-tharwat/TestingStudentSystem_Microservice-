using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestManagment.Infrastructure;
using TestManagment.Infrastructure.RabbitMQ;
using TestManagment.Services.CreateTest;
using TestManagment.Shared.Dtos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    }); 
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<TestDbContext>(ops=> ops.UseSqlServer(builder.Configuration.GetConnectionString("local")));
builder.Services.AddScoped<CreateTestService>();
builder.Services.AddScoped<RabbitMqService>();
builder.Services.AddAutoMapper(conf => { }, typeof(Program));

builder.Services.AddEndpointsApiExplorer();  
builder.Services.AddSwaggerUI();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
