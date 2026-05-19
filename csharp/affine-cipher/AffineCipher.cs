using System.Text;

public static class AffineCipher
{
    private static readonly int m = 26;

    public static string Encode(string plainText, int a, int b)
    {
        if (GCD(a, m) != 1)
        {
            throw new ArgumentException();
        }

        var cleaned = plainText.ToLower().Where(char.IsLetterOrDigit).ToArray();

        var transformed = new StringBuilder();

        foreach (var ch in cleaned)
        {
            if (char.IsDigit(ch))
            {
                transformed.Append(ch);
            }
            else if (char.IsLetter(ch))
            {
                var x = ch - 'a';
                var y = (a * x + b) % m;
                transformed.Append((char)('a' + y));
            }
        }

        return string.Join(" ", transformed.ToString().Chunk(5).Select(chunk => new string(chunk)));
    }

    public static string Decode(string cipheredText, int a, int b)
    {
        var aInv = ModInverse(a, m);
        var cleaned = cipheredText.ToLower().Where(char.IsLetterOrDigit).ToArray();

        var transformed = new StringBuilder();

        foreach (var ch in cleaned)
        {
            if (char.IsDigit(ch))
            {
                transformed.Append(ch);
            }
            else if (char.IsLetter(ch))
            {
                var y = ch - 'a';
                var x = (aInv * Mod(y - b, m)) % m;
                transformed.Append((char)('a' + x));
            }
        }

        return transformed.ToString();
    }

    private static int GCD(int x, int y)
    {
        var a = x;
        var b = y;

        while (b != 0)
        {
            var t = b;
            b = a % b;
            a = t;
        }

        return a;
    }

    private static int ModInverse(int a, int m)
    {
        for (var x = 1; x < m; x++)
        {
            if ((a * x) % m == 1) return x;
        }

        throw new ArgumentException();
    }

    private static int Mod(int a, int m) => ((a % m) + m) % m;
}
