SET DATEFORMAT DMY
--Facturación total del negocio
SELECT SUM(pre_unitario*cantidad) 'Facturacion total'
FROM detalle_facturas

--También se quiere saber el total de la factura Nro. 236, la cantidad de 
--artículos vendidos, cantidad de ventas, el precio máximo y mínimo vendido. 
SELECT SUM(df.pre_unitario*cantidad) 'Monto total',
COUNT(cantidad) 'Cantidad de art. vendidos',
MAX(df.pre_unitario) 'Precio maximo',
MIN(df.pre_unitario) 'Precio mínimo'
FROM facturas f
JOIN detalle_facturas df ON df.nro_factura = f.nro_factura
WHERE f.nro_factura = 236

--Se nos solicita además lo siguiente: ¿Cuánto se facturó el año pasado? 
SELECT SUM(pre_unitario*cantidad) 'Facturación total del año anterior'
From detalle_facturas df
JOIN facturas f on df.nro_factura = f.nro_factura
WHERE YEAR(fecha) = YEAR(getdate())-1

--¿Cantidad de clientes con dirección de e-mail sea conocido (no nulo)
SELECT COUNT(*) 'Cantidad de clientes',
COUNT([e-mail]) 'Cantidad de clientes con e-mail no nulo'
FROM clientes c

--¿Cuánto fue el monto total de la facturación de este negocio? ¿Cuántas 
--facturas se emitieron? 
SELECT SUM(pre_unitario*cantidad) 'Facturación total',
COUNT(DISTINCT f.nro_factura) 'Cantidad de facturas emitidas'
FROM facturas f
JOIN detalle_facturas df on df.nro_factura = f.nro_factura

--Se necesita conocer el promedio de monto facturado por factura el año 
--pasado.
SELECT AVG(pre_unitario*cantidad) 'Promedio de monto facturado por factura'
FROM facturas f
JOIN detalle_facturas df on df.nro_factura = f.nro_factura
WHERE YEAR(fecha) = YEAR(getdate())-1

--Se quiere saber la cantidad de ventas que hizo el vendedor de código 3.
SELECT COUNT(f.nro_factura) 'Ventas del vendedor nro 3'
FROM vendedores v
JOIN facturas f on f.cod_vendedor = v.cod_vendedor
WHERE v.cod_vendedor = 3

--¿Cuál fue la fecha de la primera y última venta que se realizó en este 
--negocio?
SELECT MIN(fecha) 'Primera venta', MAX(fecha) 'Ultima venta'
FROM facturas

--Mostrar la siguiente información respecto a la factura nro.: 450: cantidad 
--total de unidades vendidas, la cantidad de artículos diferentes vendidos y 
--el importe total. 
SELECT COUNT(cantidad) 'Cantidad de unidades vendidas', 
COUNT(distinct cod_articulo) 'Cantidad de articulos diferentes vendidos',
SUM(pre_unitario*cantidad) 'Monto total'
FROM facturas f
JOIN detalle_facturas df on df.nro_factura = f.nro_factura
WHERE f.nro_factura = 450

--¿Cuál fue la cantidad total de unidades vendidas, importe total y el importe 
--promedio para vendedores cuyos nombres comienzan con letras que van 
--de la “d” a la “l”? 
SELECT COUNT(df.cod_articulo) 'cantidad total de unidades vendidas',
SUM(pre_unitario*cantidad) 'importe total',
AVG(pre_unitario*cantidad) 'importe promedio'
FROM vendedores v
JOIN facturas f on f.cod_vendedor = v.cod_vendedor
JOIN detalle_facturas df on df.nro_factura = f.nro_factura
WHERE v.nom_vendedor like '[d-l]%'

--Se quiere saber el importe total vendido, el promedio del importe vendido y 
--la cantidad total de artículos vendidos para el cliente Ana María.
SELECT SUM(pre_unitario*cantidad) 'importe total vendido',
AVG(pre_unitario*cantidad) 'promedio del importe vendido',
COUNT(cod_articulo) 'cantidad total de articulos vendidos'
FROM facturas f
JOIN detalle_facturas df on df.nro_factura = f.nro_factura
JOIN clientes c on c.cod_cliente = f.cod_cliente
WHERE c.nom_cliente = 'Ana María'

