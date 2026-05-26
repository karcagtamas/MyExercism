using System.Text;

public static class FlowerField
{
    public static string[] Annotate(string[] input)
    {
        var x = input.Length;
        var y = x > 0 ? input[0].Length : 0;

        var result = new List<string>();

        for (var i = 0; i < x; i++)
        {
            var sb = new StringBuilder();
            for (var j = 0; j < y; j++)
            {
                if (input[i][j] == '*')
                {
                    sb.Append('*');
                }
                else
                {
                    var count = Calc(i, j, input, x, y);

                    sb.Append(count == 0 ? ' ' : (char)('0' + count));
                }
            }

            result.Add(sb.ToString());
        }

        return [.. result];
    }

    private static int Calc(int i, int j, string[] input, int x, int y)
    {
        var count = 0;

        for (var r = Math.Max(0, i - 1); r <= Math.Min(x - 1, i + 1); r++)
        {
            for (var c = Math.Max(0, j - 1); c <= Math.Min(y - 1, j + 1); c++)
            {
                if (input[r][c] == '*')
                {
                    count++;
                }
            }
        }

        return count;
    }
}
