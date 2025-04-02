using Microsoft.EntityFrameworkCore;
using AutoMapper;
using EventApi.Data;
using API.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure the HTTP request pipeline.
builder.Services.AddHttpClient();

// Register AutoMapper (scanning all assemblies for profiles)
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Register your database context (change connection string as needed)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repository and service for dependency injection
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventService, EventService>();

// Retrieve the API provider from configuration
var plantIDAPIProvider = builder.Configuration["PlantIDProvider"];

if (plantIDAPIProvider == "PlantNet")
{
    builder.Services.AddScoped<IPlantIDService, PlantNetService>();
}
else if (plantIDAPIProvider == "PlantID")
{
    builder.Services.AddHttpClient<IPlantIDService, PlantIDService>();
}
else
{
    throw new Exception("Invalid PlantIDProvider configuration. Must be 'PlantNet' or 'PlantID'.");
}

// Load user secrets
builder.Configuration.AddUserSecrets<Program>();

// Add controllers
builder.Services.AddControllers();

// Configure Swagger (if you're using it for API documentation)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => 
{
    options.MapType<IFormFile>(() => new Microsoft.OpenApi.Models.OpenApiSchema
    {
        Type = "string",
        Format = "binary"
    });
});
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Enable Swagger (only for development or debugging)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline for production
app.UseCors(MyAllowSpecificOrigins);

// Enable authorization (if applicable)
app.UseAuthorization();

// Map controllers (API endpoints)
app.MapControllers();

// Run the application
app.Run();
