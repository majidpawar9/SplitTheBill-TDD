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
        public void SplitAmount_ReturnsCorrectSplit()
        {

            decimal totalAmount = 100.00M;
            int numberOfPeople = 4;
            decimal expectedSplit = 25.00M;

            // Total amount of 100 divided by 4 people should be 25
            decimal splitAmount = _STBService.SplitAmount(totalAmount, numberOfPeople);

            Assert.AreEqual(expectedSplit, splitAmount);
        }

        [TestMethod]
        public void SplitAmount_InvalidInput_ThrowsArgumentException()
        {
            decimal totalAmount = -100.00M;
            int numberOfPeople = 4;

            // Total amount of -100 is negative and should throw exception
            Action act = () => _STBService.SplitAmount(totalAmount, numberOfPeople);
            Assert.ThrowsException<Exception>(act);
        }

        [TestMethod]
        public void SplitAmount_ZeroAmount_ReturnZero_IrrespectiveOfNoOfPeople()
        {
            decimal totalAmount = 0.00M;
            int numberOfPeople = 4; 

            // Total Amount of 0 should return a split of 0
            decimal splitAmount = _STBService.SplitAmount(totalAmount, numberOfPeople);
            Assert.AreEqual(0, splitAmount);
        }

        [TestMethod]
        public void CalculateTips_ValidInput_ReturnsCorrectTipAmounts()
        {
            decimal mealCost = 20.00M;
            float tipPercentage = 15.00f;
            decimal expectedTip = 3.00M;

            var mealCosts = new Dictionary<string, decimal>
        {
            { "People", mealCost },
        };

        // Total tip on Amount 20 should be 3
            var tipAmounts = _STBService.CalculateTips(mealCosts, tipPercentage);
            Assert.AreEqual(expectedTip, tipAmounts["People"]);
            
        }

        [TestMethod]
        public void CalculateTips_NullMealCosts_ThrowsException()
        {
            // null or zero in place of dictionary should throw an Exception
            Assert.ThrowsException<Exception>(() => _STBService.CalculateTips(null, 15));
        }

        [TestMethod]
        public void CalculateTips_NegativeTipPercentage_ThrowsException()
        {
            decimal mealCost = 100.00M;
            float tipPercentage = -10.00f;

            var mealCosts = new Dictionary<string, decimal>
        {
            { "Person", mealCost }
        };
            // A negative Tip should throw an Exception
            Assert.ThrowsException<Exception>(() => _STBService.CalculateTips(mealCosts, tipPercentage));
        }

    }
}