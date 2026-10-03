using System;
using FlightBooking.Application.DTOs.flights;
using FlightBooking.Application.Interfaces;
using FlightBooking.Domain.Entities;

namespace FlightBooking.Application.Services.Flights;

public class FlightService : IFlightService
{
    private readonly IFlightRepository _flightRepository;
    private readonly IAirportRepository _airportRepository;
    private readonly IAircraftRepository _aircraftRepository;

    public FlightService(
        IFlightRepository flightRepository,
        IAirportRepository airportRepository,
        IAircraftRepository aircraftRepository)
    {
        _flightRepository = flightRepository;
        _airportRepository = airportRepository;
        _aircraftRepository = aircraftRepository;
    }
    public async Task<FlightResponseDto> CreateFlightAsync(CreateFlightDto flight)
    {
        var departureAirport = await _airportRepository.GetAirportByIdAsync(flight.DepartureAirportId)
         ?? throw new InvalidOperationException("Departure airport not found.");

        var arrivalAirport = await _airportRepository.GetAirportByIdAsync(flight.ArrivalAirportId)
            ?? throw new InvalidOperationException("Arrival airport not found.");

        var aircraft = await _aircraftRepository.GetAirportByIdAsync(flight.AircraftId)
            ?? throw new InvalidOperationException("Aircraft not found.");


        var newFlight = new Flight
        {
            Id = Guid.NewGuid(),
            FlightNumber = flight.FlightNumber,
            AircraftId = flight.AircraftId,
            ArrivalAirportId = flight.ArrivalAirportId,
            DepartureAirportId = flight.DepartureAirportId,
            DepartureTime = flight.DepartureTime,
            ArrivalTime = flight.ArrivalTime,
            Price = flight.Price,
            ArrivalAirport = arrivalAirport,
            DepartureAirport = departureAirport,
            Aircraft = aircraft
        };


        var createdflight = await _flightRepository.CreateFlightAsync(newFlight);

        return ToResponseDto(createdflight);
    }

    public async Task<bool> DeleteFlightAsync(Guid id)
    {
        return await _flightRepository.DeleteFlightAsync(id);
    }

    public async Task<FlightResponseDto?> GetFlightByIdAsync(Guid id)
    {
        var flight = await _flightRepository.GetFlightByIdAsync(id);

        if (flight == null) return null;

        return ToResponseDto(flight);
    }

    public async Task<IEnumerable<FlightResponseDto>> GetFlightsAsync()
    {
        var airport = await _flightRepository.GetFlightsAsync();

        return airport.Select(ToResponseDto);
    }

    public async Task<FlightResponseDto?> UpdateFlightAsync(Guid id, UpdateFlightDto flight)
    {

        var departureAirport = await _airportRepository.GetAirportByIdAsync(flight.DepartureAirportId)
        ?? throw new InvalidOperationException("Departure airport not found.");

        var arrivalAirport = await _airportRepository.GetAirportByIdAsync(flight.ArrivalAirportId)
            ?? throw new InvalidOperationException("Arrival airport not found.");

        var aircraft = await _aircraftRepository.GetAirportByIdAsync(flight.AircraftId)
            ?? throw new InvalidOperationException("Aircraft not found.");


        var updateFlight = new Flight
        {
            FlightNumber = flight.FlightNumber,
            AircraftId = flight.AircraftId,
            ArrivalAirportId = flight.ArrivalAirportId,
            DepartureAirportId = flight.DepartureAirportId,
            DepartureTime = flight.DepartureTime,
            ArrivalTime = flight.ArrivalTime,
            Price = flight.Price,
            ArrivalAirport = arrivalAirport,
            DepartureAirport = departureAirport,
            Aircraft = aircraft
        };

        var updatedFlight = await _flightRepository.UpdateFlightAsync(id, updateFlight);

        if (updatedFlight == null) return null;

        return ToResponseDto(updatedFlight);
    }

    private static FlightResponseDto ToResponseDto(Flight flight)
    {
        return new FlightResponseDto
        {
            Id = flight.Id,
            FlightNumber = flight.FlightNumber,
            DepartureAirportId = flight.DepartureAirportId,
            ArrivalAirportId = flight.ArrivalAirportId,
            AircraftId = flight.AircraftId,
            DepartureTime = flight.DepartureTime,
            ArrivalTime = flight.ArrivalTime,
            Price = flight.Price
        };
    }
}
