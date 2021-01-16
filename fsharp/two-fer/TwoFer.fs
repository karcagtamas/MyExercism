module TwoFer

let defaultVal: string = "you";

let twoFer (input: string option): string = $"One for {input |> Option.defaultValue defaultVal}, one for me."

