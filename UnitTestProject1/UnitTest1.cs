using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StaticClassLibraryForUnitTests;

namespace StaticClassLibraryForUnitTests.Tests
{
    [TestClass()]
    public class UnitTest1
    {
        [TestMethod()]
        public void GetVCWUIContextTest()
        {
            var sut = new SUT();
            var context = sut.NonStaticGetVCWUIContext();
            Assert.IsTrue(context.BoolProperty);
        }
    }

    public class SUT : VCWBL
    {
        public override VCWUIContext GetContext()
        {
            return new VCWUIContext();
        }
    }
}
