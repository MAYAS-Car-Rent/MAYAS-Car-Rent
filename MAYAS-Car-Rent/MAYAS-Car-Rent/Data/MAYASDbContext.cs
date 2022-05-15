using MAYAS_Car_Rent.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAYAS_Car_Rent.Data
{

    public class MAYASDbContext : IdentityDbContext<ApplicationUser>

    {        
        public DbSet<Admin> Admins { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Customer> customers { get; set; }

        public DbSet<Company> Companies { get; set; }        

        public DbSet<Car> Cars { get; set; }
       
        public DbSet<Reservation> Reservations { get; set; }
        
        public MAYASDbContext(DbContextOptions options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>().HasData(
              new Company { Id = 1, UserName = "Sultan Rental", Email = "SultanRental@Gmail.com", Password = "Sultan123", Address = "Amman" , PhoneNumber = "962791234567", CommercialRegistrationNumber = 123456789 },
              new Company { Id = 2, UserName = "Ola Rental", Email = "OlaRental@Gmail.com", Password = "Ola123", Address = "Irbid", PhoneNumber = "962791234567", CommercialRegistrationNumber = 123456789 },
              new Company { Id = 3, UserName = "Haneen Rental", Email = "HaneenRental@Gmail.com", Password = "Haneen123", Address = "Jarash", PhoneNumber = "962791234567", CommercialRegistrationNumber = 123456789 },
              new Company { Id = 4, UserName = "Abdalrahman Rental", Email = "AbdalrahmanRental@Gmail.com", Password = "Abdalrahman123", Address = "Amman", PhoneNumber = "962791234567", CommercialRegistrationNumber = 123456789 }
              );

            //modelBuilder.Entity<Car>().HasData(
            //  new Car { Id = 1, Name = "KIA", Color = "Red", Year = 2022 , Model = "sportage", PlateNumber = "Jo-12-1234" },
            //  new Car { Id = 2, Name = "BMW", Color = "Black", Year = 2022, Model = "m3", PlateNumber = "Jo-13-123" },
            //  new Car { Id = 3, Name = "Toyota", Color = "Blue", Year = 2022, Model = "corolla", PlateNumber = "Jo-14-24685" },
            //  new Car { Id = 4, Name = "Mercedes", Color = "White", Year = 2022, Model = "G-Class", PlateNumber = "Jo-10-10" }
            //  );

            modelBuilder.Entity<Admin>().HasData(
              new Admin { Id = 1, Name = "Admin", Email = "MAYAS_Admin@Gmail.com", Password = "Admin123" }
             );
        }
    }
}
