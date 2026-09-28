using FlightBooking.Application.DTOs.Aircraft;
using FlightBooking.Application.Services.Aircrafts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftController(IAircraftService aircraftService) : ControllerBase
    {
        private readonly IAircraftService _aircraftService = aircraftService;

        //  GET    /api/aircraft
        [HttpGet]
        public async Task<IActionResult> GetAirports()
        {
            return Ok(await _aircraftService.GetAircraftAsync());
        }
        //  GET    /api/aircraft/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAirport(Guid id)
        {
            var airport = await _aircraftService.GetAircraftByIdAsync(id);

            if (airport == null) return NotFound();
            return Ok(airport);
        }

        //  POST   /api/aircraft
        [HttpPost]
        public async Task<IActionResult> CreateAiport([FromBody] CreateAircraftDto createAircraftDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var airport = await _aircraftService.CreateAircraftAsync(createAircraftDto);
            return CreatedAtAction(nameof(GetAirport), new { id = airport.Id }, airport);
        }

        //  PUT    /api/aircraft/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAirport(Guid id, [FromBody] UpdateAircraftDto updateAircraftDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var airport = await _aircraftService.UpdateAircraftAsync(id, updateAircraftDto);

            if (airport == null)
                return NotFound();

            return Ok(airport);
        }

        //  DELETE /api/aircraft/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirport(Guid id)
        {
            var result = await _aircraftService.DeleteAircraftAsync(id);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
