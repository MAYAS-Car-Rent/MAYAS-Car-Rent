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
    public class CarService : ICar
    {
        private readonly MAYASDbContext _context;

        public CarService(MAYASDbContext context)
        {
            _context = context;
        }

        public async Task<Car> CreateCar(Car car)
        {
            Car NewCar = new Car
            {
                Name = car.Name,
                Color = car.Color,
                Year = car.Year,
                Model = car.Model,
                PlateNumber = car.PlateNumber,
            };
            _context.Entry(NewCar).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task DeleteCar(int Id)
        {
            Car car = await _context.Cars.FindAsync(Id);
            _context.Entry(car).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<CarDTO> GetCar(int Id)
        {
            return await _context.Cars.Select(car => new CarDTO
            {
                Id = car.Id,
                Name = car.Name,
                Color = car.Color,
                Year = car.Year,
                Model = car.Model,
                PlateNumber = car.PlateNumber,

            }).FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<CarDTO>> GetCars()
        {
            return await _context.Cars.Select(car => new CarDTO
            {
                Id = car.Id,
                Name = car.Name,
                Color = car.Color,
                Year = car.Year,
                Model = car.Model,
                PlateNumber = car.PlateNumber,

            }).ToListAsync();
        }

        public async Task<Car> UpdateCar(int id, Car car)
        {
            Car updateCar = new Car
            {
                Id = car.Id,
                Name = car.Name,
                Color = car.Color,
                Year = car.Year,
                Model = car.Model,
                PlateNumber = car.PlateNumber,
                IsRent = car.IsRent
            };
            _context.Entry(updateCar).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return car;
        }
        public Task<List<Car>> SearchByName(string term)
        {
            var result = _context.Cars.Include(x => x.Name)
                                        .Where(x => x.Name.Contains(term))
                                        .ToListAsync();
            return result;
        }
    }
}