create database dbMinimartBCSP6E;
use dbMinimartBCSP6E;

create table tbCategory
(
	categoryID int not null,
	categoryName nvarchar(20),
	constraint pk_categoryID primary key(categoryID) 
)
select * from tbCategory

insert into tbCategory values(1,N'ເຂົ້າໜົມ');

Create table tbUnit
(
	unitID int not null,
	unitName nvarchar(20),
	constraint pk_unitID primary key(unitID),

)

Create table tbProduct
(
	productID varchar(14) not null,
	productName nvarchar(30),
	price int,
	qty float,
	unitID int,
	categoryID int,
	conditionCheck int,
	constraint pk_productID primary key(productID),
	constraint fk_unitID foreign key(unitID)references tbUnit,
	constraint fk_categoryID foreign key(categoryID) references tbCategory,
)

select * from tbCategory;

select * from tbProduct;

select * from tbUnit;
