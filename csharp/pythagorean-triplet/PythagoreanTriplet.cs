using System;
using System.Collections.Generic;

public static class PythagoreanTriplet
{
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
    {
        List<(int a, int b, int c)> list = new List<(int a, int b, int c)>();
        int a = 1;
        int b = 2;
        int c = sum - (a + b);
        bool f = true;

        while (f)
        {
            if (Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2))
            {
                list.Add((a, b, c));
            }

            b++;
            c--;
            if (b >= c)
            {
                a++;
                b = a + 1;
                c = sum - (a + b);
                if (c < b)
                {
                    f = false;
                }
            }
        }

        return list;
    }
}