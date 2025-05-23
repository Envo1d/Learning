{
	// O(n)
	// линейный поиск
	const array = [1, 4, 5, 6, 8, 1, 4, 8, 5, 11]
	let count = 0
	function linearSearch(array, item) {
		for (let i = 0; i < array.length; i++) {
			count += 1
			if (array[i] === item) return i
		}
		return null
	}
	console.log(linearSearch(array, 6))
	console.log(`count = ${count}`)
}

{
	// O(log n)
	// бинарный поиск
	const arr = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]
	let count = 0

	function binarySearch(array, item) {
		let start = 0
		let end = array.length
		let middle
		let found = false
		let pos = -1
		while (found === false && start <= end) {
			count += 1
			middle = Math.floor((start + end) / 2)
			if (array[middle] === item) {
				found = true
				pos = middle
				return pos
			}
			if (item < array[middle]) {
				end = middle - 1
			} else {
				start = middle + 1
			}
		}
		return pos
	}
	console.log(binarySearch(arr, 8))
	console.log(`count = ${count}`)

	count = 0
	function recursiveBinarySearch(array, item, start, end) {
		count += 1
		let middle = Math.floor((start + end) / 2)
		if (item === array[middle]) return middle
		if (item < array[middle])
			return recursiveBinarySearch(array, item, 0, middle - 1)
		else return recursiveBinarySearch(array, item, middle + 1, end)
	}
	console.log(recursiveBinarySearch(arr, 8, 0, arr.length))
	console.log(`count = ${count}`)
}

{
	// O(n*n)
	// сортировка выборкой
	const arr = [
		0, 3, 2, 5, 6, 8, 1, 9, 4, 2, 1, 2, 9, 6, 4, 1, 7, -1, -5, 23, 6, 2, 353, 6,
		3, 32,
	]
	let count = 0

	function selectionSort(array) {
		for (let i = 0; i < array.length; i++) {
			let indexMin = i
			for (let j = i + 1; j < array.length; j++) {
				if (array[j] < array[indexMin]) {
					indexMin = j
				}
				count += 1
			}
			let tmp = array[i]
			array[i] = array[indexMin]
			array[indexMin] = tmp
		}
		return array
	}

	console.log(selectionSort(arr))
	console.log(`count = ${count}`)
}

{
	// O(n*n)
	// сортировка пузырьком
	const arr = [
		0, 3, 2, 5, 6, 8, 1, 9, 4, 2, 1, 2, 9, 6, 4, 1, 7, -1, -5, 23, 6, 2, 353, 6,
		3, 32,
	]
	let count = 0

	function bubbleSort(array) {
		for (let i = 0; i < array.length; i++) {
			for (let j = 0; j < array.length; j++) {
				if (array[j + 1] < array[j]) {
					let tmp = array[j]
					array[j] = array[j + 1]
					array[j + 1] = tmp
				}
				count += 1
			}
		}
		return array
	}

	console.log(bubbleSort(arr))
	console.log(`count = ${count}`)
}

{
	// O(log n*n)
	// быстрая сортировка
	const arr = [
		0, 3, 2, 5, 6, 8, 1, 9, 4, 2, 1, 2, 9, 6, 4, 1, 7, -1, -5, 23, 6, 2, 353, 6,
		3, 32,
	]
	let count = 0

	function quickSort(array) {
		if (array.length <= 1) return array
		let pivotIndex = Math.floor(array.length / 2)
		let pivot = array[pivotIndex]
		let less = []
		let greater = []
		for (let i = 0; i < array.length; i++) {
			count += 1
			if (i === pivotIndex) continue
			if (array[i] < pivot) less.push(array[i])
			else greater.push(array[i])
		}
		return [...quickSort(less), pivot, ...quickSort(greater)]
	}

	console.log(quickSort(arr))
	console.log(`count = ${count}`)
}

{
	// поиск в ширину (графы)
	const graph = {}
	graph.a = ['b', 'c']
	graph.b = ['f']
	graph.c = ['d', 'e']
	graph.d = ['f']
	graph.e = ['f']
	graph.f = ['g']

	function breadthSearch(graph, start, end) {
		let queue = []
		queue.push(start)
		while (queue.length > 0) {
			const current = queue.shift()
			if (!graph[current]) {
				graph[current] = []
			}
			if (graph[current].includes(end)) return true
			else queue = [...queue, ...graph[current]]
		}

		return false
	}

	console.log(breadthSearch(graph, 'a', 'g'))
}

{
	// алгоритм дейкстры
	const graph = {}
	graph.a = { b: 2, c: 1 }
	graph.b = { f: 7 }
	graph.c = { d: 5, e: 2 }
	graph.d = { f: 2 }
	graph.e = { f: 1 }
	graph.f = { g: 1 }
	graph.g = {}

	function shortPath(graph, start, end) {
		const costs = {}
		const processed = []
		let neighbors = {}
		Object.keys(graph).forEach(node => {
			if (node !== start) {
				let value = graph[start][node]
				costs[node] = value || 1000000000
			}
		})
		let node = findNodeLowestCost(costs, processed)
		while (node) {
			const cost = costs[node]
			neighbors = graph[node]
			Object.keys(neighbors).forEach(neighbor => {
				let newCost = cost + neighbors[neighbor]
				if (newCost < costs[neighbor]) costs[neighbor] = newCost
			})
			processed.push(node)
			node = findNodeLowestCost(costs, processed)
		}
		return costs
	}

	function findNodeLowestCost(costs, processed) {
		let lowestCost = 1000000000
		let lowestNode

		Object.keys(costs).forEach(node => {
			let cost = costs[node]
			if (cost < lowestCost && !processed.includes(node)) {
				lowestCost = cost
				lowestNode = node
			}
		})
		return lowestNode
	}

	console.log(shortPath(graph, 'a', 'g'))
}

{
	// обход бинарного дерева
	const tree = [
		{
			v: 5,
			c: [
				{
					v: 10,
					c: [
						{
							v: 11,
						},
					],
				},
				{
					v: 7,
					c: [
						{
							v: 5,
							c: [
								{
									v: 11,
								},
							],
						},
					],
				},
			],
		},
		{
			v: 5,
			c: [
				{
					v: 10,
				},
				{
					v: 15,
				},
			],
		},
	]

	const recursive = tree => {
		let sum = 0
		tree.forEach(node => {
			sum += node.v
			if (!node.c) return node.v
			sum += recursive(node.c)
		})
		return sum
	}

	const iteration = tree => {
		if (!tree.length) return 0
		let sum = 0
		let stack = []
		tree.forEach(node => stack.push(node))
		while (stack.length) {
			const node = stack.pop()
			sum += node.v
			if (node.c) node.c.forEach(child => stack.push(child))
		}
		return sum
	}

	console.log(recursive(tree))
	console.log(iteration(tree))
}

{
	// кеширование

	function cashFunction(fn) {
		const cash = {}
		return function (n) {
			if (cash[n]) {
				console.log('cash', cash[n])
				return cash[n]
			}
			let res = fn(n)
			console.log('func', res)
			cash[n] = res
			return res
		}
	}

	function factorial(n) {
		let res = 1
		while (n != 1) {
			res *= n
			n -= 1
		}
		return res
	}

	const cashFactorial = cashFunction(factorial)

	cashFactorial(5)
	cashFactorial(4)
	cashFactorial(3)
	cashFactorial(4)
	cashFactorial(5)
	cashFactorial(1)
}
