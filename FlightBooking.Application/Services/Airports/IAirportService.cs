using System;
using FlightBooking.Application.DTOs.Airports;

namespace FlightBooking.Application.Services.Airports;

public interface IAirportService
{
    Task<IEnumerable<AirportResponseDto>> GetAirportsAsync();
    Task<AirportResponseDto?> GetAirportByIdAsync(Guid id);
    Task<AirportResponseDto> CreateAirportAsync(CreateAirportDto createAirportDto);
    Task<AirportResponseDto?> UpdateAirportAsync(Guid id, UpdateAirportDto updateAirportDto);
    Task<bool> DeleteAirportAsync(Guid id);
}
