// ES6 - добавление классов для определения объектов

{
	// определение класса
	class Person {}
	// определение анонимного класса и присвоение переменной
	// const Person = class {}
	// const User = class Person {}
}

{
	// поля / свойства / методы
	class Person {
		name
		age
		move(place) {
			console.log(`Go to ${place}`)
		}
	}
}

{
	// конструктор
	class Person {
		// определения полей класса избыточно если в конструкторе идет обращение к ним
		constructor(personName, personAge) {
			;(this.name = personName), (this.age = personAge)
		}
		print() {
			console.log(`Name: ${this.name} Age: ${this.age}`)
		}
	}
}

{
	// приватные поля
	class Person {
		#name
		#age = 1
		constructor(name, age) {
			this.#name = name
			this.setAge(age)
		}
		setAge(age) {
			if (age > 0 && age < 110) this.#age = age
		}
		print() {
			console.log(`Name: ${this.#name} Age: ${this.#age}`)
		}
	}

	const test = new Person('Tom', 21)
	// test.#age = 25    ! Ошибка - нельзя обратиться к приватному полю
	test.print()
	test.setAge(25)
	test.print()
	test.setAge(-25)
	test.print()
}

{
	// приватные методы
	class Person {
		#name = 'undefined'
		#age = 1
		constructor(name, age) {
			this.#name = this.#checkName(name)
			this.setAge(age)
		}
		#checkName(name) {
			if (name !== 'admin') return name
		}
		setAge(age) {
			if (age > 0 && age < 110) this.#age = age
		}
		print() {
			console.log(`Name: ${this.#name} Age: ${this.#age}`)
		}
	}

	const tom = new Person('Tom', 27)
	tom.print()
	const bob = new Person('admin', 42)
	bob.print()
	// let name = bob.#checkName('admin)  ! Ошибка - нельзя обратиться к приватному методу
}

{
	// статические поля и методы
	class Person {
		static retirementAge = 65
		constructor(name, age) {
			this.name = name
			this.age = age
		}
		static printAge() {
			console.log(this.age) // для статического метода this.age не существует
			console.log(this.retirementAge)
		}
		print() {
			console.log(`Name: ${this.name} Age: ${this.age}`)
			//  к статическому полю нельзя обратиться через this
			console.log(`Retirement age: ${Person.retirementAge}`)
		}
	}

	// обращение к статик полю идет через имя класса, а не через имя объекта
	console.log(Person.retirementAge)
	Person.retirementAge = 62
	console.log(Person.retirementAge)
	let user = new Person('Tom', 45)
	user.print()
	Person.printAge()
}

{
	// приватные статические поля и методы
	class Person {
		static #retirementAge = 65
		constructor(name, age) {
			this.name = name
			this.age = age
		}
		print() {
			console.log(`Name: ${this.name} Age: ${this.age}`)
		}
		// Обратиться к приватному статическому полю можно только через статический метод
		static calculateRestAges(person) {
			if (this.#retirementAge > person.age) {
				const restAges = this.#retirementAge - person.age
				console.log(`Remaining until retirement ${restAges}`)
			} else console.log('You are already retired')
		}
	}

	const tom = new Person('Tom', 37)
	Person.calculateRestAges(tom)
}

{
	// get & set
	class Test {
		#field
		#readOnly = 5
		#id = 2
		// только на чтение
		get readOnly() {
			return this.#readOnly
		}
		// только установка
		set id(value) {
			this.#id = value
		}
		set field(value) {
			this.#field = value
		}
		get field() {
			return this.#field
		}
		// свойство без обращения к полям
		get sum() {
			return this.#field + this.#readOnly
		}
	}
	// работа с методами доступа производится также, как с обычными свойствами
	const test = new Test()
	test.field = 5
	console.log(test.field)
	test.readOnly = 20
	console.log(test.readOnly) // 5
	console.log(test.id) // undefined - нельзя получить
	console.log(test.sum)
}

// Наследование
{
	// Для наследования одного класса от другого применяется ключевое слово extends
	// При наследовании стоит учитывать, что производный класс может обращаться к любой функциональности базового класса, кроме приватных полей и методов
	class Person {
		name
		age
		print() {
			console.log(`Name: ${this.name} Age: ${this.age}`)
		}
	}
	class Employee extends Person {
		company
		work() {
			console.log(`${this.name} works in ${this.company}`)
		}
	}
	const tom = new Person()
	tom.name = 'Tom'
	tom.age = 34
	const bob = new Employee()
	bob.name = 'Bob'
	bob.age = 34
	bob.company = 'Google'
	tom.print()
	bob.print()
	bob.work()
}

{
	// наследование с конструктором
	class Person {
		constructor(name, age) {
			this.name = name
			this.age = age
		}
		print() {
			console.log(`Name: ${this.name}  Age: ${this.age}`)
		}
	}
	class Employee extends Person {
		company
		// ключевое слово super
		constructor(name, age, company) {
			super(name, age)
			this.company = company
		}
		// переопределение метода
		print() {
			super.print()
			console.log(`Company: ${this.company}`)
		}
		work() {
			console.log(`${this.name} works in ${this.company}`)
		}
	}
	const tom = new Person('Tom', 34)
	tom.print()
	const sam = new Employee('Sam', 26, 'Google')
	sam.print()
}
