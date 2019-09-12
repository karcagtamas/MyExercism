using System;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        string acro = "";
        string[] words = phrase.Replace("_", "").Replace("-", " ").Split(" ");
        foreach (var word in words)
        {
            if (word != "")
            {
                acro += word[0].ToString().ToUpper();
            }
        }
        return acro;
    }
}