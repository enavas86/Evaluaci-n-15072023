-- 1.- TABLA
CREATE TABLE [EVA_Clientes](
	id INT IDENTITY(1, 1) PRIMARY KEY,
	primerNombre VARCHAR(250) NOT NULL,
	primeroApellido VARCHAR(250) NOT NULL,
	edad INT,
	fechaCreacion DATETIME
)

ALTER TABLE [EVA_Clientes]
	ADD DEFAULT (GETDATE()) FOR [fechaCreacion]
GO
