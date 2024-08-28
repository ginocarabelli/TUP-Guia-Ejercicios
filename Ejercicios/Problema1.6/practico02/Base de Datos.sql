CREATE DATABASE Banco
GO
USE Banco
GO
SET DATEFORMAT DMY
GO
CREATE TABLE Tipos_Cuentas(
id_tipo_cuenta int identity primary key,
nombre varchar(50)
)
CREATE TABLE Cuentas(
id_cuenta int primary key,
cbu varchar(50),
saldo decimal(10,2),
id_tipo_cuenta int,
ultimo_movimiento datetime
CONSTRAINT fk_id_tipo_cuenta FOREIGN KEY (id_tipo_cuenta) REFERENCES Tipos_Cuentas(id_tipo_cuenta)
)
CREATE TABLE Clientes(
id_cliente int identity primary key,
nombre varchar(20),
apellido varchar(50),
dni int,
id_cuenta int,
CONSTRAINT fk_id_cuenta FOREIGN KEY (id_cuenta) REFERENCES Cuentas(id_cuenta)
)
GO
CREATE PROCEDURE SP_GetAllAccounts
AS
BEGIN
SELECT * FROM Cuentas
END
GO
CREATE PROCEDURE SP_GetAccountById
	@codigo int
AS
BEGIN
	SELECT *
	FROM Cuentas
	WHERE id_cuenta = @codigo
END
GO
CREATE PROCEDURE SP_GetAccountTypeById
	@codigo int
AS
BEGIN
	SELECT *
	FROM Tipos_Cuentas
	WHERE id_tipo_cuenta = @codigo
END
GO
CREATE PROCEDURE SP_CreateAccount
	@codigo int,
	@cbu varchar(50),
	@saldo decimal(10,2),
	@id_tipo_cuenta int,
	@ultimo_movimiento datetime
AS
BEGIN
INSERT INTO Cuentas VALUES(@codigo, @cbu, @saldo, @id_tipo_cuenta, @ultimo_movimiento)
END
GO
CREATE PROCEDURE SP_DeleteAccount
	@codigo int
AS
BEGIN
	DELETE FROM Cuentas
	WHERE id_cuenta = @codigo
END
GO
CREATE PROCEDURE SP_UpdateAccount
	@codigo int,
	@cbu varchar(50),
	@saldo decimal(10,2),
	@id_tipo_cuenta int,
	@ultimo_movimiento datetime
AS
BEGIN
	UPDATE Cuentas
	SET cbu = @cbu,
	saldo = @saldo,
	id_tipo_cuenta = @id_tipo_cuenta,
	ultimo_movimiento = @ultimo_movimiento
	WHERE id_cuenta = @codigo
END
	

INSERT INTO Tipos_Cuentas VALUES('Cuenta Corriente')
INSERT INTO Tipos_Cuentas VALUES('Caja de Ahorro')

INSERT INTO Cuentas VALUES(1, '12345', 20000.00, 2, '27/08/2024')
INSERT INTO Cuentas VALUES(2, '23456', 300000.00, 2, '23/08/2024')

INSERT INTO Clientes VALUES('Gino', 'Carabelli García', 46846013, 1)
INSERT INTO Clientes VALUES('Luca', 'Casamayor Porto', 46342113, 2) 