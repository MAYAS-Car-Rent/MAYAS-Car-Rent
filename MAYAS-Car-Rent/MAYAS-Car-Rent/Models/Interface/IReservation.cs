using MAYAS_Car_Rent.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAYAS_Car_Rent.Models.Interface
{
    public interface IReservation
    {
        Task<ReservationDTO> GetReservation(int Id);
        Task<List<ReservationDTO>> GetReservations();
        Task<Object> CreateReservation(Reservation reservation);

        Task<Reservation> UpdateReservation(int Id, Reservation reservation);
        Task DeleteReservation(int Id);
    }
}