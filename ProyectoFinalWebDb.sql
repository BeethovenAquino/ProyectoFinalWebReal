create database ProyectoFinalWebDb
GO

select *from Inversionns(InversionID,Monto) value (1,4000)

insert into Inversionns(InversionID,Monto) values(1,4000);

select *from Inversionns


SET IDENTITY_INSERT Inversionns ON

INSERT INTO Inversionns (InversionID,Monto) VALUES (1,5000);

SET IDENTITY_INSERT Inversionns OFF