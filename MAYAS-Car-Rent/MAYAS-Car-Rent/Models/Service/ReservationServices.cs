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
    public class ReservationServices : IReservation
    {
        private readonly MAYASDbContext _context;

        public ReservationServices(MAYASDbContext context)
        {
            _context = context;
        }

        public async Task<Object> CreateReservation(Reservation reservation)
        {
            var carForRent = await _context.Cars.FindAsync(reservation.CarId);
            List<Reservation> reservCar = await _context.Reservations.Where(x => x.CarId == carForRent.Id).ToListAsync();
            var IsRent = false;
            foreach (var item in reservCar)
            {
                if (reservation.PickupDate >= item.PickupDate && reservation.PickupDate <= item.ReturnDate)
                {
                    IsRent = true;
                }
                else if (reservation.ReturnDate >= item.PickupDate && reservation.ReturnDate <= item.ReturnDate)
                {
                    IsRent = true;
                }
                else if (reservation.PickupDate <= item.PickupDate && reservation.ReturnDate >= item.ReturnDate)
                {
                    IsRent = true;
                }
                else 
                {
                    IsRent = false;
                }
            }

            if (IsRent == false)
            {
                Reservation Newreservation = new Reservation
                {
                    Id = reservation.Id,
                    PickupDate = reservation.PickupDate,
                    ReturnDate = reservation.ReturnDate,
                    NumberOfDays = Convert.ToInt32(reservation.ReturnDate.Day - reservation.PickupDate.Day),
                    Price = reservation.Price,
                    CompanyId = reservation.CompanyId,
                    CustomerId = reservation.CustomerId,
                    CarId = reservation.CarId
                };
                _context.Entry(Newreservation).State = EntityState.Added;
                await _context.SaveChangesAsync();
                return reservation;
            }
            else
                return IsRent;
        }

        public async Task DeleteReservation(int Id)
        {
            Reservation reservation = await _context.Reservations.FindAsync(Id);
            _context.Entry(reservation).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<ReservationDTO> GetReservation(int Id)
        {
            return await _context.Reservations.Select(reservation => new ReservationDTO
            {
                Id = reservation.Id,
                PickupDate = reservation.PickupDate,
                ReturnDate = reservation.ReturnDate,
                NumberOfDays = reservation.NumberOfDays,
                Price = reservation.Price

            }).FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<ReservationDTO>> GetReservations()
        {
            return await _context.Reservations.Select(reservation => new ReservationDTO
            {
                Id = reservation.Id,
                PickupDate = reservation.PickupDate,
                ReturnDate = reservation.ReturnDate,
                NumberOfDays = reservation.NumberOfDays,
                Price = reservation.Price

            }).ToListAsync();
        }

        public async Task<Reservation> UpdateReservation(int Id, Reservation reservation)
        {
            Reservation updatereservation = new Reservation
            {
                Id = reservation.Id,
                PickupDate = reservation.PickupDate,
                ReturnDate = reservation.ReturnDate,
                NumberOfDays = reservation.NumberOfDays,
                Price = reservation.Price
            };
            _context.Entry(updatereservation).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return reservation;
        }
    }
}