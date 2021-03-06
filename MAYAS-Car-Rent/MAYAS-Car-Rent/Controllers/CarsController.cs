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
using Microsoft.AspNetCore.Authorization;

namespace MAYAS_Car_Rent.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase // Made By Sultan
    {
        private readonly ICar _car;

        public CarsController(ICar car)
        {
            _car = car;
        }

        // GET: api/Cars
        [HttpGet]
        //[AllowAnonymous]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<CarDTO>>> GetCars() // show list of cars
        {
            return Ok(await _car.GetCars());
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarDTO>> GetCar(int id) // show car by id
        {
            var car = await _car.GetCar(id);

            return Ok(car);
        }

        // PUT: api/Cars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, Car car) // update car
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            var updatedCar = await _car.UpdateCar(id, car);
            return Ok(updatedCar);
        }

        // POST: api/Cars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(Car car) // add car
        {
            return Ok(await _car.CreateCar(car));
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id) // Delete Car by id
        {
            var car = await _car.GetCar(id);
            if (car == null)
            {
                return NotFound();
            }
            await _car.DeleteCar(id);
            return Ok("This Car was Deleted");
        }      

        // GET: api/Cars/filter             Made by Mutaz Altbakhi
        [HttpGet("filter")]
        public async Task<ActionResult<CarDTO>> FilterOnCar(string name, int year, string color, string model)
        {
            var car = await _car.FilterOnCar(name , year , color , model );
            if (car == null)
            {
                return BadRequest($"Your search for Car did not return any results");

            }
            return Ok(car);

        }
        // GET: api/Cars/SortbyYearDescending
        [HttpGet("SortbyYearDescending")]  // sort the car by yaer descending controler
        public async Task<ActionResult<CarDTO>> SortYear() // sultan
        {
            var Year = await _car.SortYear();
            
            return Ok(Year);

        }
        // GET: api/Cars/SortbyPriceDescending
        [HttpGet("SortByPriceDescending")]  // sort the car by price descending controler
        public async Task<ActionResult<CarDTO>> SortByPrice(int price)
        {
            var Price = await _car.SortByPrice(price);

            return Ok(Price);
        }




    }
}
