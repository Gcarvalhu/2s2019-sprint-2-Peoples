create database T_Peoples;

create table Funcionarios
( IdFuncionario int primary key identity,
	Nome varchar (200) not null,
	Sobrenome varchar(200) not null
)

insert into Funcionarios (Nome,Sobrenome) values
('Gustavo','Carvalho'),
('Erik','Vitelli');

select * from Funcionarios