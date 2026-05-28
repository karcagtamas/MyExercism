using System.Text.RegularExpressions;

public class LogParser
{
    public bool IsValidLine(string text) => Regex.IsMatch(text, @"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]");

    public string[] SplitLogLine(string text) => Regex.Split(text, @"<[\^*=\-]*>");

    public int CountQuotedPasswords(string lines) => Regex.Matches(lines, "\"[^\"]*password[^\"]*\"", RegexOptions.IgnoreCase).Count;

    public string RemoveEndOfLineText(string line) => Regex.Replace(line, @"end-of-line\d+", "");

    public string[] ListLinesWithPasswords(string[] lines) => 
        [.. lines.Select(line =>
            {
                var match = Regex.Match(line, @"\b(password\w+)\b", RegexOptions.IgnoreCase);

                return match.Success
                    ? $"{match.Value}: {line}"
                    : $"--------: {line}";
            })];
}
