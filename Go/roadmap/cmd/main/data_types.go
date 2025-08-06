package main

import "fmt"

func dataTypes() {
	var a int8 = 127
	var b int16 = 32000
	var c int32 = 2147483632
	var d int64 = 9223372036854775806
	var e int = 9223372036854775807

	fmt.Print(a)
	fmt.Printf(" %T\n", a)
	fmt.Print(b)
	fmt.Printf(" %T\n", b)
	fmt.Print(c)
	fmt.Printf(" %T\n", c)
	fmt.Print(d)
	fmt.Printf(" %T\n", d)
	fmt.Print(e)
	fmt.Printf(" %T\n", e)
	a += 1
	fmt.Print(a)
	fmt.Printf(" %T overflow\n", a)

	a -= 1
	fmt.Print(a)
	fmt.Printf(" %T underflow\n", a)

	var f float32 = 3.02
	var g float64 = 3.02

	fmt.Printf("%T %g\n", f, f+0.012)
	fmt.Printf("%T %g\n", g, g+0.012)

	fmt.Printf("%T %g\n", f, f-0.012)
	fmt.Printf("%T %g\n", g, g-0.012)

	fmt.Printf("%T %g\n", f, f*0.012)
	fmt.Printf("%T %g\n", g, g*0.012)

	fmt.Printf("%T %g\n", f, f/2.012)
	fmt.Printf("%T %g\n", g, g/2.012)

	var h float64 = 0.1
	var i float64 = 0.2
	var j float64 = h + i

	tolerance := 0.000001

	if j == 0.3 {
		fmt.Printf("%g == 0.3\n", j)
	} else {
		fmt.Printf("%g != 0.3\n", j)
	}

	if j > 0.3-tolerance && j < 0.3+tolerance {
		fmt.Printf("%g is approximately equal to 0.3\n", j)
	}

	var truly bool = true
	var falsy bool = false

	fmt.Printf("%t\n", truly && falsy)
	fmt.Printf("%t\n", truly || falsy)
	fmt.Printf("%t\n", truly != falsy)

	var testNum int = 3

	if testNum%2 == 0 {
		fmt.Printf("%v is even\n", testNum)
	} else {
		fmt.Printf("%v is odd\n", testNum)
	}

	var first string = "First"
	var second string = "Second"

	fmt.Printf("%s\n", first+" "+second)
	fmt.Printf("%s length: %v\n", first, len(first))
	fmt.Printf("%s length: %v\n", second, len(second))

	var zeroInt int
	var zeroBool bool
	var zeroString string
	fmt.Printf("int zero: %v, bool zero: %v, string zero: %v\n", zeroInt, zeroBool, zeroString)

	// type conversion
	init := 42
	initF := float64(init)
	initU := uint(initF)
	fmt.Println(init, initF, initU)
}
