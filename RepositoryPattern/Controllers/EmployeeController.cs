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
            try
            {
                var employees = _employee.GetEmployees();
                return Ok(employees);
            }
            catch (Exception)
            {

                return BadRequest("Error occured");
            }
        }
        [HttpGet("{Ssn}")]
        public ActionResult<Employee> GetEmployeeBySsn(string Ssn)
        {
            try
            {
                var employee = _employee.GetEmployeeBySsn(Ssn);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
            catch (Exception)
            {

                return BadRequest("Error occured");
            }
        }
        [HttpPost]
        public ActionResult<Employee> AddEmployee(Employee employee)
        {
            try
            {
                _employee.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployeeBySsn), new { Ssn = employee.Ssn }, employee);
            }
            catch (Exception)
            {

                return BadRequest("Error occured");
            }
        }
        [HttpPut]
        public IActionResult UpdateEmployee(string Ssn, Employee employee)
        {
            try
            {
                if (Ssn != employee.Ssn)
                {
                    return BadRequest();
                }
                _employee.UpdateEmployee(employee);
                return NoContent();
            }
            catch (Exception)
            {

                return BadRequest("Error occured");
            }
        }
        [HttpDelete("{Ssn}")]
        public IActionResult DeleteEmployee(string Ssn)
        {
            try
            {
                _employee.DeleteEmployee(Ssn);
                return NoContent();
            }
            catch (Exception)
            {

                return BadRequest("Error occured");
            }
        }
    }
}
