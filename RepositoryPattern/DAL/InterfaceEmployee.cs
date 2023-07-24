using RepositoryPattern.Models;

namespace RepositoryPattern.DAL
{
    public interface InterfaceEmployee
    {
        IEnumerable<Employee>GetEmployees();
        Employee GetEmployeeBySsn(string Ssn);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(string Ssn);
    }
}
