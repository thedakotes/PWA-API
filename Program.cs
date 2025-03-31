using Microsoft.EntityFrameworkCore;
using AutoMapper;
using EventApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register AutoMapper (scanning all assemblies for profiles)
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Register your database context (change connection string as needed)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repository and service for dependency injection
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventService, EventService>();

// Add controllers
builder.Services.AddControllers();

// Configure Swagger (if you're using it for API documentation)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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

// Configure the HTTP request pipeline.

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
