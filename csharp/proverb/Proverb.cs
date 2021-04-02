using System;

public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        if (subjects.Length == 0)
        {
            return Array.Empty<string>();
        }

        string[] result = new string[subjects.Length];

        for (int i = 0; i < subjects.Length; i++)
        {
            if (i == subjects.Length - 1)
            {
                result[i] = $"And all for the want of a {subjects[0]}.";
            }
            else
            {
                result[i] = $"For want of a {subjects[i]} the {subjects[i + 1]} was lost.";
            }
        }

        return result;
    }
}