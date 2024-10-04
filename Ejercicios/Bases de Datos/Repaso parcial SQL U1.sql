SET DATEFORMAT DMY
--1. Facturaci�n total del negocio 
SELECT SUM(cantidad*pre_unitario) FacturacionTotal
FROM detalle_facturas df

--2. Tambi�n se quiere saber el total de la factura Nro. 236, la cantidad de 
--art�culos vendidos, cantidad de ventas, el precio m�ximo y m�nimo vendido.
SELECT SUM(cantidad*pre_unitario) Total,
SUM(cantidad) CantidadVendida,
COUNT(*) CantidadVentas,
MAX(pre_unitario) PrecioMaximo,
MIN(pre_unitario) PrecioMinimo
FROM Facturas f
JOIN detalle_facturas df on df.nro_factura = f.nro_factura
WHERE f.nro_factura = 236

--3. Se nos solicita adem�s lo siguiente: �Cu�nto se factur� el a�o pasado? 
SELECT SUM(cantidad*pre_unitario) TotalA�oPasado
FROM Facturas f
JOIN detalle_facturas df on df.nro_factura = f.nro_factura
WHERE DATEDIFF(YEAR, fecha, getdate()) = 1

--4. �Cantidad de clientes con direcci�n de e-mail sea conocido (no nulo)
SELECT COUNT(*) ClientesConEmailConocido
FROM clientes c
WHERE c.[e-mail] is not null

--5. �Cu�nto fue el monto total de la facturaci�n de este negocio? �Cu�ntas 
--facturas se emitieron?
SELECT SUM(cantidad*pre_unitario) FacturacionTotal,
COUNT(f.nro_factura) FacturasEmitidas
FROM facturas f
JOIN detalle_facturas df on df.nro_factura = f.nro_factura

--6. Se necesita conocer el promedio de monto facturado por factura el a�o 
--pasado.
SELECT AVG(cantidad*pre_unitario) 'Promedio por detalle factura',
SUM(cantidad*pre_unitario) / COUNT(DISTINCT f.nro_factura) 'Promedio por factura'
FROM detalle_facturas df
JOIN facturas f on f.nro_factura = df.nro_factura
WHERE DATEDIFF(year, fecha, getdate()) = 1

--7. Se quiere saber la cantidad de ventas que hizo el vendedor de c�digo 3.
SELECT COUNT(f.cod_vendedor) 'Cantidad de ventas del vendedor 3'
FROM facturas f
JOIN vendedores v on v.cod_vendedor = f.cod_vendedor
WHERE v.cod_vendedor = 3

--8. �Cu�l fue la fecha de la primera y �ltima venta que se realiz� en este 
--negocio?
SELECT MIN(fecha) 'Primera venta',
MAX(fecha) 'Ultima venta'
FROM facturas f

--9. Mostrar la siguiente informaci�n respecto a la factura nro.: 450: cantidad 
--total de unidades vendidas, la cantidad de art�culos diferentes vendidos y 
--el importe total. 
SELECT SUM(cantidad) 'Cantidad total de unidades vendidas',
COUNT(cod_articulo) 'Cantidad de art�culos diferentes',
SUM(cantidad*pre_unitario) 'Importe total'
FROM detalle_facturas df
JOIN facturas f on f.nro_factura = df.nro_factura
WHERE f.nro_factura = 450

--10. �Cu�l fue la cantidad total de unidades vendidas, importe total y el importe 
--promedio para vendedores cuyos nombres comienzan con letras que van 
--de la �d� a la �l�? 
SELECT SUM(cantidad) 'Cantidad total de unidades vendidas',
SUM(cantidad*pre_unitario) 'Importe total',
SUM(cantidad*pre_unitario) / COUNT(distinct f.cod_vendedor) 'Importe promedio por vendedor'
FROM detalle_facturas df
JOIN facturas f on f.nro_factura = df.nro_factura
JOIN vendedores v on v.cod_vendedor = f.cod_vendedor
WHERE v.nom_vendedor like '[d-l]%'

