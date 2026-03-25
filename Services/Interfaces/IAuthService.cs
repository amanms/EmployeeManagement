using EmployeeManagement.Model.DTOs;
namespace EmployeeManagement.Services.Interfaces
{
    public interface IAuthService
    {
        Task RegisterEmployeeAsync(EmployeeDto employeeDto);
        Task<GetTokenDto> LoginEmployeeAsync(LoginDto loginDto);
    }
}
