CREATE DATABASE Facturacion
USE Facturacion

CREATE TABLE Articulos(
codigo int identity primary key,
nombre varchar(50),
precioUnitario decimal(10,2)
)

CREATE TABLE FormasPagos(
idFormaPago int identity primary key,
nombre varchar(50)
)

CREATE TABLE DetallesFacturas(
idDetallesFacturas int identity primary key,
codigo int,
cantidad int,
CONSTRAINT fk_codigo FOREIGN KEY (codigo) REFERENCES Articulos(codigo)
)

CREATE TABLE Facturas(
nroFactura int identity primary key,
fecha datetime,
idFormaPago int,
idDetallesFacturas int,
cliente varchar(75),
CONSTRAINT fk_idFormaPago FOREIGN KEY (idFormaPago) REFERENCES FormasPagos(idFormaPago),
CONSTRAINT fk_idDetallesFacturas FOREIGN KEY (idDetallesFacturas) REFERENCES DetallesFacturas(idDetallesFacturas)
)

INSERT INTO Articulos VALUES('Zapatillas Running', 209000.00) 
INSERT INTO DetallesFacturas VALUES(1, 1)
INSERT INTO FormasPagos VALUES('Efectivo')
INSERT INTO FormasPagos VALUES('Transferencia')
INSERT INTO FormasPagos VALUES('Credito')
INSERT INTO FormasPagos VALUES('Debito')
INSERT INTO Facturas VALUES('29/08/2024', 2, 1, 'Gino Carabelli')

SET DATEFORMAT DMY