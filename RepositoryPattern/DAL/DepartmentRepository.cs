using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data;
using RepositoryPattern.Models;

namespace RepositoryPattern.DAL
{
    public class DepartmentRepository : InterfaceDepartment
    {
        public readonly MySQLDataBase _db;
        public DepartmentRepository(MySQLDataBase mySQLDataBase)
        {
            _db = mySQLDataBase;
        }

        public void AddDepartment(Department department)
        {
            _db.DEPARTMENT.Add(department);
            _db.SaveChanges();
        }

        public void DeleteDepartment(int Dnumber)
        {
            var department = _db.DEPARTMENT.Find(Dnumber);
            if (department != null)
            {
                _db.Remove(department);
                _db.SaveChanges();
            }
        }

        public IEnumerable<Department> GetDepartment()
        {
            return _db.DEPARTMENT.ToList();
        }

        public Department GetDepartmentByDnumber(int Dnumber)
        {
            var employee = _db.DEPARTMENT.Find(Dnumber);
            return employee;
        }
        public void UpdateDepartment(Department department)
        {
            _db.Entry(department).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
