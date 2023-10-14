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
        [DataRow(100.00, 4, 25.00)] // Total amount divided by 4 people should be 25.00
        [DataRow(50.00, 2, 25.00)]  // Total amount divided by 2 people should be 25.00
        [DataRow(100.00, 1, 100.00)] // When there's only 1 person, they should pay the full amount

        public void SplitAmount_ReturnsCorrectSplit(double totalAmount, int numberOfPeople, double expectedSplit)
        {

            double splitAmount = _STBService.SplitAmount(totalAmount, numberOfPeople);
            Console.WriteLine(splitAmount);

            Assert.AreEqual(expectedSplit, splitAmount);
        }
        [TestMethod]
        [DataRow(-100.00, 4)]  // Total amount is negative
        [DataRow(100.00, -4)]  // Number of people is negative
        [DataRow(-100.00, -4)] // Both total amount and number of people are negative
        [DataRow(100.00, 0)]   // Number of people is zero
        public void SplitAmount_InvalidInput_ThrowsArgumentException(double totalAmount, int numberOfPeople)
        {
            Action act = () => _STBService.SplitAmount(totalAmount, numberOfPeople);
            Assert.ThrowsException<Exception>(act);
        }
        [TestMethod]
        [DataRow(0.00, 4)]
        public void SplitAmount_ZeroAmount_ReturnZero_IrrespectiveOfNoOfPeople(double totalAmount, int numberOfPeople)
        {
            double splitAmount = _STBService.SplitAmount(totalAmount, numberOfPeople);
            Assert.AreEqual(0, splitAmount);
        }

    }
}