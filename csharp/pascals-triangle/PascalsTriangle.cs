using System;
using System.Collections.Generic;

public static class PascalsTriangle
{
    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
    {
        List<List<int>> tri = new List<List<int>>();
        for (int i = 0; i < rows; i++)
        {
            tri.Add(new List<int>());
            for (int j = 0; j < i + 1; j++)
            {
                tri[i].Add(CalcValue(i, j, tri));
            }
        }
        return tri;
    }

    private static int CalcValue(int row, int el, List<List<int>> tri)
    {
        if (row == 0 && el == 0)
        {
            return 1;
        }

        if (row - 1 == 0)
        {
            return 1;
        }

        if (el == 0 || el == row)
        {
            return 1;
        }
        
        return tri[row - 1][el - 1] + tri[row - 1][el];
    }
}