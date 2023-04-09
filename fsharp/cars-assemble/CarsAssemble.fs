module CarsAssemble

let successRate (speed: int) : float =
    match speed with
    | 0 -> 0
    | _ when speed < 5 -> 1
    | _ when speed < 9 -> 0.9
    | 9 -> 0.8
    | _ -> 0.77

let productionRatePerHour (speed: int) : float =
    (float speed) * (float 221) * (successRate speed)

let workingItemsPerMinute (speed: int) : int =
    int (productionRatePerHour speed / (float 60))
