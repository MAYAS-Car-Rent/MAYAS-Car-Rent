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
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            return Ok(await _car.GetCars());
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
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


    }
}
