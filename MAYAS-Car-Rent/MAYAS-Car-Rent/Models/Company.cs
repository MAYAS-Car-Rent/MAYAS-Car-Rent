using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MAYAS_Car_Rent.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }

        public string ProfilePicture { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }
        [Required]
        public int CommercialRegistrationNumber{ get; set; }
        
        public double Rate { get; set; }

        public int RateCount { get; set; }

        public List<Car> Cars { get; set; }

        public List<Reservation> Reservations { get; set; }

        public List<Employee> Employees { get; set; }

    }
}
