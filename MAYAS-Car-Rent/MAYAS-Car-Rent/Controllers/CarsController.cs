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
        public async Task<ActionResult<IEnumerable<CarDTO>>> GetCars()
        {
            return Ok(await _car.GetCars());
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarDTO>> GetCar(int id)
        {
            var car = await _car.GetCar(id);

            return Ok(car);
        }

        // PUT: api/Cars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, Car car)
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
        public async Task<ActionResult<Car>> PostCar(Car car)
        {
            await _car.CreateCar(car);
            return CreatedAtAction("GetRoom", new { id = car.Id }, car);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _car.DeleteCar(id);
            return NoContent();
        }

        // GET: api/Cars/search/name
        [HttpGet("{search}/{name}")]
        public async Task<ActionResult<CarDTO>> GetCarbyname(string name)
        {
            var car = await _car.GetCarbyname(name);
            if (car == null)
            {
                return BadRequest($"Your search for {name} did not return any results");
                
            }
            return Ok(car);

        }
        
        // GET: api/Cars/search/year
        [HttpGet("{search}/{year}")]
        public async Task<ActionResult<CarDTO>> GetCarbyYear(int year)
        {
            var car = await _car.GetCarbyYear(year);
            if (car == null)
            {
                return BadRequest($"Your search for {year} did not return any results");

            }
            return Ok(car);

        }

        // GET: api/Cars/search/color
        [HttpGet("{search}/{color}")]
        public async Task<ActionResult<CarDTO>> GetCarbyColor(string color)
        {
            var car = await _car.GetCarbyColor(color);
            if (car == null)
            {
                return BadRequest($"Your search for {color} did not return any results");

            }
            return Ok(car);

        }


        // GET: api/Cars/search/model
        [HttpGet("{search}/{model}")]
        public async Task<ActionResult<CarDTO>> GetCarbyModel(string model)
        {
            var car = await _car.GetCarbyModel(model);
            if (car == null)
            {
                return BadRequest($"Your search for {model} did not return any results");

            }
            return Ok(car);

        }



    }
}
