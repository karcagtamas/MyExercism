module TwoFer

let name (input: string option): string = if input.IsNone then "you" else input.Value;

let twoFer (input: string option): string = $"One for {name input}, one for me."

