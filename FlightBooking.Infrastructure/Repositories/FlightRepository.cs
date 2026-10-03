using System;
using FlightBooking.Application.Interfaces;
using FlightBooking.Domain.Entities;
using FlightBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FlightBooking.Infrastructure.Repositories;

public class FlightRepository(FlightBookingDbContext context) : IFlightRepository
{

    private readonly FlightBookingDbContext _context = context;

    public async Task<Flight> CreateFlightAsync(Flight flight)
    {
        _context.Add(flight);

        await _context.SaveChangesAsync();

        return flight;
    }

    public async Task<bool> DeleteFlightAsync(Guid id)
    {
        var flight = await _context.Flights.FirstOrDefaultAsync(x => x.Id == id);

        if (flight == null) return false;

        _context.Remove(flight);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<Flight?> GetFlightByIdAsync(Guid id)
    {
        return await _context.Flights.FirstOrDefaultAsync(x => x.Id == id);

    }

    public async Task<IEnumerable<Flight>> GetFlightsAsync()
    {
        return await _context.Flights.ToListAsync();

    }

    public async Task<Flight?> UpdateFlightAsync(Guid id, Flight flight)
    {
        var currentFlight = await _context.Flights.FirstOrDefaultAsync(x => x.Id == id);

        if (currentFlight == null) return null;

        currentFlight.FlightNumber = flight.FlightNumber;
        currentFlight.AircraftId = flight.AircraftId;
        currentFlight.ArrivalAirportId = flight.ArrivalAirportId;
        currentFlight.DepartureAirportId = flight.DepartureAirportId;
        currentFlight.DepartureTime = flight.DepartureTime;
        currentFlight.ArrivalTime = flight.ArrivalTime;
        currentFlight.Price = flight.Price;

        await _context.SaveChangesAsync();

        return currentFlight;
    }
}
