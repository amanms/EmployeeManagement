using Azure.Core;
using EmployeeManagement.Model.DTOs;
using EmployeeManagement.Model.Entitties;
using EmployeeManagement.Repository.Interfaces;
using EmployeeManagement.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace EmployeeManagement.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task RegisterEmployeeAsync(EmployeeDto employeeDto)
        {
            if (employeeDto == null)
            {
                throw new ArgumentNullException("Provide employee data");
            }

            var hasUser = await _employeeRepository.GetEmployeeByEmail(employeeDto.EmployeeEmail);

            if (hasUser != null)
            {
                throw new Exception("User already exist");
            }
            CreatePasswordHash(employeeDto.Password, out string hash, out string salt);
            var employee = new Employee
            {
                EmployeeFirstName = employeeDto.EmployeeFirstName,
                EmployeeLastName = employeeDto.EmployeeLastName,
                EmployeeEmail = employeeDto.EmployeeEmail,
                PasswordHash = hash,
                PasswordSalt = salt
            };
            
            await _employeeRepository.RegisterEmployeeAsync(employee);

        }

        private void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt)
        {
            using var hmac = new HMACSHA512();

            byte[] saltBytes = hmac.Key;
            byte[] hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            passwordSalt = Convert.ToBase64String(saltBytes);
            passwordHash = Convert.ToBase64String(hashBytes);
        }
    }
}
