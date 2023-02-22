function sum(x, y) {
	if (y === undefined) y = 5
	if (x === undefined) x = 8
	console.log(x + y)
}

sum()
sum(6)
sum(6, 4)

function cSum(x = 8, y = 10 + x) {
	console.log(x + y)
}

cSum()
cSum(6)
cSum(6, 4)

function argSum() {
	let res = 0
	for (const n of arguments) res += n
	console.log(res)
}

argSum(6)
argSum(6, 4)
argSum(6, 4, 5)

function display(season, ...temps) {
	console.log(season)
	for (index in temps) {
		console.log(temps[index])
	}
}

display('Весна', -2, -3, 4, 2, 5)
display('Лето', 20, 23, 31)

// функция параметр

function sum(x, y) {
	return x + y
}
function subs(x, y) {
	return x - y
}
function operation(x, y, func) {
	const res = func(x, y)
	console.log(res)
}

console.log('Sum')
operation(10, 6, sum)

console.log('Subtract')
operation(10, 6, subs)

// возвращение функции
function menu(n) {
	if (n == 1)
		return function (x, y) {
			return x + y
		}
	else if (n == 2)
		return function (x, y) {
			return x - y
		}
	else if (n == 3)
		return function (x, y) {
			return x * y
		}
	return function () {
		return 0
	}
}
const action = menu(1)
const result = action(2, 5)
console.log(result)

// глобальная и локальная область видимости

// глобальная
var a = 5
let b = 21
const c = 312
// локальная
{
	var a = 5
	let b = 3123
	const c = 12
}
// let - уровень функции
// var - уровень блока кода
{
	var f = 5
}
console.log('f = ', f)
if (true) {
	var g = 6
}
console.log('g = ', g)
for (var i = 0; i < 5; i++) {
	var s = 12
}
console.log('s = ', s)
{
	let k = 21
	const l = 21
}
console.log('local k = ', k) // Uncaught ReferenceError: k is not defined
console.log('local l = ', l) // Uncaught ReferenceError: l is not defined
function bar() {
	foo = '12'
}
bar()
console.log(foo) // глобальная необъявленная переменная
// если функция не будет вызвана, переменная не будет определена

// строгий режим
function barS() {
	'use strict'
	test = '21'
}
barS()
console.log(test)

// рекурсия
function getFactorial(n) {
	if (n === 1) return 1
	else return n * getFactorial(n - 1)
}

// переопределение функции
function display() {
	console.log('Hello')
	display = function () {
		console.log('World')
	}
}
var displayMessage = display
display() // Hello
display() // World
var displayMessageAf = display
displayMessage() // Hello
displayMessageAf() // World

// Передача параметров
// По значению передается копия
// Объекты и массивы передаются по ссылке
function change(user) {
	user.name = 'Tom'
}

var bob = {
	name: 'Bob',
}

console.log('before change:', bob.name) // Bob
change(bob)
console.log('after change:', bob.name) // Tom

function changeFull(user) {
	user = {
		name: 'Tom',
	}
}
console.log('before change:', bob.name) // Bob
changeFull(bob)
console.log('after change:', bob.name) // Bob

// Стрелочные функции
let hello = () => console.log('hello')

let print = mes => console.log(mes)

let sum1 = (x, y) => x + y

let user = (userName, userAge) => ({ name: userName, age: userAge })

const square = n => {
	let res = n * n
	return res
}

// замыкания
// Замыкание технически включает три компонента
// внешняя функция, которая определяет некоторую область видимости и в которой определены некоторые переменные - лексическое окружение
// переменные (лексическое окружение), которые определены во внешней функции
// вложенная функция, которая использует эти переменные
function outer() {
	var n
	function inner() {}
}
function multiply(n) {
	var x = n
	return function (m) {
		return x * m
	}
}
var fn1 = multiply(5)
var res1 = fn(6)
var res2 = multiply(5)(6) // 30
console.log(res1)(
	// 30
	// fn1 - замыкание со своим окружением

	// Самовызывающиеся функции - Immediately Invoked Function Expression (IIFE)
	(function () {
		console.log('Привет мир')
	})()
)(
	(function (n) {
		var result = 1
		for (var i = 1; i <= n; i++) result *= i
		console.log('Factorial ' + n + ' = ' + result)
	})(4)
)

// Паттерн "Модуль" базируется на замыканиях и состоит из двух компонентов: внешняя функция, которая определяет лексическое окружение, и возвращаемый набор внутренних функций, которые имеют доступ к этому окружению.
let calculator = (function () {
	let data = { number: 0 }

	return {
		sum: function (n) {
			data.number += n
		},
		subtract: function (n) {
			data.number -= n
		},
		display: function () {
			console.log('Result: ', data.number)
		},
	}
})()
calculator.sum(10)
calculator.sum(3)
calculator.display() // Result: 13
calculator.subtract(4)
calculator.display() // Result: 9
// Hoisting представляет процесс доступа к переменным до их определения. Возможно, данная концепция выглядит немного странно, но она связана с работой компилятора JavaScript. Компиляция кода происходит в два прохода. При первом проходе компилятор получает все объявления переменных, все идентификаторы. При этом никакой код не выполняется, методы не вызываются. При втором проходе собственно происходит выполнение. И даже если переменная определена после непосредственного использования, ошибки не возникнет, так как при первом проходе компилятору уже известны все переменные.
