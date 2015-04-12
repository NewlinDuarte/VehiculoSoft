CREATE TABLE Usuarios(
	IdUsuario int primary key identity  (1,1) ,
	Fecha date,
	NombreUsuario varchar (30),
	Nombres varchar(60),
	Contra varchar(20),
	Email varchar(30)
);
