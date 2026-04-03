package main

import "fmt"

// base func
func add(a int, b int) int {
	return a + b
}

// shortened params
func add2(a, b int) int {
	return a + b
}

// two returned values
func swap(a, b string) (string, string) {
	return b, a
}

// named return
func split(sum int) (x, y int) {
	x = sum * 4 / 9
	y = sum - x
	return
}

func functionsLes() {
	fmt.Println(add(2, 4))

	a, b := swap("hello", "world")
	fmt.Println(a, b)

	fmt.Println(split(17))
}
