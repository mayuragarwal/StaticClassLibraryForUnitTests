using System;

namespace StaticClassLibraryForUnitTests
{
    internal class OrderBL
    {
        internal static VCWUIContext GetContext()
        {
            return new VCWUIContext();
        }
    }
}