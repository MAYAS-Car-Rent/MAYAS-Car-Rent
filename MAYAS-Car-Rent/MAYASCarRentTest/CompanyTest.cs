using MAYAS_Car_Rent.Models;
using MAYAS_Car_Rent.Models.DTOs;
using MAYAS_Car_Rent.Models.Interface;
using MAYAS_Car_Rent.Models.Service;
using MAYASCarRentTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace MAYAS_Car_Rent
{
    public class CompanyTest : Mock
    {
        private ICompany BuildRepository()
        {
            return new CompanyService(_db);
        }
        [Fact]
        public async Task CanSaveAndGetCompany()
        {
            // Arrange
            var company = new Company
            {
                Id = 5,
                UserName = "Sultan Rental",
                Email = "MutazRental@Gmail.com",
                Password = "Mutaz123",
                Address = "Amman",
                PhoneNumber = "962725834567",
                CommercialRegistrationNumber = 123456654
            };
            var repository = BuildRepository();
            // Act
            Company saved = await repository.CreateCompany(company);
            // Assert
            Assert.NotNull(saved);
            Assert.NotEqual(0, company.Id);
            Assert.Equal(saved.Id, company.Id);
            Assert.Equal(saved.UserName, company.UserName);
        }
        [Fact]
        public async Task CanGetASingleEmployee()
        {
            // Arrange
            var company1 = new Company
            {
                Id = 6,
                UserName = "Mutaz Rental",
                Email = "MutazRental@Gmail.com",
                Password = "Mutaz123",
                Address = "Amman",
                PhoneNumber = "962725834567",
                CommercialRegistrationNumber = 123456654
            };
            var company2 = new Company
            {
                Id = 7,
                UserName = "Ashraf Rental",
                Email = "AshrafRental@Gmail.com",
                Password = "Ashraf123",
                Address = "Aqaba",
                PhoneNumber = "962725834567",
                CommercialRegistrationNumber = 789456654
            };
            var repository = BuildRepository();
            company1 = await repository.CreateCompany(company1);
            company2 = await repository.CreateCompany(company2);
            // Act
            CompanyDTO result1 = await repository.GetCompany(6);
            CompanyDTO result2 = await repository.GetCompany(7);
            // Assert
            Assert.Equal("Mutaz Rental", result1.UserName);
            Assert.Equal("Ashraf Rental", result2.UserName);
        }
        [Fact]
        public async Task CanGetAllCompany()
        {
            // Arrange
            var company1 = new Company
            {
                Id = 5,
                UserName = "Mutaz Rental",
                Email = "MutazRental@Gmail.com",
                Password = "Mutaz123",
                Address = "Amman",
                PhoneNumber = "962725834567",
                CommercialRegistrationNumber = 123456654
            };
            var company2 = new Company
            {
                Id = 6,
                UserName = "Ashraf Rental",
                Email = "AshrafRental@Gmail.com",
                Password = "Ashraf123",
                Address = "Aqaba",
                PhoneNumber = "962725834567",
                CommercialRegistrationNumber = 789456654
            };
            var company3 = new Company
            {
                Id = 7,
                UserName = "Ahmad Rental",
                Email = "AhmadRental@Gmail.com",
                Password = "Ahmad123",
                Address = "Madaba",
                PhoneNumber = "962725836943",
                CommercialRegistrationNumber = 789528654
            };
            var repository = BuildRepository();
            company1 = await repository.CreateCompany(company1);
            company2 = await repository.CreateCompany(company2);
            company3 = await repository.CreateCompany(company3);
            // Act
            List<CompanyDTO> result = await repository.GetCompanies();
            // Assert
            Assert.Equal(7, result.Count);
        }
        [Fact]
        public async Task CanDeleteAnCompany()
        {
            // Arrange
            var company1 = new Company
            {
                Id = 6,
                UserName = "Mutaz Rental",
                Email = "MutazRental@Gmail.com",
                Password = "Mutaz123",
                Address = "Amman",
                PhoneNumber = "962725834567",
                CommercialRegistrationNumber = 123456654
            };
            var company2 = new Company
            {
                Id = 7,
                UserName = "Ashraf Rental",
                Email = "AshrafRental@Gmail.com",
                Password = "Ashraf123",
                Address = "Aqaba",
                PhoneNumber = "962725834567",
                CommercialRegistrationNumber = 789456654
            };
            var company3 = new Company
            {
                Id = 8,
                UserName = "Ahmad Rental",
                Email = "AhmadRental@Gmail.com",
                Password = "Ahmad123",
                Address = "Madaba",
                PhoneNumber = "962725836943",
                CommercialRegistrationNumber = 789528654
            };
            var repository = BuildRepository();
            company1 = await repository.CreateCompany(company1);
            company2 = await repository.CreateCompany(company2);
            company3 = await repository.CreateCompany(company3);
            // Act
            List<CompanyDTO> resultBefore = await repository.GetCompanies();
            await repository.DeleteCompany(3);
            List<CompanyDTO> resultAfter = await repository.GetCompanies();
            // Assert
            Assert.Equal(6, resultAfter.Count);
        }
        [Fact]
        public async Task CanUpdateCompany()
        {
            // Arrange
            var company = new Company
            {
                
                UserName = "Mutaz Rental",
                Email = "MutazRental@Gmail.com",
                Password = "Mutaz123",
                Address = "Amman",
                PhoneNumber = "962725834567",
                CommercialRegistrationNumber = 123456654
            };
            var companyUpdated = new Company
            {
                Id = 4,
                UserName = "Mohammed Rental",
                Email = "MutazRental@Gmail.com",
                Password = "Mutaz123",
                Address = "Amman",
                PhoneNumber = "962725834567",
                CommercialRegistrationNumber = 123456654
            };
            var repository = BuildRepository();
            company = await repository.CreateCompany(company);
            // Act
             await repository.UpdateCompany(companyUpdated.Id, companyUpdated);
            CompanyDTO result = await repository.GetCompany(4);
            // Assert
            Assert.Equal("Mohammed Rental", result.UserName);
            Assert.NotEqual("Mutaz Rental", result.UserName);
        }
    }
}