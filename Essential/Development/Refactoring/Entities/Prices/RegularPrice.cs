﻿namespace Entities.Prices
{
    public class RegularPrice : Price
    {
        public override double GetCharge(int daysRented)
        {
            double result = 2;
            if (daysRented > 2)
                result += (daysRented - 2) * 1.5;
            return result;
        }

        public override int GetPriceCode() => Movie.regular;
    }
}
