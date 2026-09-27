using System;

namespace FlightBooking.Domain.Entities;

public class Aircraft
{
    public Guid Id { get; set; }
    public required string Model { get; set; }
    public required string Registration { get; set; }
    public int SeatCapacity { get; set; }

}
