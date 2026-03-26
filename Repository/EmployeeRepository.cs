using EmployeeManagement.Data;
using EmployeeManagement.Model.Entitties;
using EmployeeManagement.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddRoleAsync(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();

        }

        public async Task<Role> GetRoleAsync(string roleName)
        {
            var role = await _context.Roles.AsNoTracking().
                FirstOrDefaultAsync(r=>r.RoleName == roleName && !r.IsDeleted);
            return role;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var employee = await _context.Employees.
                FirstOrDefaultAsync(emp=>emp.EmployeeId == id && !emp.IsDeleted);
            return employee;
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        
        public async Task<Role> GetRoleByIdAsync(int id)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r=>r.RoleId == id && !r.IsDeleted);
            return role;
        }

        public async Task<Boolean> IsRoleNameTaken(int id , string roleName)
        {
            var exists = await _context.Roles
                        .AnyAsync(r => r.RoleName == roleName && r.RoleId != id && !r.IsDeleted);

            return exists;
        }
        public async Task UpdateRoleAsync(Role role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(Role role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
        }
    }
}
