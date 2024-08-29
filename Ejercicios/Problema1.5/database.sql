CREATE DATABASE Billing
GO
USE Billing
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
	SELECT invoice_id AS INVOICE_ID, invoice_date AS INVOICE_DATE,
	pf.payment_form_id AS PAYMENT_FORM_ID, pf.payment_form AS PAYMENT_FORM,
	id.invoice_details_id AS INVOICE_DETAILS_ID,
	a.article_id AS ARTICLE_ID, a.article_name AS ARTICLE_NAME, a.unit_price AS UNIT_PRICE,
	client as CLIENT
	FROM Bills b
	JOIN PaymentForms pf ON pf.payment_form_id = b.payment_form_id
	JOIN InvoiceDetails id ON id.invoice_details_id = b.invoice_details_id
	JOIN Articles a ON a.article_id = id.article_id
END
GO
CREATE PROCEDURE SP_GetInvoiceDetailsById
	@ID int
AS
BEGIN
	SELECT invoice_details_id AS INVOICE_DETAILS_ID,
	a.article_id AS ARTICLE_ID , a.article_name AS ARTICLE_NAME, a.unit_price AS UNIT_PRICE,
	cantidad AS QUANTITY
	FROM InvoiceDetails id
	JOIN Articles a ON a.article_id = id.article_id
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
CREATE PROCEDURE SP_GetArticleById
	@ID int
AS
BEGIN
	SELECT a.article_id AS ARTICLE_ID, a.article_name AS ARTICLE_NAME, a.unit_price AS UNIT_PRICE
	FROM Articles a
	WHERE article_id = @ID
END
GO
CREATE PROCEDURE SP_GetInvoiceById
	@ID int
AS
BEGIN
	SELECT invoice_id AS INVOICE_ID, invoice_date AS INVOICE_DATE,
	pf.payment_form_id as PAYMENT_FORM_ID, pf.payment_form AS PAYMENT_FORM_NAME, 
	id.invoice_details_id AS INVOICE_DETAILS_ID, id.cantidad AS QUANTITY,
	a.article_id AS ARTICLE_ID, a.article_name AS ARTICLE_NAME, a.unit_price AS UNIT_PRICE,
	client
	FROM Bills b
	JOIN PaymentForms pf ON pf.payment_form_id = b.payment_form_id
	JOIN InvoiceDetails id ON id.invoice_details_id = b.invoice_details_id
	JOIN Articles a ON a.article_id = id.invoice_details_id
	WHERE invoice_id = @ID
END