--11. Se quiere saber el importe total vendido, el promedio del importe vendido y 
--la cantidad total de art�culos vendidos para el cliente Roque Paez.
SELECT SUM(cantidad*pre_unitario) 'Importe total vendido',
SUM(cantidad) 'Cantidad total de art�culos vendidos'
FROM facturas f
JOIN detalle_facturas df on df.nro_factura = f.nro_factura
JOIN clientes c on c.cod_cliente = f.cod_cliente
WHERE c.nom_cliente = 'Roque' and c.ape_cliente = 'Paez'

--12. Mostrar la fecha de la primera venta, la cantidad total vendida y el importe 
--total vendido para los art�culos que empiecen con �C�.
SELECT MIN(fecha) 'Primera venta',
SUM(cantidad) 'Cantidad total vendida',
SUM(cantidad*df.pre_unitario) 'Importe total vendido',
a.cod_articulo
FROM articulos a
JOIN detalle_facturas df on df.cod_articulo = a.cod_articulo
JOIN facturas f on f.nro_factura = df.nro_factura
WHERE a.descripcion like 'C%'
GROUP by a.cod_articulo

--13. Se quiere saber la cantidad total de art�culos vendidos y el importe total 
--vendido para el periodo del 15/06/2011 al 15/06/2017. 
SELECT SUM(cantidad) 'Cantidad de art�culos vendidos',
SUM(cantidad*pre_unitario) 'Importe total'
FROM facturas f
JOIN detalle_facturas df on df.nro_factura = f.nro_factura
WHERE fecha between '15/06/2011' and '15/06/2017'

--14. Se quiere saber la cantidad de veces y la �ltima vez que vino el cliente de 
--apellido Abarca y cu�nto gast� en total. 
SELECT COUNT(f.cod_cliente) 'Cantidad de veces que vino el cliente',
MAX(fecha) '�ltima vez que vino'
FROM facturas f
JOIN clientes c on c.cod_cliente = f.cod_cliente
WHERE c.ape_cliente = 'Abarca'

--15. Mostrar el importe total y el promedio del importe para los clientes cuya 
--direcci�n de mail es conocida.
SELECT SUM(cantidad*pre_unitario) 'Importe total',
SUM(cantidad*pre_unitario) / COUNT(DISTINCT f.cod_cliente) 'Promedio del importe'
FROM facturas f
JOIN clientes c on c.cod_cliente = f.cod_cliente
JOIN detalle_facturas df on df.nro_factura = f.nro_factura
WHERE c.[e-mail] is not null

--16. Obtener la siguiente informaci�n: el importe total vendido y el importe 
--promedio vendido para n�meros de factura que no sean los siguientes: 13, 
--5, 17, 33, 24.
SELECT SUM(cantidad*pre_unitario) 'Importe total vendido',
SUM(cantidad*pre_unitario) / COUNT(DISTINCT f.nro_factura) 'Promedio vendido por factura'
FROM facturas f
JOIN detalle_facturas df on df.nro_factura = f.nro_factura
WHERE f.nro_factura not in (13, 5, 17, 33, 24)

--1. Los importes totales de ventas por cada art�culo que se tiene en el negocio
SELECT SUM(cantidad*pre_unitario) 'Importes totales por art�culo',
cod_articulo
FROM detalle_facturas df
GROUP BY cod_articulo
ORDER BY cod_articulo ASC

--2. Por cada factura emitida mostrar la cantidad total de art�culos vendidos 
--(suma de las cantidades vendidas), la cantidad �tems que tiene cada factura 
--en el detalle (cantidad de registros de detalles) y el Importe total de la 
--facturaci�n de este a�o.
SELECT df.nro_factura,
SUM(cantidad) 'Cantidad de art�culos vendidos',
COUNT(*) 'Cantidad de detalles factura',
SUM(cantidad*pre_unitario) 'Importe total de facturaci�n'
FROM detalle_facturas df
GROUP BY df.nro_factura

--3. Se quiere saber en este negocio, cu�nto se factura: 
--a. Diariamente  
--b. Mensualmente  
--c. Anualmente 
SELECT MONTH(fecha) 'Mes',
SUM(cantidad*pre_unitario) 'Facturaci�n'
FROM facturas f
JOIN detalle_facturas df on df.nro_factura = f.nro_factura
GROUP BY MONTH(fecha)
ORDER BY MONTH(fecha) ASC

