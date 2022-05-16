//using MAYAS_Car_Rent.Models;
//using MAYAS_Car_Rent.Models.DTOs;
//using MAYAS_Car_Rent.Models.Interface;
//using MAYAS_Car_Rent.Models.Service;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace MAYASCarRentTest
//{
//    public class ReservationTest : Mock
//    {
//        private IReservation BuildRepository()
//        {
//            return new ReservationServices(_db);
//        }
//        [Fact]
//        public async Task CanSaveAndGetReservation()
//        {
//            // Arrange
//            var reservation = new Reservation
//            {
//                Id = 1,
//                CompanyId = 2,
//                CustomerId = 1,
//                CarId = 2,
//                Price = 350,
//                PickupDate = new DateTime(2022, 5, 20),
//                ReturnDate = new DateTime(2022, 5, 25),
//                NumberOfDays = 5
//            };
//            var repository = BuildRepository();

//            // Act
//            Reservation saved = await repository.CreateReservation(reservation);

//            // Assert
//            Assert.NotNull(saved);
//            Assert.NotEqual(0, reservation.Id);
//            Assert.Equal(saved.Id, reservation.Id);

//            //Assert.Equal(saved.NumberOfDays, reservation.NumberOfDays);
//        }
//        [Fact]
//        public async Task CanGetASingleReservation()
//        {
//            // Arrange
//            var firstReservation = new Reservation
//            {
//                Id = 1,
//                CompanyId = 2,
//                CustomerId = 1,
//                CarId = 2,
//                Price = 350,
//                PickupDate = new DateTime(2022, 5, 20),
//                ReturnDate = new DateTime(2022, 5, 25),
//                NumberOfDays = 5
//            };

//            var secondReservation = new Reservation
//            {
//                Id = 2,
//                CompanyId = 3,
//                CustomerId = 1,
//                CarId = 1,
//                Price = 150,
//                PickupDate = new DateTime(2022, 5, 22),
//                ReturnDate = new DateTime(2022, 5, 25),
//                NumberOfDays = 3
//            };

//            var repository = BuildRepository();

//            firstReservation = await repository.CreateReservation(firstReservation);
//            secondReservation = await repository.CreateReservation(secondReservation);

//            // Act
//            ReservationDTO result1 = await repository.GetReservation(1);
//            ReservationDTO result2 = await repository.GetReservation(2);

//            // Assert

//            //Assert.Equal(, result1);
//            //Assert.Equal(, result2);
//        }

//        [Fact]
//        public async Task CanGetAllReservations()
//        {
//            // Arrange
//            var firstReservation = new Reservation
//            {
//                Id = 1,
//                CompanyId = 2,
//                CustomerId = 1,
//                CarId = 2,
//                Price = 350,
//                PickupDate = new DateTime(2022, 5, 20),
//                ReturnDate = new DateTime(2022, 5, 25),
//                NumberOfDays = 5
//            };

//            var secondReservation = new Reservation
//            {
//                Id = 2,
//                CompanyId = 3,
//                CustomerId = 1,
//                CarId = 1,
//                Price = 150,
//                PickupDate = new DateTime(2022, 5, 22),
//                ReturnDate = new DateTime(2022, 5, 25),
//                NumberOfDays = 3
//            };

//            var repository = BuildRepository();

//            firstReservation = await repository.CreateReservation(firstReservation);
//            secondReservation = await repository.CreateReservation(secondReservation);

//            // Act
//            List<ReservationDTO> result = await repository.GetReservations();


//            // Assert
//            //Assert.Equal(5, result.Count);
//        }
//        [Fact]
//        public async Task CanDeleteAnReservation()
//        {
//            var firstReservation = new Reservation
//            {
//                Id = 1,
//                CompanyId = 2,
//                CustomerId = 1,
//                CarId = 2,
//                Price = 350,
//                PickupDate = new DateTime(2022, 5, 20),
//                ReturnDate = new DateTime(2022, 5, 25),
//                NumberOfDays = 5
//            };

//            var secondReservation = new Reservation
//            {
//                Id = 2,
//                CompanyId = 3,
//                CustomerId = 1,
//                CarId = 1,
//                Price = 150,
//                PickupDate = new DateTime(2022, 5, 22),
//                ReturnDate = new DateTime(2022, 5, 25),
//                NumberOfDays = 3
//            };
//            var ThirdReservation = new Reservation
//            {
//                Id = 3,
//                CompanyId = 4,
//                CustomerId = 2,
//                CarId = 4,
//                Price = 250,
//                PickupDate = new DateTime(2022, 6, 2),
//                ReturnDate = new DateTime(2022, 6, 5),
//                NumberOfDays = 3
//            };

//            var repository = BuildRepository();

//            firstReservation = await repository.CreateReservation(firstReservation);
//            secondReservation = await repository.CreateReservation(secondReservation);
//            ThirdReservation = await repository.CreateReservation(ThirdReservation);


//            // Act

//            List<ReservationDTO> resultBefore = await repository.GetReservations();
//            await repository.DeleteReservation(2);
//            List<ReservationDTO> resultAfter = await repository.GetReservations();

//            // Assert
//            //Assert.Equal(5, resultAfter.Count);
//        }
//        [Fact]
//        public async Task CanUpdateAnReservation()
//        {
//            // Arrange

//            var reservation = new Reservation
//            {
//                Id = 1,
//                CompanyId = 2,
//                CustomerId = 1,
//                CarId = 2,
//                Price = 350,
//                PickupDate = new DateTime(2022, 5, 20),
//                ReturnDate = new DateTime(2022, 5, 25),
//                NumberOfDays = 5
//            };

//            var repository = BuildRepository();

//            // Act

//            await repository.UpdateReservation(reservation.Id, reservation);

//            ReservationDTO result = await repository.GetReservation(1);

//            // Assert
//            //Assert.Equal(, result.);
//        }
//    }
//}
