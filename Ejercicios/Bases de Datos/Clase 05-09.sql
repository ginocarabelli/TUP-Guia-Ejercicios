--Clase 05/09/2024

--Ej 6, Pág 12 Desde la administración se solicita un reporte que muestre el precio 
--promedio, el importe total y el promedio del importe vendido por artículo 
--que no comiencen con “c”, que su cantidad total vendida sea 100 o más o 
--que ese importe total vendido sea superior a 700. 
SELECT d.cod_articulo, descripcion, 
AVG(d.pre_unitario) precio_promedio, SUM(cantidad*d.pre_unitario) Imp_total,
AVG(d.pre_unitario*cantidad) importe_promedio,
COUNT(distinct nro_factura) 'cant nro_facturas',
COUNT(distinct a.cod_articulo) 'cant cod_articulos'
FROM detalle_facturas d
JOIN articulos a on a.cod_articulo = d.cod_articulo
WHERE descripcion not like 'C%'
GROUP BY d.cod_articulo, descripcion
HAVING SUM(cantidad)>=100 or SUM(cantidad*d.pre_unitario)>700

--Ej 7 Pág 15, El encargado del negocio quiere saber cuánto fue la facturación del año pasado. 
--Por otro lado, cuánto es la facturación del mes pasado, la de este mes y la de hoy 
--(Cada pedido en una consulta distinta, y puede unirla en una sola tabla de 
--resultado) 
SELECT '4' ord, 'Año pasado', SUM(cantidad*pre_unitario) Importe
from facturas f join detalle_facturas d on d.nro_factura = f.nro_factura
where datediff(year, fecha, getdate()) = 1
union
SELECT '3' ord, 'Mes pasado', sum(cantidad*pre_unitario)
from facturas f join detalle_facturas d on d.nro_factura = f.nro_factura
where datediff(month, fecha, getdate()) = 1
union
SELECT '2' ord, 'Este mes', sum(Cantidad*pre_unitario)
from facturas f join detalle_facturas d on d.nro_factura = f.nro_factura
where datediff(month, fecha, getdate()) = 1
union
SELECT '1' ord, 'Hoy', sum(cantidad*pre_unitario)
from facturas f join detalle_facturas d on d.nro_factura = f.nro_factura
where datediff(month, fecha, getdate()) = 0

--Vistas
--crear una vista que guarde una consulta uqe liste por cliente
-- la cantidad de facturas y montos totales anuales que compró
CREATE VIEW VIS_Compra_Anual
AS
SELECT cod_cliente cliente, year(fecha) año, sum(cantidad*pre_unitario) total,
count(distinct df.nro_factura) 'cantidad de facturas'
FROM facturas f
JOIN detalle_facturas df on df.nro_factura = f.nro_factura
GROUP BY cod_cliente, year(fecha)

--mostrar utilizando la vista anterior los totales anuales comprados
--por clientes cuyo apellido no comience con A y que realizaron menos de
--2 compras por año
select v.cliente, total as 'total anual'
from VIS_Compra_Anual as v
join clientes c on c.cod_cliente = v.cliente
where c.ape_cliente not like 'A%'
and [cantidad de facturas] > 2

--TEST DE PERTENENCIA AL CONJUNTO
-- listar los articulos que se vendieron este año
select *
from articulos
where cod_articulo in (select cod_articulo from detalle_facturas df
					   join facturas f on f.nro_factura = df.nro_factura
					   where YEAR(fecha) = YEAR(getdate()))

--TEST DE EXISTENCIA
--listar los clientes que vinieron este año
SELECT cod_cliente, ape_cliente, nom_cliente
FROM clientes c
WHERE exists (select *
		from facturas f
		where year(fecha) = year(getdate())
		and f.cod_cliente=c.cod_cliente)

--TEST CUANTIFICADOS: ANY Y ALL
--listar los clientes que compraron algún artículo
--con precio mayor a 1000
SELECT f.cod_cliente
FROM facturas f
join detalle_facturas df on df.nro_factura = f.nro_factura
join clientes c on c.cod_cliente = f.nro_factura
WHERE 1000<all(select pre_unitario
		from detalle_facturas df
		join facturas f on f.nro_factura = df.nro_factura
		where c.cod_cliente = cod_cliente)

--Actividades de práctica
--2 Emitir un listado de los artículos que no fueron vendidos este año. En 
--ese listado solo incluir aquellos cuyo precio unitario del artículo oscile 
--entre 50 y 100. 
SELECT a.*
FROM articulos a
join detalle_facturas df on df.cod_articulo = a.cod_articulo
join facturas f on f.nro_factura = df.nro_factura
WHERE a.cod_articulo in (SELECT df.cod_articulo
				from facturas f
				join detalle_facturas df on df.nro_factura = f.nro_factura
				where YEAR(fecha) = YEAR(getdate())
				and a.pre_unitario between 500 and 1000)

