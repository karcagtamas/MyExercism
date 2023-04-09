module KindergartenGarden

type Plant =
    | Grass
    | Clover
    | Radishes
    | Violets
    | Unknown

let children =
    [ "Alice"
      "Bob"
      "Charlie"
      "David"
      "Eve"
      "Fred"
      "Ginny"
      "Harriet"
      "Ileana"
      "Joseph"
      "Kincaid"
      "Larry" ]

let parse (code: char) : Plant =
    match code with
    | 'V' -> Violets
    | 'R' -> Radishes
    | 'G' -> Grass
    | 'C' -> Clover
    | _ -> Unknown

let plants (diagram: string) (student: string) : Plant list =
    let index = children |> List.findIndex (fun c -> c = student)

    diagram.Split("\n")
    |> Seq.collect (Seq.skip (index * 2) >> Seq.take 2)
    |> Seq.map parse
    |> Seq.toList