--4. Emitir un listado de la cantidad de facturas confeccionadas diariamente, 
--correspondiente a los meses que no sean enero, julio ni diciembre. Ordene 
--por la cantidad de facturas en forma descendente y fecha.
SELECT DAY(fecha) 'D�a',
MONTH(fecha) 'Mes',
COUNT(nro_factura) 'Cantidad de facturas confeccionadas'
FROM facturas f
WHERE MONTH(fecha) not in (1, 7, 12)
GROUP BY MONTH(fecha), DAY(fecha)
ORDER BY COUNT(nro_factura), MONTH(fecha), DAY(fecha) DESC

--5. Se quiere saber la cantidad y el importe promedio vendido por fecha y 
--cliente, para c�digos de vendedor superiores a 2. Ordene por fecha y 
--cliente.
SELECT SUM(cantidad) 'Cantidad vendida',
SUM(cantidad*pre_unitario) / COUNT(DISTINCT cod_cliente) 'Importe promedio por cliente',
fecha,
cod_cliente
FROM facturas f
JOIN detalle_facturas df on df.nro_factura = f.nro_factura
WHERE cod_cliente > 2
GROUP BY fecha, cod_cliente 
ORDER BY fecha, cod_cliente ASC

--6. Se quiere saber el importe promedio vendido y la cantidad total vendida por 
--fecha y art�culo, para c�digos de cliente inferior a 3. Ordene por fecha y 
--art�culo.
SELECT SUM(cantidad*pre_unitario) / COUNT(DISTINCT cod_articulo) 'Importe promedio por art�culo',
SUM(cantidad) 'cantidad total vendida', 
fecha,
cod_cliente
FROM detalle_facturas df
JOIN facturas f on f.nro_factura = df.nro_factura
WHERE cod_cliente < 3
GROUP BY fecha, cod_cliente
ORDER BY fecha, cod_cliente

--7. Listar la cantidad total vendida, el importe total vendido y el importe 
--promedio total vendido por n�mero de factura, siempre que la fecha no 
--oscile entre el 13/2/2007 y el 13/7/2010.
SELECT fecha,
SUM(cantidad) 'Cantidad total vendida',
SUM(cantidad*pre_unitario) 'Importe total vendido',
SUM(cantidad*pre_unitario) / COUNT(DISTINCT f.nro_factura) 'Importe promedio por numero de factura'
FROM facturas f
JOIN detalle_facturas df on df.nro_factura = f.nro_factura
WHERE fecha not between '13/02/2007' and '13/07/2010'
GROUP BY fecha

--8. Emitir un reporte que muestre la fecha de la primer y �ltima venta y el 
--importe comprado por cliente. Rotule como CLIENTE, PRIMER VENTA, 
--�LTIMA VENTA, IMPORTE.
SELECT f.cod_cliente 'Cliente',
MIN(fecha) 'Primer venta', MAX(fecha) 'Ultima venta',
SUM(cantidad*pre_unitario) 'Importe'
FROM facturas f
JOIN detalle_facturas df on df.nro_factura = f.nro_factura
GROUP BY f.cod_cliente

--9. Se quiere saber el importe total vendido, la cantidad total vendida y el precio 
--unitario promedio por cliente y art�culo, siempre que el nombre del cliente 
--comience con letras que van de la �a� a la �m�. Ordene por cliente, precio 
--unitario promedio en forma descendente y art�culo. Rotule como IMPORTE 
--TOTAL, CANTIDAD TOTAL, PRECIO PROMEDIO. 
SELECT SUM(cantidad*pre_unitario) 'importe total',
SUM(cantidad) 'cantidad total vendida',
SUM(pre_unitario) / COUNT(distinct df.cod_articulo) 'Precio unitario promedio',
f.cod_cliente, df.cod_articulo
FROM facturas f
JOIN detalle_facturas df on df.nro_factura = f.nro_factura
JOIN clientes c on c.cod_cliente = f.cod_cliente
WHERE c.nom_cliente like '[a-m]%'
GROUP BY f.cod_cliente, df.cod_articulo
ORDER BY f.cod_cliente, df.cod_articulo DESC

