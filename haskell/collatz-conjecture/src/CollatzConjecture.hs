module CollatzConjecture (collatz) where

collatz :: Integer -> Maybe Integer
collatz n
  | n <= 0 = Nothing
  | n == 1 = Just 0
  | even n = case collatz (n `div` 2) of
      Nothing -> Nothing
      Just x -> Just (1 + x)
  | otherwise = case collatz (3 * n + 1) of
      Nothing -> Nothing
      Just x -> Just (1 + x)
