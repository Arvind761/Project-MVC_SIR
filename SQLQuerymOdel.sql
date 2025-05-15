create database db2425_29425
use db2425_29425
create table tblEmployee
(
empid int primary key identity,
name varchar(50),
mobile bigint,
age int
)
select * from tblEmployee
create proc employee_insert
@name varchar(50),
@mobile bigint,
@age int
as
begin
insert into tblEmployee(name,mobile,age)values(@name,@mobile,@age)
end

create proc employee_get
as 
begin
select * from tblEmployee
end

create proc employee_delete
@empid int 
as 
begin
delete from tblEmployee where empid=@empid
end

create proc employee_edit
@empid int
as
begin
select * from tblEmployee where empid=@empid
end


create proc employee_update
@empid int,
@name varchar(50),
@mobile bigint,
@age int 
as 
begin 
update tblEmployee set name=@name,mobile=@mobile,age=@age where empid=@empid
end