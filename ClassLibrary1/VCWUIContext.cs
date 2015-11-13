using System.Collections.Generic;
using ClassLibraryDataAccess;

namespace StaticClassLibraryForUnitTests
{
    public class VCWUIContext
    {
        public bool BoolProperty { get; set; }

        public List<Employee> EmployeesOfContext { get; set; }

        public string TestProperty { get; set; }

        public Employee Manager { get; set; }
    }
}