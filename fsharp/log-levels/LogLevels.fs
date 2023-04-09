module LogLevels

let message (logLine: string) : string =
    logLine.Substring(logLine.IndexOf ':' + 1).Trim()

let logLevel (logLine: string) : string =
    logLine
        .Substring(logLine.IndexOf '[' + 1, (logLine.IndexOf ']' - logLine.IndexOf '[') - 1)
        .ToLower()

let reformat (logLine: string) : string =
    $"{message logLine} ({logLevel logLine})"
