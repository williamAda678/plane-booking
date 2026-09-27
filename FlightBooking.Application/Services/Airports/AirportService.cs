using System;
using FlightBooking.Application.DTOs.Airports;
using FlightBooking.Application.Interfaces;
using FlightBooking.Domain.Entities;

namespace FlightBooking.Application.Services.Airports;

public class AirportService(IAirportRepository repository) : IAirportService
{

    private readonly IAirportRepository _repository = repository;

    public async Task<AirportResponseDto> CreateAirportAsync(CreateAirportDto createAirportDto)
    {
        var newAirport = new Airport
        {
            Id = Guid.NewGuid(),
            Code = createAirportDto.Code,
            Country = createAirportDto.Country,
            City = createAirportDto.City,
            Name = createAirportDto.Name
        };


        var airport = await _repository.CreateAirportAsync(newAirport);

        return ToResponseDto(airport);

    }

    public Task<bool> DeleteAirportAsync(Guid id)
    {
        return _repository.DeleteAirportAsync(id);
    }

    public async Task<AirportResponseDto?> GetAirportByIdAsync(Guid id)
    {
        var airport = await _repository.GetAirportByIdAsync(id);

        if (airport == null) return null;

        return ToResponseDto(airport);
    }

    public async Task<IEnumerable<AirportResponseDto>> GetAirportsAsync()
    {
        var airport = await _repository.GetAirportsAsync();


        return airport.Select(ToResponseDto);
    }

    public async Task<AirportResponseDto?> UpdateAirportAsync(Guid id, UpdateAirportDto updateAirportDto)
    {
        var updateAirport = new Airport
        {
            Code = updateAirportDto.Code,
            Country = updateAirportDto.Country,
            City = updateAirportDto.City,
            Name = updateAirportDto.Name
        };

        var airport = await _repository.UpdateAirportAsync(id, updateAirport);

        if (airport == null) return null;

        return ToResponseDto(airport);
    }

    private static AirportResponseDto ToResponseDto(Airport airport)
    {
        return new AirportResponseDto
        {
            Id = airport.Id,
            Code = airport.Code,
            Country = airport.Country,
            City = airport.City,
            Name = airport.Name
        };
    }
}
