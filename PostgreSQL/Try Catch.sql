Create Table Accounts (FirstName nvarchar not null, Age int not null) 
Begin Try
Insert Into
    Accounts
Values
    (NULL, NULL) Print 'Data has been added'
End Try Begin Catch Print 'Error ' + Convert(varchar, Error_Number()) + ':' + Error_Message()
End Catch

/*В блоке CATCH для обаботки ошибки мы можем использовать ряд функций:

ERROR_NUMBER(): возвращает номер ошибки

ERROR_MESSAGE(): возвращает сообщение об ошибке

ERROR_SEVERITY(): возвращает степень серьезности ошибки. Степень серьезности представляет числовое значение. И если оно равно 10 и меньше, то такая ошибка рассматривается как предупреждение и не обрабатывается конструкцией TRY...CATCH. Если же это значение равно 20 и выше, то такая ошибка приводит к закрытию подключения к базе данных, если она не обрабатывается конструкцией TRY...CATCH.

ERROR_STATE(): возвращает состояние ошибки*/