--10. Se quiere saber la cantidad de facturas y la fecha la primer y �ltima factura 
--por vendedor y cliente, para n�meros de factura que oscilan entre 5 y 30. 
--Ordene por vendedor, cantidad de ventas en forma descendente y cliente.
SELECT COUNT(f.nro_factura) 'Cantidad de facturas', 
MIN(fecha) 'Primer factura', MAX(fecha) '�ltima factura',
f.cod_vendedor, f.cod_cliente
FROM facturas f
WHERE nro_factura between 5 and 30
GROUP BY f.cod_cliente, f.cod_vendedor
ORDER BY COUNT(f.nro_factura) DESC, f.cod_vendedor, f.cod_cliente

--1. Se necesita saber el importe total de cada factura, pero solo aquellas donde 
--ese importe total sea superior a 25000.
SELECT SUM(pre_unitario*cantidad) 'Importe total',
f.nro_factura
FROM facturas f
JOIN detalle_facturas df on df.nro_factura = f.nro_factura
GROUP BY f.nro_factura
HAVING SUM(pre_unitario*cantidad) > 25000

--2. Se desea un listado de vendedores y sus importes de ventas del a�o 2017 
--pero solo aquellos que vendieron menos de $ 17.000.- en dicho a�o. 
SELECT f.cod_vendedor,
SUM(cantidad*pre_unitario) 'Importes de ventas'
FROM facturas f
JOIN detalle_facturas df on df.nro_factura = f.nro_factura
WHERE YEAR(fecha) = 2017
GROUP BY f.cod_vendedor
HAVING SUM(cantidad*pre_unitario) < 17000

--3. Se quiere saber la fecha de la primera venta, la cantidad total vendida y el 
--importe total vendido por vendedor para los casos en que el promedio de 
--la cantidad vendida sea inferior o igual a 56.
SELECT MIN(fecha) 'Primera venta',
SUM(cantidad) 'Cantidad total vendida',
SUM(cantidad*pre_unitario) 'Importe total vendido',
f.cod_vendedor
FROM facturas f
Join detalle_facturas df on df.nro_factura = f.nro_factura
GROUP BY f.cod_vendedor
HAVING AVG(cantidad) <= 56

--4. Se necesita un listado que informe sobre el monto m�ximo, m�nimo y total 
--que gast� en esta librer�a cada cliente el a�o pasado, pero solo donde el 
--importe total gastado por esos clientes est� entre 30000 y 80000.
SELECT MAX(cantidad*pre_unitario) 'Monto m�ximo', MIN(cantidad*pre_unitario) 'Monto m�nimo',
SUM(cantidad*pre_unitario) 'Total que gast�',
f.cod_cliente
FROM facturas f
JOIN detalle_facturas df on df.nro_factura = f.nro_factura
WHERE DATEDIFF(YEAR, fecha, getdate()) = 1
GROUP BY f.cod_cliente
HAVING SUM(cantidad*pre_unitario) between 30000 and 80000

--5. Muestre la cantidad facturas diarias por vendedor; para los casos en que 
--esa cantidad sea 2 o m�s.
SELECT DAY(fecha) 'D�a', 
COUNT(f.nro_factura) 'Cantidad de facturas',
f.cod_vendedor
FROM facturas f
GROUP BY f.cod_vendedor, DAY(fecha)
HAVING COUNT(f.nro_factura) > 2
ORDER BY f.cod_vendedor

--6. Desde la administraci�n se solicita un reporte que muestre el precio 
--promedio, el importe total y el promedio del importe vendido por art�culo 
--que no comiencen con �c�, que su cantidad total vendida sea 100 o m�s o 
--que ese importe total vendido sea superior a 700.
SELECT AVG(df.pre_unitario) 'Precio promedio',
SUM(cantidad*df.pre_unitario) 'Importe total',
SUM(cantidad*df.pre_unitario) / COUNT(DISTINCT df.cod_articulo) 'Importe promedio por art�culo',
a.descripcion
FROM articulos a
JOIN detalle_facturas df on df.cod_articulo = a.cod_articulo
WHERE a.descripcion not like 'C%'
GROUP BY a.descripcion 
HAVING SUM(cantidad) >= 100 OR SUM(cantidad*df.pre_unitario) > 7000

