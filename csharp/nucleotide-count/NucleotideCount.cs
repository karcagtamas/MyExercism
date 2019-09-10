using System;
using System.Collections.Generic;

public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        IDictionary<char, int> counts = new Dictionary<char, int>() { { 'A', 0 }, { 'C', 0 }, { 'G', 0 }, { 'T', 0 } };
        foreach (char character in sequence)
        {
            try
            {
                counts[character]++;
            }
            catch (System.Exception)
            {
                throw new ArgumentException("Invalid DNA element.");
            }
        }
        return counts;
    }
}