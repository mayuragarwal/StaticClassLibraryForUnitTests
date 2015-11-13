using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using ClassLibrary1;
using ClassLibraryDataAccess;
using ClassLibraryDataAccess.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class OrderBlTests
    {
        [TestMethod]
        public void GetContextTest()
        {
            var orderBl = GetSystemUnderTest();
            var context = orderBl.GetContext();

            Assert.AreEqual(2, context.EmployeesOfContext.Count);
            Assert.AreEqual("TEST 3", context.EmployeesOfContext.First().Name);
        }

        [TestMethod]
        public void GetContextJSTest()
        {
            var orderBl = GetSystemUnderTest();
            var context = orderBl.GetContext();

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string output = serializer.Serialize(context);
            string path =
                @"C:\Users\Mayur\Documents\visual studio 2015\Projects\StaticClassLibraryForUnitTests\UnitTestProject1\Fakes\Output_OrderBL_GetContext.txt";
            //File.WriteAllText(path, output);

            string content = File.ReadAllText(path);
            Assert.AreEqual(output, content);
        }

        private static OrderBl GetSystemUnderTest()
        {
            IDbContext dbContext = new StubIDbContext()
            {
                NonStaticGetEmployees = () => new List<Employee>
                {
                    new Employee {Age = 23, Name = "TEST 3"},
                    new Employee {Age = 26, Name = "TEST 4"}
                }
            };

            var orderBl = new OrderBl(dbContext);
            return orderBl;
        }
    }

    public class FakeDbContext : IDbContext
    {
        public List<Employee> NonStaticGetEmployees()
        {
            return new List<Employee>
            {
                new Employee {Age = 23, Name = "TEST 3"},
                new Employee {Age = 26, Name = "TEST 4"}
            };
        }
    }
}