using ECommerce.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Console.WriteLine("Hello world");	
builder.Services.AddControllers();	
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connStringKey = "PgConnString";
var connectionString =
    builder.Configuration.GetConnectionString(connStringKey)
        ?? throw new InvalidOperationException("Connection string"
        + connStringKey + " not found.");

builder.Services.AddDbContext<ECommerceDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var logger = LoggerFactory.Create(config =>
{
    config.AddConsole();
}).CreateLogger("Startup");

logger.LogInformation("Hello from logger");   

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ECommerceDbContext>();

    if (db.Database.CanConnect())
    {
        Console.WriteLine("Database connection successful");
    }
    else
    {
        Console.WriteLine("Database connection failed");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
