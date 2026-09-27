using System;
using System.Net;
using FlightBooking.Application.Interfaces;
using FlightBooking.Domain.Entities;
using FlightBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FlightBooking.Infrastructure.Repositories;

public class AirportRepository(FlightBookingDbContext context) : IAirportRepository
{
    private readonly FlightBookingDbContext _context = context;

    public async Task<Airport> CreateAirportAsync(Airport airport)
    {

        _context.Add(airport);

        await _context.SaveChangesAsync();

        return airport;
    }

    public async Task<bool> DeleteAirportAsync(Guid id)
    {
        var airport = await _context.Airports.FirstOrDefaultAsync(x => x.Id == id);

        if (airport == null) return false;

        _context.Remove(airport);
        await _context.SaveChangesAsync();

        return true;

    }

    public async Task<Airport?> GetAirportByIdAsync(Guid id)
    {
        return await _context.Airports.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Airport>> GetAirportsAsync()
    {
        return await _context.Airports.ToListAsync();
    }

    public async Task<Airport?> UpdateAirportAsync(Guid id, Airport airport)
    {
        var currentAirport = await _context.Airports.FirstOrDefaultAsync(x => x.Id == id);

        if (currentAirport == null) return null;

        currentAirport.City = airport.City;
        currentAirport.Code = airport.Code;
        currentAirport.Country = airport.Country;
        currentAirport.Name = airport.Name;

        await _context.SaveChangesAsync();

        return currentAirport;

    }


}
