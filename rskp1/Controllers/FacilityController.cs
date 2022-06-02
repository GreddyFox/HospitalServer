using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]


    public class FacilityController : ControllerBase
{
        private readonly FacilityService _context;

        public FacilityController(FacilityService context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Facility>>> GetFacility()
        {
            return await _context.GetFacilities();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Facility>> GetFacility(int id)
        {
            var facility = await _context.GetFacility(id);

            if (facility == null)
            {
                return NotFound();
            }

            return facility;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Facility>> PutFacility(int id, [FromBody] Facility facility)
        {
            var result = await _context.UpdateFacility(id, facility);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Facility>> PostFacility([FromBody] Facility facility)
        {
            var result = await _context.AddFacility(facility);
            if (result == null)
            {
                BadRequest();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacility(int id)
        {
            var facility = await _context.DeleteFacility(id);
            if (facility)
            {
                return Ok();
            }
            return BadRequest();
        }
    }

