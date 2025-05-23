const name = 'Tom'
const name2 = new String('Tom')

// длина строки
const hello = 'hello world'
console.log(`In line ${hello} ${hello.length} letters`)

// повторение строки
console.log(hello.repeat(3))

{
	// поиск в строке
	const test = 'hello world. bye world'
	const key = 'world'
	const firstPos = test.indexOf(key)
	const lastPos = test.lastIndexOf(key)
	console.log(`First occurrence: ${firstPos}`) // 6
	console.log(`Last occurrence: ${lastPos}`) // 17

	console.log(test.includes('world')) // true
	console.log(test.includes('worlds')) // false
}

{
	// выбор подстроки
	const hello = 'hello world. bye world'
	const world = hello.substring(6, 11)
	console.log(world) // world
	const bye = hello.substring(13)
	console.log(bye)

	// slice - работает также но строг к индексам, в то время как substring меняет местами индексы если первый больше второго
	const world2 = hello.substring(11, 6)
	console.log(world2) // world
	let worldSlice = hello.slice(11, 6)
	console.log(worldSlice) // пустая строка
	worldSlice = hello.slice(6, 11)
	console.log(worldSlice) // world
	// также slice позволяет использовать отрицательные индексы
	// Отрицательный индекс указывает на индекс символа относительно конца строки
	const byeSlice = hello.slice(-9, -6)
	console.log(byeSlice) // bye
}

{
	// управление регистром
	const hello = 'Hello World'
	console.log(hello.toLowerCase()) // hello world
	console.log(hello.toUpperCase()) // HELLO WORLD

	// получение символа по индексу
	console.log(hello.charAt(2)) // l
	console.log(hello.charCodeAt(2)) // 108
}

{
	// удаление пробелов
	let hello = '   Hello    '
	const beforeLength = hello.length
	hello = hello.trim()
	const afterLength = hello.length
	console.log(beforeLength, afterLength, hello)

	// объединение строк
	let world = ' world'
	hello = hello.concat(world)
	console.log(hello)

	// замена подстроки
	hello = hello.replace('world', 'JS') // заменяет первое вхождение строки
	console.log(hello)
	let menu = 'Завтрак: каша, чай. Обед: суп, чай. Ужин: салат, чай.'
	menu = menu.replaceAll('чай', 'кофе') // заменяет все вхождения
	console.log(menu)
}

{
	// разделение строки на массив слов
	const message = 'The weather was good today'
	const messageParts = message.split(' ')
	console.log(messageParts)

	// проверка начала и конца строки
	console.log(message.startsWith('the')) // false
	console.log(message.startsWith('The')) // true
	console.log(message.endsWith('Day')) // false
	console.log(message.endsWith('day')) // true

	// заполнение строки
	let hello = 'hello'.padStart(8)
	hello = hello.padEnd(12, ' 0')
	console.log(hello)
}

{
	// шаблоны строк
	const name = 'Tom'
	const hello = `Hello ${name}`
	console.log(hello)

	function check(parts, name) {
		console.log(parts)
		return parts[0] + name + parts[1]
	}
	let checkedTemplate = check`Person: ${name}.`
	console.log(checkedTemplate)
}

{
	// регулярные выражения
	const initialText = 'hello world!'
	let exp = /hello/
	let res = exp.test(initialText) // true
	console.log(res)

	// exec - он также проверяет, соответствует ли строка и возвращает строку или null
	res = exp.exec(initialText)
	console.log(res)

	// группы символов
	let hello = 'привет'
	let hello2 = 'hello'
	exp = /[а-я]/
	console.log(exp.test(hello)) // true
	console.log(exp.test(hello2)) // false
	exp = /[^а-я]/
	console.log(exp.test(hello)) // false
	console.log(exp.test(hello2)) // true
}

{
	// флаги выражений
	const initText = 'привет Мир'
	let exp = /мир/
	let res = exp.test(initText) // false
	// флаг global - позволяет найти все подстроки, которые соответствуют регулярному выражению
	// флаг ignoreCase
	// флаг multiline - которые соответствуют регулярному выражению, в многострочном тексте
	exp = /мир/gi
	console.log(exp.test(initText)) // true
	// флаг dotAll - позволяет сопоставить точку в регулярном выражении с любым символом текста, в том числе с разделителем строки.
	// Для этого в регулярных выражениях применяется символ s
	const text = 'hello\nworld'
	exp = /hello world/
	res = exp.test(text) // false
	console.log(res)
	exp = /hello.world/s
	res = exp.test(text) //true
	console.log(res)
}

{
	// метод split - разделение строки
	const initText = 'Сегодня была прекрасная погода'
	const exp = /\s/
	const res = initText.split(exp)
	res.forEach(val => console.log(val))
}

{
	// метод match - поиск соответствий
	const initText = 'Он пришел домой и сделал домашнюю работу'
	const exp = /дом[а-я]*/gi
	const res = initText.match(exp)
	res.forEach(val => console.log(val))
}

{
	// метод search - поиск в строке, возвращает индекс первого включения
	const initText = 'hello world'
	const exp = /wor/
	const res = initText.search(exp)
	console.log(res) // 6
}

{
	// метод replace - заменяет все соответствия регулярному выражению определенной строкой
	let menu = 'Завтрак: каша, чай. Обед: суп, чай. Ужин: салат, чай.'
	const exp = /чай/gi
	menu = menu.replace(exp, 'кофе')
	console.log(menu)
}

// синтаксис регулярных выражений
{
	// \d - цифры от 0 до 9
	// \D - символы, которые не являются цифрой
	// \w - буквы, цифры, символы подчеркивания (A-Z, a-z, 0-9)
	// \W - противоположность верхнему
	// \s - пробел
	// \S - не пробел
	// \. - любой символ

	let phone = '+1-234-567-8901'
	let exp = /\d-\d\d\d-\d\d\d-\d\d\d\d/
	phone = phone.replace(exp, '00000000000')
	console.log(phone)
}
{
	// модификаторы

	// {n} - повторение символа (h{3} - 'hhh')
	// {n,} - соответствует n и более количеству повторений предыдущего символа (h{3,} - 'hhh', 'hhhh', 'hhhhh')
	// {n,m} - соответствует от n до m повторений предыдущего символа (h{2,4} - 'hh', 'hhh', 'hhhh')
	// ? - соответствует одному вхождению предыдущего символа в подстроку или его отсутствию в подстроке (/h?ome/ - 'home', 'ome')
	// + - соответствует одному и более повторений предыдущего символа
	// * - соответствует любому количеству повторений или отсутствию предыдущего символа
	// ^ - соответствует началу строки (^h - 'home', но не 'ohme')
	// $ - конец строки (e$ - 'home')

	let phone = '+1-234-567-8901'
	let exp = /\d-\d{3}-\d{3}-\d{4}/
	phone = phone.replace(exp, '80000000000')
	console.log(phone)

	// \b - соответствие в пределах слова
	let initialText = 'Языки обучения: Java, JavaScript, C++'
	exp = /\bJava\b/g
	let result = initialText.replace(exp, 'C#')
	console.log(result) // Языки обучения: C#, JavaScript, C++
}

// группы в регулярных выражениях
{
	// Для поиска в строке более сложных соответствий применяются группы.
	// В регулярных выражениях группы заключаются в скобки
	let initialText = '<img src= "picture.png" />'
	let exp = /[a-z]+\.(png|jpg)/i
	let result = initialText.match(exp)
	result.forEach(function (value, index, array) {
		console.log(value)
	})
}
