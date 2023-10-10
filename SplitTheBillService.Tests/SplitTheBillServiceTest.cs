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
        public void IsSTB_InputIs1_ReturnFalse()
        {
            bool result = _STBService.IsBill(1);

            Assert.IsFalse(result, "1 should not be prime");
        }
    }
}