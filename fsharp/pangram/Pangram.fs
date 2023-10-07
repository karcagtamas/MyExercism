module Pangram

let allCharacters = "abcdefghijklmnopqrstuvwxyz"

let isPangram (input: string) : bool =
    input.ToLower() |> Seq.filter System.Char.IsLetter |> Set.ofSeq |> Seq.length = allCharacters.Length
