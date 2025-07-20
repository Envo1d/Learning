package main

import (
	"fmt"
	"math"
)

const IMTPower = 2

func outputResult(IMT float64) {
	result := fmt.Sprintf("Your IMT: %.0f", IMT)

	fmt.Print(result)
}

func calculateIMT(userHeight, userWeight float64) (IMT float64) {
	IMT = userWeight / math.Pow(userHeight/100, IMTPower)

	return
}

func getInput() (float64, float64) {
	var userHeight float64
	var userWeight float64

	fmt.Print("Enter your height (sm): ")
	fmt.Scan(&userHeight)

	fmt.Print("Enter your weight (kg): ")
	fmt.Scan(&userWeight)

	return userHeight, userWeight
}

func main() {
	fmt.Println("IMT Calculator")

	// userHeight, userWeight := getInput()

	IMT := calculateIMT(getInput())

	outputResult(IMT)
}
