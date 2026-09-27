using FlightBooking.Application.Interfaces;
using FlightBooking.Application.Services.Airports;
using FlightBooking.Infrastructure.Data;
using FlightBooking.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<FlightBookingDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddScoped<IAirportRepository, AirportRepository>();
builder.Services.AddScoped<IAirportService, AirportService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.Run();

