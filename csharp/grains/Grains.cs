using System;

public static class Grains
{
    public static ulong Square(int n)
    {
        if (n <= 0)
        {
            throw new ArgumentOutOfRangeException("The n cannot be less than or equal with zero.");
        }
        if (n > 64)
        {
            throw new ArgumentOutOfRangeException("The n cannot be greater than 64.");
        }
        return 1UL * (ulong)Math.Pow(2, n - 1);
    }

    public static ulong Total()
    {
        ulong sum = 0L;
        for (int i = 1; i <= 64; i++)
        {
            sum += Square(i);
        }
        return sum;
    }
}