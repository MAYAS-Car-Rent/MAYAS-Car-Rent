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

        public CompaniesController(ICompany company)
        {
            _company = company;
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
    }
}
