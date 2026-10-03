using System;
using FlightBooking.Application.DTOs.Aircraft;
using FlightBooking.Application.DTOs.Airports;

namespace FlightBooking.Application.DTOs.flights
{
    public class FlightResponseDto
    {

        public Guid Id { get; set; }
        public required string FlightNumber { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Price { get; set; }

        public Guid DepartureAirportId { get; set; }
        public Guid ArrivalAirportId { get; set; }
        public Guid AircraftId { get; set; }

        public AirportResponseDto DepartureAirport { get; set; } = null!;
        public AirportResponseDto ArrivalAirport { get; set; } = null!;
        public AircraftResponseDto Aircraft { get; set; } = null!;
    }
}
