using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EmployeeManagement.Model.DTOs;
namespace EmployeeManagement.Helpers
{
    public class JwtTokenGenerator
    {
        private readonly IConfiguration _configuration;

        public JwtTokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(GetEmployeeDto getEmployeeDto)
        {
            var claims = new[]
            {
            new Claim("UserId", getEmployeeDto.EmployeeId.ToString()),
            new Claim("FirstName", getEmployeeDto.EmployeeFirstName),
            new Claim("LastName", getEmployeeDto.EmployeeLastName),
            new Claim(ClaimTypes.Email, getEmployeeDto.EmployeeEmail),

        };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