--Mostrar la fecha de la primera venta, la cantidad total vendida y el importe 
--total vendido para los artículos que empiecen con “C”. 
SELECT a.descripcion, MIN(fecha) 'fecha',
COUNT(a.cod_articulo) 'cantidad de articulos vendidos',
SUM(df.pre_unitario*cantidad) 'importe total vendido'
FROM facturas f
JOIN detalle_facturas df on df.nro_factura = f.nro_factura
JOIN articulos a on a.cod_articulo = df.cod_articulo
WHERE a.descripcion like '[C]%'
GROUP BY a.descripcion

--Se quiere saber la cantidad total de artículos vendidos y el importe total 
--vendido para el periodo del 15/06/2011 al 15/06/2017. 
SELECT COUNT(cod_articulo) 'cantidad total de articulos vendidos',
SUM(df.pre_unitario*cantidad) 'importe total vendido'
FROM facturas f
JOIN detalle_facturas df on df.nro_factura = f.nro_factura
WHERE fecha between '15/06/2011' and '15/06/2017'

--Se quiere saber la cantidad de veces y la última vez que vino el cliente de 
--apellido Abarca y cuánto gastó en total.
SELECT COUNT(f.cod_cliente) 'cantidad de veces que vino',
MAX(fecha) 'ultima vez que vino',
SUM(pre_unitario*cantidad) 'gasto total'
FROM facturas f
JOIN clientes c on f.cod_cliente = c.cod_cliente
JOIN detalle_facturas df on df.nro_factura = f.nro_factura
where c.ape_cliente in ('Abarca')

--Mostrar el importe total y el promedio del importe para los clientes cuya 
--dirección de mail es conocida.
SELECT SUM(pre_unitario*cantidad) 'importe total',
AVG(pre_unitario*cantidad) 'promedio del importe'
FROM clientes c
JOIN facturas f on f.cod_cliente = c.cod_cliente
JOIN detalle_facturas df on df.nro_factura = f.nro_factura
WHERE c.[e-mail] is not null

--Obtener la siguiente información: el importe total vendido y el importe 
--promedio vendido para números de factura que no sean los siguientes: 13, 
--5, 17, 33, 24.
SELECT SUM(pre_unitario*cantidad) 'importe total vendido',
AVG(pre_unitario*cantidad) 'importe promedio vendido'
FROM facturas f
join detalle_facturas df on df.nro_factura = f.nro_factura
WHERE f.nro_factura not in (13, 5, 17, 33, 24)

--CONSULTAS CON GROUP BY
--Los importes totales de ventas por cada artículo que se tiene en el negocio 
SELECT SUM(df.pre_unitario*cantidad) 'importes totales',
a.descripcion
FROM articulos a
join detalle_facturas df on df.cod_articulo = a.cod_articulo
group by a.descripcion

--Por cada factura emitida mostrar la cantidad total de artículos vendidos 
--(suma de las cantidades vendidas), la cantidad ítems que tiene cada factura 
--en el detalle (cantidad de registros de detalles) y el Importe total de la 
--facturación de este año.
SELECT f.nro_factura, SUM(cantidad) 'suma de las cantidades vendidas',
COUNT(df.nro_factura) 'detalles factura por factura',
SUM(pre_unitario*cantidad) 'importe total'
FROM detalle_facturas df
JOIN facturas f on f.nro_factura = df.nro_factura
WHERE YEAR(fecha) = YEAR(getdate())
GROUP BY f.nro_factura

--Se quiere saber en este negocio, cuánto se factura:
--Diariamente 
SELECT DAY(fecha) 'dia', SUM(pre_unitario*cantidad) 'facturacion total'
FROM detalle_facturas df
JOIN facturas f on f.nro_factura = df.nro_factura
group by DAY(fecha)
order by day(fecha)
--Mensualmente
SELECT MONTH(fecha) 'mes', SUM(pre_unitario*cantidad) 'facturacion total'
FROM detalle_facturas df
JOIN facturas f on f.nro_factura = df.nro_factura
group by MONTH(fecha)
order by MONTH(fecha)
--Anualmente
SELECT YEAR(fecha) 'mes', SUM(pre_unitario*cantidad) 'facturacion total'
FROM detalle_facturas df
JOIN facturas f on f.nro_factura = df.nro_factura
group by YEAR(fecha)
order by YEAR(fecha)

--Emitir un listado de la cantidad de facturas confeccionadas diariamente, 
--correspondiente a los meses que no sean enero, julio ni diciembre. Ordene 
--por la cantidad de facturas en forma descendente y fecha.
SELECT fecha, COUNT(f.nro_factura) 'facturas confeccionadas'
FROM facturas f
WHERE MONTH(fecha) not in (1,7,11)
GROUP BY fecha
ORDER BY COUNT(f.nro_factura) desc

