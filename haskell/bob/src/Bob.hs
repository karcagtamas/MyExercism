module Bob (responseFor) where

import Data.Char (isLetter, isSpace, isUpper)

responseFor :: String -> String
responseFor xs
  | isQuestion s && isShouting s = "Calm down, I know what I'm doing!"
  | isQuestion s = "Sure."
  | isShouting s = "Whoa, chill out!"
  | s == "" = "Fine. Be that way!"
  | otherwise = "Whatever."
  where
    s = filter (not . isSpace) xs

isQuestion :: String -> Bool
isQuestion [] = False
isQuestion s = last s == '?'

isShouting :: String -> Bool
isShouting s = all (\c -> not (isLetter c) || isUpper c) s && any isLetter s