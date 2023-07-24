using RepositoryPattern.Models;

namespace RepositoryPattern.DAL
{
    public interface InterfaceDepartment
    {
        IEnumerable<Department> GetDepartment();
        Department GetDepartmentByDnumber(int Dnumber);
        void AddDepartment(Department department);
        void UpdateDepartment(Department department);
        void DeleteDepartment(int Dnumber);
    }
}
