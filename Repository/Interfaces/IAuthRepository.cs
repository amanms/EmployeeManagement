using EmployeeManagement.Model.Entitties;
namespace EmployeeManagement.Repository.Interfaces
{
    public interface IAuthRepository
    {
        Task RegisterEmployeeAsync(Employee employee);
        Task<Employee?> GetEmployeeByEmail(string email);
    }
}
