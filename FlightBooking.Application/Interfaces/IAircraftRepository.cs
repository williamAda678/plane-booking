using System;
using FlightBooking.Domain.Entities;

namespace FlightBooking.Application.Interfaces
{
    public interface IAircraftRepository
    {

        Task<IEnumerable<Aircraft>> GetAirportsAsync();
        Task<Aircraft?> GetAirportByIdAsync(Guid id);
        Task<Aircraft> CreateAirportAsync(Aircraft aircraft);
        Task<Aircraft?> UpdateAirportAsync(Guid id, Aircraft aircraft);
        Task<bool> DeleteAirportAsync(Guid id);
    }
}
