using EmployeeManagement.Model.Entitties;
namespace EmployeeManagement.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        Task RegisterEmployeeAsync(Employee employee);
        Task<Employee?> GetEmployeeByEmail(string email);
    }
}
