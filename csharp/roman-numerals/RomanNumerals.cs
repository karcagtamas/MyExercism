using System;
using System.Collections.Generic;

public static class RomanNumeralExtension
{
    private static readonly Dictionary<string, int> RomanNumbers = new Dictionary<string, int>
    {
        {"I", 1},
        {"IV", 4},
        {"V", 5},
        {"IX", 9},
        {"X", 10},
        {"XL", 40},
        {"L", 50},
        {"XC", 90},
        {"C", 100},
        {"CD", 400},
        {"D", 500},
        {"CM", 900},
        {"M", 1000}
    };

    public static string ToRoman(this int value)
    {
        if (value == 0)
        {
            return "";
        }
        string roman = "";

        string key = FindNearestNumber(value);

        if (value == RomanNumbers[key])
        {
            roman += key;
        }
        else
        {
            roman += key;
            roman += (value - RomanNumbers[key]).ToRoman();
        }

        return roman;
    }

    private static string FindNearestNumber(int number)
    {
        string nearestKey = "I";

        foreach (var key in RomanNumbers.Keys)
        {
            if (Math.Abs(RomanNumbers[key]) <= number)
            {
                nearestKey = key;
            }
        }

        return nearestKey;
    }
}