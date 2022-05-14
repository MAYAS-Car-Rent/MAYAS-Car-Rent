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

        public async Task<Reservation> CreateReservation(Reservation reservation)
        {
            Reservation Newreservation = new Reservation
            {
                Id = reservation.Id,
                PickupDate = reservation.PickupDate,
                ReturnDate = reservation.ReturnDate,
                NumberOfDays = reservation.NumberOfDays,
                Price = reservation.Price
            };
            _context.Entry(Newreservation).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return reservation;
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