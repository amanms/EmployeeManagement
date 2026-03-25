using EmployeeManagement.Model.DTOs;
using EmployeeManagement.Repository.Interfaces;
using EmployeeManagement.Services.Interfaces;
using EmployeeManagement.Model.Entitties;

namespace EmployeeManagement.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAuthRepository _authRepository;
        public EmployeeService(IEmployeeRepository employeeRepository , IAuthRepository authRepository) 
        { 
            _employeeRepository = employeeRepository;
            _authRepository = authRepository;
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

        public async Task UpdateEmployeeAsync(int id, UpdateEmployeeDto updateEmployeeDto)
        {
            var getEmployee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if(getEmployee == null)
            {
                throw new Exception("Employee Not found");
            }

            var getEmployeeByEmail = await _authRepository.GetEmployeeByEmail(updateEmployeeDto.EmployeeEmail);
            if(getEmployeeByEmail != null && getEmployeeByEmail.EmployeeId != id)
            {
                throw new Exception("Email already exists");
            }


            getEmployee.EmployeeFirstName = updateEmployeeDto.EmployeeFirstName;
            getEmployee.EmployeeLastName = updateEmployeeDto.EmployeeLastName;
            getEmployee.EmployeeEmail = updateEmployeeDto.EmployeeEmail;
            getEmployee.UpdatedAt = DateTime.UtcNow;
            

            await _employeeRepository.UpdateEmployeeAsync(getEmployee);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var getEmployee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (getEmployee == null)
            {
                throw new Exception("Employee Not found");
            }
            getEmployee.IsDeleted = true; ;

            await _employeeRepository.DeleteEmployeeAsync(getEmployee);
        }

    }
}
