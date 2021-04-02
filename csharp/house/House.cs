using System;

public static class House
{
    private static string[] Things = {
        "the house that Jack built",
        "the malt",
        "the rat",
        "the cat",
        "the dog",
        "the cow with the crumpled horn",
        "the maiden all forlorn",
        "the man all tattered and torn",
        "the priest all shaven and shorn",
        "the rooster that crowed in the morn",
        "the farmer sowing his corn",
        "the horse and the hound and the horn"
    };

    private static string[] Actions = {
        "lay in",
        "ate",
        "killed",
        "worried",
        "tossed",
        "milked",
        "kissed",
        "married",
        "woke",
        "kept",
        "belonged to"
    };
    
    public static string Recite(int verseNumber)
    {
        string result = "";
        for (int i = verseNumber - 1; i >= 0; i--)
        {
            if (i == verseNumber - 1)
            {
                result += $"This is {Things[i]}";
            }
            else
            {
                result += $" that {Actions[i]} {Things[i]}";
            }
        }

        result += ".";

        return result;
    }

    public static string Recite(int startVerse, int endVerse)
    {
        string result = "";
        for (int i = startVerse; i <= endVerse; i++)
        {
            result += Recite(i);

            if (i != endVerse)
            {
                result += "\n";
            }
        }

        return result;
    }
}