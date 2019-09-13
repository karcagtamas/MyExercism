using System;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        if (number <= 0)
        {
            throw new ArgumentOutOfRangeException("Not natural number");
        }
        int dividerSum = DividerSum(number);
        if (dividerSum < number)
        {
            return Classification.Deficient;
        }
        if (dividerSum == number)
        {
            return Classification.Perfect;
        }
        return Classification.Abundant;

    }

    public static int DividerSum(int number)
    {
        int sum = 0;
        for (int i = 1; i <= number / 2; i++)
        {
            if (number % i == 0)
            {
                sum += i;
            }
        }
        return sum;
    }
}
