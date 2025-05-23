const validateValue = require('./validateValue')

describe('validateValue', () => {
	test('Correct value', () => {
		expect(validateValue(50)).toBe(true)
	})
	test('Less than correct', () => {
		expect(validateValue(-1)).toBe(false)
	})
	test('Greater than correct', () => {
		expect(validateValue(101)).toBe(false)
	})
	test('Greatest correct', () => {
		expect(validateValue(100)).toBe(true)
	})
	test('Smallest correct', () => {
		expect(validateValue(0)).toBe(true)
	})
})
