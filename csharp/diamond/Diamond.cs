using System.Text;

public static class Diamond
{
    public static string Make(char target)
    {
        var side = target - 'A' + 1;
        var rows = side * 2 - 1;

        var result = new List<string>();
        for (var r = 0; r < rows; r++)
        {
            var d = Math.Min(r, rows - 1 - r);
            var c = (char)(d + 'A');

            var outerSpaces = side - d - 1;

            var sb = new StringBuilder();

            sb.Append(' ', outerSpaces);
            sb.Append(c);

            if (d > 0)
            {
                sb.Append(' ', 2 * d - 1);
                sb.Append(c);
            }

            sb.Append(' ', outerSpaces);

            result.Add(sb.ToString());
        }

        return string.Join('\n', result);
    }
}