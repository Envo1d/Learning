// Objects

// создание объекта
let user = {} // let user = new Object()
// определение свойств
user.name = 'Tom'
user.age = 26
// методы объекта
user.display = function () {
	console.log(user.name)
	console.log(user.age)
}
user.move = function (place) {
	console.log(this.name, 'goes to', place)
}
// удаление свойств
delete user.move
// константные объекты
const person = { name: 'Tom', age: 37 }
person.name = 'Bob'
console.log(person.name) // Bob - значение изменилось
// обозначение const запрещает присвоить переменной новый объект, но не запрещает изменять объект
// чтоб сделать объект константным нужно использовать Object.freeze()
Object.freeze(person)
person.name = 'Tom'
console.log(person) // Bob

// создание объекта из набора пар ключ-значение
const personData = [
	['name', 'Tom'],
	['age', 37],
]
const newPerson = Object.fromEntries(personData)
// вложенные объекты и массивы
var country = {
	name: 'Швейцария',
	languages: ['немецкий', 'французский', 'итальянский'],
	capital: {
		name: 'Берн',
		population: 126598,
	},
	cities: [
		{ name: 'Цюрих', population: 378884 },
		{ name: 'Женева', population: 188634 },
		{ name: 'Базель', population: 164937 },
	],
}
// копирование объектов
let tom = { name: 'Tom' }
let bob = tom

console.log(tom, ' ', bob) // Tom Tom
bob.name = 'Bob'
console.log(tom, ' ', bob) // Bob Bob
// обе константы указывают на один и тот же объект в памяти
bob = Object.assign({}, tom)
tom.name = 'Tom'
console.log(tom, ' ', bob) // Tom Bob
// копирование с помощью spread-оператора (вложенные объекты будут ссылками)
tom = { name: 'Tom', company: { title: 'Microsoft' }, age: 20 }
bob = { ...tom, name: 'Bob' }
bob.company.title = 'Google'
console.log(tom.company.title, ' ', bob.company.title)

// проверка наличия свойства в объекте
const hasCompanyProp = 'company' in tom
const hasNameProp = tom.name !== undefined
const hasAgeProp = tom.hasOwnProperty('age')
console.log(hasCompanyProp) // true
console.log(hasNameProp) // true
console.log(hasAgeProp) // true

// перебор свойств
for (const prop in tom) console.log(prop, ' : ', tom[prop])
for (const prop of Object.entries(tom)) console.log(prop)
console.log(Object.keys(tom))
console.log(Object.values(tom))

// конструкторы объектов
function User(pName, pAge) {
	this.name = pName
	this.age = pAge
	this.displayInfo = function () {
		console.log('Name: ', this.name, '; age: ', this.age)
	}
}
var tim = new User('Tim', 25)
tim.displayInfo()

// оператор instanceof позволяет проверить, с помощью какого конструктора создан объект
var isUser = tim instanceof User
console.log(isUser) // true

// расширение объектов / prototype
// Каждая функция имеет свойство prototype, представляющее прототип функции

User.prototype.hello = function () {
	console.log(`${this.name} said: Hello`)
}
User.prototype.maxAge = 110 // статическое поле для всех объектов User
tom.maxAge = 99 // свойство определенное в объекте имеет высший приоритет

// Инкапсуляция - сокрытие состояния объекта от прямого доступа извне
function Person(name, age) {
	this.name = name
	var _age = age
	this.displayInfo = function () {
		console.log(`Name: ${this.name}; Age ${_age}`)
	}
	this.getAge = function () {
		return _age
	}
	this.setAge = function (age) {
		if (typeof age === 'number' && age > 0 && age < 110) _age = age
		else console.log('Error')
	}
}

// функция тоже является объектом - объектом Function
var square = new Function('n', 'return n * n;')
console.log(square(5))

// Метод call() вызывает функцию с указанным значением this и аргументами
function add(x, y) {
	return x + y
}
var res = add.call(this, 3, 8)
console.log(res)
// При передаче объекта через первый параметр, мы можем ссылаться на него через ключевое слово this
function display() {
	console.log(`Your name is ${this.name}`)
}
display.call(tim)
// apply() работает также, но теперь принимает массива аргументов
console.log(add.apply(null, [3, 8]))

// Наследование
function Person2(name, age) {
	this.name = name
	this.age = age
	this.go = function () {
		console.log(`${this.name} goes`)
	}
	this.displayInfo = function () {
		console.log(`Name: ${this.name}; age: ${this.age}`)
	}
}
Person2.prototype.maxAge = 110

function Employee(name, age, company) {
	Person2.call(this, name, age) // вызов конструктора для этого объекта
	this.company = company
	this.displayInfo = function () {
		console.log(
			`Name: ${this.name}; age: ${this.age}; company: ${this.company}`
		)
	}
}
Employee.prototype = Object.create(Person2.prototype) // наследование прототипа
// Метод Object.create() позволяет создать объект прототипа Persone2, который затем присваивается прототипу Employee.
var sam = new Person2('Sam', 25)
var bill = new Employee('Bill', 32, 'Google')
sam.go()
bill.go()
sam.displayInfo()
bill.displayInfo()
console.log(bill.maxAge)
// Метод f.bind(o) позволяет создать новую функцию с тем же телом и областью видимости, что и функция f, но с привязкой к объекту o

// Деструктуризация (destructuring) позволяет извлечь из объекта отдельные значения в переменные или константы
const test_user = {
	name: 'Tom',
	age: 24,
	phone: '+324352312',
	email: 'tom@mail.com',
	account: {
		login: 'tom21',
		password: 'qwerty',
	},
}
{
	let { name, age } = test_user
	console.log(name, age)
}
{
	const { name: userName, email: userEmail } = test_user
	console.log(userName, userEmail)
}
{
	const { account } = test_user
	console.log(account.login, account.password)
}
{
	const {
		name: usName,
		account: { login },
	} = test_user
	console.log(usName, login)
}
{
	const { name, age, ...contacts } = test_user
	console.log(name, age, contacts)
}
let users = ['Tom', 'Sam', 'Bob', 'Ann', 'Alice', 'Kate']
{
	let [a, b] = users
	console.log(a, b)
}
{
	let [tom, ...others] = users
	console.log(tom, others)
}
{
	// skip
	let [, second, , forth] = users
	console.log(second, forth)
}
// обмен значениями
{
	let first = 'Tom'
	let second = 'Sam'
	;[first, second] = [second, first]
	console.log(first, second)
}
// Оператор ?. или optional chaning-оператор позволяет проверить объект и его свойства и методы на null и undefined, и если объект или его свойства/методы определены, то обратиться к его свойствам или методам
