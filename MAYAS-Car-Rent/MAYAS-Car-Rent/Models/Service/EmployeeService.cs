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
        

        public EmployeeService(MAYASDbContext context )
        {
            _context = context;
            
        }

        // Create a new Employee in the DataBase
        public async Task<Employee> CreateEmployee(Employee employee)
        {
            Employee newEmployee = new Employee()
            {
                Id = employee.Id,
                Name = employee.Name,
                PhoneNumber = employee.PhoneNumber,
                ProfilePicture = employee.ProfilePicture,
                Email = employee.Email,
                Password = employee.Password,
                CompanyId = employee.CompanyId
            };
            _context.Entry(newEmployee).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return newEmployee;
        }

        // return List of Employees to the controller
        public async Task<List<EmployeeDTO>> GetEmployees()
        {
            return await _context.Employees
                .Select(e => new EmployeeDTO
                {
                    Id = e.Id,
                    Name = e.Name,
                    PhoneNumber = e.PhoneNumber,
                    ProfilePicture = e.ProfilePicture,
                    Email = e.Email,
                    Company = new CompanyDTO
                    {
                        UserName = e.Company.UserName,
                        PhoneNumber = e.Company.PhoneNumber,
                        ProfilePicture = e.ProfilePicture,
                        Address = e.Company.Address
                    }
                })
                .ToListAsync();
        }

        // return one Employee by Id to the controller
        public async Task<EmployeeDTO> GetEmployee(int id)
        {
            return await _context.Employees
                .Where(x => x.Id == id)
                .Select(e => new EmployeeDTO
                {
                    Id = e.Id,
                    Name = e.Name,
                    PhoneNumber = e.PhoneNumber,
                    ProfilePicture = e.ProfilePicture,
                    Email = e.Email,
                    Company = new CompanyDTO
                    {
                        UserName = e.Company.UserName,
                        PhoneNumber = e.Company.PhoneNumber,
                        ProfilePicture = e.ProfilePicture,
                        Address = e.Company.Address,
                    }
                })
                .FirstOrDefaultAsync();
        }

        // Update an existed Employee by Id with data From a POST body.
        public async Task<Employee> UpdateEmployee(int id, Employee employee)
        {
            Employee updatedEmployee = new Employee
            {
                Id = id,
                Name = employee.Name,
                PhoneNumber = employee.PhoneNumber,
                ProfilePicture = employee.ProfilePicture,
                Password = employee.Password,
                Email = employee.Email,
                CompanyId = employee.CompanyId
            };
            _context.Entry(updatedEmployee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return employee;
        }

        // Delete an existed Employee by Id
        public async Task DeleteEmployee(int id)
        {
            Employee employee = await _context.Employees.FindAsync(id);
            _context.Entry(employee).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        // Done by Ola, AbdUlrahman
        // return list of Employees their names contain's "term"
        public Task<List<EmployeeDTO>> SearchByName(string term)
        {
            var result = _context.Employees
                .Where(x => x.Name.Contains(term))
                .Select(e => new EmployeeDTO
                {
                    Name = e.Name,
                    PhoneNumber = e.PhoneNumber,
                    ProfilePicture = e.ProfilePicture,
                    Email = e.Email,
                    
                })
                .ToListAsync();
            return result;
        }

        //public async Task<string>AcceptReservation(Reservation reservation)
        //{
        //    var Myreservation = await _reservation.CreateReservation(reservation);
        //        if(Myreservation.Equals(false))
            //return "";
        //}
    }
}
