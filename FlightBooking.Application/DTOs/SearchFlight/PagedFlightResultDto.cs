using System;

namespace FlightBooking.Application.DTOs.SearchFlight;

public class PagedFlightResultDto
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public List<FlightSearchResultDto> Items { get; set; } = new();
}
