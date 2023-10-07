module DNA (nucleotideCounts, Nucleotide(..)) where

import Data.Map (Map, fromList)

data Nucleotide = A | C | G | T deriving (Eq, Ord, Show)

nucleotideCounts :: String -> Either String (Map Nucleotide Int)
nucleotideCounts xs = if valid then Right (fromList $ counts) else Left "error"
    where 
        counts = map (\x -> (x, findCounts x xs)) [A, C, G, T]
        valid = foldr (\(_, c) b -> c + b) 0 counts == length xs

findCounts :: Nucleotide -> String -> Int
findCounts n s = length $ filter (== c) s
    where 
        c = case n of
            A -> 'A'
            C -> 'C'
            G -> 'G'
            T -> 'T'
