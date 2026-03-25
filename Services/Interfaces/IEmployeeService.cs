using EmployeeManagement.Model.DTOs;

namespace EmployeeManagement.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task AddRoleAsync(CreateRole createRole);
        Task UpdateEmployeeAsync(int id,UpdateEmployeeDto updateEmployee);
        Task DeleteEmployeeAsync(int id);

    }
}
