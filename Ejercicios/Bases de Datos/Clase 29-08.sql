-- ACTIVIDADES Librería 29/08/2024 BD I
USE LIBRERIA

-- Cuánto facturó cada vendedor por día el mes pasado? Listar solo aquellos que hayan hecho 2 o más
-- facturas por día
SELECT day(f.fecha) AS DIA, v.cod_vendedor, df.nro_factura, v.nom_vendedor + ' ' + v.ape_vendedor AS NOMBRE_APELLIDO, sum(df.cantidad*df.pre_unitario) AS MONTO_TOTAL
FROM facturas f
JOIN detalle_facturas df ON df.nro_factura = f.nro_factura
JOIN vendedores v ON v.cod_vendedor = f.cod_vendedor
WHERE datediff(month, fecha, getdate()) = 1
GROUP BY v.cod_vendedor, v.nom_vendedor, v.ape_vendedor, df.nro_factura, day(fecha)
HAVING COUNT(DISTINCT df.nro_factura) >= 2
ORDER BY cod_vendedor, DIA

--Listar todos los clientes y vendedores en una misma tabla de resultados
SELECT c.cod_cliente AS CODIGO, c.nom_cliente + ' ' + c.ape_cliente AS NOMBRE_APELLIDO, 'CLIENTE' AS TIPO
FROM clientes c
UNION
SELECT v.cod_vendedor AS CODIGO, v.nom_vendedor + ' ' + v.ape_vendedor AS NOMBRE_APELLIDO, 'VENDEDOR' AS TIPO
FROM vendedores v
ORDER BY 3, 1, 2

-- Listar los montos totales mensuales facturados de este año y al final
-- del listado se quiere ver el monto total facturado este año
SELECT MONTH(fecha) AS MES, SUM(cantidad*pre_unitario) AS FACTURACION_TOTAL
FROM detalle_facturas df
JOIN facturas f ON f.nro_factura = df.nro_factura
WHERE YEAR(fecha) = YEAR(getdate())-1
GROUP BY MONTH(fecha)
UNION
SELECT year(getdate())-1 AS MES, SUM(cantidad*pre_unitario) AS FACTURACION_TOTAL
FROM detalle_facturas df
JOIN facturas f ON f.nro_factura = df.nro_factura
WHERE YEAR(fecha) = YEAR(getdate())-1

-- view1
CREATE VIEW vis_clientes2
as
select cod_cliente, ape_cliente+', '+nom_cliente as 'NOMBRE COMPLETO',
calle+' '+trim(str(altura))+' B°'+barrio as DIRECCION
from clientes as c JOIN barrios b on b.cod_barrio = c.cod_barrio

-- Consultar la vista anterior para cleintes cuyo apellido comience
-- con letras de la a a la m
select *
from vis_clientes2
where [NOMBRE COMPLETO] like '[a-m]%'