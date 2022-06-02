using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]

public class MedicalFileController: ControllerBase
    {
    private readonly MedicalFileService _context;

    public MedicalFileController(MedicalFileService context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<MedicalFile>>> GetMedicalFile()
    {
        return await _context.GetMedicalFiles();
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<MedicalFile>> GetMedicalFile(int id)
    {
        var medicalFile = await _context.GetMedicalFile(id);

        if (medicalFile == null)
        {
            return NotFound();
        }

        return medicalFile;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MedicalFile>> PutMedicalFile(int id, [FromBody] MedicalFile medicalFile)
    {
        var result = await _context.UpdateMedicalFile(id, medicalFile);
        if (result == null)
        {
            return BadRequest();
        }
        return Ok(result);
    }


    [HttpPost]
    public async Task<ActionResult<MedicalFile>> PostMedicalFile([FromBody] MedicalFileDTO medicalFile)
    {
        var result = await _context.AddMedicalFile(medicalFile);
        if (result == null)
        {
            BadRequest();
        }

        return Ok(result);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMedicalFile(int id)
    {
        var medicalFile = await _context.DeleteMedicalFile(id);
        if (medicalFile)
        {
            return Ok();
        }
        return BadRequest();
    }
}

