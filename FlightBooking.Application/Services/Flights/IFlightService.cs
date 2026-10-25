using System;
using FlightBooking.Application.DTOs.flights;
using FlightBooking.Application.DTOs.SearchFlight;

namespace FlightBooking.Application.Services.Flights;

public interface IFlightService
{
    Task<IEnumerable<FlightResponseDto>> GetFlightsAsync();
    Task<FlightResponseDto?> GetFlightByIdAsync(Guid id);
    Task<FlightResponseDto> CreateFlightAsync(CreateFlightDto flight);
    Task<FlightResponseDto?> UpdateFlightAsync(Guid id, UpdateFlightDto flight);
    Task<bool> DeleteFlightAsync(Guid id);
    Task<PagedFlightResultDto> SearchFlightsAsync(SearchFlightRequestDto request);

}
