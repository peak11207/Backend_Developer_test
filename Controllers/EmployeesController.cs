using Backend_Developer_test.DTOs;
using Backend_Developer_test.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend_Developer_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeDTO employeeDto)
        {
            await _employeeService.AddEmployeeAsync(employeeDto);
            return CreatedAtAction(nameof(Get), new { id = employeeDto.EmpNo }, employeeDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeDTO employeeDto)
        {
            if (id != employeeDto.EmpNo)
            {
                return BadRequest();
            }
            await _employeeService.UpdateEmployeeAsync(employeeDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return NoContent();
        }
    }
}
