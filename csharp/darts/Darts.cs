using System;

public static class Darts
{
    public static int Score(double x, double y)
    {
        double fromO = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

        if (fromO > 10)
        {
            return 0;
        }

        if (fromO > 5)
        {
            return 1;
        }

        if (fromO > 1)
        {
            return 5;
        }

        return 10;
    }
}
