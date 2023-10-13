module Isogram

let isIsogram (str: string) =
    let b = str.ToLower().ToCharArray()

    let characterList = b |> List.ofArray |> List.filter System.Char.IsLetter
    let characterSet = b |> Set.ofArray |> Set.filter System.Char.IsLetter

    characterList.Length = characterSet.Count
