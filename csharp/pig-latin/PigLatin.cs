public static class PigLatin
{
    private static readonly char[] vowels = ['a', 'e', 'i', 'o', 'u'];

    public static string Translate(string word) => string.Join(' ', word.Split(' ').Select(TranslateWord));

    private static string TranslateWord(string word)
    {
        var idx = FirstConsonantClusterEnd(word);
        var quIndex = word.IndexOf("qu");
        var yIndex = word.IndexOf('y');

        if (vowels.Contains(word[0]) || word.StartsWith("xr") || word.StartsWith("yt"))
        {
            return $"{word}ay";
        }
        else if (quIndex != -1 && quIndex < idx)
        {
            return $"{word[(quIndex + 2)..]}{word[..(quIndex + 2)]}ay";
        }
        else if (yIndex > 0 && word.Substring(0, yIndex).All(c => !vowels.Contains(c)))
        {
            return $"{word[yIndex..]}{word[..yIndex]}ay";
        }
        else
        {
            return $"{word[idx..]}{word[..idx]}ay";
        }
    }

    private static int FirstConsonantClusterEnd(string word)
    {
        for (var i = 0; i < word.Length; i++)
        {
            if (vowels.Contains(word[i])) return i;
        }

        return word.Length;
    }
}