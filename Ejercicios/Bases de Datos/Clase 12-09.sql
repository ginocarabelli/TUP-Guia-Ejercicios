--Clase 12/09
--Genere un reporte con los clientes que vinieron mas de 2 veces el año pasado
SELECT cod_cliente, ape_cliente +' '+ nom_cliente as Cliente
FROM clientes c
WHERE 2 < (select count(*) from facturas f where year(fecha)=YEAR(getdate())-1 and cod_cliente=f.cod_cliente)

--5. Listar los datos de las facturas de los clientes que solo vienen a comprar en febrero , es decir
-- que TODAS las vees que vienen a comprar haya sido en el mes de febrero (y no otro mes)
SELECT *
FROM facturas f
WHERE 2 = all(select MONTH(fecha) from facturas f1 where f.cod_cliente = f1.cod_cliente)

--Clientes que no vinieron nunca
SELECT *
FROM clientes c
WHERE cod_cliente not in (select f.cod_cliente from facturas f)

--Factura de febrero
SELECT *
FROM facturas f
WHERE MONTH(fecha) = 2

--Facturas que no sean de febrero
SELECT nro_factura, cod_cliente, cod_vendedor, fecha
FROM facturas f 
WHERE not exists (SELECT MONTH(fecha) from facturas f1 where f.cod_cliente = f1.cod_cliente and MONTH(fecha) != 2)