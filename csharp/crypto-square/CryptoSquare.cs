using System.Text;

public static class CryptoSquare
{
    public static string Ciphertext(string plaintext)
    {
        var normalized = string.Join("", plaintext.Where(c => char.IsLetter(c) || char.IsDigit(c))).ToLower();
        var (r, c) = Rectangle(normalized);

        var result = new List<string>();

        for (var i = 0; i < c; i++)
        {
            var sb = new StringBuilder();

            for (var j = 0; j < r; j++)
            {
                var index = j * c + i;
                sb.Append(index < normalized.Length ? normalized[index] : ' ');
            }

            result.Add(sb.ToString());
        }

        return string.Join(" ", result);
    }

    private static (int, int) Rectangle(string normalized)
    {
        var n = normalized.Length;
        var r = 1;
        var c = n;

        for (var i = 1; i <= n; i++)
        {
            var rows = i;
            var cols = (n + rows - 1) / rows;

            if (cols >= rows && cols - rows <= 1)
            {
                r = rows;
                c = cols;
                break;
            }
        }

        return (r, c);
    }
}
