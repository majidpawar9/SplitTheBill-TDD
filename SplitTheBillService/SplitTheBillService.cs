using System;

namespace SplitTheBill.Service
{
    public class SplitTheBillService
    {
        public double SplitAmount(double totalAmount, int numberOfPeople)
        {
            if (numberOfPeople <= 0)
            {
                throw new Exception("Number of people must be greater than zero.");
            }

            if (totalAmount < 0)
            {
                throw new Exception("Total amount must be a non-negative value.");
            }

            double split = totalAmount / numberOfPeople;
            
            return split;
        }
    }
}
