create table class
(
    id   uniqueidentifier default newid() not null
        constraint PK_Class
            primary key,
    name varchar(50)                      not null
)
go

create table student
(
    id   uniqueidentifier default newid() not null
        constraint PK_Student
            primary key,
    name varchar(50)                      not null
)
go

create table [table]
(
    id       uniqueidentifier default newid() not null
        constraint PK_Table
            primary key,
    classId  uniqueidentifier
        constraint table_class_id_fk
            references class,
    capacity int                              not null
)
go

create table tableStudent
(
    tableId   uniqueidentifier not null
        constraint tableStudent_table_id_fk
            references [table],
    studentId uniqueidentifier not null
        constraint tableStudent_student_id_fk
            references student,
    constraint PK_TableStudent
        primary key (tableId, studentId)
)
go

CREATE TRIGGER trigger_tableStudent
ON tableStudent
INSTEAD OF INSERT
AS
BEGIN
   declare @msg varchar(max)
   if exists(
       select studentId,T.classId from inserted
        LEFT JOIN [table] t on t.ID = inserted.tableId
    intersect
        select studentId, T.classId from tableStudent
        LEFT JOIN [table] t on t.ID = tableStudent.tableId
       )
    begin
        SELECT @msg=STRING_AGG(concat('Студент ', student.Name, ' не может записаться еще раз на курс по классу "',class.name,'"'), ', ')
        from inserted
        LEFT JOIN [table] t on t.ID = inserted.tableId
             left outer join student on student.id = inserted.studentId
             left outer join class on [t].classId = class.id
        GROUP BY classId;

       throw 51000, @msg,1;
    end;

    if exists( select 1
         from [table] t
        where t.id in (Select tableId from Inserted) and   (Select count(*) from (Select studentId from tableStudent ts where ts.tableId = t.id
        union select studentId from Inserted where Inserted.tableId = t.Id) tt) > capacity)

    BEGIN
        SELECT @msg=STRING_AGG(concat('Этот курс ("', className, '") уже содержит ',tt.Taken,' студентов из ', tt.capacity, ' возможных. Найдите другой курс.'), ', ')
        from (
            select class.name as className,t.id,
                t.capacity,
                (select count(*) from tableStudent where tableStudent.tableId = t.id) as Taken
            from [inserted]
                    left outer join [table] t on t.id = inserted.tableId
                    left outer join class on t.classId = class.id
            ) tt
            GROUP BY tt.id;
            throw 51000, @msg,1;
    end;

  INSERT INTO tableStudent
  SELECT inserted.* FROM inserted
END;
go