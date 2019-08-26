use RestauranteBD
go
create table CLIENTES(
clientes_id int identity(1,1) primary key not null,
username nvarchar(25) unique not null,
userpass nvarchar(25) not null,
nombre nvarchar(50) not null,
apellidos nvarchar(100) not null,
email nvarchar(255) unique not null,
direccion nvarchar(255) not null,
dni nvarchar(8) unique not null,
)
go

insert into CLIENTES
 values(
'ahmadsleimanr',
'admin',
'ahmad',
'sleiman romero',
'werty_51@hotmail.com',
'Mauricio Casatti 106 dpt 301, San Borja',
'75116591');
go

select * from CLIENTES
go