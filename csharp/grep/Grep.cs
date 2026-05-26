using System.Text;

public static class Grep
{
    public static string Match(string pattern, string flags, string[] files)
    {
        var options = flags.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        bool lineNumbers = options.Contains("-n");
        bool fileNamesOnly = options.Contains("-l");
        bool ignoreCase = options.Contains("-i");
        bool invert = options.Contains("-v");
        bool exact = options.Contains("-x");

        bool multipleFiles = files.Length > 1;

        var results = new List<string>();

        var comparison = ignoreCase
            ? StringComparison.OrdinalIgnoreCase
            : StringComparison.Ordinal;

        foreach (var file in files)
        {
            var lines = File.ReadAllLines(file);

            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];

                bool match = exact ? string.Equals(line, pattern, comparison) : line.Contains(pattern, comparison);

                if (invert) match = !match;

                if (!match) continue;

                if (fileNamesOnly)
                {
                    results.Add(file);
                    break;
                }

                var output = new StringBuilder();

                if (multipleFiles)
                {
                    output.Append(file).Append(':');
                }

                if (lineNumbers)
                {
                    output.Append(i + 1).Append(':');
                }

                output.Append(line);

                results.Add(output.ToString());
            }
        }

        return string.Join("\n", results);
    }
}