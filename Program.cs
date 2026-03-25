using Microsoft.AspNetCore.Authentication.JwtBearer;
using EmployeeManagement.Data;
using EmployeeManagement.Repository.Interfaces;
using EmployeeManagement.Repository;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Services.Interfaces;
using EmployeeManagement.Services;
using EmployeeManagement.Helpers;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IAuthService , AuthService>();

builder.Services.AddScoped<IEmployeeRepository , EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService , EmployeeService>();

builder.Services.AddScoped<JwtTokenGenerator>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

