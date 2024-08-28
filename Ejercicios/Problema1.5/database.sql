CREATE DATABASE Facturacion
GO
USE Facturacion
GO
CREATE TABLE Articles(
article_id int identity primary key,
article_name varchar(50),
unit_price decimal(10,2)
)

CREATE TABLE PaymentForms(
payment_form_id int identity primary key,
payment_form varchar(50)
)

CREATE TABLE InvoiceDetails(
invoice_details_id int identity primary key,
article_id int,
cantidad int,
CONSTRAINT fk_article_id  FOREIGN KEY (article_id) REFERENCES Articles(article_id)
)

CREATE TABLE Bills(
invoice_id int identity primary key,
invoice_date datetime,
payment_form_id int,
invoice_details_id int,
client varchar(75),
CONSTRAINT fk_payment_form_id FOREIGN KEY (payment_form_id) REFERENCES PaymentForms(payment_form_id),
CONSTRAINT fk_invoice_details_id FOREIGN KEY (invoice_details_id) REFERENCES InvoiceDetails(invoice_details_id)
)

INSERT INTO Articles VALUES('Zapatillas Running', 209000.00) 
INSERT INTO InvoiceDetails VALUES(1, 1)
INSERT INTO PaymentForms VALUES('Efectivo')
INSERT INTO PaymentForms VALUES('Transferencia')
INSERT INTO PaymentForms VALUES('Credito')
INSERT INTO PaymentForms VALUES('Debito')
INSERT INTO Bills VALUES('29/08/2024', 2, 1, 'Gino Carabelli')

SET DATEFORMAT DMY
GO
CREATE PROCEDURE SP_GetAll
AS
BEGIN
	SELECT * 
	FROM Bills
END
GO
CREATE PROCEDURE SP_GetInvoiceDetailsById
	@ID int
AS
BEGIN
	SELECT *
	FROM InvoiceDetails
	WHERE invoice_details_id = @ID
END
GO
CREATE PROCEDURE SP_GetPaymentFormById
	@ID int
AS
BEGIN
	SELECT *
	FROM PaymentForms
	WHERE payment_form_id = @ID
END
GO
CREATE PROCEDURE SP_GetInvoiceById
	@ID int
AS
BEGIN
	SELECT *
	FROM Bills
	WHERE invoice_id = @ID
END
