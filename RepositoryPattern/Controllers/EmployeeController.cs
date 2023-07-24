using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.DAL;
using RepositoryPattern.Models;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class EmployeeController : ControllerBase
    {
        private readonly InterfaceEmployee _employee;

        public EmployeeController(InterfaceEmployee employee)
        {  
            _employee = employee;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            var employees = _employee.GetEmployees();
            return Ok(employees);
        }
        [HttpGet("{Ssn}")]
        public ActionResult<Employee> GetEmployeeBySsn(string Ssn)
        {
            var employee = _employee.GetEmployeeBySsn(Ssn);
            if(employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPost]
        public ActionResult<Employee> AddEmployee(Employee employee)
        {
            _employee.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployeeBySsn), new { Ssn = employee.Ssn }, employee);
        }
        [HttpPut]
        public IActionResult UpdateEmployee(string Ssn, Employee employee)
        {
            if (Ssn!= employee.Ssn)
            {
                return BadRequest();
            }
            _employee.UpdateEmployee(employee);
            return NoContent();
        }
        [HttpDelete("{Ssn}")]
        public IActionResult DeleteEmployee(string Ssn)
        {
            _employee.DeleteEmployee(Ssn);
            return NoContent();
        }
    }
}
