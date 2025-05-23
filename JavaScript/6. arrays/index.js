// Массивы в JavaScript представлены объектом Array

{
	// создание массива
	const users = new Array()
	const people = []
}
{
	// создание с инициализацией
	const users = new Array('tom', 'sam', 'alice')
	const people = ['tom', 'sam', 'alice']
}
{
	// инициализация через Array.of
	const people = Array.of('tom', 'bob')
}
{
	// инициализация через Array.from
	const array = Array.from('hello')
	console.log(array)
	const numbers = [1, 2, 3, 4]
	const array2 = Array.from(numbers, n => n * n)
	console.log(array2)
	const array3 = Array.from({ length: 3 }, (element, index) => {
		console.log(element)
		return index
	})
	console.log(array3)
	const array4 = Array.from(
		{ length: 3, 0: 'Tom', 1: 'Sam', 2: 'Bob' },
		element => {
			console.log(element)
			return element
		}
	)
	console.log(array4)
}

// Spread operator
{
	const users = ['Tom', 'Sam', 'Bob']
	console.log(...users)
	const people1 = [...users]
	const people2 = new Array(...users)
	const people3 = Array.of(...users)
	console.log(people1) //  ["Tom", "Sam", "Bob"]
	console.log(people2) //  ["Tom", "Sam", "Bob"]
	console.log(people3) //  ["Tom", "Sam", "Bob"]
}

{
	// объединение массивов
	const men = ['Tom', 'Sam', 'Bob']
	const women = ['Kate', 'Alice', 'Mary']
	const people = [...men, 'Alex', ...women]
	console.log(people)
}
{
	// передача аргументов функции
	function sum(a, b, c) {
		console.log(a + b + c)
	}
	const nums = [1, 2, 3]
	sum(...nums)
}
// копирование массивов slice
{
	const users = ['Tom', 'Bob', 'Sam', 'Alice', 'Kate']
	console.log(users)
	const people = users.slice() // [...users]
	people[1] = 'Mike'
	console.log(people)
	const people2 = people.slice(1, 4)
	console.log(people2)
}
{
	// push \ pop \ shift \ unshift \ splice \ concat \ join \ sort \ reverse
	// push добавление в конец
	let people = ['Tom', 'Bob', 'Sam']
	people.push('Tim')
	console.log(people.length)
	// pop удаление последнего элемента
	const last = people.pop()
	console.log(last, people.length)
	people.push(last)
	// shift удаляет первый элемент
	const first = people.shift()
	console.log(first)
	// unshift добавляет в начало
	people.unshift(first)
	console.log(people)
	// splice удаление по индексу
	const deleted = people.splice(1) // people.splice(1,2)
	console.log(people, deleted)
	// concat объединение массивов
	people = people.concat(deleted)
	console.log(people)
	// join объединяет элементы массива в строку
	const peopleToString = people.join('; ')
	console.log(peopleToString)
	// sort сортировка по возрастанию
	people.sort()
	console.log(people)
	const numbers = [200, 15, 5, 35]
	numbers.sort()
	console.log(numbers) // [15, 200, 35, 5]
	numbers.sort((a, b) => a - b)
	console.log(numbers) // [5, 15, 35, 200]
	// reverse переворачивает массив
	people.reverse()
	console.log(people)
}

{
	// indexOf \ lastIndexOf возвращают первое и последнее включение элемента
	const people = ['Tom', 'Bob', 'Sam', 'Tom']
	console.log(people.indexOf('Tom'), people.lastIndexOf('Tom'))

	// includes проверка на вхождение элемента
	console.log(people.includes('Tom'), people.includes('Alice'))

	// every проверяет, все ли элементы соответствуют определенному условию
	const numbers = [1, -12, 8, -4, 25, 42]
	let passed = numbers.every(n => n > 0)
	console.log(passed)
	// some проверяет соответствует ли хотя бы один элемент условию
	passed = numbers.some(n => n > 0)
	console.log(passed)
	// filter возвращает массив которые соответствуют условию
	const filtered = numbers.filter(n => n > 0)
	console.log(filtered)
}

{
	// forEach перебор элементов и выполнение операций над ними
	const numbers = [1, 2, 3, 4, 5, 6]
	numbers.forEach(n => {
		console.log(`The square of the number ${n} is ${n * n}`)
	})
	// map похож на forEach но возвращает новый массив
	const squares = numbers.map(n => n * n)
	console.log(squares)
}

{
	// find возвращает первый элемент подходящий под условие
	const numbers = [1, 2, 3, 5, 8, 13, 21, 34]
	let found = numbers.find(n => n > 10)
	console.log(found) // 13
	// findIndex аналогичен только возвращает индекс элемента
}

{
	// flat упрощает массив с учётом указанной вложенности
	const people = ['Tom', 'Bob', ['Alice', 'Kate', ['Sam', 'Ann', ['Nick']]]]
	const flatten1 = people.flat()
	console.log(flatten1) // ['Tom', 'Bob', 'Alice', 'Kate', Array(3)]
	const flatten2 = people.flat(2)
	console.log(flatten2) // ['Tom', 'Bob', 'Alice', 'Kate', 'Sam', 'Ann', Array(1)]
	const flatten3 = people.flat(Infinity)
	console.log(flatten3) // ['Tom', 'Bob', 'Alice', 'Kate', 'Sam', 'Ann', 'Nick']
}

{
	// наследование массивов
	class Team extends Array {
		// также можно переопределять стандартные методы массивов
		constructor(name, ...members) {
			super(...members)
			this.name = name
		}
	}
	const barcelona = new Team('Barcelona', 'Tom', 'Sam', 'Bob')
	console.log(barcelona)
	for (const person of barcelona) {
		console.log(person)
	}
	barcelona.push('Tim') // добавим один элемент
	console.log(barcelona) // Team(4) ["Tom", "Sam", "Bob", "Tim"]
	barcelona.splice(1, 1) // удалим второй элемент
	console.log(barcelona) // Team(3) ["Tom", "Bob", "Tim"]
}
