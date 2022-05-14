using MAYAS_Car_Rent.Data;
using MAYAS_Car_Rent.Models.DTOs;
using MAYAS_Car_Rent.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAYAS_Car_Rent.Models.Service
{
    public class EmployeeService : IEmployee //Made by AbdUlrahman Jaran
    {
        private MAYASDbContext _context;

        public EmployeeService(MAYASDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            Employee newEmployee = new Employee()
            {
                Id = employee.Id,
                Name = employee.Name,
                PhoneNumber = employee.PhoneNumber,
                Email = employee.Email,
                Password = employee.Password,
                CompanyId = employee.CompanyId
            };
            _context.Entry(newEmployee).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return newEmployee;
        }

        public async Task<List<EmployeeDTO>> GetEmployees()
        {
            return await _context.Employees
                .Select(e => new EmployeeDTO
                {
                    Id = e.Id,
                    Name = e.Name,
                    PhoneNumber = e.PhoneNumber,
                    Email = e.Email,
                    Company = new CompanyDTO
                    {
                        UserName = e.Company.UserName,
                        PhoneNumber = e.Company.PhoneNumber,
                        Address = e.Company.Address
                    }
                })
                .ToListAsync();
        }

        public async Task<EmployeeDTO> GetEmployee(int id)
        {
            return await _context.Employees
                .Where(x => x.Id == id)
                .Select(e => new EmployeeDTO
                {
                    Id = e.Id,
                    Name = e.Name,
                    PhoneNumber = e.PhoneNumber,
                    Email = e.Email,
                    Company = new CompanyDTO
                    {
                        UserName = e.Company.UserName,
                        PhoneNumber = e.Company.PhoneNumber,
                        Address = e.Company.Address,
                    }
                })
                .FirstOrDefaultAsync();
        }

        public async Task<Employee> UpdateEmployee(int id, Employee employee)
        {
            Employee updatedEmployee = new Employee
            {
                Id = id,
                Name = employee.Name,
                PhoneNumber = employee.PhoneNumber,
                Password = employee.Password,
                Email = employee.Email,
                CompanyId = employee.CompanyId
            };
            _context.Entry(updatedEmployee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task DeleteEmployee(int id)
        {
            Employee employee = await _context.Employees.FindAsync(id);
            _context.Entry(employee).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
