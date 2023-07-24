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
            var department = _department.GetDepartment();
            return Ok(department);
        }
        [HttpGet("{Dnumber}")]
        public ActionResult<Employee> GetDepartmentByDnumber(int Dnumber)
        {
            var department = _department.GetDepartmentByDnumber(Dnumber);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }
        [HttpPost]
        public ActionResult<Department> AddDepartment(Department department)
        {
            _department.AddDepartment(department);
            return CreatedAtAction(nameof(GetDepartmentByDnumber), new { Dnumber = department.Dnumber }, department);
        }
        [HttpPut]
        public IActionResult UpdateDepartment(int Dnumber, Department department)
        {
            if (Dnumber != department.Dnumber)
            {
                return BadRequest();
            }
            _department.UpdateDepartment(department);
            return NoContent();
        }
        [HttpDelete("{Dnumber}")]
        public IActionResult DeleteDepartment(int Dnumber)
        {
            _department.DeleteDepartment(Dnumber);
            return NoContent();
        }
    }
}
