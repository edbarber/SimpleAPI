using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using SimpleAPI.Data;

namespace SimpleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        public EmployeesController(EmployeeDbContext context)
        {
            _context = context;
        }

        // GET api/employees
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return _context.Employee;
        }

        // GET api/employees/5
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            Employee employee = _context.Employee.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // POST api/employees/add
        [HttpPost("add")]
        public async Task<ActionResult> AddAsync(Employee employee)
        {
            TrimEmployeeData(employee);

            _context.Employee.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
        }

        // PUT api/employees/edit
        [HttpPut("edit")]
        public async Task<ActionResult> Edit(Employee employee)
        {
            TrimEmployeeData(employee);

            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/employees/delete/5
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Employee employee = _context.Employee.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private void TrimEmployeeData(Employee employee)
        {
            if (employee != null)
            {
                employee.FirstName = employee.FirstName?.Trim();
                employee.LastName = employee.FirstName?.Trim();
            }
        }
    }
}
