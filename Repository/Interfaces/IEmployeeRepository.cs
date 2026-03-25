using EmployeeManagement.Model.Entitties;

namespace EmployeeManagement.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        Task AddRoleAsync(Role role);
        Task<Role> GetRoleAsync(string roleName);
    }
}
