using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MAYAS_Car_Rent.Data;
using MAYAS_Car_Rent.Models;
using MAYAS_Car_Rent.Models.DTOs;
using MAYAS_Car_Rent.Models.Interface;

namespace MAYAS_Car_Rent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class customersController : ControllerBase
    {
        private readonly ICustomer _customer;
        private readonly ICompany _company;
        public customersController(ICustomer customer, ICompany company)
        {
            _customer = customer;
            _company = company;
        }

        // GET: api/customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> Getcustomers()
        {
            var customer = await _customer.GetCustomer();
            return Ok(customer);
        }

        // GET: api/customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> Getcustomer(int id)
        {
            CustomerDTO newCustomer = await _customer.GetCustomer(id);
            return Ok(newCustomer);
        }

        // PUT: api/customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            var modifiedCustomer = await _customer.UpdateCustomer(id, customer);

            return Ok(modifiedCustomer);
        }

        // POST: api/customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> Postcustomer(Customer customer)
        {
            Customer newCustomer = await _customer.Create(customer);
            return Ok(newCustomer);

            // return CreatedAtAction("Getcustomer", new { id = customer.Id }, customer);
        }

        // DELETE: api/customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecustomer(int id)
        {
            await _customer.Delete(id);

            return NoContent();
        }

        // Done by AbdUlrahman
        // Reciving feedback from Coustmers by giving a Rate for companies.
        // PUT: api/customers/rating/{rate}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("rating/{rate}")]
        public async Task<IActionResult> PutRatingForCompanies(Company company, int rate)
        {
            if (rate > 5 || rate < 0)
                return BadRequest("Rating is from 1 to 5");

            var modifiedRate = await _company.UpdateRate(company, rate);
            return Ok(modifiedRate);
        }
    }
}
