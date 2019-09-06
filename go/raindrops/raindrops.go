// Package raindrops contains the solution of the Raindrops task
package raindrops

import "strconv"

// Convert function for PlingPlangPlong task
// If the number is divisible with 3 return with Pling
// If the number is divisible with 5 return with Plang
// If the number is divisible with 7 return with Plong
func Convert(number int) string {
	s := ""
	if number%3 == 0 {
		s += "Pling"
	}

	if number%5 == 0 {
		s += "Plang"
	}

	if number%7 == 0 {
		s += "Plong"
	}

	if s == "" {
		s += strconv.Itoa(number)
	}

	return s
}
