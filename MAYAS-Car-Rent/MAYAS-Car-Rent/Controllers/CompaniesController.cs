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
    public class CompaniesController : ControllerBase // Made by Mutaz Altbakhi
    {
        private readonly ICompany _company;
        private readonly ICar _car;
        private readonly IEmployee _employee;
        private readonly IReservation _reservation;

        public CompaniesController(ICompany company , ICar car , IEmployee employee , IReservation reservation)
        {
            _company = company;
            _car = car;
            _employee = employee;
            _reservation = reservation;
        }

        // GET: api/Companies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDTO>>> GetCompanies()
        {
            return await _company.GetCompanies();
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]        
        public async Task<ActionResult<CompanyDTO>> GetCompany(int id)
        {
            var company = await _company.GetCompany(id);

            if (company == null)
            {
                return NotFound();
            }

            return company;
        }

        // PUT: api/Companies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, Company company)
        {
            if (id != company.Id)
            {
                return BadRequest();
            }

            var updateCompany = await _company.UpdateCompany(id, company);

            return Ok(updateCompany);
        }

        // POST: api/Companies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany(Company company)
        {
            var newCompany = await _company.CreateCompany(company);
            return Ok( newCompany);
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var company = await _company.GetCompany(id);
            if (company == null)
            {
                return NotFound();
            }

            await _company.DeleteCompany(id);
            return NoContent();
        }

        //[HttpGet("{UserName}")]
        //public async Task<ActionResult<IEnumerable<Company>>> SearchByName(string name)
        //{
        //    return await _company.SearchByName(name);
        //}


                                                // Made by Mutaz Altbakhi
        [HttpPost]
        [Route("{carId}/Car/{companyId}")]
        public async Task<ActionResult<Company>> AddCarToCompany(int carId , int companyId) 
        {
            await _company.AddCarToCompany(carId, companyId);
            return NoContent();
        }
        [HttpPost]
        [Route("{employeeId}/Employee/{companyId}")]
        public async Task<ActionResult<Company>> AddEmployeeToCompany(int employeeId, int companyId)
        {
            await _company.AddEmployeeToCompany(employeeId, companyId);
            return NoContent();
        }
        [HttpPost]
        [Route("{reservationId}/Reservation/{companyId}")]
        public async Task<ActionResult<Company>> AddReservationToCompany(int reservationId, int companyId)
        {
            await _company.AddReservationToCompany(reservationId, companyId);
            return NoContent();
        }

        [HttpDelete]
        [Route("{carId}/Car/{companyId}")]
        public async Task<ActionResult<Company>> RemoveCarFromCompany(int carId, int companyId)
        {
            var car = await _car.GetCar(carId);
            if (car == null)
            {
                return NotFound();
            }

            await _company.RemoveCarFromCompany(carId, companyId);
            return NoContent();
        }

        [HttpDelete]
        [Route("{employeeId}/Employee/{companyId}")]
        public async Task<ActionResult<Company>> RemoveEmployeeFromCompany(int employeeId, int companyId)
        {
            var employee = await _employee.GetEmployee(employeeId);
            if (employee == null)
            {
                return NotFound();
            }

            await _company.RemoveEmployeeFromCompany(employeeId, companyId);
            return NoContent();
        }

        [HttpDelete]
        [Route("{reservationId}/Reservation/{companyId}")]
        public async Task<ActionResult<Company>> RemoveReservationFromCompany(int reservationId, int companyId)
        {
            var reservation = await _reservation.GetReservation(reservationId);
            if (reservation == null)
            {
                return NotFound();
            }

            await _company.RemoveReservationFromCompany(reservationId, companyId);
            return NoContent();
        }
    }
}
