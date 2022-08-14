using AutoMapper;
using FluentValidation.AspNetCore;
using Product.API.Filters;
using Product.Application;
using Product.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationRegister();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers(options =>
        options.Filters.Add<ApiExceptionFilterAttribute>())
    .AddFluentValidation(x => x.AutomaticValidationEnabled = false);


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
