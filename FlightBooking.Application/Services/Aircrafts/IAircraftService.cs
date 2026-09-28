using System;
using FlightBooking.Application.DTOs.Aircraft;

namespace FlightBooking.Application.Services.Aircrafts;

public interface IAircraftService
{
    Task<IEnumerable<AircraftResponseDto>> GetAircraftAsync();
    Task<AircraftResponseDto?> GetAircraftByIdAsync(Guid id);
    Task<AircraftResponseDto> CreateAircraftAsync(CreateAircraftDto createAircraftDto);
    Task<AircraftResponseDto?> UpdateAircraftAsync(Guid id, UpdateAircraftDto updateAircraftDto);
    Task<bool> DeleteAircraftAsync(Guid id);
}
