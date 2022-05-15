using MAYAS_Car_Rent.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MAYASCarRentTest
{
    public class MayasTest : Mock
    {
        [Fact]
        public async Task Can_enroll_and_drop_a_Car()
        {
            // Arrange
            var Company = await CreateAndSaveTestCompany();
            var car = await CreateAndSaveTestCar();

            var repository = new CompanyService(_db);

            // Act
            await repository.AddCarToCompany(car.Id,Company.Id);

            // Assert
            var actualCar = await repository.GetCompany(Company.Id);

            Assert.Contains(actualCar.Cars, e => e.Id == car.Id);

           
        }
    }
}
