
BEGIN TRY  
	insert into tableStudent (tableId, studentId)
	select top 1 [table].id as tableId, student.Id as studentId from
	[table] cross join student
END TRY 
BEGIN CATCH 
	PRINT ERROR_MESSAGE()
END CATCH  

BEGIN TRY
    DECLARE @OutputTbl TABLE (ID uniqueidentifier)
	Insert into Student(name)
	OUTPUT INSERTED.ID INTO @OutputTbl(ID)
	values (CONVERT(varchar(255), NEWID()))

    insert into tableStudent (tableId, studentId)
	select top 1 (Select  top 1 [table].id from [table]) as tableId, ID as studentId from @OutputTbl
END TRY
BEGIN CATCH
	PRINT ERROR_MESSAGE()
END CATCH