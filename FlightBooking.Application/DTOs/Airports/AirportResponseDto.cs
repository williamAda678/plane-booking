using System;

namespace FlightBooking.Application.DTOs.Airports
{
    public class AirportResponseDto
    {
        public Guid Id { get; set; }
        public required string Code { get; set; }
        public required string Name { get; set; }
        public required string City { get; set; }
        public required string Country { get; set; }
    }
}
