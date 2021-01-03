using System;
using System.Collections.Generic;
using System.Linq;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        List<int> digits = new List<int>();
        int origin = number;

        while (number != 0)
        {
            digits.Add(number % 10);
            number = (int)Math.Floor(number / (double)10);
        }

        int sum = digits.Sum(x => (int)Math.Pow(x, digits.Count));
        
        return sum == origin;
    }
}