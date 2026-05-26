using System.Text;

public static class FoodChain
{
    private static readonly string[] Animals = [
        "fly",
        "spider",
        "bird",
        "cat",
        "dog",
        "goat",
        "cow",
        "horse"
    ];

    private static readonly string?[] Remarks =
    [
        null,
        "It wriggled and jiggled and tickled inside her.",
        "How absurd to swallow a bird!",
        "Imagine that, to swallow a cat!",
        "What a hog, to swallow a dog!",
        "Just opened her throat and swallowed a goat!",
        "I don't know how she swallowed a cow!",
        "She's dead, of course!"
    ];

    public static string Recite(int verseNumber) => BuildVerse(verseNumber - 1);

    public static string Recite(int startVerse, int endVerse)
    {
        var verses = new List<string>();

        for (int i = startVerse; i <= endVerse; i++)
        {
            verses.Add(Recite(i));
        }

        return string.Join("\n\n", verses);
    }

    private static string BuildVerse(int index)
    {
        var sb = new StringBuilder();

        sb.AppendLine($"I know an old lady who swallowed a {Animals[index]}.");

        if (Remarks[index] != null)
        {
            sb.AppendLine(Remarks[index]);
        }

        if (Animals[index] == "horse")
        {
            return sb.ToString().TrimEnd();
        }

        for (int i = index; i > 0; i--)
        {
            var prey = Animals[i - 1];

            if (prey == "spider")
            {
                prey += " that wriggled and jiggled and tickled inside her";
            }

            sb.AppendLine($"She swallowed the {Animals[i]} to catch the {prey}.");
        }

        sb.AppendLine("I don't know why she swallowed the fly. Perhaps she'll die.");

        return sb.ToString().TrimEnd();
    }
}