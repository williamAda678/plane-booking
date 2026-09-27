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

        modelBuilder.Entity<Flight>()
        .HasOne(d => d.DepartureAirport).WithMany().HasForeignKey(f => f.DepartureAirportId);
        modelBuilder.Entity<Flight>()
        .HasOne(a => a.ArrivalAirport).WithMany().HasForeignKey(f => f.ArrivalAirportId);
        modelBuilder.Entity<Flight>()
        .HasOne(p => p.Aircraft).WithMany().HasForeignKey(f => f.AircraftId);
    }
}


