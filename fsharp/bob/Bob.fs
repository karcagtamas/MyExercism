module Bob

let isYell (input: string) : bool =
    input.ToUpper() = input && input.ToLower() <> input.ToUpper()

let isQuestion (input: string) : bool =
    if input.Length > 0 then
        input[input.Length - 1] = '?'
    else
        false

let response (input: string) : string =
    let formatted = input.Trim()

    let question = isQuestion formatted
    let yell = isYell formatted

    if (formatted = "") then
        "Fine. Be that way!"
    elif (question && yell) then
        "Calm down, I know what I'm doing!"
    elif (yell) then
        "Whoa, chill out!"
    elif (question) then
        "Sure."
    else
        "Whatever."
