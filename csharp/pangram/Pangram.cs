using System;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
        int codeA = 97;
        int codeZ = 122;
        string newValue = input.ToLower();
        for (int i = codeA; i <= codeZ; i++)
        {
            if (Count(newValue, (char)i) == 0)
            {
                return false;
            }
        }
        return true;
    }

    private static int Count(string input, char toFind)
    {
        int count = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == toFind)
            {
                count++;
            }
        }
        return count;
    }
}
