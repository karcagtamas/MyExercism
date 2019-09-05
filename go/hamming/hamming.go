// Package hamming contains the solution of the Hamming distance task
package hamming

import "errors"

// Distance function calculates the hamming distance between two string value
func Distance(a, b string) (int, error) {
	if len(a) != len(b) {
		err := errors.New("length of A and B is not equal")
		return 0, err
	}
	count := 0
	for index := 0; index < len(a); index++ {
		if a[index] != b[index] {
			count++
		}
	}
	return count, nil
}
