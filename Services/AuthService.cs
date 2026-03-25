using Azure.Core;
using EmployeeManagement.Helpers;
using EmployeeManagement.Model.DTOs;
using EmployeeManagement.Model.Entitties;
using EmployeeManagement.Repository.Interfaces;
using EmployeeManagement.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace EmployeeManagement.Services
{
    public class AuthService:IAuthService
    {
        private readonly IAuthRepository _employeeRepository;
        private readonly JwtTokenGenerator _jwt;

        public AuthService(IAuthRepository employeeRepository, JwtTokenGenerator jwt)
        {
            _employeeRepository = employeeRepository;
            _jwt = jwt;
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

        public async Task<GetTokenDto> LoginEmployeeAsync(LoginDto loginDto)
        {
            var getUser = await _employeeRepository.GetEmployeeByEmail(loginDto.Email);
            if (getUser == null)
            {
                throw new Exception ($"Invalid Login {loginDto.Email}");
            }

            var validPassword = VerifyPasswordHash(loginDto.Password , getUser.PasswordHash, getUser.PasswordSalt);

            if (!validPassword)
            {
                throw new Exception("Invalid credentials");
            }

            var getEmployee = new GetEmployeeDto
            {
                EmployeeId = getUser.EmployeeId,
                EmployeeFirstName = getUser.EmployeeFirstName,
                EmployeeLastName = getUser.EmployeeLastName,
                EmployeeEmail = getUser.EmployeeEmail,

            };

            var accessToken = _jwt.GenerateToken(getEmployee);
            var refreshToken = GenerateRefreshToken();

            var jwtToken = new GetTokenDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };

            return jwtToken;

        }

        private void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt)
        {
            using var hmac = new HMACSHA512();

            byte[] saltBytes = hmac.Key;
            byte[] hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            passwordSalt = Convert.ToBase64String(saltBytes);
            passwordHash = Convert.ToBase64String(hashBytes);
        }

        private bool VerifyPasswordHash(string password, string storedHash, string storedSalt)
        {
            byte[] saltBytes = Convert.FromBase64String(storedSalt);

            using var hmac = new HMACSHA512(saltBytes);

            byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            string computedHashString = Convert.ToBase64String(computedHash);

            return computedHashString == storedHash;
        }

        private string GenerateRefreshToken()
        {
            var bytes = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
    }
}
