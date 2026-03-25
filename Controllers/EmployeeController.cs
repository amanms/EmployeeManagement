using EmployeeManagement.Model.DTOs;
using EmployeeManagement.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("Api")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService) 
        {
            _employeeService = employeeService;
        }

        [HttpPost("Role")]

        public async Task<IActionResult> AddRoleAsync([FromBody]CreateRole createRole)
        {
            await _employeeService.AddRoleAsync(createRole);
            return Ok("Registered successfully");
        }

    }
}
