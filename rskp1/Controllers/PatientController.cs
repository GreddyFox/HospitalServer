using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]

public class PatientController: ControllerBase
    {
    private readonly PatientService _context;
        
    public PatientController(PatientService context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Patient>>> GetPatient()
    {
        return await _context.GetPatients();
    } 


    [HttpGet("{id}")]
    public async Task<ActionResult<Patient>> GetPatient(int id)
    {
        var patient = await _context.GetPatient(id);

        if (patient == null)
        {
            return NotFound();
        }

        return patient;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Patient>> PutDoctor(int id, [FromBody] Patient patient)
    {
        var result = await _context.UpdatePatient(id, patient);
        if (result == null)
        {
            return BadRequest();
        }
        return Ok(result);
    }


    [HttpPost]
    public async Task<ActionResult<Patient>> PostPatient([FromBody] PatientDTO patient)
    {
        var result = await _context.AddPatient(patient);
        if (result == null)
        {
            BadRequest();
        }

        return Ok(result);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePatient(int id)
    {
        var patient = await _context.DeletePatient(id);
        if (patient)
        {
            return Ok();
        }
        return BadRequest();
    }
}

