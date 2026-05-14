enum LogLevel
{
    Trace,
    Debug,
    Info,
    Warning,
    Error,
    Fatal,
    Unknown,
}

static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine) => Parse(logLine[(logLine.IndexOf('[') + 1)..logLine.IndexOf(']')]);

    public static string OutputForShortLog(LogLevel logLevel, string message)
    {
        return $"{Code(logLevel)}:{message}";
    }

    private static LogLevel Parse(string key)
    {
        return key switch
        {
            "TRC" => LogLevel.Trace,
            "DBG" => LogLevel.Debug,
            "INF" => LogLevel.Info,
            "WRN" => LogLevel.Warning,
            "ERR" => LogLevel.Error,
            "FTL" => LogLevel.Fatal,
            _ => LogLevel.Unknown
        };
    }

    private static int Code(LogLevel level)
    {
        return level switch
        {
            LogLevel.Trace => 1,
            LogLevel.Debug => 2,
            LogLevel.Info => 4,
            LogLevel.Warning => 5,
            LogLevel.Error => 6,
            LogLevel.Fatal => 42,
            LogLevel.Unknown => 0,
            _ => throw new NotImplementedException(),
        };
    }
}
