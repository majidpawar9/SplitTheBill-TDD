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

        public Dictionary<string, double> CalculateTips(Dictionary<string, double> mealCosts, float tipPercentage)
        {
            if (mealCosts == null || mealCosts.Count == 0)
            {
                throw new Exception("The meal costs dictionary cannot be null or empty.");
            }

            if (tipPercentage < 0)
            {
                throw new Exception("The tip percentage cannot be negative.");
            }

            double totalMealCost = mealCosts.Values.Sum();
            double totalTip = (double)tipPercentage / 100 * totalMealCost;

            var tipAmounts = new Dictionary<string, double>();

            foreach (var entry in mealCosts)
            {
                double tip = entry.Value / totalMealCost * totalTip;
                tipAmounts[entry.Key] = tip;
            }

            return tipAmounts;
        }
    }
}
