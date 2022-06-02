
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]

public class DoctorController : ControllerBase
{
    private readonly DoctorService _context;

    public DoctorController(DoctorService context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Doctor>> PostDoctor([FromBody] DoctorDTO doctor)
    {
        var result = await _context.AddDoctor(doctor);
        if (result == null)
        {
            BadRequest();
        }

        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
    {
        return await _context.GetDoctors();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Doctor>> GetDoctor(int id)
    {
        var doctor = await _context.GetDoctor(id);

        if (doctor == null)
        {
            return NotFound();
        }

        return doctor;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Doctor>> PutDoctor(int id, [FromBody] Doctor doctor)
    {
        var result = await _context.UpdateDoctor(id, doctor);
        if (result == null)
        {
            return BadRequest();
        }
        return Ok(result);
    }



    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDoctor(int id)
    {
        var doctor = await _context.DeleteDoctor(id);
        if (doctor)
        {
            return Ok();
        }
        return BadRequest();
    }


}
