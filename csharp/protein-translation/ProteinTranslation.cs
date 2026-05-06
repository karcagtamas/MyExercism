using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualBasic;

public static class ProteinTranslation
{
    private static readonly Dictionary<string, string[]> ProteinList = new()
    {
        {"Methionine", new[] {"AUG"}}, 
        {"Phenylalanine", new[] {"UUU", "UUC"}},
        {"Leucine", new[] {"UUA", "UUG"}},
        {"Serine", new[] {"UCU", "UCC", "UCA", "UCG"}},
        {"Tyrosine", new[] {"UAU", "UAC"}},
        {"Cysteine", new[] {"UGU", "UGC"}},
        {"Tryptophan", new[] {"UGG"}},
        {"STOP", new[] {"UAA", "UAG", "UGA"}},
    };

    public static string[] Proteins(string strand)
    {
        int length = strand.Length / 3;
        List<string> result = [];
        for (int i = 0; i < length; i++)
        {
            string prot = FindProtein(strand.Substring(i * 3, 3));

            if (prot == "STOP")
            {
                break;
            }
            
            result.Add(prot);
        }

        return [.. result];
    }

    private static string FindProtein(string strand) => ProteinList.FirstOrDefault(x => x.Value.Contains(strand)).Key;
}