using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MAYAS_Car_Rent.Data;
using MAYAS_Car_Rent.Models;
using MAYAS_Car_Rent.Models.Interface;
using MAYAS_Car_Rent.Models.DTOs;
namespace MAYAS_Car_Rent.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservation _reservation;
        public ReservationsController(IReservation reservation)
        {
            _reservation = reservation;
        }
        // GET: api/Reservations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationDTO>>> GetReservations()
        {
            return await _reservation.GetReservations();
        }
        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationDTO>> GetReservation(int id)
        {
            var reservation = await _reservation.GetReservation(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return reservation;
        }
        // PUT: api/Reservations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservation(int id, Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return BadRequest();
            }
            var updateReservation = await _reservation.UpdateReservation(id, reservation);
            return Ok(updateReservation);
        }
        // POST: api/Reservations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reservation>> PostReservation(Reservation reservation)
        {
            var newReservation = await _reservation.CreateReservation(reservation);
            return Ok(newReservation);
        }
        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            await _reservation.DeleteReservation(id);
            return NoContent();
        }
    }
}