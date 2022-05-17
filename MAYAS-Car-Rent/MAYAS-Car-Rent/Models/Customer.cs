using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MAYAS_Car_Rent.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string  Email { get; set; }
        [Required]
        public string Password { get; set; }

        public char Gender { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public long NationalNumber { get; set; }

        public string Address { get; set; }      

        public List<Reservation> Reservations { get; set; }

    }
}
