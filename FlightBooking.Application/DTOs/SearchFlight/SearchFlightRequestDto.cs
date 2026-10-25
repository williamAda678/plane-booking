using System;

namespace FlightBooking.Application.DTOs.SearchFlight;

public class SearchFlightRequestDto
{
    public Guid? DepartureAirportId { get; set; }
    public Guid? ArrivalAirportId { get; set; }
    public DateTime? DepartureDate { get; set; }
    public int Passengers { get; set; } = 1;
    public string SortBy { get; set; } = "price";
    public bool Descending { get; set; } = false;
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
