create database db_almacen
use db_almacen

create table T_Productos(
codigo int identity primary key,
n_producto varchar(50) not null,
stock int not null,
activo bit 
)

insert into T_Productos values ('Coca Cola', 20, 1)
insert into T_Productos values ('Doritos', 12, 2)

create procedure SP_GetAll
AS
BEGIN
Select * From T_Productos
END

create procedure SP_Save
@codigo int,
@nombre varchar(50),
@stock int
AS
BEGIN
IF @codigo = 0
	BEGIN
	INSERT INTO T_Productos VALUES(@nombre, @stock, 1)
	END
ELSE
	BEGIN
	UPDATE T_Productos SET n_producto = @nombre, stock = stock
	WHERE codigo = @codigo
	END
END