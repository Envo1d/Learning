package main

import (
	"fmt"
	"math"
	"strings"
)

type Vertex struct {
	X int
	Y int
}

type Vertex2 struct {
	Lat, Long float64
}

func printSlice(s []int) {
	fmt.Printf("len=%d cap=%d %v\n", len(s), cap(s), s)
}

func printSlice2(s string, x []int) {
	fmt.Printf("%s len=%d cap=%d %v\n",
		s, len(x), cap(x), x)
}

func sliceWithMake() {
	a := make([]int, 5)
	printSlice2("a", a)

	b := make([]int, 0, 5)
	printSlice2("b", b)

	c := b[:2]
	printSlice2("c", c)

	d := c[2:5]
	printSlice2("d", d)
}

func sliceTypes() {
	// Slices can contain any type, including other slices.

	// Create a tic-tac-toe board.
	board := [][]string{
		[]string{"_", "_", "_"},
		[]string{"_", "_", "_"},
		[]string{"_", "_", "_"},
	}

	// The players take turns.
	board[0][0] = "X"
	board[2][2] = "O"
	board[1][2] = "X"
	board[1][0] = "O"
	board[0][2] = "X"

	for i := 0; i < len(board); i++ {
		fmt.Printf("%s\n", strings.Join(board[i], " "))
	}
}

func sliceAppend() {
	var s []int
	printSlice(s)

	s = append(s, 0)
	printSlice(s)

	s = append(s, 1)
	printSlice(s)

	s = append(s, 2, 3, 4)
	printSlice(s)
}

func sliceRange() {
	var pow = []int{1, 2, 4, 8, 16, 32, 64, 128}

	for i, v := range pow {
		fmt.Printf("pow[%d] = %d\n", i, v)
	}

	for i := range pow {
		pow[i] = 1 << uint(i)
	}

	for _, value := range pow {
		fmt.Printf("%d\n", value)
	}
}

func initMap() {
	var m map[string]Vertex2
	m = make(map[string]Vertex2)
	m["Bell Labs"] = Vertex2{
		40.68433, -74.39967,
	}
	m["Google"] = Vertex2{
		37.4223, -122.0856,
	}
	fmt.Println(m["Bell Labs"])

	fmt.Println(m)
}

func mutatingMaps() {
	m := make(map[string]int)

	m["Answer"] = 42
	fmt.Println("The value:", m["Answer"])

	m["Answer"] = 48
	fmt.Println("The value:", m["Answer"])

	delete(m, "Answer")
	fmt.Println("The value:", m["Answer"])

	v, ok := m["Answer"]
	fmt.Println("The value:", v, "Present?", ok)
}

func compute(fn func(float64, float64) float64) float64 {
	return fn(3, 4)
}

func adder() func(int) int {
	sum := 0
	return func(x int) int {
		sum += x
		return sum
	}
}

func moreTypes() {
	i, j := 42, 2701

	p := &i
	fmt.Println(*p) // read i through the pointer p

	*p = 21        // set i through the pointer p
	fmt.Println(i) // see the new value of i

	p = &j         // point to j
	*p = *p / 37   // divide j through the pointer p
	fmt.Println(j) // see the new value of j

	v := Vertex{1, 2}
	v.X = 4
	fmt.Println(v.X)

	pV := &v
	pV.X = 1e9
	fmt.Println(v)

	var (
		v1  = Vertex{1, 2}  // has type Vertex
		v2  = Vertex{X: 1}  // Y:0 is implicit
		v3  = Vertex{}      // X:0 and Y:0
		pV2 = &Vertex{1, 2} // has type *Vertex
	)

	fmt.Println(v1, pV2, v2, v3)

	var a [2]string
	a[0] = "Hello"
	a[1] = "World"
	fmt.Println(a[0], a[1])
	fmt.Println(a)

	primes := [6]int{2, 3, 5, 7, 11, 13}
	fmt.Println(primes)

	var s []int = primes[1:4]
	fmt.Println(s)

	names := [4]string{
		"John",
		"Paul",
		"George",
		"Ringo",
	}
	fmt.Println(names)

	aN := names[0:2]
	bN := names[1:3]
	fmt.Println(aN, bN)

	bN[0] = "XXX"
	fmt.Println(aN, bN)
	fmt.Println(names)

	q := []int{2, 3, 5, 7, 11, 13}
	fmt.Println(q)

	r := []bool{true, false, true, true, false, true}
	fmt.Println(r)

	sS := []struct {
		i int
		b bool
	}{
		{2, true},
		{3, false},
		{5, true},
		{7, true},
		{11, false},
		{13, true},
	}
	fmt.Println(sS)

	sZ := []int{2, 3, 5, 7, 11, 13}

	sZ = sZ[1:4]
	fmt.Println(sZ)

	sZ = sZ[:2]
	fmt.Println(sZ)

	sZ = sZ[1:]
	fmt.Println(sZ)

	sZ = []int{2, 3, 5, 7, 11, 13}
	printSlice(sZ)

	// Slice the slice to give it zero length.
	sZ = sZ[:0]
	printSlice(s)

	// Extend its length.
	sZ = sZ[:4]
	printSlice(sZ)

	// Drop its first two values.
	sZ = sZ[2:]
	printSlice(sZ)

	var n []int
	fmt.Println(n, len(n), cap(n))
	if n == nil {
		fmt.Println("nil!")
	}

	sliceWithMake()

	sliceTypes()

	sliceAppend()

	sliceRange()

	initMap()

	mutatingMaps()

	hypot := func(x, y float64) float64 {
		return math.Sqrt(x*x + y*y)
	}
	fmt.Println(hypot(5, 12))

	fmt.Println(compute(hypot))
	fmt.Println(compute(math.Pow))

	pos, neg := adder(), adder()
	for i := 0; i < 10; i++ {
		fmt.Println(
			pos(i),
			neg(-2*i),
		)
	}
}
