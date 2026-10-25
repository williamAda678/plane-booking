using FlightBooking.Application.Interfaces;
using FlightBooking.Application.DTOs.SearchFlight;
using FlightBooking.Application.Services.Flights;
using Moq;

public class FlightServiceTests
{
    [Fact]
    public async Task SearchFlightsAsync_RejectsInvalidPassengerCount()
    {
        var repository = new Mock<IFlightRepository>();
        var airportRepository = new Mock<IAirportRepository>();
        var aircraftRepository = new Mock<IAircraftRepository>();

        var service = new FlightService(
            repository.Object,
            airportRepository.Object,
            aircraftRepository.Object);

        var request = new SearchFlightRequestDto
        {
            Passengers = 0
        };

        await Assert.ThrowsAsync<ArgumentException>(() =>
            service.SearchFlightsAsync(request));
    }
}