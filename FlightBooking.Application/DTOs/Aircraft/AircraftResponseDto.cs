using System;

namespace FlightBooking.Application.DTOs.Aircraft
{
    public class AircraftResponseDto
    {
        public Guid Id { get; set; }
        public required string Model { get; set; }
        public required string Registration { get; set; }
        public int SeatCapacity { get; set; }
    }
}
