using Microsoft.AspNetCore.Mvc;
using Employee_and_Skills_Management_App.Services;
using Employee_and_Skills_Management_App.Model;

namespace Employee_and_Skills_Management_App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _service;

    public EmployeesController(IEmployeeService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var e = await _service.GetEmployeeAsync(id);
        if (e == null) return NotFound();

        // Return a predictable JSON shape with camel-cased property names the client expects
        var dto = new
        {
            id = e.Id,
            firstName = e.FirstName,
            lastName = e.LastName,
            dateOfBirth = e.DateOfBirth,
            phone = e.Phone,
            skillIds = e.Skills?.Select(s => s.Id).ToArray() ?? Array.Empty<int>()
        };

        return Ok(dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] EmployeeSaveDto dto)
    {
        if (dto == null) return BadRequest("Payload required");

        var employee = await _service.GetEmployeeAsync(id);
        if (employee == null) return NotFound();

        // apply changes
        employee.FirstName = dto.FirstName ?? employee.FirstName;
        employee.LastName = dto.LastName ?? employee.LastName;
        employee.DateOfBirth = dto.DateOfBirth;
        employee.Phone = dto.Phone ?? employee.Phone;

        var skillIds = dto.SkillIds ?? Array.Empty<int>();
        await _service.UpdateEmployeeAsync(employee, skillIds);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var employee = await _service.GetEmployeeAsync(id);
        if (employee == null) return NotFound();

        await _service.DeleteEmployeeAsync(id);
        return NoContent();
    }
}
