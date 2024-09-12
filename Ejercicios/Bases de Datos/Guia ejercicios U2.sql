--Ejercicios unidad 2

--Se solicita un listado de artículos cuyo precio es inferior al promedio de 
--precios de todos los artículos. 
SELECT *
from articulos a
where a.pre_unitario < (select AVG(pre_unitario) from articulos)

--Emitir un listado de los artículos que no fueron vendidos este año. En 
--ese listado solo incluir aquellos cuyo precio unitario del artículo oscile 
--entre 50 y 100.
SELECT a.cod_articulo, a.descripcion, a.pre_unitario
FROM articulos a
join detalle_facturas df on df.cod_articulo = a.cod_articulo
join facturas f on f.nro_factura = df.nro_factura
WHERE not exists (SELECT * from articulos a1 where YEAR(fecha) = YEAR(getdate()) and pre_unitario between 500 and 1000)

--Genere un reporte con los clientes que vinieron más de 2 veces el año 
--pasado.
SELECT c.cod_cliente, ape_cliente+' '+nom_cliente as cliente
FROM clientes c
WHERE 2 < (select COUNT(*) from facturas f where YEAR(fecha) = YEAR(getdate())-1 and c.cod_cliente = f.cod_cliente)
ORDER BY c.cod_cliente

--Se quiere saber qué clientes no vinieron entre el 12/12/2015 y el 13/7/2020
SELECT DISTINCT c.cod_cliente, ape_cliente+' '+nom_cliente as cliente
FROM clientes c
JOIN facturas f on f.cod_cliente = c.cod_cliente
WHERE c.cod_cliente not in (select cod_cliente from facturas f1 where f1.fecha between '12/12/2015' and '13/07/2020')

--Listar los datos de las facturas de los clientes que solo vienen a comprar 
--en febrero es decir que todas las veces que vienen a comprar haya sido 
--en el mes de febrero (y no otro mes).






--Realice un informe que muestre cuánto fue el total anual facturado por 
--cada vendedor, para los casos en que el nombre de vendedor no 
--comience con ‘B’ ni con ‘M’, que los números de facturas oscilen entre 5 
--y 25 y que el promedio del monto facturado sea inferior al promedio de 
--ese año.
SELECT v.cod_vendedor, YEAR(fecha), SUM(cantidad*pre_unitario)
FROM facturas f
JOIN vendedores v on v.cod_vendedor = f.cod_vendedor
JOIN detalle_facturas df on f.nro_factura = df.nro_factura
WHERE nom_vendedor not like '[B,M]%'
AND df.nro_factura between 5 and 25
GROUP BY v.cod_vendedor, YEAR(fecha)
HAVING AVG(pre_unitario*cantidad) < (select AVG(pre_unitario*cantidad) from detalle_facturas df1
									join facturas f1 on f1.nro_factura = df1.nro_factura
									where YEAR(f1.fecha) = YEAR(f.fecha))