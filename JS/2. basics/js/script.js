var username
username = 'Tom'
console.log(username)

const userName = 'Bob'

console.log(
	'Data Types:\n' +
		'String\n' +
		'Number\n' +
		'BigInt\n' +
		'Boolean\n' +
		'Undefined\n' +
		'Null\n' +
		'Symbol\n' +
		'Object'
)

// Number - целые и дробные от -2^53 до 2^53

let x = 45
let y = 23.987

// BigInt

let num = 9007199254740991
console.log(num)
console.log(num + 1)
console.log(num + 2) // превышение диапазона

let num2 = 9007199254740991n
console.log(num2)
console.log(num2 + 1n)
console.log(num2 + 2n)
console.log(num2 + 3n)

// String интерполяция

let user = 'Tom'
let text = `Name: ${user}`
console.log(text)

// null/undefined
// undefined - значение не определено/установлено

let isAlive
console.log(isAlive)

// null - значение отсутствует
isAlive = null
console.log(isAlive)

// Object

let userObj = {
	name: 'Tom',
	age: 24,
}
console.log(userObj)

// typeof
// null вернет object

console.log(typeof num2)

let a = 10
let res = a + 50
console.log(res)

a = 100
res = a - 50
console.log(res)

a = 4
let b = 5
res = a * b
console.log(res)

a = 5
b = 2
res = a / b
console.log(res)

res = a % b
console.log(res)

// возведение в степень
res = 2 ** 3
console.log(res)

let res1 = 'hello' ?? 'world'
console.log(res1)

res1 = null ?? 'not null'
console.log(res1)

res1 = undefined ?? 'defined'
console.log(res1)

let test = 'abc'
console.log(isNaN(test))

for (let i = 0; i < 5; i++) {
	console.log(i)
}

const person = { name: 'Tom', age: 37 }
for (prop in person) {
	console.log(prop)
}

const word = 'WORD'
for (ch of word) {
	console.log(ch)
}
