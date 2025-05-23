// Объект Date
{
	// создание
	var currDate = new Date()
	console.log(currDate)
	var dateMilliseconds = new Date(1359270000000)
	console.log(dateMilliseconds)
	var date = new Date('3/27/2008')
	console.log(date)
	var dateWithTime = new Date(2012, 11, 25, 18, 30, 20, 10)
	console.log(dateWithTime)
}
{
	// Получение даты и времени
	// getDate(): возвращает день месяца
	// getDay(): возвращает день недели
	// getMonth(): возвращает номер месяца
	// getFullYear(): возвращает год
	// toDateString(): возвращает полную дату в виде строки
	// getHours(): возвращает час
	// getMinutes(): возвращает минуты
	// getSeconds(): возвращает секунды
	// getMilliseconds(): возвращает миллисекунды
	// toTimeString(): возвращает полное время в виде строки

	var days = [
		'Воскресенье',
		'Понедельник',
		'Вторник',
		'Среда',
		'Четверг',
		'Пятница',
		'Суббота',
	]
	var months = [
		'Январь',
		'Февраль',
		'Март',
		'Апрель',
		'Май',
		'Июнь',
		'Июль',
		'Август',
		'Сентябрь',
		'Октябрь',
		'Ноябрь',
		'Декабрь',
	]

	var myDate = new Date()
	var fullDate =
		'Сегодня: ' +
		myDate.getDate() +
		' ' +
		months[myDate.getMonth()] +
		' ' +
		myDate.getFullYear() +
		', ' +
		days[myDate.getDay()]
	console.log(fullDate)

	var welcome
	var myDate = new Date()
	var hour = myDate.getHours()
	var minute = myDate.getMinutes()
	var second = myDate.getSeconds()
	if (minute < 10) {
		minute = '0' + minute
	}
	if (second < 10) {
		second = '0' + second
	}
	if (hour < 12) {
		welcome = 'Доброе утро'
	} else if (hour < 17) {
		welcome = 'Добрый день'
	} else {
		welcome = 'Добрый вечер'
	}
	console.log(
		welcome + ', текущее время: ' + hour + ':' + minute + ':' + second
	)
}
{
	// Установка даты и времени
	// setDate(): установка дня в дате
	//setMonth(): установка месяца
	//setFullYear(): устанавливает год
	//setHours(): установка часа
	//setMinutes(): установка минут
	//setSeconds(): установка секунд
	//setMilliseconds(): установка миллисекунд

	var days = [
		'Воскресенье',
		'Понедельник',
		'Вторник',
		'Среда',
		'Четверг',
		'Пятница',
		'Суббота',
	]
	var months = [
		'Январь',
		'Февраль',
		'Март',
		'Апрель',
		'Май',
		'Июнь',
		'Июль',
		'Август',
		'Сентябрь',
		'Октябрь',
		'Ноябрь',
		'Декабрь',
	]

	var myDate = new Date()
	myDate.setDate(15)
	myDate.setMonth(6)
	myDate.setYear(2023)

	var fullDate =
		myDate.getDate() +
		' ' +
		months[myDate.getMonth()] +
		' ' +
		myDate.getFullYear() +
		', ' +
		days[myDate.getDay()]
	console.log(fullDate)
	myDate.setHours(54)
	var fullDate =
		myDate.getDate() +
		' ' +
		months[myDate.getMonth()] +
		' ' +
		myDate.getFullYear() +
		', ' +
		days[myDate.getDay()]
	console.log(fullDate)
}
