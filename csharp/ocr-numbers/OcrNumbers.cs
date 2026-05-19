using System.Text;

public static class OcrNumbers
{
    private static readonly Dictionary<string, char> Digits = new()
    {
        [" _ | ||_|   "] = '0',
        ["     |  |   "] = '1',
        [" _  _||_    "] = '2',
        [" _  _| _|   "] = '3',
        ["   |_|  |   "] = '4',
        [" _ |_  _|   "] = '5',
        [" _ |_ |_|   "] = '6',
        [" _   |  |   "] = '7',
        [" _ |_||_|   "] = '8',
        [" _ |_| _|   "] = '9'
    };

    public static string Convert(string input)
    {
        var rows = input.Split("\n");

        if (rows.Length % 4 != 0)
        {
            throw new ArgumentException();
        }

        foreach (var row in rows)
        {
            if (row.Length % 3 != 0)
            {
                throw new ArgumentException();
            }
        }

        var result = new List<string>();

        for (var blockRow = 0; blockRow < rows.Length; blockRow += 4)
        {
            var line = new StringBuilder();
            var digits = rows[blockRow].Length / 3;

            for (int digit = 0; digit < digits; digit++)
            {
                var pattern = new StringBuilder();

                for (int r = 0; r < 4; r++)
                {
                    pattern.Append(rows[blockRow + r].Substring(digit * 3, 3));
                }

                line.Append(Digits.TryGetValue(pattern.ToString(), out var value) ? value : '?');
            }

            result.Add(line.ToString());
        }

        return string.Join(",", result);
    }
}