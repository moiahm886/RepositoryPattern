using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data;
using RepositoryPattern.Models;

namespace RepositoryPattern.DAL
{
    public class EmployeeRepository : InterfaceEmployee
    {
        private readonly MySQLDataBase _db;

        public EmployeeRepository(MySQLDataBase db)
        {
            _db = db;
        }

        public void AddEmployee(Employee employee)
        {
            _db.EMPLOYEE.Add(employee);
            _db.SaveChanges();
        }

        public void DeleteEmployee(string Ssn)
        {
            var employee = _db.EMPLOYEE.Find(Ssn);
            if (employee != null)
            {
                _db.EMPLOYEE.Remove(employee);
                _db.SaveChanges();
            }

        }

        public Employee GetEmployeeBySsn(string Ssn)
        {
            var employee  = _db.EMPLOYEE.Find(Ssn);
            return employee;
            
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _db.EMPLOYEE.ToList();
        }

        public void UpdateEmployee(Employee employee)
        {
            _db.Entry(employee).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
