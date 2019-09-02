using System;

public static class Leap
{
    public static bool IsLeapYear(int year)
    {
        return (year % 2 == 0 && year % 100 != 0) || year % 400 == 0;
    }
}