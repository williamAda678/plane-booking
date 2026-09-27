using FlightBooking.Application.DTOs.Airports;
using FlightBooking.Application.Services.Airports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController(IAirportService airportService) : ControllerBase
    {
        private readonly IAirportService _airportService = airportService;

        //  GET    /api/airports
        [HttpGet]
        public async Task<IActionResult> GetAirports()
        {
            return Ok(await _airportService.GetAirportsAsync());
        }
        //  GET    /api/airports/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAirport(Guid id)
        {
            var airport = await _airportService.GetAirportByIdAsync(id);

            if (airport == null) return NotFound();
            return Ok(airport);
        }

        //  POST   /api/airports
        [HttpPost]
        public async Task<IActionResult> CreateAiport([FromBody] CreateAirportDto createAirportDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var airport = await _airportService.CreateAirportAsync(createAirportDto);
            return CreatedAtAction(nameof(GetAirport), new { id = airport.Id }, airport);
        }

        //  PUT    /api/airports/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAirport(Guid id, [FromBody] UpdateAirportDto updateAirportDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var airport = await _airportService.UpdateAirportAsync(id, updateAirportDto);

            if (airport == null)
                return NotFound();

            return Ok(airport);
        }

        //  DELETE /api/airports/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirport(Guid id)
        {
            var result = await _airportService.DeleteAirportAsync(id);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
