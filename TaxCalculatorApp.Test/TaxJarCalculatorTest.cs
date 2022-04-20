using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using TaxCalculatorApp.Models;
using TaxCalculatorApp.Services;

namespace TaxCalculatorApp.Test
{
    [TestClass]
    public class TaxJarCalculatorTest
    {
        [TestMethod]
        public void TestMockTaxCollector()
        {
            ITaxCollector mockCollector = new MockTaxCollector();
            ITaxService service = new TaxService(mockCollector);
            Assert.IsNotNull(service);

        }

        [TestMethod]
        public void TestGetRates()
        {
            ITaxCollector taxCollector = new TaxCollector();
            var t1 = Task.Run(() => taxCollector.GetRates(TestData.RaleighZipCode));
            Assert.IsTrue(t1.Result.Rate != null && !String.IsNullOrEmpty(t1.Result.Rate.Combined_Rate));

        }

        [TestMethod]
        public void TestGetTaxes()
        {
            ITaxCollector taxCollector = new TaxCollector();
            Order testOrder = new Order
            {
                Amount = 50,
                Shipping = 10,
                From_Country = TestData.Country,
                To_Country = TestData.Country,
                To_State = TestData.State,
                From_State = TestData.State,
                To_Zip = TestData.RaleighZipCode2,
                From_Zip = TestData.RaleighZipCode
            };
            var t1 = Task.Run(() => taxCollector.GetTaxes(testOrder));
            Assert.IsTrue(t1.Result.Amount_To_Collect >= 0);

        }

        [TestMethod]
        public void TestGetRatesService()
        {
            ITaxCollector taxCollector = new TaxCollector();
            ITaxService taxService = new TaxService(taxCollector);
            var t1 = Task.Run(() => taxService.GetRates(TestData.RaleighZipCode));
            Assert.IsTrue(!String.IsNullOrEmpty(t1.Result.Rate.Combined_Rate));

        }

        [TestMethod]
        public void TestGetTaxesService()
        {
            ITaxCollector taxCollector = new TaxCollector();
            ITaxService taxService = new TaxService(taxCollector);
            Order testOrder = new Order
            {
                Amount = 50,
                Shipping = 10,
                From_Country = TestData.Country,
                To_Country = TestData.Country,
                To_State = TestData.State,
                From_State = TestData.State,
                To_Zip = TestData.RaleighZipCode2,
                From_Zip = TestData.RaleighZipCode
            };
            var t1 = Task.Run(() => taxService.GetTaxes(testOrder));
            Assert.IsTrue(t1.Result.Amount_To_Collect >= 0);

        }
    }
}
