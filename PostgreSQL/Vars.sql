Declare @name nvarchar(20), @age int;
Set @name = 'Tom';
Set @age = 18;

Print 'Hello World!'

Print 'Name: ' + @name;
Print 'Age: ' + Convert(char, @age);
Select @name, @age