using System;

namespace FlightBooking.Domain.Entities;

public class Airport
{
    public Guid Id { get; set; }
    public required string Code { get; set; }
    public required string Name { get; set; }
    public required string City { get; set; }
    public required string Country { get; set; }

}
