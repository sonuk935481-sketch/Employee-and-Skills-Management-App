using Microsoft.AspNetCore.Mvc;
using Employee_and_Skills_Management_App.Model;

namespace Employee_and_Skills_Management_App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CreateEmployeeController : ControllerBase
{
    private readonly Employee_and_Skills_Management_App.Services.IEmployeeService _service;

    public CreateEmployeeController(Employee_and_Skills_Management_App.Services.IEmployeeService service)
    {
        _service = service;
    }

    [HttpPost("usp_employyesave")]
    public async Task<IActionResult> Save([FromBody] EmployeeSaveDto dto)
    {
        if (dto == null)
            return BadRequest("Employee data is required.");

        try
        {
            // Delegate to service (which executes the stored procedure)
            await _service.SaveEmployeeAsync(dto);
            return Ok(new { message = "Saved" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }
}
