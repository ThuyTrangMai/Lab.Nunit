using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Calculator;
using System.Collections.Generic;

namespace CalculatorTester
{
    [TestClass]
    public class UnitTest1
    {
        private Calculation cal;
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            this.cal = new Calculation(10, 5);
        }

        [TestMethod]
        public void TestAddOperator()
        {
            Assert.AreEqual(cal.Execute("+"), 15);
        }
        [TestMethod]
        public void TestSubOperator()
        {
            Assert.AreEqual(cal.Execute("-"), 5);
        }
        [TestMethod]
        public void TestMulOperator()
        {
            Assert.AreEqual(cal.Execute("*"), 50);
        }
        [TestMethod]
        public void TestDivOperator()
        {
            Assert.AreEqual(cal.Execute("/"), 2);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestDivByZero()
        {
            Calculation c = new Calculation(2, 0);
            c.Execute("/");
        }
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                        @".\Data\TestData.csv", "TestData#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TestWithDataSource()
        {
            string operation;
            int a = int.Parse(TestContext.DataRow[0].ToString());
            int b = int.Parse(TestContext.DataRow[1].ToString());
            operation = TestContext.DataRow[2].ToString();
            operation = operation.Remove(0, 1);
            int expected = int.Parse(TestContext.DataRow[3].ToString());
            Calculation c = new Calculation(a, b);
            int actual = c.Execute(operation);
            Assert.AreEqual(expected,actual);
        }
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                        @".\Data\TestDataPower.csv", "TestDataPower#csv", DataAccessMethod.Sequential)] 
        public void TestPower()
        {
            int n;
            double actual;
            double x, expected;
            n = int.Parse(TestContext.DataRow[1].ToString());
            x = double.Parse(TestContext.DataRow[0].ToString());
            expected = double.Parse(TestContext.DataRow[2].ToString());
            actual = Calculation.Power(x, n);

            Assert.AreEqual(expected, actual);
        }

        #region Polynomial
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Polynomial1()
        {
            int n = -1;
            List<int> a = new List<int>();
            Polynomial p = new Polynomial(n, a);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Polynomial2()
        {
            int n = 3;
            List<int> a = new List<int>() { 1, 2, 3 };
            Polynomial p = new Polynomial(n, a);
        }
        [TestMethod]
        public void Cal1()
        {
            int n = 3;
            List<int> a = new List<int>() { 4, 3, 2, 1 };
            Polynomial p = new Polynomial(n, a);
            Assert.AreEqual(26, p.Cal(2));
        }
        #endregion

        #region Radix
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Radix1()
        {
            int number = -1;
            Radix r = new Radix(number);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConvertDecimal1()
        {
            int number = 8;
            int radix = 17;
            Radix r = new Radix(number);
            r.ConvertDecimalToAnother(radix);
        }
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                        @".\Data\RadixData.csv", "RadixData#csv", DataAccessMethod.Sequential)]
        
        public void ConvertDecimal2()
        {
            int number ;
            int radix ;
            string expected;
            number = int.Parse(TestContext.DataRow[0].ToString());
            radix = int.Parse(TestContext.DataRow[1].ToString());
            expected = TestContext.DataRow[2].ToString();

            Radix r = new Radix(number);
            Assert.AreEqual(expected,r.ConvertDecimalToAnother(radix));
        }
        #endregion

    }
}
