using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]

public class AppointmentController : ControllerBase
{
    private readonly AppointmentService _context;

    public AppointmentController(AppointmentService context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointment()
    {
        return await _context.GetAppointments();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Appointment>> GetAppointment(int id)
    {
        var appointment = await _context.GetAppointment(id);

        if (appointment == null)
        {
            return NotFound();
        }

        return appointment;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Appointment>> PutAppointment(int id, [FromBody] Appointment appointment)
    {
        var result = await _context.UpdateAppointment(id, appointment);
        if (result == null)
        {
            return BadRequest();
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Appointment>> PostAppointment([FromBody] AppointmentDTO appointment)
    {
        var result = await _context.AddAppointment(appointment);
        if (result == null)
        {
            BadRequest();
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAppointment(int id)
    {
        var appointment = await _context.DeleteAppointment(id);
        if (appointment)
        {
            return Ok();
        }
        return BadRequest();
    }
}

