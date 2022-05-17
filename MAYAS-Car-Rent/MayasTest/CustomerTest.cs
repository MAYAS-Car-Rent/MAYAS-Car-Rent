using MAYAS_Car_Rent.Models;
using MAYAS_Car_Rent.Models.DTOs;
using MAYAS_Car_Rent.Models.Interface;
using MAYAS_Car_Rent.Models.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MayasTest
{
    public class CustomerTest : Mock
    {
        private ICustomer CreatCustomerR()
        {
            return new CustomerService(_db);
        }
        [Fact]

        public async Task CanSaveAndGetCustomer()
        {
            // Arrange
            var customer = new Customer
            {
                Id = 1,
                UserName = "Haneen Alhamdan",
                Email = "haneenalhamdan@gmail.com",
                Password = "12345",
                Gender = 'F',
                PhoneNumber = "+962796706610",
                NationalNumber = 9962000279,
                Address = "Amman",
                
            };

            var repository = CreatCustomerR();

            // Act
            Customer saved = await repository.Create(customer);

            // Assert
            Assert.NotNull(saved);
            Assert.NotEqual(0, customer.Id);
            Assert.Equal(saved.Id, customer.Id);

        }



        [Fact]
        public async Task CanGetAllCustomer()
        {
            // Arrange
            var customer1 = new Customer
            {
                Id = 1,
                UserName = "Haneen Alhamdan",
                Email = "haneenalhamdan@gmail.com",
                Password = "12345",
                Gender = 'f',
                PhoneNumber = "+962796706610",
                NationalNumber = 9962000279,
                Address = "Amman",
            };

            var customer2 = new Customer
            {
                Id = 2,
                UserName = "Mahmoud Alhamdan",
                Email = "mahmoudalhamdan@gmail.com",
                Password = "00000",
                Gender = 'M',
                PhoneNumber = "+96279305981",
                NationalNumber = 9992000279,
                Address = "Amman",
            };
            var customer3 = new Customer
            {
                Id = 3,
                UserName = "Gader Farrar",
                Email = "gaderfrrar@gmail.com",
                Password = "54321",
                Gender = 'f',
                PhoneNumber = "+962799012354",
                NationalNumber = 201545662,
                Address = "Amman",
            };

            var repository = CreatCustomerR();

            customer1 = await repository.Create(customer1);
            customer2 = await repository.Create(customer2);
            customer3 = await repository.Create(customer3);


            // Act
            List<CustomerDTO> result = await repository.GetCustomer();


            // Assert
            Assert.Equal(5, result.Count);
        }

        [Fact]
        public async Task CanDeleteAnCustomer()
        {
            // Arrange
            var customer1 = new Customer
            {
                Id = 1,
                UserName = "Haneen Alhamdan",
                Email = "haneenalhamdan@gmail.com",
                Password = "12345",
                Gender = 'F',
                PhoneNumber = "+962796706610",
                NationalNumber = 9962000279,
                Address = "Amman",
            };

            var customer2 = new Customer
            {
                Id = 2,
                UserName = "Mahmoud Alhamdan",
                Email = "mahmoudalhamdan@gmail.com",
                Password = "00000",
                Gender = 'M',
                PhoneNumber = "+96279305981",
                NationalNumber = 9992000279,
                Address = "Amman",
            };
           

            var repository = CreatCustomerR();

            customer1 = await repository.Create(customer1);
            customer2 = await repository.Create(customer2);
            


            // Act
            List<CustomerDTO> resultBefore = await repository.GetCustomer();
            await repository.Delete(2);
            List<CustomerDTO> resultAfter = await repository.GetCustomer();

            // Assert
            Assert.Equal(4, resultAfter.Count);
        }
        [Fact]
        public async Task CanUpdateEmployee()
        {
            // Arrange

            var customer = new Customer
            {
                Id = 2,
                UserName = "Adam Alhamdan",
                Email = "mahmoudalhamdan@gmail.com",
                Password = "00000",
                Gender = 'M',
                PhoneNumber = "+96279305981",
                NationalNumber = 9992000279,
                Address = "Amman",
            };

            var repository = CreatCustomerR();

            // Act

            await repository.UpdateCustomer(customer.Id, customer);

            CustomerDTO result = await repository.GetCustomer(3);

            // Assert
            Assert.Equal("Sana'a Shlool", result.UserName);
        }
    }
}
