const arr = [1, 2, 3, 4, 5, 6]
// O(1) - получить элемент
// O(n) - добавить/удалить элемент
// O(n) - поиск

{
	// связный список
	// O(1) - вставка\удаление в начало/конец
	// O(n) - вставка в произвольное место
	// O(n) - поиск

	class LinkedList {
		constructor() {
			this.size = 0
			this.root = null
		}
		add(value) {
			if (this.size === 0) {
				this.root = new Node(value)
				this.size += 1
				return true
			}
			let node = this.root
			while (node.next) {
				node = node.next
			}
			let newNode = new Node(value)
			node.next = newNode
			this.size += 1
		}
		getSize() {
			return this.size
		}
		print() {
			let res = []
			let node = this.root
			while (node) {
				res.push(node.value)
				node = node.next
			}
			console.log(res)
		}
	}

	class Node {
		constructor(value) {
			this.value = value
			this.next = null
		}
	}

	const list = new LinkedList()
	list.add(5)
	list.add(6)
	list.add(2)
	list.add(7)
	list.add(1)
	list.add(3)
	list.add(4)
	list.add(8)
	list.print()
	console.log(list.getSize())
}

{
	// бинарное дерево поиска
	// O(log n) - вставка удаление
	// O(log n) - поиск

	class BinaryTree {
		constructor() {
			this.root = null
		}
		add(value) {
			if (!this.root) {
				this.root = new TreeNode(value)
			} else {
				let node = this.root
				let newNode = new TreeNode(value)
				while (node) {
					if (value > node.value) {
						if (!node.right) {
							break
						}
						node = node.right
					} else {
						if (!node.left) {
							break
						}
						node = node.left
					}
				}
				if (value > node.value) {
					node.right = newNode
				} else {
					node.left = newNode
				}
			}
		}
		print(root = this.root) {
			if (!root) return true
			console.log(root.value)
			this.print(root.left)
			this.print(root.right)
		}
	}

	class TreeNode {
		constructor(value) {
			this.value = value
			this.left = null
			this.right = null
		}
	}

	const tree = new BinaryTree()
	tree.add(5)
	tree.add(3)
	tree.add(8)
	tree.add(1)
	tree.add(4)
	tree.print()
}

{
	// set & map
	// map = key-value
	// O(1) - добавление/удаление
	const map = new Map()
	map.set('name', 'test')
	console.log(map.get('name'))
	// set - хранит уникальные значения
	const set = new Set()
	set.add(5)
	set.add(5)
	set.add(4)
	set.add(3)
	console.log(set)
}
