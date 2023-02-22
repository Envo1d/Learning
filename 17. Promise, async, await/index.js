// Promise - объект-результат асинхронной операции, имеет состояние:
// pending - начало, промис создан, но выполнение ещё не завершено
// fulfilled - действие успешно завершено
// rejected - произошла ошибка

const x = 4
const y = 0

const myPromise = new Promise(function (resolve, reject) {
	if (y === 0) reject('y = 0')
	else {
		const z = x / y
		resolve(z)
	}
}).then(
	function (value) {
		// получение результата из промиса
		console.log(`promise res = ${value}`)
	},
	function (error) {
		console.log(`promise error: ${error}`)
	}
)
// .catch(function (error) {
// 	console.log(`promise error: ${error}`)
// })

// методы then & catch & finally генерируют новые промисы, поэтому можно сложить цепочку промисов
new Promise(resolve => resolve('Hello'))
	.then(value => value + ' World')
	.then(final => console.log(final))
	.catch(error => console.log(`error: ${error}`))
	.finally(() => console.log('end'))

// Promise.all() позволяет объединить несколько промисов и выполнять их параллельно, но как единое целое
const promise1 = new Promise((resolve, reject) => {
	setTimeout(resolve, 1000, 'Hello')
})
const promise2 = new Promise((resolve, reject) => {
	setTimeout(resolve, 500, 'World')
})
// Promise.all([promise1, promise2])
// 	.then(values => {
// 		const [promise1data, promise2data] = values
// 		console.log(promise1data, promise2data) // Hello World
// 	})
// 	.catch(error => console.log(error))
// Promise.allSettled() тоже что и предыдущее, но также возвращает статус промиса
// Функция Promise.race() также принимает несколько промисов, только возвращает первый завершенный промис
// Функция Promise.any() принимает несколько промисов и возвращает первый успешно завершившийся промис

// ES2017: async / await
// Оператор async определяет асинхронную функцию
// Оператор await приостанавливает выполнение асинхронной функции, пока объект Promise не возвратить результат

function sum(x, y) {
	return new Promise(function (resolve) {
		const result = x + y
		resolve(result)
	})
}
sum(5, 3).then(function (value) {
	console.log('Async op res:', value)
})

async function calculate() {
	const value = await sum(5, 3)
	console.log(`Async op res ${value}`)
}
calculate()

// В этом случае все асинхронные операции будут выполняться последовательно
async function calculate2() {
	const value1 = await sum(5, 3)
	console.log('Async op 1 res:', value1)
	const value2 = await sum(6, 4)
	console.log('Async op 2 res:', value2)
	const value3 = await sum(7, 5)
	console.log('Async op 3 res:', value3)
}
calculate2()
// обработка ошибок с помощью блока try catch finally
