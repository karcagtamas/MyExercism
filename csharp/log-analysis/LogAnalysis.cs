public static class LogAnalysis
{
    extension(string target)
    {

        public string SubstringAfter(string after) => target[(target.IndexOf(after) + after.Length)..];

        public string SubstringBetween(string start, string end) => target[(target.IndexOf(start) + start.Length)..target.IndexOf(end)];

        public string Message() => target.SubstringAfter(": ");

        public string LogLevel() => target.SubstringBetween("[", "]");
    }
}