SET DATEFORMAT DMY
--1. Se solicita un listado de artículos cuyo precio es inferior al promedio de 
--precios de todos los artículos. 
SELECT *
FROM articulos a
WHERE pre_unitario < (SELECT AVG(pre_unitario) FROM articulos)

--2. Emitir un listado de los artículos que no fueron vendidos este año. En 
--ese listado solo incluir aquellos cuyo precio unitario del artículo oscile 
--entre 500 y 1000.
SELECT *
FROM articulos a
WHERE a.cod_articulo IN (SELECT cod_articulo FROM articulos a1
						 WHERE pre_unitario between 500 and 1000)

--3. Genere un reporte con los clientes que vinieron más de 2 veces el año 
--pasado.
SELECT *
FROM clientes c
WHERE 2 > any (SELECT COUNT(nro_factura) FROM facturas f
					  WHERE YEAR(fecha) = YEAR(getdate())-1
					  AND c.cod_cliente = f.cod_cliente)

--4. Se quiere saber qué clientes no vinieron entre el 12/12/2015 y el 13/7/2020
SELECT * 
FROM clientes
WHERE cod_cliente not in (SELECT cod_cliente FROM facturas
						  WHERE fecha between '12/12/2015' and '13/07/2020')

--5. Listar los datos de las facturas de los clientes que solo vienen a comprar 
--en febrero es decir que todas las veces que vienen a comprar haya sido 
--en el mes de febrero (y no otro mes).  
SELECT * 
FROM facturas f
WHERE EXISTS (SELECT nro_factura FROM facturas f1
			  WHERE MONTH(fecha) = 2
			  AND f1.nro_factura = f.nro_factura)

--6. Mostrar los datos de las facturas para los casos en que por año se hayan 
--hecho menos de 9 facturas.
--NO ENTIENDO

--7. Emitir un reporte con las facturas cuyo importe total haya sido superior a 
--1.500 (incluir en el reporte los datos de los artículos vendidos y los 
--importes).
SELECT fecha, f.nro_factura, cod_cliente, cod_vendedor, df.cod_articulo, SUM(pre_unitario*cantidad) 'Importe'
FROM facturas f
JOIN detalle_facturas df on df.nro_factura = f.nro_factura
WHERE 1500 > all (SELECT SUM(pre_unitario*cantidad) FROM facturas f1
				JOIN detalle_facturas df1 on df1.nro_factura = f1.nro_factura
				WHERE f.nro_factura = f1.nro_factura)
GROUP BY fecha, f.nro_factura, cod_cliente, cod_vendedor, df.cod_articulo
ORDER BY SUM(pre_unitario*cantidad) DESC

--8. Se quiere saber qué vendedores atendieron a estos clientes: 1 y 6. 
--Muestre solamente el nombre del vendedor.
SELECT nom_vendedor
from vendedores
where EXISTS (SELECT nom_vendedor from vendedores v1
			  join facturas f on f.cod_vendedor = v1.cod_vendedor
			  WHERE cod_cliente = 1)

--9. Listar los datos de los artículos que superaron el promedio del Importe 
--de ventas de $ 1.000. 
SELECT * 
FROM articulos a
where 1000 < all (SELECT AVG(pre_unitario*cantidad) FROM detalle_facturas df
				 WHERE a.cod_articulo = df.cod_articulo)

--10. ¿Qué artículos nunca se vendieron? Tenga además en cuenta que su 
--nombre comience con letras que van de la “d” a la “p”.  Muestre 
--solamente la descripción del artículo.
SELECT descripcion
FROM articulos a
WHERE NOT EXISTS (SELECT a1.descripcion from detalle_facturas df
				  JOIN articulos a1 on a1.cod_articulo = df.cod_articulo
				  WHERE a1.descripcion LIKE '[d-p]%')

--11. Listar número de factura, fecha y cliente para los casos en que ese 
--cliente haya sido atendido alguna vez por el vendedor de código 4.
SELECT nro_factura, fecha, cod_cliente, cod_vendedor
FROM facturas f
WHERE 4 = all (SELECT cod_vendedor FROM facturas f1
				WHERE f.cod_cliente = f1.cod_cliente)

--12. Listar número de factura, fecha, artículo, cantidad e importe para los 
--casos en que todas las cantidades (de unidades vendidas de cada 
--artículo) de esa factura sean superiores a 40.
SELECT f.nro_factura, fecha, df.cod_articulo, cantidad, SUM(cantidad*pre_unitario) 'Importe'
FROM facturas f
Join detalle_facturas df on df.nro_factura = f.nro_factura
WHERE 40 < all (SELECT cantidad from detalle_facturas df1
				WHERE df1.nro_factura = df.nro_factura)
GROUP BY f.nro_factura, fecha, df.cod_articulo, cantidad