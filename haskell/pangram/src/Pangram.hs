module Pangram (isPangram) where

import Data.Char (toLower)

validCharacters :: String
validCharacters = "abcdefghijklmnopqrstuvwxyz"

isPangram :: String -> Bool
isPangram text = all (`elem` validCharacters) convertedText && allUsed convertedText validCharacters
  where
    convertedText = convert text

convert :: String -> String
convert text = filter (`elem` validCharacters) $ map toLower text

allUsed :: String -> String -> Bool
allUsed _ [] = True
allUsed [] _ = False
allUsed (x : xs) validText = allUsed xs (filter (/= x) validText)