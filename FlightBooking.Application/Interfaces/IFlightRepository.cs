using System;
using FlightBooking.Domain.Entities;

namespace FlightBooking.Application.Interfaces;

public interface IFlightRepository
{
    Task<IEnumerable<Flight>> GetFlightsAsync();
    Task<Flight?> GetFlightByIdAsync(Guid id);
    Task<Flight> CreateFlightAsync(Flight flight);
    Task<Flight?> UpdateFlightAsync(Guid id, Flight flight);
    Task<bool> DeleteFlightAsync(Guid id);
}
