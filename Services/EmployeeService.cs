using EmployeeManagement.Model.DTOs;
using EmployeeManagement.Repository.Interfaces;
using EmployeeManagement.Services.Interfaces;
using EmployeeManagement.Model.Entitties;

namespace EmployeeManagement.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository) 
        { 
            _employeeRepository = employeeRepository;
        }

        public async Task AddRoleAsync(CreateRole createRole)
        {
            if(createRole == null)
            {
                throw new ArgumentNullException("Provide Role data");
            }
            var role = await _employeeRepository.GetRoleAsync(createRole.RoleName);
            if (role != null)
            {
                throw new Exception("Role already exists");
            }

            var newRole = new Role
            {
                RoleName = createRole.RoleName
            };
            
            await _employeeRepository.AddRoleAsync(newRole);
        }

    }
}
