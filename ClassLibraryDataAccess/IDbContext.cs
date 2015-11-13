using System.Collections.Generic;

namespace ClassLibraryDataAccess
{
    public interface IDbContext
    {
        List<Employee> NonStaticGetEmployees();
    }
}