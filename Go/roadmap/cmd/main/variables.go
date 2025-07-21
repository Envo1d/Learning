package main

import "fmt"

func declaring() {
	var age int
	fmt.Println("Age:", age)

	var name string
	fmt.Println("Name", name)

	var isEmployed bool
	fmt.Println("Is employed:", isEmployed)

	var age2 int = 30
	fmt.Println("Age:", age2)

	var name2 string = "Bob"
	fmt.Println("Name", name2)

	var isEmployed2 bool = true
	fmt.Println("Is employed:", isEmployed2)

	var PI float64
	PI = 3.14159
	fmt.Println("PI:", PI)

	var firstName, age3 = "Test", 20
	fmt.Println("First Name:", firstName)
	fmt.Println("Age: ", age3)

	message := "Hello, Go!"
	fmt.Println("Message", message)

	var count = 0
	if true {
		count := 1
		fmt.Println("if Count:", count)
	}
	fmt.Println("Count", count)
}
