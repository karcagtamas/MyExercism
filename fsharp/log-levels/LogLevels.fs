module LogLevels

open System.Text.RegularExpressions

let private LogRegex = Regex("\[(?<loglevel>[A-Z]+)\]:\s+(?<message>.*)")

let private parse (group: string) (logLine: string) =
    let m = logLine.Trim() |> LogRegex.Match
    m.Groups.[group].Value

let message (logLine: string) : string = logLine |> parse "message"

let logLevel (logLine: string) : string = (logLine |> parse "loglevel").ToLower()

let reformat (logLine: string) : string =
    $"{message logLine} ({logLevel logLine})"
