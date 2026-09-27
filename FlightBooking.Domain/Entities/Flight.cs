using System;

namespace FlightBooking.Domain.Entities;

public class Flight
{
    public Guid Id { get; set; }
    public required string FlightNumber { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public decimal Price { get; set; }

    public required Guid DepartureAirportId { get; set; }
    public required Guid ArrivalAirportId { get; set; }
    public required Guid AircraftId { get; set; }

    public required Airport DepartureAirport { get; set; }
    public required Airport ArrivalAirport { get; set; }
    public required Aircraft Aircraft { get; set; }

}
