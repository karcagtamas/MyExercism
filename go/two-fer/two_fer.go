// Package twofer contains the solution of the ShareWith task.
package twofer

// ShareWith function returns with a sharing string what contains the given name.
// If the name is empty, the name will replace with 'you' word.
func ShareWith(name string) string {
	if name != "" {
		return "One for " + name + ", one for me."
	}
	return "One for you, one for me."
}