--Se quiere saber la cantidad y el importe promedio vendido por fecha y 
--cliente, para códigos de vendedor superiores a 2. Ordene por fecha y cliente. 
SELECT fecha,
v.nom_vendedor + ' ' + v.ape_vendedor 'vendedor',
COUNT(f.nro_factura) 'cantidad ventas',
AVG(pre_unitario*cantidad) 'importe promedio',
c.nom_cliente + ' ' + c.ape_cliente 'cliente'
FROM facturas f
join detalle_facturas df on df.nro_factura = f.nro_factura
join clientes c on c.cod_cliente = f.cod_cliente
join vendedores v on v.cod_vendedor = f.cod_vendedor
where v.cod_vendedor > 2
group by fecha, c.nom_cliente, c.ape_cliente, v.nom_vendedor, v.ape_vendedor
order by fecha, cliente

--Se quiere saber el importe promedio vendido y la cantidad total vendida por 
--fecha y artículo, para códigos de cliente inferior a 3. Ordene por fecha y 
--artículo. 
SELECT AVG(df.pre_unitario*cantidad) 'importe promedio vendido',
SUM(cantidad) 'cantidad total vendida',
f.fecha,
a.descripcion
FROM detalle_facturas df
JOIN facturas f on f.nro_factura = df.nro_factura
JOIN articulos a on a.cod_articulo = df.cod_articulo
WHERE cod_cliente < 3
GROUP BY f.fecha, a.descripcion
ORDER BY fecha, a.descripcion

--Listar la cantidad total vendida, el importe total vendido y el importe 
--promedio total vendido por número de factura, siempre que la fecha no 
--oscile entre el 13/2/2007 y el 13/7/2010.
SELECT fecha,
f.nro_factura,
SUM(cantidad) 'cantidad total vendida',
SUM(df.pre_unitario*cantidad) 'importe total vendido',
AVG(df.pre_unitario*cantidad) 'importe promedio vendido'
FROM facturas f
JOIN detalle_facturas df on df.nro_factura = f.nro_factura
WHERE fecha not between '13/02/2007' and '13/07/2010'
GROUP BY f.nro_factura, fecha
ORDER BY f.nro_factura

--Emitir un reporte que muestre la fecha de la primer y última venta y el 
--importe comprado por cliente. Rotule como CLIENTE, PRIMER VENTA, 
--ÚLTIMA VENTA, IMPORTE.
SELECT f.cod_cliente 'CLIENTE',
MIN(fecha) 'PRIMERA VENTA',
MAX(fecha) 'ÚLTIMA VENTA',
SUM(pre_unitario*cantidad) 'IMPORTE'
from clientes c
join facturas f on f.cod_cliente = c.cod_cliente
join detalle_facturas df on df.nro_factura = f.nro_factura
GROUP BY f.cod_cliente
ORDER BY f.cod_cliente

--Se quiere saber el importe total vendido, la cantidad total vendida y el precio 
--unitario promedio por cliente y artículo, siempre que el nombre del cliente 
--comience con letras que van de la “a” a la “m”. Ordene por cliente, precio 
--unitario promedio en forma descendente y artículo. Rotule como IMPORTE 
--TOTAL, CANTIDAD TOTAL, PRECIO PROMEDIO.
SELECT SUM(df.pre_unitario*cantidad) 'IMPORTE TOTAL', 
SUM(cantidad) 'CANTIDAD TOTAL',
AVG(df.pre_unitario) 'PRECIO PROMEDIO',
c.nom_cliente,
a.descripcion
FROM facturas f
join detalle_facturas df on df.nro_factura = f.nro_factura
join articulos a on a.cod_articulo = df.cod_articulo
join clientes c on c.cod_cliente = f.cod_cliente
where c.nom_cliente like '[a-m]%'
group by c.nom_cliente, a.descripcion
order by c.nom_cliente, AVG(df.pre_unitario) desc

--Se quiere saber la cantidad de facturas y la fecha la primer y última factura 
--por vendedor y cliente, para números de factura que oscilan entre 5 y 30. 
--Ordene por vendedor, cantidad de ventas en forma descendente y cliente. 
SELECT count(f.nro_factura) 'cantidad de facturas',
min(fecha) 'primer factura',
max(fecha) 'ultima factura',
f.cod_vendedor,
f.cod_cliente
from facturas f
where f.nro_factura between 5 and 30
group by f.cod_vendedor, f.cod_cliente
order by f.cod_vendedor, count(f.nro_factura), f.cod_cliente desc