--7. Muestre en un listado la cantidad total de art�culos vendidos, el importe 
--total y la fecha de la primer y �ltima venta por cada cliente, para lo 
--n�meros de factura que no sean los siguientes: 2, 12, 20, 17, 30 y que el 
--promedio de la cantidad vendida oscile entre 2 y 60.
SELECT SUM(cantidad) 'cantidad total de art�culos vendidos',
SUM(cantidad*pre_unitario) 'importe total',
MIN(fecha) 'primer venta', MAX(fecha) 'ultima venta',
f.cod_cliente
FROM facturas f
JOIN detalle_facturas df on df.nro_factura = f.nro_factura
WHERE f.nro_factura not in (2,12,20,17,30)
GROUP BY f.cod_cliente
HAVING AVG(cantidad) between 2 and 60

--8. Emitir un listado que muestre la cantidad total de art�culos vendidos, el 
--importe total vendido y el promedio del importe vendido por vendedor y 
--por cliente; para los casos en que el importe total vendido est� entre 200 
--y 600 y para c�digos de cliente que oscilen entre 1 y 5.
SELECT SUM(cantidad) 'cantidad total de art�culos vendidos',
SUM(cantidad*pre_unitario) 'importe total vendido',
SUM(cantidad*pre_unitario) / COUNT(DISTINCT f.cod_vendedor) 'Importe promedio por vendedor',
f.cod_vendedor, f.cod_cliente
FROM facturas f
JOIN detalle_facturas df on df.nro_factura = f.nro_factura
GROUP BY f.cod_vendedor, f.cod_cliente
HAVING SUM(cantidad*pre_unitario) between 2000 and 6000
AND f.cod_cliente between 1 and 5

--9. �Cu�les son los vendedores cuyo promedio de facturaci�n por mes supera los $ 800?
SELECT AVG(pre_unitario*cantidad) 'facturacion por mes',
f.cod_vendedor
FROM facturas f
join detalle_facturas df on df.nro_factura = f.nro_factura
GROUP BY f.cod_vendedor
HAVING AVG(pre_unitario*cantidad) > 800

--10. �Cu�nto le vendi� cada vendedor a cada cliente el a�o pasado siempre 
--que la cantidad de facturas emitidas (por cada vendedor a cada cliente) 
--sea menor a 5?
SELECT SUM(pre_unitario*cantidad) 'importe total', COUNT(f.nro_factura) 'cantidad de facturas',
f.cod_vendedor, f.cod_cliente
FROM facturas f
JOIN detalle_facturas df on df.nro_factura = f.nro_factura
WHERE DATEDIFF(YEAR, fecha, getdate()) = 1
GROUP BY f.cod_cliente, f.cod_vendedor
HAVING COUNT(f.nro_factura) < 5

--1. Confeccionar un listado de los clientes y los vendedores indicando a qu� grupo 
--pertenece cada uno. 
SELECT cod_vendedor Codigo, nom_vendedor + ' ' + ape_vendedor 'vendedor', 'Vendedor' Tipo
FROM vendedores
UNION
SELECT cod_cliente Codigo, nom_cliente + ' ' + ape_cliente 'cliente', 'Cliente' Tipo
FROM clientes

--2. Se quiere saber qu� vendedores y clientes hay en la empresa; para los casos en 
--que su tel�fono y direcci�n de e-mail sean conocidos. Se deber� visualizar el 
--c�digo, nombre y si se trata de un cliente o de un vendedor. Ordene por la columna 
--tercera y segunda.
SELECT cod_vendedor Codigo, nom_vendedor + ' ' + ape_vendedor 'vendedor', 'Vendedor' Tipo
FROM vendedores 
UNION
SELECT cod_cliente Codigo, nom_cliente + ' ' + ape_cliente 'cliente', 'Cliente' Tipo
FROM clientes c
WHERE [e-mail] is not null AND nro_tel is not null AND calle is not null

