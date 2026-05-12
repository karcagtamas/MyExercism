public static class AtbashCipher
{
    public static string Encode(string plainValue) => string.Join(' ', Translate(plainValue)
            .Chunk(5)
            .Select(chunk => new string(chunk)));

    public static string Decode(string encodedValue) => Translate(encodedValue);

    private static string Translate(string s) => string.Join("", s.ToLower()
        .Where(char.IsLetterOrDigit)
        .Select(x =>
        {
            return char.IsLetter(x)
                ? (char)('z' - (x - 'a'))
                : x;
        }));
}
