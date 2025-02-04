using CRUD_VideoGamesConsoles.DTOs;
using CRUD_VideoGamesConsoles.Models;
using CRUD_VideoGamesConsoles.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Entity Framework Configuration
builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnection"));
});

//validators
builder.Services.AddScoped<IValidator<GameConsoleInsertDto>, GameConsoleInsertValidator>();
builder.Services.AddScoped<IValidator<GameConsoleUpdateDto>, GameConsoleUpdateValidator>();

builder.Services.AddControllers();
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
