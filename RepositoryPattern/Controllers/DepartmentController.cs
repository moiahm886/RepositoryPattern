using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.DAL;
using RepositoryPattern.Models;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly InterfaceDepartment _department;

        public DepartmentController(InterfaceDepartment department)
        {
            _department = department;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            try
            {
                var department = _department.GetDepartment();
                return Ok(department);
            }
            catch (Exception)
            {

                return BadRequest("Error occured");
            }
        }
        [HttpGet("{Dnumber}")]
        public ActionResult<Employee> GetDepartmentByDnumber(int Dnumber)
        {
            try
            {
                var department = _department.GetDepartmentByDnumber(Dnumber);
                if (department == null)
                {
                    return NotFound();
                }
                return Ok(department);
            }
            catch (Exception)
            {

                return BadRequest("Error occured");
            }
        }
        [HttpPost]
        public ActionResult<Department> AddDepartment(Department department)
        {
            try
            {
                _department.AddDepartment(department);
                return CreatedAtAction(nameof(GetDepartmentByDnumber), new { Dnumber = department.Dnumber }, department);
            }
            catch (Exception )
            {

                return BadRequest("Error occured");
            }
        }
        [HttpPut]
        public IActionResult UpdateDepartment(int Dnumber, Department department)
        {
            try
            {
                if (Dnumber != department.Dnumber)
                {
                    return BadRequest();
                }
                _department.UpdateDepartment(department);
                return NoContent();
            }
            catch (Exception)
            {

               return BadRequest("Error occured");
            }
        }
        [HttpDelete("{Dnumber}")]
        public IActionResult DeleteDepartment(int Dnumber)
        {
            try
            {
                _department.DeleteDepartment(Dnumber);
                return NoContent();
            }
            catch (Exception)
            {

                return BadRequest("Error occured");
            }
        }
    }
}
