// namespace SplitTheBillService.Tests;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SplitTheBill.Service;

namespace STB.UnitTests.Services
{
    [TestClass]
    public class SplitTheBillServiceTest
    {
        private readonly SplitTheBillService _STBService;

        public SplitTheBillServiceTest()
        {
            _STBService = new SplitTheBillService();
        }

        [TestMethod]
        [DataRow(100.00, 4, 25.00)] 
        [DataRow(50.00, 2, 25.00)]  
        [DataRow(0.00, 5, 0.00)]
        [DataRow(100.00, 1, 100.00)]
        public void SplitAmount_ReturnsCorrectSplit(double totalAmount, int numberOfPeople, double expectedSplit)
        {
            
            double splitAmount = _STBService.SplitAmount(totalAmount, numberOfPeople);
            Console.WriteLine(splitAmount);
            
            Assert.AreEqual(expectedSplit, splitAmount);
        }
    }
}