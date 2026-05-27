using System.Text;

public static class TwelveDays
{
    private static readonly string[] Days = [
        "first",
        "second",
        "third",
        "fourth",
        "fifth",
        "sixth",
        "seventh",
        "eighth",
        "ninth",
        "tenth",
        "eleventh",
        "twelfth",
    ];

    private static readonly string[] Gifts = [
        "a Partridge in a Pear Tree",
        "two Turtle Doves",
        "three French Hens",
        "four Calling Birds",
        "five Gold Rings",
        "six Geese-a-Laying",
        "seven Swans-a-Swimming",
        "eight Maids-a-Milking",
        "nine Ladies Dancing",
        "ten Lords-a-Leaping",
        "eleven Pipers Piping",
        "twelve Drummers Drumming",
    ];

    public static string Recite(int verseNumber) => Verse(verseNumber);

    public static string Recite(int startVerse, int endVerse)
    {
        var sb = new StringBuilder();

        for (int i = startVerse; i <= endVerse; i++)
        {
            sb.Append(Verse(i));

            if (i != endVerse) sb.Append('\n');
        }

        return sb.ToString();
    }

    private static string Verse(int verse)
    {
        var sb = new StringBuilder();

        sb.Append($"On the {Days[verse - 1]} day of Christmas my true love gave to me: ");

        for (var i = verse - 1; i >= 0; i--)
        {
            if (i == 0 && verse > 1) sb.Append("and ");

            sb.Append(Gifts[i]);

            if (i > 0) sb.Append(", ");
        }

        sb.Append('.');

        return sb.ToString();
    }
}