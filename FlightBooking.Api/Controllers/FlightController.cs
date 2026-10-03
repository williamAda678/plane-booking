using FlightBooking.Application.DTOs.flights;
using FlightBooking.Application.Services.Flights;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController(IFlightService flightService) : ControllerBase
    {
        private readonly IFlightService _flightService = flightService;

        //  GET    /api/flight
        [HttpGet]
        public async Task<IActionResult> GetFlight()
        {
            return Ok(await _flightService.GetFlightsAsync());
        }
        //  GET    /api/flight/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlight(Guid id)
        {
            var flight = await _flightService.GetFlightByIdAsync(id);

            if (flight == null) return NotFound();
            return Ok(flight);
        }

        //  POST   /api/flight
        [HttpPost]
        public async Task<IActionResult> CreateAiport([FromBody] CreateFlightDto createFlightDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var flight = await _flightService.CreateFlightAsync(createFlightDto);
            return CreatedAtAction(nameof(GetFlight), new { id = flight.Id }, flight);
        }

        //  PUT    /api/flight/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAirport(Guid id, [FromBody] UpdateFlightDto updateFlightDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var flight = await _flightService.UpdateFlightAsync(id, updateFlightDto);

            if (flight == null)
                return NotFound();

            return Ok(flight);
        }

        //  DELETE /api/flight/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirport(Guid id)
        {
            var result = await _flightService.DeleteFlightAsync(id);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
