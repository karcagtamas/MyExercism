using System;
using System.Linq;

public class Anagram
{
    private readonly string baseWord;
    private readonly string sortedWord;

    public Anagram(string baseWord)
    {
        this.baseWord = baseWord;
        this.sortedWord = SortedString(baseWord);
    }

    public string[] FindAnagrams(string[] potentialMatches) => potentialMatches
            .Where(s => sortedWord == SortedString(s))
            .Where(s => s.ToLower() != baseWord.ToLower())
            .ToArray();

    private static string SortedString(string text) => string.Join("", text.ToLower().ToCharArray().OrderBy(o => o).ToList());
}