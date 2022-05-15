using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MAYAS_Car_Rent.Models
{
    public class Car  // All Models made by Mutaz Altbakhi 
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string PlateNumber { get; set; }

        public bool IsRent { get; set; }

        public Company Company { get; set; }

        public int CompanyId { get; set; }

        public List<Reservation> Reservations { get; set; }   

        public enum CarType
        {
            Micro,
            Sport,
            Van,
            SUV,
            Luxury
        }
    }
}
