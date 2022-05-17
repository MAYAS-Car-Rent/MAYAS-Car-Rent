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
    public class EmployeeTest : Mock
    {
        private IEmployee BuildRepository()
        {
            return new EmployeeService(_db);
        }

        [Fact]
        public async Task CanSaveAndGetReservation()
        {
            // Arrange
            var employee = new Employee
            {
                Id= 1,
                CompanyId=1,
                Name="Ola M Shlool",
                Email="olashlool@gmail.com",
                Password="2052022",
                PhoneNumber="+9627854281"   
            };
            var repository = BuildRepository();

            // Act
            Employee saved = await repository.CreateEmployee(employee);

            // Assert
            Assert.NotNull(saved);
            Assert.NotEqual(0, employee.Id);
            Assert.Equal(saved.Id, employee.Id);
            Assert.Equal(saved.Name, employee.Name);
        }
        [Fact]
        public async Task CanGetASingleEmployee()
        {
            // Arrange
            var employee1 = new Employee
            {
                Id = 1,
                CompanyId = 2,
                Name = "Ola M Shlool",
                Email = "olashlool@gmail.com",
                Password = "2052022",
                PhoneNumber = "+9627854281"
            };

            var employee2 = new Employee
            {
                Id = 2,
                CompanyId = 1,
                Name = "Abber M Shlool",
                Email = "abeershlool@gmail.com",
                Password = "12345",
                PhoneNumber = "+9627858981"
            };

            var repository = BuildRepository();

            employee1 = await repository.CreateEmployee(employee1);
            employee2 = await repository.CreateEmployee(employee2);

            // Act
            EmployeeDTO result1 = await repository.GetEmployee(1);
            EmployeeDTO result2 = await repository.GetEmployee(2);

            // Assert
            Assert.Equal("Ola M Shlool", result1.Name);
            Assert.Equal("Abber M Shlool", result2.Name);
        }

        [Fact]
        public async Task CanGetAllEmployee()
        {
            // Arrange
            var employee1 = new Employee
            {
                Id = 3,
                CompanyId = 2,
                Name = "Ola M Shlool",
                Email = "olashlool@gmail.com",
                Password = "2052022",
                PhoneNumber = "+962 785344281"
            };

            var employee2 = new Employee
            {
                Id = 4,
                CompanyId = 1,
                Name = "Abber M Shlool",
                Email = "abeershlool@gmail.com",
                Password = "12345",
                PhoneNumber = "+962 785844981"
            };
            var employee3 = new Employee
            {
                Id = 5,
                CompanyId = 1,
                Name = "Fareda Khries",
                Email = "faredakhries@gmail.com",
                Password = "98765",
                PhoneNumber = "+962 7985985981"
            };

            var repository = BuildRepository();

            employee1 = await repository.CreateEmployee(employee1);
            employee2 = await repository.CreateEmployee(employee2);
            employee3 = await repository.CreateEmployee(employee3);


            // Act
            List<EmployeeDTO> result = await repository.GetEmployees();


            // Assert
            Assert.Equal(5, result.Count);
        }
        [Fact]
        public async Task CanDeleteAnEmployee()
        {
            // Arrange
            var employee1 = new Employee
            {
                Id = 3,
                CompanyId = 2,
                Name = "Ola M Shlool",
                Email = "olashlool@gmail.com",
                Password = "2052022",
                PhoneNumber = "+962 785344281"
            };

            var employee2 = new Employee
            {
                Id = 4,
                CompanyId = 1,
                Name = "Abber M Shlool",
                Email = "abeershlool@gmail.com",
                Password = "12345",
                PhoneNumber = "+962 785844981"
            };
            var employee3 = new Employee
            {
                Id = 5,
                CompanyId = 1,
                Name = "Fareda Khries",
                Email = "faredakhries@gmail.com",
                Password = "98765",
                PhoneNumber = "+962 7985985981"
            };

            var repository = BuildRepository();

            employee1 = await repository.CreateEmployee(employee1);
            employee2 = await repository.CreateEmployee(employee1);
            employee3 = await repository.CreateEmployee(employee1);


            // Act
            List<EmployeeDTO> resultBefore = await repository.GetEmployees();
            await repository.DeleteEmployee(2);
            List<EmployeeDTO> resultAfter = await repository.GetEmployees();

            // Assert
            Assert.Equal(4, resultAfter.Count);
        }
        [Fact]
        public async Task CanUpdateEmployee()
        {
            // Arrange

            var employee = new Employee
            {
                Id = 3,
                CompanyId = 2,
                Name = "Sana'a Shlool",
                Email = "olashlool@gmail.com",
                Password = "2052022",
                PhoneNumber = "+962 785344281"
            };

            var repository = BuildRepository();

            // Act

            await repository.UpdateEmployee(employee.Id, employee);

            EmployeeDTO result = await repository.GetEmployee(3);

            // Assert
            Assert.Equal("Sana'a Shlool", result.Name);
        }
    }
}
