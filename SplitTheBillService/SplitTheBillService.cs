﻿using System;

namespace SplitTheBill.Service
{
    public class SplitTheBillService
    {
        // This func Splits a total amount evenly among a specified number of people.
        public decimal SplitAmount(decimal totalAmount, int numberOfPeople)
        {
            if (numberOfPeople <= 0)
            {
                throw new Exception("Number of people must be greater than zero.");
            }

            if (totalAmount < 0)
            {
                throw new Exception("Total amount must be a non-negative value.");
            }

            decimal split = totalAmount / numberOfPeople;

            return split;
        }

        // This func Calculates the tip amount for each person based on meal costs and tip percentage.
        public Dictionary<string, decimal> CalculateTips(Dictionary<string, decimal> mealCosts, float tipPercentage)
        {
            if (mealCosts == null || mealCosts.Count == 0)
            {
                throw new Exception("The meal costs dictionary cannot be null or empty.");
            }

            if (tipPercentage < 0)
            {
                throw new Exception("The tip percentage cannot be negative.");
            }

            decimal totalMealCost = mealCosts.Values.Sum();
            decimal totalTip = (decimal)tipPercentage / 100 * totalMealCost;

            var tipAmounts = new Dictionary<string, decimal>();

            foreach (var entry in mealCosts)
            {
                decimal tip = entry.Value / totalMealCost * totalTip;
                tipAmounts[entry.Key] = tip;
            }

            return tipAmounts;
        }

        // This func Calculates the tip amount per person based on the price, number of patrons, and tip percentage.
        public decimal CalculateTipPerPerson(decimal price, int numberOfPatrons, float tipPercentage)
        {
            if (price < 0 || numberOfPatrons <= 0 || tipPercentage < 0)
            {
                throw new Exception("Invalid input values. Price, number of patrons, and tip percentage must be non-negative values.");
            }

            decimal totalTip = price * (decimal)(tipPercentage / 100);

            decimal tipPerPerson = totalTip / numberOfPatrons;

            return tipPerPerson;
        }
    }
}
