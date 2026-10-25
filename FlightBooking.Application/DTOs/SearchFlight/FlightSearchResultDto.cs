using System;
using FlightBooking.Application.DTOs.Aircraft;
using FlightBooking.Application.DTOs.Airports;

namespace FlightBooking.Application.DTOs.SearchFlight;

public class FlightSearchResultDto
{
   public Guid Id { get; set; }
    public string FlightNumber { get; set; } = string.Empty;
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public decimal Price { get; set; }

    public AirportResponseDto DepartureAirport { get; set; } = null!;
    public AirportResponseDto ArrivalAirport { get; set; } = null!;
    public AircraftResponseDto Aircraft { get; set; } = null!;
}
