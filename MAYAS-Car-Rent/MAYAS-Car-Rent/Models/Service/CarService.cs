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
    public class CarService : ICar // sultan
    {
        private readonly MAYASDbContext _context;

        public CarService(MAYASDbContext context)
        {
            _context = context;
        }

        public async Task<Car> CreateCar(Car car)  // logic for Create Car
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

        public async Task DeleteCar(int Id) // logic for Delete Car
        {
            Car car = await _context.Cars.FindAsync(Id);
            _context.Entry(car).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<CarDTO> GetCar(int Id) // logic for show car by id
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

        public async Task<List<CarDTO>> GetCars() // logic for get list of cars
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

        public async Task<Car> UpdateCar(int id, Car car) // logic for Update Car
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
        // Made by Mutaz Altbakhi

        public async Task<List<CarDTO>> FilterOnCar(string name, int year, string color, string model)
        {
            var result = await _context.Cars.Select(

                       car1 => new CarDTO
                       {
                           Name = car1.Name.ToLower(),
                           Color = car1.Color.ToLower(),
                           Year = car1.Year,
                           Model = car1.Model.ToLower(),
                           PlateNumber = car1.PlateNumber
                       }
               )
               .AsNoTracking()
                .ToListAsync();
            if (name != null)
            {
                result = result.Where(y => y.Name.Contains(name)).ToList();
            }
            if (year > 0)
            {
                result = result.Where(y => y.Year.Equals(year)).ToList();
            }
            if (color != null)
            {
                result = result.Where(y => y.Color.Contains(color)).ToList();
            }
            if (model != null)
            {
                result = result.Where(y => y.Model.Contains(model)).ToList();
            }

            return result;
        }
        public async Task<List<CarDTO>> SortYear(int way) // sort the car by yaer ascending or descending logic by sultan
        {
            var car =  await _context.Cars.Select(

                      car1 => new CarDTO
                      {
                          Id = car1.Id,
                          Name = car1.Name,
                          Color = car1.Color,
                          Year = car1.Year,
                          Model = car1.Model,
                          PlateNumber = car1.PlateNumber
                      }

              ).ToListAsync();
            if (way == 1)
            {
                car = car.OrderBy(car => car.Year).ToList();
            }
            if (way == 9)
            {
                car = car.OrderByDescending(car => car.Year).ToList();
            }
            return car;
        }
    
        
    }
}