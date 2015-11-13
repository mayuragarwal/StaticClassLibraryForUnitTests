using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ClassLibraryDataAccess
{
    public class DbContext : IDbContext
    {
        public static List<Employee> GetEmployees()
        {
            DbContext context = new DbContext();
            return context.NonStaticGetEmployees();
        }

        public List<Employee> NonStaticGetEmployees()
        {
            Thread.Sleep(5000); //Slow DataBase
            return new List<Employee>
            {
                new Employee {Age = 23, Name = "TEST 1"},
                new Employee {Age = 26, Name = "TEST 2"}
            };
        }

        public static IEnumerable<Employee> GetEmployeeByAge(int age)
        {
            Thread.Sleep(5000); //Slow DataBase
            var employees = new List<Employee>
            {
                new Employee {Age = 23, Name = "TEST 1"},
                new Employee {Age = 26, Name = "TEST 2"}
            };
            return employees.Where(e => e.Age == age);
        }
    }
}
