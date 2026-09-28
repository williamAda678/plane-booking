using System;
using FlightBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlightBooking.Infrastructure.Data;

public class FlightBookingDbContext(DbContextOptions<FlightBookingDbContext> options) : DbContext(options)
{
    public DbSet<Aircraft> Aircraft { get; set; }
    public DbSet<Airport> Airports { get; set; }
    public DbSet<Flight> Flights { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var sydneyAirportId = Guid.Parse("11111111-1111-1111-1111-111111111111");
        var tokyoAirportId = Guid.Parse("22222222-2222-2222-2222-222222222222");
        var singaporeAirportId = Guid.Parse("33333333-3333-3333-3333-333333333333");
        var airbusId = Guid.Parse("44444444-4444-4444-4444-444444444444");
        var boeingId = Guid.Parse("55555555-5555-5555-5555-555555555555");

        modelBuilder.Entity<Airport>().HasData(
            new Airport
            {
                Id = sydneyAirportId,
                Code = "SYD",
                Name = "Sydney Kingsford Smith",
                City = "Sydney",
                Country = "Australia"
            },
            new Airport
            {
                Id = tokyoAirportId,
                Code = "HND",
                Name = "Tokyo Haneda",
                City = "Tokyo",
                Country = "Japan"
            },
            new Airport
            {
                Id = singaporeAirportId,
                Code = "SIN",
                Name = "Singapore Changi",
                City = "Singapore",
                Country = "Singapore"
            });

        modelBuilder.Entity<Aircraft>().HasData(
            new Aircraft
            {
                Id = airbusId,
                Model = "Airbus A320",
                Registration = "VH-ABC",
                SeatCapacity = 180
            },
            new Aircraft
            {
                Id = boeingId,
                Model = "Boeing 787-9",
                Registration = "VH-XYZ",
                SeatCapacity = 296
            });

        modelBuilder.Entity<Flight>().HasData(
            new
            {
                Id = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                FlightNumber = "FB101",
                DepartureTime = new DateTime(2027, 3, 15, 10, 0, 0, DateTimeKind.Utc),
                ArrivalTime = new DateTime(2027, 3, 15, 18, 0, 0, DateTimeKind.Utc),
                Price = 850m,
                DepartureAirportId = sydneyAirportId,
                ArrivalAirportId = tokyoAirportId,
                AircraftId = boeingId
            },
            new
            {
                Id = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                FlightNumber = "FB202",
                DepartureTime = new DateTime(2027, 3, 16, 2, 0, 0, DateTimeKind.Utc),
                ArrivalTime = new DateTime(2027, 3, 16, 10, 0, 0, DateTimeKind.Utc),
                Price = 420m,
                DepartureAirportId = tokyoAirportId,
                ArrivalAirportId = singaporeAirportId,
                AircraftId = airbusId
            },
            new
            {
                Id = Guid.Parse("88888888-8888-8888-8888-888888888888"),
                FlightNumber = "FB303",
                DepartureTime = new DateTime(2027, 3, 18, 12, 0, 0, DateTimeKind.Utc),
                ArrivalTime = new DateTime(2027, 3, 18, 18, 0, 0, DateTimeKind.Utc),
                Price = 610m,
                DepartureAirportId = singaporeAirportId,
                ArrivalAirportId = sydneyAirportId,
                AircraftId = boeingId
            });

        modelBuilder.Entity<Flight>()
        .HasOne(d => d.DepartureAirport).WithMany().HasForeignKey(f => f.DepartureAirportId);
        modelBuilder.Entity<Flight>()
        .HasOne(a => a.ArrivalAirport).WithMany().HasForeignKey(f => f.ArrivalAirportId);
        modelBuilder.Entity<Flight>()
        .HasOne(p => p.Aircraft).WithMany().HasForeignKey(f => f.AircraftId);
    }
}


