using ClassLibraryDataAccess;
using StaticClassLibraryForUnitTests;

namespace ClassLibrary1
{
    public class OrderBl
    {
        readonly IDbContext _context; //dependency

        public OrderBl(IDbContext context)
        {
            _context = context;
        }

        public OrderBl()
        {
            _context = new DbContext();
        }

        public static VCWUIContext StaticGetContext()
        {
            var orderBl = new OrderBl(new DbContext());
            return orderBl.GetContext();
        }

        public VCWUIContext GetContext()
        {
            var vCwuiContext = new VCWUIContext
            {
                BoolProperty = false,
                TestProperty = "123",
                EmployeesOfContext = _context.NonStaticGetEmployees(),//DbContext.GetEmployeeByAge(23).ToList()
                Manager = new Employee { Name = "TestManager", Age = 40 }
            }; 
            return vCwuiContext;
        }
    }
}