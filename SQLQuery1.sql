USE Bibliothèque
GO

create table Clients(
id_client int primary key identity(1,1) not null,
nom varchar(30),
prenom varchar(30),
adresse varchar(30),
telephone nchar(10))

create table Genres(
id_genre int primary key identity(1,1) not null,
lib_genre varchar(30) not null)

create Table Films(
id_film int identity(1,1) primary key not null,
titre varchar(30) not null,
id_genre int foreign key references Genres(id_genre),
acteur_p varchar(30))

create table Livres(
id_livre int primary key identity(1,1) not null,
titre varchar(30) not null,
id_genre int foreign key references Genres(id_genre),
resum_livre varchar(200),
editeur varchar(30))

create table EmpruntsLivres(
id_emprunt_l int primary key identity(1,1) not null,
id_client int foreign key references Clients(id_client),
id_livre int foreign key references Livres(id_livre),
date_emprunt_l date not null,
date_retour_l date)

create table EmpruntsFilms(
id_emprunt_f int primary key identity(1,1) not null,
id_client int foreign key references Clients(id_client),
id_film int foreign key references Films(id_film),
date_emprunt_f date not null,
date_retour_f date)

create table Bibliothèque(
id_bibli int primary key identity(1,1) not null,
adresse_bibli varchar(30),
tel_bibli nchar(10))