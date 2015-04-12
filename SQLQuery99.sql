create table Personas (
	IdPersona int primary key identity(1,1),
	IsClient bit,
	Ingreso float,
	Cedula varchar(12),
	Telefono varchar(12),
	Direccion varchar(40),
);

create table Motores(
	IdMotor int primary key identity(1,1),
	Fabricante varchar(30),
	Modelo varchar(20),
	IdColor int,
	NumeroChasis varchar(30),
	AProduccion int,
	Precio float,
);

create table Cobros(
	IdCobro int primary key identity(1,1),
	Fecha date,
	Balance float,
	Abono float
);

create table CobroDetalles(
	IdCobroDetalle int primary key identity(1,1),
	IdCobro int ,
	Fecha date,
	BalanceQuota float,
	Interes float,
	BalanceInteres float,	
	Quotas int
);

create table Financiamientos(
	IdFinanciamiento int primary key identity(1,1),
	Fecha date,
	IdPersona int,
	IdGarante int,
	IdCobros int,
	IdMotor int
);

create table Colores (
	IdColor int primary key identity (1,1),
	Color varchar (20)
);


alter table Financiamientos add Balance float;

Insert into CobroDetalles(IdCobro, Fecha, BalanceQuota, Interes,BalanceInteres,Quotas)
 values (1, GetDate(), 5000, 10, 500, 15);
 

 select * from CobroDetalles;