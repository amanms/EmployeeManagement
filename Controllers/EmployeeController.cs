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

        [HttpPut("EditRole/{id}")]
        public async Task<IActionResult> UpdateRoleAsync(int id , [FromBody]CreateRole updateRole)
        {
            await _employeeService.UpdateRoleAsync(id, updateRole);
            return Ok("Updated successfully");
        }

        [HttpPut("DeleteRole/{id}")]
        public async Task<IActionResult> DeleteRoleAsync(int id)
        {
            await _employeeService.DeleteRoleAsync(id);
            return Ok("Role deleted");
        }

        [HttpPut("Employee/{id}")]
        public async Task<IActionResult> UpdateEmployeeAsync(int id , [FromBody] UpdateEmployeeDto updateEmployeeDto)
        {
            await _employeeService.UpdateEmployeeAsync(id, updateEmployeeDto);
            return Ok("Employee updated successfully");
        }

        [HttpPut("Delete/{id}")]
        public async Task<IActionResult> DeleteEmployeeAsync(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return Ok("Employee deleted");
        }

    }
}
