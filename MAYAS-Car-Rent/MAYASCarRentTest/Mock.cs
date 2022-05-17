using MAYAS_Car_Rent.Data;
using MAYAS_Car_Rent.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MAYASCarRentTest
{
    public abstract class Mock : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly MAYASDbContext _db;

        public Mock()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _db = new MAYASDbContext(
                new DbContextOptionsBuilder<MAYASDbContext>()
                    .UseSqlite(_connection)
                    .Options);

            _db.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }

        protected async Task<Car> CreateAndSaveTestCar()
        {
            var car = new Car { Id = 200, Name = "test", Color = "Red", Year = 2000, Model = "test", PlateNumber = "Jo-13-1434" };
            _db.Cars.Add(car);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, car.Id);
            return car;
        }
        protected async Task<Company> CreateAndSaveTestCompany()
        {
            var company = new Company { Id = 55, UserName = "Sultan Rental", Email = "SultanRental@Gmail.com", Password = "Sultan123", Address = "Amman", PhoneNumber = "962791234567", CommercialRegistrationNumber = 123456789 };
            _db.Companies.Add(company);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, company.Id);
            return company;
        }

    }
}
