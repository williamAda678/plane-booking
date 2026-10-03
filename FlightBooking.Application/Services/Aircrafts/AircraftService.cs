using System;
using FlightBooking.Application.DTOs.Aircraft;
using FlightBooking.Application.Interfaces;
using FlightBooking.Domain.Entities;

namespace FlightBooking.Application.Services.Aircrafts
{
    public class AircraftService(IAircraftRepository repository) : IAircraftService
    {
        private readonly IAircraftRepository _repository = repository;
        public async Task<AircraftResponseDto> CreateAircraftAsync(CreateAircraftDto createAircraftDto)
        {
            var newAircraft = new Aircraft
            {
                Id = Guid.NewGuid(),
                Model = createAircraftDto.Model,
                Registration = createAircraftDto.Registration,
                SeatCapacity = createAircraftDto.SeatCapacity,

            };

            var airport = await _repository.CreateAirportAsync(newAircraft);

            return ToResponseDto(airport);
        }

        public Task<bool> DeleteAircraftAsync(Guid id)
        {
            return _repository.DeleteAirportAsync(id);
        }

        public async Task<IEnumerable<AircraftResponseDto>> GetAircraftAsync()
        {
            var aircraft = await _repository.GetAirportsAsync();

            return aircraft.Select(ToResponseDto);
        }

        public async Task<AircraftResponseDto?> GetAircraftByIdAsync(Guid id)
        {
            var aircraft = await _repository.GetAirportByIdAsync(id);

            if (aircraft == null) return null;

            return ToResponseDto(aircraft);
        }

        public async Task<AircraftResponseDto?> UpdateAircraftAsync(Guid id, UpdateAircraftDto updateAircraftDto)
        {
            var updateAircraft = new Aircraft
            {
                Model = updateAircraftDto.Model,
                Registration = updateAircraftDto.Registration,
                SeatCapacity = updateAircraftDto.SeatCapacity,
            };

            var airport = await _repository.UpdateAirportAsync(id, updateAircraft);

            if (airport == null) return null;

            return ToResponseDto(airport);
        }

        private static AircraftResponseDto ToResponseDto(Aircraft aircraft)
        {
            return new AircraftResponseDto
            {
                Id = aircraft.Id,
                Model = aircraft.Model,
                Registration = aircraft.Registration,
                SeatCapacity = aircraft.SeatCapacity,
            };
        }
    }
}
