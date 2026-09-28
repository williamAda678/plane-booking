using System;
using FlightBooking.Application.Interfaces;
using FlightBooking.Domain.Entities;
using FlightBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FlightBooking.Infrastructure.Repositories;

public class AircraftRepository(FlightBookingDbContext context) : IAircraftRepository
{
    private readonly FlightBookingDbContext _context = context;



    public async Task<Aircraft> CreateAirportAsync(Aircraft aircraft)
    {
        _context.Add(aircraft);

        await _context.SaveChangesAsync();

        return aircraft;
    }

    public async Task<bool> DeleteAirportAsync(Guid id)
    {
        var airport = await _context.Aircraft.FirstOrDefaultAsync(x => x.Id == id);

        if (airport == null) return false;

        _context.Remove(airport);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<Aircraft?> GetAirportByIdAsync(Guid id)
    {
        return await _context.Aircraft.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Aircraft>> GetAirportsAsync()
    {
        return await _context.Aircraft.ToListAsync();
    }

    public async Task<Aircraft?> UpdateAirportAsync(Guid id, Aircraft aircraft)
    {
        var currentAircarft = await _context.Aircraft.FirstOrDefaultAsync(x => x.Id == id);

        if (currentAircarft == null) return null;

        currentAircarft.Model = aircraft.Model;
        currentAircarft.Registration = aircraft.Registration;
        currentAircarft.SeatCapacity = aircraft.SeatCapacity;

        await _context.SaveChangesAsync();

        return currentAircarft;
    }
}
