using System.Collections.Generic;

public static class BottleSong
{
    private readonly static List<string> numbers = ["no", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten"];

    public static IEnumerable<string> Recite(int startBottles, int takeDown)
    {
        var last = startBottles - takeDown + 1;
        for (var i = startBottles; i >= last; i--)
        {
            foreach(var line in Verse(i))
            {
                yield return line;
            }

            if (i != last)
            {
                yield return "";
            }
        }
    }

    private static string[] Verse(int n)
    {
        var current = Bottles(n);
        var next = Bottles(n - 1);

        return [
            $"{Capitalize(current)} hanging on the wall,",
            $"{Capitalize(current)} hanging on the wall,",
            "And if one green bottle should accidentally fall,",
            $"There'll be {next} hanging on the wall."
        ];
    }

    private static string Bottles(int n)
    {
        var word = numbers[n];
        var bottle = n == 1 ? "green bottle" : "green bottles";
        return $"{word} {bottle}";
    }

    private static string Capitalize(string text) =>
    string.IsNullOrEmpty(text)
        ? text
        : char.ToUpper(text[0]) + text[1..];
}
