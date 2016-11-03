create database Cars
go

use Cars

create table Car
(
	Id int primary key identity,
	Brand varchar(max) not null,
	Doors int not null,
	TopSpeed int null
)



insert into Car (Brand, Doors, TopSpeed)

values

('Toyota', 4, 230),

('Citroën', 4, 200),

('Volkswagen', 2, 170),

('Ford', 4, 270),

('Volvo', 3,250)

go

select * from Car

use master
go

sp_rename 'Cars', 'CarDB'
go

ALTER DATABASE Cars
Modify Name = CarDB ;  
GO  

create table Owner
(
	Id int primary key identity,
	FirstName varchar(max) not null,
	LastName varchar(max) not null
)
go

create table OwnerCarRelations
(
	Owner_ID int not null,
	Car_ID int not null,
	constraint PK_OwnerCar_Relations primary key (Owner_ID, Car_ID),
	constraint FK_OwnerCar_Relations2Owner foreign key (Owner_ID) references Owner (ID),
	constraint FK_OwnerCar_Relations2Car foreign key (Car_ID) references Car (ID)
)
go

insert into Owner
values
('Anna','Amalia'),
('Horst', 'Kevin'),
('Foo', 'Bar')

insert into OwnerCarRelations
values
(1,1),
(1,2),
(1,3),
(2,5),
(3,7)
go

select * from OwnerCarRelations

select o.FirstName, o.LastName, c.brand
from Owner as O
join OwnerCarRelations as R on o.Id = r.Owner_ID
join Car as c on c.id = r.Car_ID
order by o.FirstName
go