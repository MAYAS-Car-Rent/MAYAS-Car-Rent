using MAYAS_Car_Rent.Data;
using MAYAS_Car_Rent.Models.DTOs;
using MAYAS_Car_Rent.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAYAS_Car_Rent.Models.Services
{


    public class CustomerService : ICustomer
    {
        private readonly MAYASDbContext _context;

        public CustomerService(MAYASDbContext context)
        {
            _context = context;
        }


        public async Task<Customer> Create(Customer customer)
        {
            Customer newcustomer = new Customer
            {
                Id = customer.Id,
                UserName = customer.UserName,
                Email = customer.Email,
                Gender = customer.Gender,
                PhoneNumber = customer.PhoneNumber,
                NationalNumber = customer.NationalNumber,
                Address = customer.Address,


            };
            _context.Entry(customer).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<CustomerDTO> GetCustomer(int id)
        {
            return await _context.customers
                .Select(cus => new CustomerDTO


                {
                    Id = cus.Id,
                    UserName = cus.UserName,
                    Email = cus.Email,
                    Gender = cus.Gender,
                    PhoneNumber = cus.PhoneNumber,
                    NationalNumber = cus.NationalNumber,
                    Address = cus.Address,

                    Cars = cus.Cars.
                Select(car => new CarDTO
                {
                    Id = car.Id,
                    Name = car.Name,
                    Color = car.Color,
                    Year = car.Year,
                    Model = car.Model,
                    PlateNumber = car.PlateNumber                    
                }).ToList(),

                    Reservations = cus.Reservations
                .Select(reservation => new ReservationDTO
                {
                    Id = reservation.Id,
                    PickupDate = reservation.PickupDate,
                    ReturnDate = reservation.ReturnDate,
                    NumberOfDays = reservation.NumberOfDays,
                    Price = reservation.Price
                }).ToList(),
                }).FirstOrDefaultAsync(x => x.Id == id);


        }

        public async Task Delete(int id)
        {
            CustomerDTO customer = await GetCustomer(id);

            _context.Entry(customer).State = EntityState.Deleted;

            await _context.SaveChangesAsync();


        }

        public async Task<List<CustomerDTO>> GetCustomer()
        {
            return await _context.customers
                .Select(cus => new CustomerDTO


                {
                    Id = cus.Id,
                    UserName = cus.UserName,
                    Email = cus.Email,
                    Gender = cus.Gender,
                    PhoneNumber = cus.PhoneNumber,
                    NationalNumber = cus.NationalNumber,
                    Address = cus.Address,

                    Cars = cus.Cars
                .Select(car => new CarDTO
                {
                    Id = car.Id,
                    Name = car.Name,
                    Color = car.Color,
                    Year = car.Year,
                    Model = car.Model,
                    PlateNumber = car.PlateNumber             
                }).ToList(),


                    Reservations = cus.Reservations
                .Select(reservation => new ReservationDTO
                {
                    Id = reservation.Id,
                    PickupDate = reservation.PickupDate,
                    ReturnDate = reservation.ReturnDate,
                    NumberOfDays = reservation.NumberOfDays,
                    Price = reservation.Price
                }).ToList(),
                }).ToListAsync();
        }


        public async Task<Customer> UpdateCustomer(int id, Customer customer)
        {

            Customer UpdateCustomer = new Customer
            {
                Id = customer.Id,
                UserName = customer.UserName,
                Email = customer.Email,
                Gender = customer.Gender,
                PhoneNumber = customer.PhoneNumber,
                NationalNumber = customer.NationalNumber,
                Address = customer.Address,
                Password = customer.Password
            };
            _context.Entry(UpdateCustomer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}