--3. Emitir un listado donde se muestren qu� art�culos, clientes y vendedores hay en 
--la empresa. Determine los campos a mostrar y su ordenamiento.
SELECT cod_vendedor Codigo, nom_vendedor + ' ' + ape_vendedor 'vendedor', 'Vendedor' Tipo
FROM vendedores 
UNION
SELECT cod_cliente Codigo, nom_cliente + ' ' + ape_cliente 'cliente', 'Cliente' Tipo
FROM clientes c
UNION
SELECT cod_articulo Codigo, descripcion, 'Producto' Tipo
FROM articulos a
ORDER BY 3

--4. Se quiere saber las direcciones (incluido el barrio) tanto de clientes como de 
--vendedores. Para el caso de los vendedores, c�digos entre 3 y 12. En ambos casos 
--las direcciones deber�n ser conocidas. Rotule como NOMBRE, DIRECCION, 
--BARRIO, INTEGRANTE (en donde indicar� si es cliente o vendedor). Ordenado por 
--la primera y la �ltima columna.
SELECT cod_cliente CODIGO, nom_cliente + ' ' + ape_cliente NOMBRE, calle DIRECCION, b.barrio BARRIO, 'Cliente' TIPO
FROM clientes c
JOIN barrios b on b.cod_barrio = c.cod_barrio
WHERE calle is not null and c.cod_barrio is not null
UNION
SELECT cod_vendedor CODIGO, nom_vendedor + ' ' + ape_vendedor NOMBRE, calle DIRECCION, b.barrio BARRIO, 'Vendedor' TIPO
FROM vendedores v
JOIN barrios b on b.cod_barrio = v.cod_barrio
WHERE cod_vendedor between 3 and 12
ORDER BY 1, 5

--5. �dem al ejercicio anterior, s�lo que adem�s del c�digo, identifique de donde 
--obtiene la informaci�n (de qu� tabla se obtienen los datos). 
SELECT cod_cliente CODIGO, nom_cliente + ' ' + ape_cliente NOMBRE, calle DIRECCION, b.barrio BARRIO, 'Cliente' TIPO
FROM clientes c
JOIN barrios b on b.cod_barrio = c.cod_barrio
WHERE calle is not null and c.cod_barrio is not null
UNION
SELECT cod_vendedor CODIGO, nom_vendedor + ' ' + ape_vendedor NOMBRE, calle DIRECCION, b.barrio BARRIO, 'Vendedor' TIPO
FROM vendedores v
JOIN barrios b on b.cod_barrio = v.cod_barrio
WHERE cod_vendedor between 3 and 12
ORDER BY 1, 5

--6. Listar todos los art�culos que est�n a la venta cuyo precio unitario oscile entre 10 
--y 50; tambi�n se quieren listar los art�culos que fueron comprados por los clientes 
--cuyos apellidos comiencen con �M� o con �P�.
SELECT cod_articulo, descripcion, pre_unitario
FROM articulos a
WHERE pre_unitario between 1000 and 5000
UNION
SELECT a.cod_articulo, descripcion, a.pre_unitario
FROM facturas f
JOIN detalle_facturas df on df.nro_factura = f.nro_factura
JOIN articulos a on a.cod_articulo = df.cod_articulo
JOIN clientes c on c.cod_cliente = f.cod_cliente
WHERE c.ape_cliente like '[m,p]%'

--7. El encargado del negocio quiere saber cu�nto fue la facturaci�n del a�o pasado. 
--Por otro lado, cu�nto es la facturaci�n del mes pasado, la de este mes y la de hoy 
--(Cada pedido en una consulta distinta, y puede unirla en una sola tabla de 
--resultado)
SELECT SUM(cantidad*pre_unitario) 'Facturaci�n', 'A�O PASADO' Periodo
FROM facturas f
JOIN detalle_facturas df on df.nro_factura = f.nro_factura
WHERE DATEDIFF(YEAR, fecha, getdate()) = 1
UNION
SELECT SUM(cantidad*pre_unitario) 'Facturaci�n', 'MES PASADO' Periodo
FROM facturas f
JOIN detalle_facturas df on df.nro_factura = f.nro_factura
WHERE DATEDIFF(MONTH, fecha, getdate()) = 1 AND YEAR(fecha) = YEAR(getdate())
UNION
SELECT SUM(cantidad*pre_unitario) 'Facturaci�n', 'ESTE MES' Periodo
FROM facturas f
JOIN detalle_facturas df on df.nro_factura = f.nro_factura
WHERE DATEDIFF(MONTH, fecha, getdate()) = 0 AND YEAR(fecha) = YEAR(getdate())
UNION
SELECT SUM(cantidad*pre_unitario) 'Facturaci�n', 'HOY' Periodo
FROM facturas f
JOIN detalle_facturas df on df.nro_factura = f.nro_factura
WHERE DATEDIFF(DAY, fecha, getdate()) = 0 AND YEAR(fecha) = YEAR(getdate())

