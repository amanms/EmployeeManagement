using EmployeeManagement.Model.DTOs;

namespace EmployeeManagement.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task AddRoleAsync(CreateRole createRole);
    }
}
