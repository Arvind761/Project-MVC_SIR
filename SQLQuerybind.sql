use db2425_29425
select * from tblemployee


create table tblcountry
(
countryid int primary key identity,
countryname varchar(50)
)
insert into tblcountry(countryname)values('india')
insert into tblcountry(countryname)values('pakistan')
insert into tblcountry(countryname)values('usa')



create table tblState
(
stateid int primary key identity,
countryid int,
statename varchar(50)
)

insert into tblState(countryid,statename)values(1,'up')
insert into tblState(countryid,statename)values(1,'bihar')
insert into tblState(countryid,statename)values(2,'Khayber')
insert into tblState(countryid,statename)values(2,'Sindh')
insert into tblState(countryid,statename)values(3,'Los vegas')
insert into tblState(countryid,statename)values(3,'California')
insert into tblState(countryid,statename)values(1,'Delhi')
insert into tblState(countryid,statename)values(1,'Maharashtra')
insert into tblState(countryid,statename)values(3,'Texas')


create table tblCity
(
cityid int primary key identity,
stateid int,
cityname varchar(50)
)

insert into tblCity(stateid,cityname)values(1,'Ballia')
insert into tblCity(stateid,cityname)values(1,'Varanasi')
insert into tblCity(stateid,cityname)values(1,'Lucknow')
insert into tblCity(stateid,cityname)values(2,'Patna')
insert into tblCity(stateid,cityname)values(2,'Motihari')
insert into tblCity(stateid,cityname)values(2,'Chhapra')
insert into tblCity(stateid,cityname)values(3,'Abbottabad')
insert into tblCity(stateid,cityname)values(3,'Peshawar')
insert into tblCity(stateid,cityname)values(3,'Swat')
insert into tblCity(stateid,cityname)values(4,'Karachi')
insert into tblCity(stateid,cityname)values(4,'Hydrabad')
insert into tblCity(stateid,cityname)values(4,'Sukkur')
insert into tblCity(stateid,cityname)values(5,'Navada')
insert into tblCity(stateid,cityname)values(5,'Menhattan')
insert into tblCity(stateid,cityname)values(6,'Los Angeles')
insert into tblCity(stateid,cityname)values(6,'San Francisco')
insert into tblCity(stateid,cityname)values(6,'San Diego')
insert into tblCity(stateid,cityname)values(7,'Pandav nagar')
insert into tblCity(stateid,cityname)values(7,'karol bagh')
insert into tblCity(stateid,cityname)values(7,'Shaheen Bagh')
insert into tblCity(stateid,cityname)values(8,'Mumbai')
insert into tblCity(stateid,cityname)values(8,'Nagpur')
insert into tblCity(stateid,cityname)values(8,'Pune')
insert into tblCity(stateid,cityname)values(9,'Houston')
insert into tblCity(stateid,cityname)values(9,'Los Antonio')
insert into tblCity(stateid,cityname)values(9,'Dallas')


alter table tblemployee add country int,state int,city int

alter proc employee_get  
as  
begin  
select * from tblEmployee 
join tblcountry on country=countryid
join tblstate on state=stateid
join tblcity on city=cityid  
end  

alter proc employee_update  
@empid int,  
@name varchar(50),  
@mobile bigint,  
@age int ,
@country int,
@state int,
@city int  
as  
begin  
update tblEmployee set name=@name,mobile=@mobile,age=@age,
country=@country,state=@state,city=@city 
where empid=@empid  
end  

alter proc employee_insert  
@name varchar(50),   
@mobile bigint,  
@age int,
@country int,
@state int,
@city int 
as  
begin  
insert into tblEmployee(name,mobile,age,country,state,city)
values(@name,@mobile,@age,@country,@state,@city)  
end