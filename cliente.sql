CREATE DATABASE BD_cliente;

use BD_cliente;

create  table cliente(
cedula INT PRIMARY KEY,
nombre VARCHAR(15) not null,
apellido VARCHAR(15) not null,
correo varchar(30) not null,
telefono varchar(15) not null ,
pago float not null
)
INSERT INTO  cliente (cedula,nombre,apellido,correo,telefono,pago) VALUES (1,'KEVIN','ORTEGA','SLASH2130KEVIN@GMAIL.COM','3026009175',1000000)

CREATE PROCEDURE USP_listar
as
begin
	select * from cliente
end

CREATE PROCEDURE USP_consutar
@CC INT
as
begin
SELECT * FROM cliente WHERE cedula = @CC;
end

CREATE PROCEDURE USP_insertar
@CC INT,
@Nombre VARCHAR(15),
@Apellido VARCHAR(15),
@Correo VARCHAR(30),
@Telefono VARCHAR(15),
@PAGO FLOAT
as
begin
INSERT INTO  cliente (cedula,nombre,apellido,correo,telefono,pago) VALUES (@CC,@Nombre,@Apellido,@Correo,@Telefono,@PAGO);
end

CREATE PROCEDURE USP_actualizar
@CC INT,
@Nombre VARCHAR(15),
@Apellido VARCHAR(15),
@Correo VARCHAR(30),
@Telefono VARCHAR(15),
@PAGO FLOAT
as
begin
UPDATE cliente
	SET nombre = @Nombre,
		apellido = @Apellido,
		correo = @Correo,
		telefono = @Telefono,
		pago = @PAGO
		WHERE cedula = @CC
end

CREATE PROCEDURE USP_eliminar
@CC int
as 
begin 
DELETE FROM cliente WHERE cedula = @CC
 end
	 
	  
	   
	    
