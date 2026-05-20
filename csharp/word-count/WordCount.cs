using System.Text.RegularExpressions;

public static class WordCount
{
    private static Regex regex = new Regex("""[A-Za-z0-9]+(?:'[A-Za-z0-9]+)*""");

    public static IDictionary<string, int> CountWords(string phrase)
    {
        var words = new Dictionary<string, int>();
        var input = phrase.ToLower();

        foreach (Match match in regex.Matches(input))
        {
            var word = match.Value;

            if (!words.TryAdd(word, 1))
            {
                words[word]++;
            }
        }

        return words;
    }
}