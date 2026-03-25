using EmployeeManagement.Model.DTOs;
using EmployeeManagement.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("Api/[controller]")]
    public class EmployeeController:ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;

        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterEmployeeAsync([FromBody] EmployeeDto employeeDto)
        {
            await _employeeService.RegisterEmployeeAsync(employeeDto);
            return Ok("registered successfully");
        }
    }
}
