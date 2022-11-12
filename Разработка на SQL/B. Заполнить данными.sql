insert into class (name) values ('Mathematics'),('Literature'),('Chemistry'),('Physics')

insert into student (name) values ('Johnson'), ('Smith'), ('Blake'), ('Walles')

insert into [table] (classId, capacity)
    select class.id  as classId, (Select count(*) from Student) as capacity
from class

insert into tableStudent (tableId, studentId)
select [table].id as tableId, student.Id as studentId from
[table] cross join student