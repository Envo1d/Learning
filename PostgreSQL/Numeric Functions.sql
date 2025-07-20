select Round(1342.345, 2) as PositiveRound
select Round(1342.345, -2) as NegativeRound

select IsNumeric(123123) as [IsNumeric]
select IsNumeric('123123') as [IsNumeric]
select IsNumeric('SQL') as [IsNumeric]
select IsNumeric('26-03-2022') as [IsNumeric]

select Abs(-223) as [ABS]

/*возвращает наименьшее целое число, которое 
больше или равно текущему значению*/
select Ceiling(-123.45) as [Ceiling]
select Ceiling(123.45) as [Ceiling]

/*возвращает наибольшее целое число, которое 
меньше или равно текущему значению.*/
select Floor(-123.45) as [Floor]
select Floor(123.45) as [Floor]

select Square(5) as POW

select Sqrt(225) as [Sqrt]

select Rand() as [Rand]

select Cos(1.0472) as [Cos]

select Sin(1.5708) as [Sin]

select Tan(0.7854) as [Tan]

select ProductName, Round(Price* ProductCount, 2) from Products