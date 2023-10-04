module DNA (toRNA) where

toRNA :: String -> Either Char String
toRNA "" = Right ""
toRNA [x]
    | x == 'G' = Right "C"
    | x == 'C' = Right "G"
    | x == 'T' = Right "A"
    | x == 'A' = Right "U"
    | otherwise = Left x
toRNA (x:xs) = case toRNA [x] of
    (Right rx) -> case toRNA xs of
        (Right rxs) -> Right (rx ++ rxs)
        (Left cxs) -> Left cxs
    (Left cx) -> Left cx
    
