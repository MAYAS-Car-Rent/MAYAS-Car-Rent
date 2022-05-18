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
                CommercialRegistrationNumber = company.CommercialRegistrationNumber,
                Rate = 0 ,
                ProfilePicture = company.ProfilePicture,
                RateCount = 0
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
                Rate = C.Rate,
                ProfilePicture = C.ProfilePicture,
                Cars = C.Cars.Select(cars => new CarDTO
                {
                    Id = cars.Id,
                    Name = cars.Name,
                    Color = cars.Color,
                    Year = cars.Year,
                    Model = cars.Model,
                    PlateNumber = cars.PlateNumber,
                    ImageUrl = cars.ImageUrl,
                    PricePerDay = cars.PricePerDay
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
                    PhoneNumber = employee.PhoneNumber,
                    ProfilePicture = employee.ProfilePicture,
                    Email = employee.Email
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
                Rate = C.Rate,
                ProfilePicture = C.ProfilePicture,                
                Cars = C.Cars.Select(cars => new CarDTO
                {
                    Id = cars.Id,
                    Name = cars.Name,
                    Color = cars.Color,
                    Year = cars.Year,
                    Model = cars.Model,
                    PlateNumber = cars.PlateNumber,
                    ImageUrl = cars.ImageUrl,
                    PricePerDay = cars.PricePerDay
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
                    PhoneNumber = employee.PhoneNumber,
                    ProfilePicture = employee.ProfilePicture,                    
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
                CommercialRegistrationNumber = company.CommercialRegistrationNumber,
                ProfilePicture = company.ProfilePicture
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

        // Done by Ola, AbdUlrahman
        // return list of Companies their names contain's "term"
        public async Task<List<CompanyDTO>> SearchByName(string term)
        {
            var result = _context.Companies.Select(C => new CompanyDTO
            {
                UserName = C.UserName,
                Address = C.Address,
                PhoneNumber = C.PhoneNumber,
                ProfilePicture = C.ProfilePicture,
                Rate = C.Rate                
            })
                .Where(x => x.UserName.Contains(term));
            
           var  c = await result.Select(m => new CompanyDTO { 
               UserName = m.UserName,
           }).AsNoTracking().ToListAsync();

            return c;
        }

        // logic to Search company By Address
        public async Task<List<CompanyDTO>> SearchByAddress(string address) // sultan 
        {
            return await _context.Companies.Select(company => new CompanyDTO
            { 
                UserName = company.UserName,
                Address = company.Address,
                PhoneNumber = company.PhoneNumber,                
                ProfilePicture = company.ProfilePicture,
                Rate = company.Rate,
                Cars = company.Cars
                .Select(cars  => new CarDTO
                {
                    Name = cars.Name,
                    Color = cars.Color,
                    Model = cars.Model,
                    Year = cars.Year
                }).ToList()

            }).Where(x => x.Address.Contains(address)).ToListAsync();
        }

        // Done by AbdUlrahman
        // Update Company Rate by rating from Coustmer
        public async Task<Company> UpdateRate(Company company, int rate)
        {
            Company updatedCompany = new Company
            {
                Id = company.Id,
                UserName = company.UserName,
                Address = company.Address,
                PhoneNumber = company.PhoneNumber,
                Email = company.Email,
                Password = company.Password,
                ProfilePicture = company.ProfilePicture,
                RateCount = company.RateCount,
                Rate = (company.Rate + rate)/(company.RateCount + 1),
            };
            _context.Entry(updatedCompany).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return company;
        }

    }
}