using System;

namespace FlightBooking.Application.DTOs.flights
{
    public class UpdateFlightDto
    {
        public required string FlightNumber { get; set; }
        public required Guid DepartureAirportId { get; set; }
        public required Guid ArrivalAirportId { get; set; }
        public required Guid AircraftId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Price { get; set; }
    }
}
