using System;

namespace SplitTheBill.Service
{
    public class SplitTheBillService
    {
        public bool IsBill(int amount)
        {
            if (amount == 1)
            {
                return false;
            }
            throw new NotImplementedException("Please create a test first.");
        }
    }
}
