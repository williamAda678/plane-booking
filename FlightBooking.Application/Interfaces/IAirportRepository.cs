using System;
using FlightBooking.Application.DTOs.Airports;
using FlightBooking.Domain.Entities;

namespace FlightBooking.Application.Interfaces
{
    public interface IAirportRepository
    {
        Task<IEnumerable<Airport>> GetAirportsAsync();
        Task<Airport?> GetAirportByIdAsync(Guid id);
        Task<Airport> CreateAirportAsync(Airport airport);
        Task<Airport?> UpdateAirportAsync(Guid id, Airport airport);
        Task<bool> DeleteAirportAsync(Guid id);
    }
}
