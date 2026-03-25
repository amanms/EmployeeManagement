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
    }
}
