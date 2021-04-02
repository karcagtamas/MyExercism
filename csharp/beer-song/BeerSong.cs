using System;

public static class BeerSong
{
    public static string Recite(int startBottles, int takeDown)
    {
        const string word = "bottle";
        var result = "";

        var current = startBottles;
        for (int i = 1; i <= takeDown; i++)
        {
            var next = current - 1;
            if (result != "")
            {
                result += "\n\n";
            }

            if (next >= 0)
            {
                result += $"{current} {GetWord(word, current)} of beer on the wall, {current} {GetWord(word, current)} of beer.";
            
                if (next == 0)
                {
                    result += "\nTake it down and pass it around, no more bottles of beer on the wall.";
                }
                else
                {
                    result += $"\nTake one down and pass it around, {next} {GetWord(word, next)} of beer on the wall.";
                }
            }
            else
            {
                result += "No more bottles of beer on the wall, no more bottles of beer.\n" +
                          "Go to the store and buy some more, 99 bottles of beer on the wall.";
            }
           

            current = next;
        }

        return result;
    }

    private static string GetWord(string word, int number) => number > 1 ? word + "s" : word;
}