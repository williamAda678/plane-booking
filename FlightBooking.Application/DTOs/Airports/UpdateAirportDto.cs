using System;
using FlightBooking.Domain.Entities;

namespace FlightBooking.Application.DTOs.Airports
{
    public class UpdateAirportDto
    {
        public required string Code { get; set; }
        public required string Name { get; set; }
        public required string City { get; set; }
        public required string Country { get; set; }

    }
}
