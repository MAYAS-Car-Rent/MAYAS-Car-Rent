using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MAYAS_Car_Rent.Models.DTOs
{
    public class ReservationDTO
    {
        public int Id { get; set; }
        [Required]
        public DateTime PickupDate { get; set; }
        [Required]
        public DateTime ReturnDate { get; set; }

        public int NumberOfDays { get; set; }
        [Required]
        public decimal Price { get; set; }

        public CompanyDTO Company { get; set; }
    }
}
