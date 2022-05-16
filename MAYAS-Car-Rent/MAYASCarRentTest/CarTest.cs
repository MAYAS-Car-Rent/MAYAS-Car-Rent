using MAYAS_Car_Rent.Models;
using MAYAS_Car_Rent.Models.DTOs;
using MAYAS_Car_Rent.Models.Interface;
using MAYAS_Car_Rent.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MAYASCarRentTest
{
    public class CarTest : Mock
    {
        private ICar BuildRepository()
        {
            return new CarService(_db);
        }

        [Fact]
        public async Task CanSaveAndGetCAr()
        {
            // Arrange
            var car = new Car
            {
                Id = 1,
                CompanyId = 1,
                Name = "BMW",
                Color = "Red",
                Model = "X5",
                Year = 2002,
                IsRent = false,
                PlateNumber = "18-75752"

            };
            var repository = BuildRepository();

            // Act
            Car saved = await repository.CreateCar(car);

            // Assert
            Assert.NotNull(saved);
            Assert.NotEqual(0, car.Id);
            Assert.Equal(saved.Id, car.Id);
            Assert.Equal(saved.Name, car.Name);
        }
        [Fact]
        public async Task CanGetASingleCAr()
        {
            // Arrange
            var car1 = new Car
            {
                Id = 1,
                CompanyId = 1,
                Name = "BMW",
                Color = "Red",
                Model = "X5",
                Year = 2002,
                IsRent = false,
                PlateNumber = "18-75752"
            };

            var car2 = new Car
            {
                Id = 2,
                CompanyId = 2,
                Name = "Toyota",
                Color = "Red",
                Model = "camry",
                Year = 2005,
                IsRent = false,
                PlateNumber = "19-75752"
            };

            var repository = BuildRepository();

            await repository.CreateCar(car1);
            await repository.CreateCar(car2);

            // Act
            CarDTO result1 = await repository.GetCar(1);
            CarDTO result2 = await repository.GetCar(2);

            // Assert
            Assert.Equal("BMW", result1.Name);
            Assert.Equal("Toyota", result2.Name);
        }
        [Fact]
        public async Task CanGetAllCars()
        {
            // Arrange
            var car1 = new Car
            {
                Id = 1,
                CompanyId = 1,
                Name = "BMW",
                Color = "Red",
                Model = "X5",
                Year = 2002,
                IsRent = false,
                PlateNumber = "18-75752"
            };

            var car2 = new Car
            {
                Id = 2,
                CompanyId = 2,
                Name = "Toyota",
                Color = "Red",
                Model = "camry",
                Year = 2005,
                IsRent = false,
                PlateNumber = "19-75752"
            };


            var repository = BuildRepository();

            await repository.CreateCar(car1);
            await repository.CreateCar(car2);


            // Act
            List<CarDTO> result = await repository.GetCars();


            // Assert
            Assert.Equal(2, result.Count);
        }
        [Fact]
        public async Task CanDeleteAnCar()
        {
            var car1 = new Car
            {
                Id = 1,
                CompanyId = 1,
                Name = "BMW",
                Color = "Red",
                Model = "X5",
                Year = 2002,
                IsRent = false,
                PlateNumber = "18-75752"
            };
            var repository = BuildRepository();

            await repository.CreateCar(car1);
            await repository.DeleteCar(1);

            // Act
            List<CarDTO> result = await repository.GetCars();


            // Assert
            Assert.NotEqual(2, result.Count);
        }
        [Fact]
        public async Task CanUpdateCar()
        {
            // Arrange

            var car1 = new Car
            {
                Id = 1,
                CompanyId = 1,
                Name = "BM",
                Color = "Red",
                Model = "X5",
                Year = 2002,
                IsRent = false,
                PlateNumber = "18-75752"
            };
            var repository = BuildRepository();
            await repository.CreateCar(car1);
            var car2 = new Car
            {
                Id = 2,
                CompanyId = 1,
                Name = "BMW",
                Color = "Red",
                Model = "X5",
                Year = 2002,
                IsRent = false,
                PlateNumber = "18-75752"
            };

            await repository.UpdateCar(1,car2);

            CarDTO result = await repository.GetCar(1);

            // Assert
            Assert.Equal("BMW", result.Name);
        }
    }
}
