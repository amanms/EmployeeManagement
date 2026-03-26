using EmployeeManagement.Model.Entitties;

namespace EmployeeManagement.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        Task AddRoleAsync(Role role);
        Task<Role> GetRoleAsync(string roleName);

        Task<Employee> GetEmployeeByIdAsync(int id);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(Employee employee);

        Task<Role> GetRoleByIdAsync(int id);
        Task<Boolean> IsRoleNameTaken(int id, string roleName);
        Task UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(Role role);
    }
}
