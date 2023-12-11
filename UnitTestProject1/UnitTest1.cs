using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CalcClassBr;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private const string connectionString = "Data Source=DESKTOP-KM0M0QD;Initial Catalog=test;Integrated Security=True";

        [TestMethod]
        [DataSource("System.Data.SqlClient", connectionString, "DataForCalculator", DataAccessMethod.Sequential)]
        public void Add_CorrectData_ShouldReturnCorrectResults()
        {
            long a = Convert.ToInt64(TestContext.DataRow["A"]);
            long b = Convert.ToInt64(TestContext.DataRow["B"]);
            int expected = Convert.ToInt32(TestContext.DataRow["ExpectedResult"]);

            int result = CalcClass.Add(a,b);

            Assert.AreEqual(expected, result, $"Adding {a} and {b} should return {expected}");
        }

        [TestMethod]
        [DataSource("System.Data.SqlClient", connectionString, "ErrorDataForCalculator", DataAccessMethod.Sequential)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Add_InvalidData_ShouldThrowArgumentOutOfRangeException()
        {
            long a = Convert.ToInt64(TestContext.DataRow["A"]);
            long b = Convert.ToInt64(TestContext.DataRow["B"]);

            int result = CalcClass.Add(a, b);

        }

        public TestContext TestContext { get; set; }
    }
}
