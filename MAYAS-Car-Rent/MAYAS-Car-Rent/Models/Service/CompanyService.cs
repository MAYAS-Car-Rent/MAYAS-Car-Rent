using MAYAS_Car_Rent.Data;
using MAYAS_Car_Rent.Models.DTOs;
using MAYAS_Car_Rent.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAYAS_Car_Rent.Models.Service
{
    public class CompanyService : ICompany
    {
        private readonly MAYASDbContext _context;

        public CompanyService(MAYASDbContext context)
        {
            _context = context;
        }
        
        public async Task<Company> CreateCompany(Company company)
        {
            Company NewCompany = new Company
            {
                Id = company.Id,
                Email = company.Email,
                Password = company.Password,
                UserName = company.UserName,
                Address = company.Address,
                PhoneNumber = company.PhoneNumber,
                CommercialRegistrationNumber = company.CommercialRegistrationNumber
            };
            _context.Entry(NewCompany).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task DeleteCompany(int Id)
        {
            Company company = await _context.Companies.FindAsync(Id);
            _context.Entry(company).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<CompanyDTO>> GetCompanies()
        {

            return await _context.Companies.Select(C => new CompanyDTO
            {
                Id = C.Id,
                UserName = C.UserName,
                Address = C.Address,
                PhoneNumber = C.PhoneNumber,
                Cars = C.Cars.Select(cars => new CarDTO
                {
                    Id = cars.Id,
                    Name = cars.Name,
                    Color = cars.Color,
                    Year = cars.Year,
                    Model = cars.Model,
                    PlateNumber = cars.PlateNumber,
                }).ToList(),
                Reservations = C.Reservations.Select(reservation => new ReservationDTO
                {
                    Id = reservation.Id,
                    PickupDate = reservation.PickupDate,
                    ReturnDate = reservation.ReturnDate,
                    NumberOfDays = reservation.NumberOfDays,
                    Price = reservation.Price
                }).ToList(),
                Employees = C.Employees.Select(employee => new EmployeeDTO
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    PhoneNumber = employee.PhoneNumber
                }).ToList()
            }).ToListAsync();
        }

        public async Task<CompanyDTO> GetCompany(int Id)
        {

            return await _context.Companies.Select(C => new CompanyDTO
            {
                Id = C.Id,
                UserName = C.UserName,
                Address = C.Address,
                PhoneNumber = C.PhoneNumber,
                Cars = C.Cars.Select(cars => new CarDTO
                {
                    Id = cars.Id,
                    Name = cars.Name,
                    Color = cars.Color,
                    Year = cars.Year,
                    Model = cars.Model,
                    PlateNumber = cars.PlateNumber,
                }).ToList(),
                Reservations = C.Reservations.Select(reservation => new ReservationDTO
                {
                    Id = reservation.Id,
                    PickupDate = reservation.PickupDate,
                    ReturnDate = reservation.ReturnDate,
                    NumberOfDays = reservation.NumberOfDays,
                    Price = reservation.Price
                }).ToList(),
                Employees = C.Employees.Select(employee => new EmployeeDTO
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    PhoneNumber = employee.PhoneNumber
                }).ToList()
            }).FirstOrDefaultAsync(x => x.Id == Id);
        }       

        public async Task<Company> UpdateCompany(int Id, Company company)
        {
            Company UpdateCompany = new Company
            {
                Id = company.Id,
                Email = company.Email,
                Password = company.Password,
                UserName = company.UserName,
                Address = company.Address,
                PhoneNumber = company.PhoneNumber,
                CommercialRegistrationNumber = company.CommercialRegistrationNumber
            };
            _context.Entry(UpdateCompany).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return company;
        }
        
        public async Task AddCarToCompany(int CarId, int CompanyId) // To add car to company I need the id of the car and company
        {                         
            Car car = new Car()
            {
                Id = CarId,
                CompanyId = CompanyId
            };

            _context.Entry(car).State = EntityState.Added;

            await _context.SaveChangesAsync();
        }

        public async Task AddEmployeeToCompany(int EmployeeId, int CompanyId)
        {
            Employee employee = new Employee()
            {
                Id = EmployeeId,
                CompanyId = CompanyId
            };

            _context.Entry(employee).State = EntityState.Added;

            await _context.SaveChangesAsync();
        }

        public async Task AddReservationToCompany(int ReservationId, int CompanyId)
        {
            Reservation reservation = new Reservation()
            {
                Id = ReservationId,
                CompanyId = CompanyId
            };

            _context.Entry(reservation).State = EntityState.Added;

            await _context.SaveChangesAsync();
        }

        public async Task RemoveCarFromCompany(int CarId, int CompanyId) // To remove car from company I need to get the car from database 
        {
            Car car = await _context.Cars.Where(o => o.Id == CarId && o.CompanyId == CompanyId).FirstOrDefaultAsync();

            _context.Entry(car).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task RemoveEmployeeFromCompany(int EmployeeId, int CompanyId)
        {
            Employee employee = await _context.Employees.Where(l => l.Id == EmployeeId && l.CompanyId == CompanyId).FirstOrDefaultAsync();

            _context.Entry(employee).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task RemoveReservationFromCompany(int ReservationId, int CompanyId)
        {
            Reservation reservation = await _context.Reservations.Where(a => a.Id == ReservationId && a.CompanyId == CompanyId).FirstOrDefaultAsync();

            _context.Entry(reservation).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public Task<List<CompanyDTO>> SearchByName(string term)
        {
            var result = _context.Companies
                .Where(x => x.UserName.Contains(term))
                .Select(C => new CompanyDTO
                {
                    UserName = C.UserName,
                    Address = C.Address,
                    PhoneNumber = C.PhoneNumber,
                }).ToListAsync();
            return result;
        }
    }
}