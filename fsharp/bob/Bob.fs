module Bob

let isYell (input: string) : bool =
    input.ToUpper() = input && input |> Seq.exists System.Char.IsLetter

let isQuestion (input: string) : bool = input.EndsWith "?"

let response (input: string) : string =
    let question = isQuestion (input.Trim())
    let yell = isYell (input.Trim())

    if (System.String.IsNullOrWhiteSpace input) then
        "Fine. Be that way!"
    elif (question && yell) then
        "Calm down, I know what I'm doing!"
    elif (yell) then
        "Whoa, chill out!"
    elif (question) then
        "Sure."
    else
        "Whatever."
