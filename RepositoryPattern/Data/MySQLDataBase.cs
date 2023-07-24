using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Models;

namespace RepositoryPattern.Data
{
    public class MySQLDataBase : DbContext
    {
        public MySQLDataBase(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Department> DEPARTMENT { get; set; }
        public DbSet<Employee> EMPLOYEE { get; set; }

    }
}