--1. El c�digo y nombre completo de los clientes, la direcci�n (calle y n�mero) y 
--barrio.
CREATE VIEW vis_clientes
AS
	SELECT cod_cliente Codigo, nom_cliente +' '+ ape_cliente Cliente, calle Calle, altura Altura, b.barrio Barrio
	FROM clientes c
	JOIN barrios b on b.cod_barrio = c.cod_barrio

SELECT * FROM vis_clientes

--2. Cree una vista que liste la fecha, la factura, el c�digo y nombre del vendedor, el 
--art�culo, la cantidad e importe, para lo que va del a�o. Rotule como FECHA, 
--NRO_FACTURA, CODIGO_VENDEDOR, NOMBRE_VENDEDOR, ARTICULO, 
--CANTIDAD, IMPORTE.
CREATE VIEW vis_rendimiento_vendedor
AS
	SELECT fecha FECHA, f.nro_factura NRO_FACTURA, f.cod_vendedor CODIGO_VENDEDOR, v.nom_vendedor NOMBRE_VENDEDOR,
	a.descripcion ARTICULO, cantidad CANTIDAD, SUM(cantidad*df.pre_unitario) IMPORTE
	FROM facturas f
	JOIN detalle_facturas df on df.nro_factura = f.nro_factura
	JOIN articulos a on a.cod_articulo = df.cod_articulo
	JOIN vendedores v on v.cod_vendedor = f.cod_vendedor
	GROUP BY fecha, f.nro_factura, f.cod_vendedor, v.nom_vendedor, a.descripcion, cantidad

--3. Modifique la vista creada en el punto anterior, agr�guele la condici�n de que 
--solo tome el  mes pasado (mes anterior al actual) y que tambi�n muestre la 
--direcci�n del vendedor.
ALTER VIEW vis_rendimiento_vendedor
AS
	SELECT fecha FECHA, f.nro_factura NRO_FACTURA, f.cod_vendedor CODIGO_VENDEDOR, v.nom_vendedor NOMBRE_VENDEDOR,
	v.calle CALLE, v.altura ALTURA, a.descripcion ARTICULO, cantidad CANTIDAD, SUM(cantidad*df.pre_unitario) IMPORTE
	FROM facturas f
	JOIN detalle_facturas df on df.nro_factura = f.nro_factura
	JOIN articulos a on a.cod_articulo = df.cod_articulo
	JOIN vendedores v on v.cod_vendedor = f.cod_vendedor
	WHERE DATEDIFF(MONTH, FECHA, getdate()) = 1
	GROUP BY fecha, f.nro_factura, f.cod_vendedor, v.nom_vendedor, a.descripcion, cantidad, v.calle, v.altura

--4. Consulta las vistas seg�n el siguiente detalle: 
--	a. Llame a la vista creada en el punto anterior pero filtrando por importes 
--	inferiores a $120. 
--	b. Llame a la vista creada en el punto anterior filtrando para el vendedor 
--	Alejandro. 
--	c. Llama a la vista creada en el punto 4 filtrando para los importes 
--	menores a 10.000.
SELECT *
FROM vis_rendimiento_vendedor
WHERE IMPORTE < 120

SELECT *
FROM vis_rendimiento_vendedor
WHERE NOMBRE_VENDEDOR = 'Alejandro'

SELECT *
FROM vis_rendimiento_vendedor
WHERE IMPORTE < 10000

--5. Elimine las vistas creadas en el punto 3
DROP VIEW vis_rendimiento_vendedor