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
    public class EmployeesController : ControllerBase //Made by AbdUlrahman Jaran
    {
        private readonly IEmployee _employee;

        public EmployeesController(IEmployee employee)
        {
            _employee = employee;
        }

        // Get a List of Employees to the controller
        // GET: api/Employees/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployees()
        {
            var employees = await _employee.GetEmployees();
            return Ok(employees);
        }

        // Get one Employee by Id to the controllera
        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployee(int id)
        {
            EmployeeDTO employee = await _employee.GetEmployee(id);
            return Ok(employee);
        }

        // Update an existed Employee by Id with data from  POST body.
        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            var updatedEmployee = await _employee.UpdateEmployee(id, employee);

            return Ok(updatedEmployee);
        }

        // Create a new Employee in the DataBase with data from POST body
        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            return await _employee.CreateEmployee(employee);
        }

        // Delete an existed Employee by Id
        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employee.DeleteEmployee(id);
            return NoContent();
        }

        // Done by AbdUlrahman
        // Get list of Employees their names contain's "name"
        // GET: api/Employees/search/name
        [HttpGet("search/{name}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployeeByName(string name)
        {
            var employee = await _employee.SearchByName(name);
            return Ok(employee);
        }
    }
}
