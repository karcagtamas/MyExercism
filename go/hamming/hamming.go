package hamming

func Distance(a, b string) (int, error) {
	count := 0
	for index := 0; index < len(a); index++ {
		if a(index) != b(index){
			count++
		}
	}
	return count
}
