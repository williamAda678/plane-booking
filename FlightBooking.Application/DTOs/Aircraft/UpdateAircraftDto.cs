using System;
using FlightBooking.Domain.Entities;

namespace FlightBooking.Application.DTOs.Aircraft;

public class UpdateAircraftDto
{
    public required string Model { get; set; }
    public required string Registration { get; set; }
    public int SeatCapacity { get; set; }
}
