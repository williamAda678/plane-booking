using System;
using FlightBooking.Application.DTOs.SearchFlight;
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

    public async Task<(IReadOnlyList<Flight> Flights, int TotalCount)> SearchFlightsAsync(
        SearchFlightRequestDto request)
    {
        var query = _context.Flights
            .AsNoTracking()
            .Include(flight => flight.DepartureAirport)
            .Include(flight => flight.ArrivalAirport)
            .Include(flight => flight.Aircraft)
            .AsQueryable();

        if (request.DepartureAirportId.HasValue)
        {
            query = query.Where(flight =>
                flight.DepartureAirportId == request.DepartureAirportId.Value);
        }

        if (request.ArrivalAirportId.HasValue)
        {
            query = query.Where(flight =>
                flight.ArrivalAirportId == request.ArrivalAirportId.Value);
        }

        if (request.DepartureDate.HasValue)
        {
            var departureDate = request.DepartureDate.Value.Date;
            query = query.Where(flight =>
                flight.DepartureTime >= departureDate &&
                flight.DepartureTime < departureDate.AddDays(1));
        }

        query = query.Where(flight =>
            flight.Aircraft.SeatCapacity >= request.Passengers);

        var totalCount = await query.CountAsync();

        query = request.SortBy.ToLowerInvariant() switch
        {
            "departuretime" => request.Descending
                ? query.OrderByDescending(flight => flight.DepartureTime)
                : query.OrderBy(flight => flight.DepartureTime),
            "price" => request.Descending
                ? query.OrderByDescending(flight => flight.Price)
                : query.OrderBy(flight => flight.Price),
            _ => query.OrderBy(flight => flight.DepartureTime)
        };

        var flights = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();

        return (flights, totalCount);
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
