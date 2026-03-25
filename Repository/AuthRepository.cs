using EmployeeManagement.Repository.Interfaces;
using EmployeeManagement.Model.Entitties;
using EmployeeManagement.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repository
{
    public class AuthRepository:IAuthRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task RegisterEmployeeAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

        }

        public async Task<Employee?> GetEmployeeByEmail(string email)
        {
            return await _context.Employees
                .AsNoTracking()
                .FirstOrDefaultAsync(emp => emp.EmployeeEmail == email && !emp.IsDeleted);
        }

    }
}
