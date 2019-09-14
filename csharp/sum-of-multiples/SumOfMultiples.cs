using System;
using System.Collections.Generic;

public static class SumOfMultiples
{
    public static int Sum(int[] multiples, int max)
    {
        int sum = 0;
        for (int i = 1; i < max; i++)
        {
            bool f = true;
            for (int x = 0; x < multiples.Length && f; x++)
            {
                if (multiples[x] != 0 && i % multiples[x] == 0)
                {
                    sum += i;
                    f = false;
                }
            }
        }
        return sum;
    }
}