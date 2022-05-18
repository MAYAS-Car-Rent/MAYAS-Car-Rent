using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MAYAS_Car_Rent.Models.DTOs
{
    public class CompanyDTO
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        public string ProfilePicture { get; set; }

        public double Rate { get; set; }

        public int RateCount { get; set; }

        public List<CarDTO> Cars { get; set; }

        public List<ReservationDTO> Reservations { get; set; }

        public List<EmployeeDTO> Employees { get; set; }
    }
}
