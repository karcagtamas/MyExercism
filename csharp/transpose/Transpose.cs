using System.Text;

public static class Transpose
{
    public static string String(string input)
    {
        if (string.IsNullOrEmpty(input)) return string.Empty;

        var rows = input.Split('\n');

        var maxLen = rows.Max(x => x.Length);
        var lastRowWithChar = new int[maxLen];

        for (var col = 0; col < maxLen; col++)
        {
            for (var row = rows.Length - 1; row >= 0; row--)
            {
                if (col < rows[row].Length)
                {
                    lastRowWithChar[col] = row;
                    break;
                }
            }
        }

        List<string> result = [];

        for (var col = 0; col < maxLen; col++)
        {
            var sb = new StringBuilder();

            for (var row = 0; row < rows.Length; row++)
            {
                if (col < rows[row].Length)
                {
                    sb.Append(rows[row][col]);
                }
                else if (row < lastRowWithChar[col])
                {
                    sb.Append(' ');
                }
            }

            result.Add(sb.ToString());
        }

        return string.Join("\n", result);
    }
}