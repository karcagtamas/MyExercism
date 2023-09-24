module SpaceAge (Planet (..), ageOn) where

data Planet
  = Mercury
  | Venus
  | Earth
  | Mars
  | Jupiter
  | Saturn
  | Uranus
  | Neptune

ageOn :: Planet -> Float -> Float
ageOn Mercury seconds = inEarthYears seconds / 0.2408467
ageOn Venus seconds = inEarthYears seconds / 0.61519726
ageOn Earth seconds = inEarthYears seconds
ageOn Mars seconds = inEarthYears seconds / 1.8808158
ageOn Jupiter seconds = inEarthYears seconds / 11.862615
ageOn Saturn seconds = inEarthYears seconds / 29.447498
ageOn Uranus seconds = inEarthYears seconds / 84.016846
ageOn Neptune seconds = inEarthYears seconds / 164.79132

inEarthYears :: Float -> Float
inEarthYears seconds = seconds / 31557600
