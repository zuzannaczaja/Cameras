using AutoMapper;
using Camera.API;
using Cameras.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("default", builder =>
    {
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
        builder.WithOrigins("*");
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cameras", Version = "v1" });
});

var config = new MapperConfiguration(cfg => { cfg.AddProfile(new AutoMapperProfileConfiguration()); });

var mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);
builder.Services.AddScoped<ICameraDataService, CameraDataService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cameras v1"));
}

app.UseHttpsRedirection();

app.UseCors("default");

app.UseAuthorization();

app.MapControllers();

app.Run();
