using System;

public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        if (number <= 0)
        {
            throw new ArgumentException("The number is cannot be less than or equal with zero.");
        }
        int steps = 0;
        while (number != 1)
        {
            if (number % 2 == 0)
            {
                number = number / 2;
            }
            else
            {
                number = number * 3 + 1;
            }
            steps++;
        }
        return steps;
    }
}