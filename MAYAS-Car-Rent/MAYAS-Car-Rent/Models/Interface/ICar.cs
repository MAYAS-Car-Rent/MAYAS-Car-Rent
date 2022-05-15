using MAYAS_Car_Rent.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MAYAS_Car_Rent.Models.Interface
{
    public interface ICar
    {
        Task<Car> CreateCar(Car car);

        Task<List<CarDTO>> GetCars();

        Task<CarDTO> GetCar(int Id);

        Task<Car> UpdateCar(int Id, Car car);

        Task DeleteCar(int Id);
        Task<List<CarDTO>> GetCarbyname(string name);
        Task<List<CarDTO>> GetCarbyYear(int year);
        Task<List<CarDTO>> GetCarbyColor(string color);
        Task<List<CarDTO>> GetCarbyModel(string model);


    }
}