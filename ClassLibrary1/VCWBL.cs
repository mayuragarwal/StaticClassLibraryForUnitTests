using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1;
using ClassLibraryDataAccess;

namespace StaticClassLibraryForUnitTests
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class VCWBL : IVCWBL
    {
        public VCWBL()
        {
        }

        public static VCWUIContext GetVCWUIContext()
        {
            VCWBL vcw = new VCWBL();
            return vcw.NonStaticGetVCWUIContext();
        }

        public VCWUIContext NonStaticGetVCWUIContext()
        {
            //non static method
            var context = GetContext();
            context.BoolProperty = true;
            return context;
        }

        public virtual VCWUIContext GetContext()
        {
            // dependency
            var orderBl = new OrderBl(new DbContext());
            return orderBl.GetContext();
        }
    }
}
