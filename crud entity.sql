 create database CRUD_ENTITY 
 use CRUD_ENTITY
 
 create table tblEmp(
 id int identity primary key,
 name varchar(50),
 mobile bigint,
 age int
 )
 
 create proc emp_insert
 @name varchar(50),
 @mobile bigint,
 @age int
 as 
 begin
 insert into tblEmp(name,mobile,age)values(@name,@mobile,@age)
 end
 
 create proc emp_delete
 @empid int
 as 
 begin
 delete from tblEmp where id=@empid
 end
 
 create proc emp_get
 as
 begin
 select * from tblEmp
 end
 
 create proc emp_edit
 @empid int
 as 
 begin
 select * from tblEmp where id=@empid
 end
 
 
create proc employee_updat
@empid int,
@name varchar(50),
@mobile bigint,
@age int 
as 
begin 
update tblEmployee set name=@name,mobile=@mobile,age=@age where id=@empid
end


 
 