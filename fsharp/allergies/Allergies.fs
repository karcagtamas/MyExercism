module Allergies

type Allergen =
    | Eggs
    | Peanuts
    | Shellfish
    | Strawberries
    | Tomatoes
    | Chocolate
    | Pollen
    | Cats

let codeMap =
    [ Cats, 128
      Pollen, 64
      Chocolate, 32
      Tomatoes, 16
      Strawberries, 8
      Shellfish, 4
      Peanuts, 2
      Eggs, 1 ]
    |> Map.ofList

let byCode (code: int) =
    let highest =
        codeMap |> Map.filter (fun _ c -> c <= code) |> Map.toList |> List.tryLast

    match highest with
    | None -> (None, 0)
    | Some(a, _) -> (Some a, code - codeMap[a])

let rec list codedAllergies =
    if (codedAllergies >= 256) then // Temp
        list (codedAllergies - 256)
    elif (codedAllergies = 0) then
        []
    else
        match byCode codedAllergies with
        | None, _ -> []
        | (Some a), n -> [ a ] |> List.append (list n)

let allergicTo codedAllergies allergen =
    (list codedAllergies) |> List.contains allergen
