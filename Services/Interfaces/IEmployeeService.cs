using EmployeeManagement.Model.DTOs;
namespace EmployeeManagement.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task RegisterEmployeeAsync(EmployeeDto employeeDto);
        Task<Boolean> LoginEmployeeAsync(LoginDto loginDto);
    }
}
