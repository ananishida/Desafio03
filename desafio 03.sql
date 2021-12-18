create database Dados
use Dados

create table Usuario
(
id int primary key identity,
nome varchar(30),
email varchar(30),
senha varchar(30)
)

create login acesso with password = 'senha';
create user acesso from login acesso;
exec sp_addrolemember 'DB_DATAREADER', 'acesso';
exec sp_addrolemember 'DB_DATAWRITER', 'acesso';