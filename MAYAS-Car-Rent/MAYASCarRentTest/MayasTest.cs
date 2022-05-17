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
        public async Task Can_enroll_and_drop_a_Company()
        {
            //Arrange
           //var company = await CreateAndSaveTestCompany();
           // var car = await CreateAndSaveTestCar();

            var repository = new CompanyService(_db);


            var savedCompanies = await repository.GetCompanies();

            Assert.Equal(4, savedCompanies.Count);
            Assert.Equal("Sultan Rental", savedCompanies[0].UserName);

           // Act
           //await repository.AddCarToCompany(car.Id, company.Id);

           // Assert
           //var actualCar = await repository.GetCompany(company.Id);

           // Assert.Contains(actualCar.Cars, e => e.Id == car.Id);

           // await repository.RemoveCarFromCompany(car.Id, company.Id);

           // Assert
           //actualCar = await repository.GetCompany(car.Id);

           // Assert.DoesNotContain(actualCar.Cars, a => a.Id == car.Id);


        }
    }
}
