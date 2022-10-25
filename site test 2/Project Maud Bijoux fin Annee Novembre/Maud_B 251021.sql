/*
Use Master
GO
Drop Database [db_a79b5b_proj6]
GO
*/
/*
Use Master
GO
Drop Database Maud_B
GO
*/

Drop Table Col_Art
Go
Drop Table Collections
go

Drop Table Metal
Go

Drop Table Colors
Go

Drop Table Pierres
Go
Drop Table Genres
go
Drop Table Familles
go
Drop Table Sous_Familles
go

Drop Table Lignes_Demande_Devis
Go
Drop Table Demande_Devis
go

Drop Table Articles
Go
Drop Table Comptes_Clients
go

Drop Table Familles
Go


Drop Table Sous_Familles
Go
Drop Table Type_Article
go
drop table Parametres
go

CREATE DATABASE Maud_B  
ON (NAME = 'Maud_B_Data', 
    FILENAME = 'D:\SQL\Maud_B_Data.MDF' , 
    SIZE = 10, 
    FILEGROWTH = 10%) 
LOG ON (NAME = 'Maud_B_Log', 
        FILENAME = 'D:\SQL\Maud_B_Log.LDF' ,
        SIZE = 5, 
        FILEGROWTH = 10%)
GO

/*Use [db_a79b5b_proj6] 
GO
*/
/*
Use Maud_B
Go
*/


/*EXEC sp_addtype 'Fr_Id',       'char (7)', 'not null'
EXEC sp_addtype 'Fr_Lib',      'varchar (50)', 'not null'
Exec sp_addtype 'Fr_Code',    'Smallint'     , 'not null' 
EXEC sp_addtype 'Fr_Indicatif','varchar (6)' 
GO*/

Set DateFormat dmy
GO

CREATE TABLE Collections
(	Collections_Id  int IDENTITY(1,1), 
	Collections_Lib varchar (50) not null 
)
GO

CREATE TABLE Familles
(	Familles_Id  char(7) not null ,
	Familles_Lib varchar (50) not null
)
GO


CREATE TABLE Genres
(	Genres_Id  char(7) not null ,
	Genres_Lib varchar (50) not null 
)
GO

CREATE TABLE Sous_Familles
(	SS_Fam_Id   char(7) not null ,
	SS_Fam_Lib  varchar (50) not null,
	Familles_Id char(7) not null
)
GO




CREATE TABLE Parametres
(	Param_Num_ID          int IDENTITY(1,1),
	Param_RaiSoc          varchar (50) not null  ,
	Param_Email_Soc       varchar (50) not null   ,
	Param_Chemin_Photos   varchar(200),
	Param_Chemin_Proforma varchar(200)
)
GO



CREATE TABLE Type_Article
(	Type_Art_Id  smallint not null ,
	Type_Art_Lib varchar (50) not null 
)
GO

CREATE TABLE Pierres
(	Pierres_Id  smallint not null ,
	Pierres_Lib varchar (50) not null 
)
GO

CREATE TABLE Metal
(	Metal_Id          smallint not null ,
	Metal_Lib         varchar (50) not null ,
	Metal_Cours       decimal (10,4), /*modification le 26 09 21 */
	Metal_CoursFin    decimal (10,4),/*modification le 26 09 21 */
	Metal_TauxAlliage decimal (4,3),/*modification le 26 09 21 */
	Metal_CoefCours   decimal (4,3),/*modification le 26 09 21 */
	Metal_DateCours   date          /*modification le 26 09 21 */
)
GO

CREATE TABLE Colors
(	Colors_Id  Varchar(3) not null ,
	Colors_Lib varchar (20) not null 
)
GO

CREATE TABLE Articles
(	Art_Num_ID        int IDENTITY(1,1),
	Art_Ref           varchar(20) not null ,
	Art_Libelle       varchar (100) not null  ,
	Art_Description   varchar(250),
	Art_Premium       int , /* 0 par defaut ce n'est pas un article premium , 1:article premium */
	Familles_Id       char(7) not null ,/*Modification le 220921 pour faciliter la recherche en acces rapide */
	SS_Fam_Id         char(7) not null ,
	Genres_Id         char(7) not null ,
	Pierres_Id	      smallint not null ,
	Metal_Id		  smallint not null,
	Colors_Id         varchar(3) null, /*Modification 05/10/21'BLA':'Or Blanc', 'JAU': 'Or Jaune', 'BIC':'Or Bicolore', '3OR': '3 Ors' */
	Type_Art_Id       smallint not null , /* au poids ou a la piece*/
	Art_Poids         decimal(5,2) NULL ,
	Art_PxVte_PubHT   decimal(8,2) NULL , /*modification 220921  prix vente affiche dans la fiche article*/
	Art_PxVte_GrosHT  decimal(8,2) NULL ,/*modification 220921 */
	Art_PxVte_Facon   decimal(6,2) NULL ,/*modification 220921 */
	Art_Fic_Img1	  varchar (50) not null ,
	Art_Fic_Img2	  varchar (50) not null ,
	Art_Fic_Img3	  varchar (50) not null ,
	Art_DatCre        Datetime NOT NULL , /* heure debut yyyy-mm-dd hh:mi:ss  extract hh:mi:ss*/
	Art_DatMaj	      Datetime NOT NULL
)
GO



CREATE TABLE Col_Art
(	Collections_Id  int not null,
	Art_Num_ID  int not null
)
GO

/*
Drop Table Lignes_Demande_Devis
Go
Drop Table Demande_Devis
go

Drop Table Comptes_Clients
go

*/

Create table Comptes_Clients(
	Cptcli_Num_ID        int IDENTITY(1,1),
	Cptcli_Email_Id      varchar (70) not null ,
	Cptcli_Password      varchar (50) not null  ,
	Cptcli_Actif         smallint not null , /* 0 : inactif, 1: actif */
	Cptcli_Acces_Premium smallint not null , /* 0 : non, 1: oui (par defaut 0) */
	Cptcli_Civilite      varchar(8) , /* M., Mme, Melle */
	Cptcli_Nomcli        varchar (50) not null ,
	Cptcli_Prenom        varchar (50) not null ,
	Cptcli_Tel1          varchar(35)  not null,
	Cptcli_RaiSoc        varchar (50) not null ,
	Cptcli_No_Siret      varchar(14),
	Cptcli_No_TVAintra   varchar(13) ,
	Cptcli_Adr1          varchar (100) not null ,
	Cptcli_Adr2          varchar (100),
	Cptcli_CP            varchar(6),
	Cptcli_ville         varchar (50) not null ,
	Cptcli_Pays          varchar (50) not null ,
	Cptcli_Tel2          varchar(35) ,
	Cptcli_RefcliMB      varchar(15) ,
	Cptcli_ComptacliMB   varchar(8) ,
	Cptcli_Cpteur_Devis  int, /* Modif 14 10 21  par defaut a 0 . C'est le nombre de devis pour lesquels le client a deja fait une demande*/
	Cptcli_Cle_secu	     varchar(100), /* Modif du 25 10 2021 */
	Cptcli_DatCre        Date NOT NULL , /* heure debut yyyy-mm-dd hh:mi:ss  extract hh:mi:ss*/
	Cptcli_DatMaj	     Date NOT NULL
)
GO





CREATE TABLE Demande_Devis
(	Demdev_Num_ID      int not null,/* Modif 14 10 21  cle composee de Cptcli_Num_ID et Demdev_NB_Devis*/
    Cptcli_Num_ID      int not null,
	Demdev_Statut      char(2), /* EV: Envoyée / EC:En cours de traitement/ TR:Traité */
	Demdev_MsgCli	   varchar(500) ,
	Demdev_MsgMB	   varchar(500) ,
	Demdev_MontantHT   decimal(8,2) ,/* Modification 260921 */
	Demdev_NB_Lig_Art	int,
	Demdev_NB_Piece		int,
	Demdev_NB_Ligne     int, /* Modif 14 10 21 Nombre de lignes de devis */
	Demdev_DatCre      Datetime NOT NULL ,
	Demdev_DatMaj	   Datetime NOT NULL
)
GO

CREATE TABLE Lignes_Demande_Devis
(	Ligdev_Num_ID    int not null , /* Modif du 14 10 21  cle composee de  Demdev_Num_ID + compteur de ligne article*/
	Demdev_Num_ID    int, /* Modif du 14 10 21 */
	Ligdev_Num_Ligne int, /* Modif du 14 10 21  numero de la ligne dans la demande */ 
  	Art_Num_ID       int ,
	Art_Ref          varchar(20) ,
	Ligdev_Qte	     smallint,
	Ligdev_Poids_TH  decimal(6,2) NULL ,
	Ligdev_Prix_HT   decimal(8,2) NULL , 
	Ligdev_MsgCli    varchar(250),
	Ligdev_PrixVteHT decimal(8,2) /* Modification 260921 */
 )
GO



ALTER TABLE Collections 
ADD
CONSTRAINT PK_Collections_Id PRIMARY KEY ([Collections_Id])
GO

ALTER TABLE  Familles
ADD
CONSTRAINT PK_Familles_Id PRIMARY KEY ([Familles_Id])
GO

ALTER TABLE  Genres
ADD
CONSTRAINT PK_Genre_Id PRIMARY KEY ([Genres_Id])
GO

ALTER TABLE Sous_Familles
ADD
CONSTRAINT PK_SS_Fam_Id PRIMARY KEY ([SS_Fam_Id])
GO

ALTER TABLE Pierres
ADD
CONSTRAINT PK_Pierres_Id PRIMARY KEY ([Pierres_Id])
GO

ALTER TABLE Metal
ADD
CONSTRAINT PK_Metal_Id PRIMARY KEY ([Metal_Id])
GO

ALTER TABLE Colors
ADD
CONSTRAINT PK_Colors_Id PRIMARY KEY ([Colors_Id])
GO

ALTER TABLE  Parametres
ADD
CONSTRAINT PK_Param_Num_ID PRIMARY KEY ([Param_Num_ID])
GO

ALTER TABLE  Type_Article
ADD
CONSTRAINT PK_Type_Art_Id PRIMARY KEY ([Type_Art_Id])
GO

ALTER TABLE  Articles
ADD
CONSTRAINT PK_Art_Num_ID PRIMARY KEY ([Art_Num_ID])
GO

ALTER TABLE  Col_Art
ADD
CONSTRAINT PK_Col_Art_ID PRIMARY KEY ([Collections_Id],[Art_Num_ID])
GO

ALTER TABLE  Comptes_Clients
ADD
CONSTRAINT PK_Cptcli_Num_ID PRIMARY KEY ([Cptcli_Num_ID])
GO

ALTER TABLE  Demande_Devis
ADD
CONSTRAINT PK_Demdev_Num_ID PRIMARY KEY ([Demdev_Num_ID])
GO

ALTER TABLE  Lignes_Demande_Devis
ADD
CONSTRAINT PK_Ligdev_Num_ID PRIMARY KEY ([Ligdev_Num_ID])
GO


ALTER TABLE Sous_Familles
ADD
CONSTRAINT FK_SS_Fam_Familles FOREIGN KEY  ([Familles_Id]) REFERENCES Familles ([Familles_Id])
GO

ALTER TABLE Articles
ADD
CONSTRAINT FK_Articles_Familles FOREIGN KEY  ([Familles_Id]) REFERENCES Familles ([Familles_Id]),
CONSTRAINT FK_Articles_SS_Familles FOREIGN KEY  ([SS_Fam_Id]) REFERENCES Sous_Familles ([SS_Fam_Id]),
CONSTRAINT FK_Articles_Genres  FOREIGN KEY  ([Genres_Id]) REFERENCES Genres ([Genres_Id]),
CONSTRAINT FK_Articles_Pierres FOREIGN KEY  ([Pierres_Id]) REFERENCES Pierres ([Pierres_Id]),
CONSTRAINT FK_Articles_Metal FOREIGN KEY  ([Metal_Id]) REFERENCES Metal ([Metal_Id]),
/*CONSTRAINT FK_Articles_Colors FOREIGN KEY  ([Colors_Id]) REFERENCES Colors ([Colors_Id]), -- supprime le 05/10/21 */
CONSTRAINT FK_Articles_Type_Article FOREIGN KEY  ([Type_Art_Id]) REFERENCES Type_Article ([Type_Art_Id])
GO

ALTER TABLE Col_Art
ADD
CONSTRAINT FK_Col_Art_Collections FOREIGN KEY  ([Collections_Id]) REFERENCES Collections ([Collections_Id]),
CONSTRAINT FK_Col_Art_Articles FOREIGN KEY  ([Art_Num_ID]) REFERENCES Articles ([Art_Num_ID])
GO

ALTER TABLE Demande_Devis
ADD
CONSTRAINT FK_Demande_Devis_Comptes_Clients FOREIGN KEY  ([Cptcli_Num_ID]) REFERENCES Comptes_Clients ([Cptcli_Num_ID])
GO

ALTER TABLE Lignes_Demande_Devis
ADD
CONSTRAINT FK_Lig_Demdev_Demande_Devis FOREIGN KEY  ([Demdev_Num_ID]) REFERENCES Demande_Devis ([Demdev_Num_ID]),
CONSTRAINT FK_Lig_Demdev_Articles FOREIGN KEY  ([Art_Num_ID]) REFERENCES Articles ([Art_Num_ID])
GO

CREATE    INDEX IDX_Cptcli_Email_Id ON Comptes_Clients ([Cptcli_Email_Id])		    
GO

CREATE    INDEX IDX_Cptcli_RaiSoc   ON Comptes_Clients ([Cptcli_RaiSoc])					    
GO

CREATE    INDEX IDX__Articles_Art_Ref ON Articles ([Art_Ref])						    
GO

/*ajout le 05/10/21*/
CREATE    INDEX IDX__Articles_Colors ON Articles ([Colors_Id])						    
GO


/*insertions en base */

INSERT INTO Collections (Collections_Lib) VALUES ('Collection Or 18 Carats 750 millièmes'),
('Collection Or 9 Carats 375 millièmes'),('Collection Diamants'),('Collection Argent 925 millièmes'),
('Collection Acier')
GO

INSERT INTO Familles (Familles_Id,Familles_Lib) 
VALUES ('BG','Bagues'),('BR', 'Bracelets'),('CO','Colliers/Chaines'),('BO', 'Boucles d''oreilles'),('PDT','Pendentifs'),
       ('PG','Percings'),('PAR','Parures')
GO

INSERT INTO Genres (Genres_Id,Genres_Lib)
VALUES ('H','Hommes'),('F','Femmes'),('E','Enfants'),('M','Mixte')
Go

INSERT INTO Sous_Familles (SS_Fam_Id,SS_Fam_Lib,Familles_Id)
VALUES ('ALL','Alliances','BG'),('SOL','Solitaires','BG'),('CHV','Chevalières','BG'),('BGDIV','Autres Bagues...','BG'),
('BRID','Bracelets Identité','BR'),('BRRGD','Bracelets Rigides','BR'),('BRDIV','Autres Bracelets...','BR'),
('CO','Colliers','CO'),('CHFIN','Chaînes Fines','CO'),('CHDIV','Autres Chaînes...','CO'),
('CREO','Créoles','BO'), ('PUCE','Puces','BO'), ('BOPEN','Pendantes','BO'),('BODIV','Autres Boucles d''oreilles...','BO'),
('PDTRG','Pendentifs Religieux','PDT'), ('PLQ','Pendentifs Plaques','PDT'), ('PDTDIV','Autres Pendentifs...','PDT'),
('PGNEZ','Piercings Nez','PG'),('PGDIV','Piercings Divers','PG')
GO


INSERT INTO Parametres (Param_RaiSoc,Param_Email_Soc,Param_Chemin_Photos,Param_Chemin_Proforma)
VALUES ('Maud BIJOUX','Maudbijoux@gmail.com',' ',' ')
GO

INSERT INTO Type_Article (Type_Art_Id,Type_Art_Lib)
VALUES (1,'au poids'), (2,'à la pièce')
GO 

INSERT INTO Pierres (Pierres_Id,Pierres_Lib)
VALUES (10,'Sans Pierres'),(1,'Diamants'),(2,'Rubis'),(3,'Saphirs'),(4,'Emeraudes'),(5,'Diamant & Autres pierres'),(6, 'Pierres semi-Précieuses'),
       (7, 'Oxydes de Zirconium'), (8, 'Onyx'), (9, 'Autres Pierres...')
GO

INSERT INTO Metal (Metal_Id,Metal_Lib,Metal_Cours,Metal_CoursFin,Metal_TauxAlliage,Metal_CoefCours,Metal_DateCours)
VALUES (1,'Or 18 Carats 750 millièmes',38.40,48.00,1.00,0.80,'20/02/2020'), (2,'Or 9 Carats 750 millièmes',15.0745,36.50,1.00,0.413,'27/06/2013'),
(3,'Argent 925 millièmes',1.00,1.00,1.00,1.00,'09/12/2014'),(4,'Acier',0.00,0.00,0.00,0.00,'06/06/2008')
GO

INSERT INTO Colors (Colors_Id,Colors_Lib)
VALUES ('BLA','Or Blanc'), ('JAU','Or Jaune'),('BIC','Or Bicolore'),('3OR','3 Ors')/*,('0',' ')*/
GO

USE Maud_B
GO


INSERT INTO Articles ([Art_Ref],[Art_Libelle],[Art_Description],[Art_Premium],[Familles_Id],[SS_Fam_Id],[Genres_Id],[Pierres_Id],[Metal_Id],
                      [Colors_Id],[Type_Art_Id],[Art_Poids],[Art_PxVte_PubHT],[Art_PxVte_GrosHT],[Art_PxVte_Facon],[Art_Fic_Img1],
					  [Art_Fic_Img2],[Art_Fic_Img3],[Art_DatCre],[Art_DatMaj])
 VALUES 
 ('10115'	,'Alliance OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°°, Alliance Femme en Serti Rail d''une Rangée de 11 Oxydes de Zirconium.'	,1	,'BG'	,'ALL'	,'F'	,7	,1	,'JAU'	,1	,1.94	,94.23	,0	,8.5	,'10115.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('10206'	,'Alliance OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°°  ,Alliance Femme sertie d''une Rangée de 9 Oxydes de Zirconium.'	,1	,'BG'	,'ALL'	,'F'	,7	,1	,'JAU'	,1	,0.86	,41.64	,0	,8.5	,'10206.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('23630W'	,'Bague Alliance en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Alliance Femme sertie de deux Rangs en Oxyde de Zirconium (OZ).'	,1	,'BG'	,'ALL'	,'F'	,7	,1	,'BLA'	,1	,2.8	,133.56	,0	,8.5	,'23630W.jpg'	,''	,''	,'20211008 16:56:03'	,'20211008 16:56:03')	,
('23631'	,'Bague Alliance en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°°Alliance Femme sertie d''une Rangée en Oxydes de Zirconium (OZ).'	,0	,'BG'	,'ALL'	,'F'	,7	,1	,'JAU'	,1	,2.3	,109.71	,0	,8.5	,'23631.jpg'	,''	,''	,'20211008 16:55:05'	,'20211008 16:55:05')	,
('23631W'	,'Bague Alliance en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°°Alliance Femme sertie d''une Rangée avec des Oxydes de Zirconium (OZ).'	,0	,'BG'	,'ALL'	,'F'	,7	,1	,'BLA'	,1	,2.2	,104.94	,0	,8.5	,'23631W.jpg'	,''	,''	,'20211008 16:56:04'	,'20211008 16:56:04')	,
('23637'	,'Bague Alliance en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°°Alliance Femme sertie d''une Rangée d''Oxydes de Zirconium (OZ).'	,1	,'BG'	,'ALL'	,'F'	,7	,1	,'JAU'	,1	,1.7	,81.09	,0	,8.5	,'23637.jpg'	,''	,''	,'20211008 16:55:09'	,'20211008 16:55:09')	,
('23637DIA'	,'Bague Alliance en OR Jaune 18 Carats 750/°°° & Diamant'	,'OR Jaune 18 Carats 750/°°°Alliance Femme sertie d''une Rangée de Diamants de 0,24 Carats'	,0	,'BG'	,'ALL'	,'F'	,1	,1	,'JAU'	,2	,1.8	,342.99	,0	,272.43	,'23637DIA.jpg'	,''	,''	,'20211008 16:59:27'	,'20211008 16:59:27')	,
('23637DIAW'	,'Bague Alliance en OR Blanc 18 Carats 750/°°° & Diamant'	,'OR Blanc 18 Carats 750/°°°Alliance Femme sertie d''une Rangée de Diamants de  0,24 Cts'	,0	,'BG'	,'ALL'	,'F'	,1	,1	,'BLA'	,2	,1.8	,342.99	,0	,272.43	,'23637DIAW.jpg'	,''	,''	,'20211008 16:59:28'	,'20211008 16:59:28')	,
('23637W'	,'Bague Alliance en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°°Alliance Femme sertie d''une Rangée d''Oxydes de Zirconium (OZ).'	,0	,'BG'	,'ALL'	,'F'	,7	,1	,'BLA'	,1	,1.8	,85.86	,0	,8.5	,'23637W.jpg'	,''	,''	,'20211008 16:56:09'	,'20211008 16:56:09')	,
('23651'	,'Bague Alliance en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Alliance Femme sertie d''une Rangée avec des Oxydes de Zirconium (OZ).'	,0	,'BG'	,'ALL'	,'F'	,7	,1	,'JAU'	,1	,1.7	,81.09	,0	,8.5	,'23651.jpg'	,''	,''	,'20211008 16:55:11'	,'20211008 16:55:11')	,
('23651DIA'	,'Bague Alliance en OR Blanc 18 Carats 750/°°° & Diamant'	,'OR Jaune 18 Carats 750/°°°Alliance Femme sertie d''une Rangée de Diamants de 0,40 Cts'	,1	,'BG'	,'ALL'	,'F'	,1	,1	,'JAU'	,2	,1.8	,523.71	,0	,453.15	,'23651DIA.jpg'	,''	,''	,'20211008 16:59:29'	,'20211008 16:59:29')	,
('23651DIAW'	,'Bague Alliance en OR Blanc 18 Carats 750/°°° & Diamant'	,'OR Blanc 18 Carats 750/°°° Alliance Femme sertie d''une Rangée de Diamants de  0,40 Cts'	,1	,'BG'	,'ALL'	,'F'	,1	,1	,'BLA'	,2	,1.8	,523.71	,0	,453.15	,'23651DIAW.jpg'	,''	,''	,'20211008 16:59:30'	,'20211008 16:59:30')	,
('23651W'	,'Bague Alliance en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Alliance Femme sertie d''une Rangée d''Oxydes de Zirconium (OZ).'	,1	,'BG'	,'ALL'	,'F'	,7	,1	,'BLA'	,1	,1.7	,81.09	,0	,8.5	,'23651W.jpg'	,''	,''	,'20211008 16:56:11'	,'20211008 16:56:11')	,
('23653'	,'Bague Alliance en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Alliance Femme sertie d''une Rangée en Oxyde de Zirconium (OZ).'	,1	,'BG'	,'ALL'	,'F'	,7	,1	,'JAU'	,1	,2.2	,104.94	,0	,8.5	,'23653.jpg'	,''	,''	,'20211008 16:55:12'	,'20211008 16:55:12')	,
('23653W'	,'Bague Alliance en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Alliance Femme sertie d''une Rangée d''Oxydes de Zirconium (OZ).'	,1	,'BG'	,'ALL'	,'F'	,7	,1	,'BLA'	,1	,2	,95.40	,0	,8.5	,'23653W.jpg'	,''	,''	,'20211008 16:56:12'	,'20211008 16:56:12')	,
('23653WD'	,'Bague Alliance en OR Jaune 18 Carats 750/°°° & Diamant'	,'OR Jaune 18 Carats 750/°°° Alliance Femme sertie d''une Rangée de Diamants de 0,17 Cts'	,1	,'BG'	,'ALL'	,'F'	,1	,1	,'JAU'	,2	,2	,294.62	,0	,216.22	,'23653WD.jpg'	,''	,''	,'20211008 16:59:31'	,'20211008 16:59:31')	,
('23653WD'	,'Bague Alliance en OR Blanc 18 Carats 750/°°° & Diamant'	,'OR Blanc 18 Carats 750/°°° Alliance Femme sertie d''une Rangée de Diamants de  0,17 Cts'	,1	,'BG'	,'ALL'	,'F'	,1	,1	,'BLA'	,2	,2	,294.62	,0	,216.22	,'23653WD.jpg'	,''	,''	,'20211008 16:59:32'	,'20211008 16:59:32')	,
('10203'	,'Bague OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°°  ,Bague Femme Entourage de Fiançailles  , Marquise ornée d''un Centre en Oxyde de Zirconium  , Navette de 5*3 .5 mm  et de 8 OZ Ronds de 2 mm'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'JAU'	,1	,1.62	,78.89	,0	,8.5	,'10203.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('11230'	,'Bague OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°°  ,Bague Femme 2 Rangs de 5 mm de Largeur avec 11 Oxydes de Zirconium de 2 mm de chaque côté.'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'JAU'	,1	,2.43	,118.34	,0	,8.5	,'11230.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('11815'	,'Bague OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°°  ,Bague de Fiançailles Femme Entourage ornée de 24 Oxydes de Zirconium sur 2 rangées avec 1 centre ovale en O.Z de 6  ,5*4 .5 mm'	,0	,'BG'	,'BGDIV'	,'F'	,7	,1	,'JAU'	,1	,2.61	,127.11	,0	,8.5	,'11815.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('14818'	,'Bague OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°°, Bague Femme Entrelacée sertie de 3 Oxydes de Zirconium de 2.2 mm.'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'JAU'	,1	,1.69	,82.4	,0	,8.5	,'14818.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('15006'	,'Bague OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°°, Bague Femme Rhodiée en Pavé ornée de 30 Oxydes de Zirconium sur 2 rangées en serti Griffes.'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'JAU'	,1	,4.01	,195.04	,0	,8.5	,'15006.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('17050'	,'Bague OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°°  ,Bague Femme en forme de Cœur  , Pavé Rhodié orné de 6 Oxydes de Zirconium.'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'JAU'	,1	,1.31	,63.55	,0	,8.5	,'17050.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('17525'	,'Bague OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°°  ,Bague Femme de Fiançailles avec Oxyde de Zirconium. Centre OZ Rond de 6 mm et 6 Ronds OZ de 3 mm'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'JAU'	,1	,2.34	,113.96	,0	,8.5	,'17525.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('19824'	,'Bague OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°°  ,Bague en Forme de Cœur ornée de 18 Oxydes de Zirconium serti griffes.'	,0	,'BG'	,'BGDIV'	,'F'	,7	,1	,'JAU'	,1	,1.13	,54.79	,0	,8.5	,'19824.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('19834'	,'Bague OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°°  ,Bague Entrelacée ornée de 21 Oxydes de Zirconium sur 2 rangées en serti Griffes.'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'JAU'	,1	,1.67	,81.09	,0	,8.5	,'19834.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('19834W'	,'Bague OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°°, Bague Femme Rhodiée Entrelacée ornée de 21 Oxydes de Zirconium sur 2 rangées en serti Griffes.'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'JAU'	,1	,1.67	,81.09	,0	,8.5	,'19834W.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('19850'	,'Bague OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°°, Bague Femme Pavé  , ornée de 50 Oxydes de Zirconium sur 4 rangées en serti Griffes.'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'JAU'	,1	,2.51	,122.29	,0	,8.5	,'19850.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('20979'	,'Bague OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°°, Bague Femme Pavé ornée de 14 Oxydes de Zirconium sur une rangée en serti Griffes.'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'JAU'	,1	,1.81	,88.1	,0	,8.5	,'20979.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('21235'	,'Bague OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°°  ,Bague Cœur avec Oxyde de Zirconium  , sertie de 14 OZ Ronds.'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'JAU'	,1	,2.43	,118.34	,0	,8.5	,'21235.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('21251'	,'Bague OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°°  ,Bague Entrelacée sertie de 60 Oxydes de Zirconium.'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'JAU'	,1	,2.61	,127.11	,0	,8.5	,'21251.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('21272'	,'Bague OR Bicolore 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Bicolore 18 Carats 750/°°°, Bague Femme Rhodiée en Pavé ornée de 6 Oxydes de Zirconium sur 2 rangées en serti Griffes.'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'BIC'	,1	,2.74	,133.24	,0	,8.5	,'21272.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('21356'	,'Bague OR Bicolore 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Bicolore 18 Carats 750/°°°, Bague Femme Rhodiée en Pavé ornée de 12 Oxydes de Zirconium sur 2 rangées en serti Griffes.'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'BIC'	,1	,1.6	,78.02	,0	,8.5	,'21356.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('21357'	,'Bague OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°°  ,Bague ornée de 25 Oxydes de Zirconium.'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'JAU'	,1	,2.03	,98.62	,0	,8.5	,'21357.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22355'	,'Bague OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°°, Bague Femme Toi & Moi ornée de 2 Oxydes de Zirconium en serti Griffes.'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'JAU'	,1	,1.4	,67.94	,0	,8.5	,'22355.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22357'	,'Bague OR Bicolore 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Bicolore 18 Carats 750/°°°, Bague Femme Fleur Rhodiée  , Pavé orné de 7 Oxydes de Zirconium en serti Griffes.'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'BIC'	,1	,2.48	,120.53	,0	,8.5	,'22357.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22361'	,'Bague OR Bicolore 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Bicolore 18 Carats 750/°°°, Bague Femme Fleur Rhodiée  , Pavé orné de 11 Oxydes de Zirconium en serti Griffes.'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'BIC'	,1	,2.34	,113.96	,0	,8.5	,'22361.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22365'	,'Bague OR Bicolore 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Bicolore 18 Carats 750/°°°,Bague Femme Rhodiée  , Pavé orné de 14 Oxydes de Zirconium en serti Griffes.'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'BIC'	,1	,2.64	,128.42	,0	,8.5	,'22365.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22366'	,'Bague OR Bicolore 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Bicolore 18 Carats 750/°°°, Bague Femme Cœur Rhodiée et Ornée de 3 Oxydes de Zirconium en serti Griffes.'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'BIC'	,1	,2.42	,117.9	,0	,8.5	,'22366.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22367'	,'Bague OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°°, Bague Femme Fleur  , Pavé orné de 10 Oxydes de Zirconium en serti Griffes.'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'JAU'	,1	,2.09	,101.69	,0	,8.5	,'22367.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22368'	,'Bague OR Bicolore 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Bicolore 18 Carats 750/°°°, Bague Femme Rhodiée  , Pavé orné de 9 Oxydes de Zirconium en serti Rail.'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'BIC'	,1	,2.39	,116.15	,0	,8.5	,'22368.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22369'	,'Bague OR Bicolore 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Bicolore 18 Carats 750/°°°  , Bague Femme Cœur Rhodiée et Ornée de 10 Oxydes de Zirconium en serti Griffes.'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'BIC'	,1	,1.38	,67.06	,0	,8.5	,'22369.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22370'	,'Bague OR Bicolore 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Bicolore 18 Carats 750/°°°  , Bague Femme Rhodiée et Ornée de 22 Oxydes de Zirconium en serti Griffes.'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'BIC'	,1	,2.22	,108.26	,0	,8.5	,'22370.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22371'	,'Bague OR Bicolore 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Bicolore 18 Carats 750/°°°  , Bague Femme Rhodiée et Ornée de 45 Oxydes de Zirconium en serti Griffes.'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'BIC'	,1	,2.39	,116.59	,0	,8.5	,'22371.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('23629'	,'Bague Pavé en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Bague Femme Pavé & Oxydes de Zirconium (OZ).'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'JAU'	,1	,3.4	,162.18	,0	,8.5	,'23629.jpg'	,''	,''	,'20211008 16:55:03'	,'20211008 16:55:03')	,
('23629W'	,'Bague en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Bague Femme en forme de Pavé & Oxydes de Zirconium (OZ).'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'BLA'	,1	,3.3	,157.41	,0	,8.5	,'23629W.jpg'	,''	,''	,'20211008 16:56:02'	,'20211008 16:56:02')	,
('23630'	,'Bague Alliance en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Alliance Femme sertie de deux Rangs  en Oxyde de Zirconium (OZ).'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'JAU'	,1	,2.8	,133.56	,0	,8.5	,'23630.jpg'	,''	,''	,'20211008 16:55:04'	,'20211008 16:55:04')	,
('23632'	,'Bague en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Bague Femme Croisée & Oxydes de Zirconium (OZ).'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'JAU'	,1	,2.9	,138.33	,0	,8.5	,'23632.jpg'	,''	,''	,'20211008 16:55:06'	,'20211008 16:55:06')	,
('23632W'	,'Bague en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Bague Femme Croisée & Oxydes de Zirconium (OZ).'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'BLA'	,1	,2.8	,133.56	,0	,8.5	,'23632W.jpg'	,''	,''	,'20211008 16:56:05'	,'20211008 16:56:05')	,
('23633'	,'Bague en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Bague Femme & Oxydes de Zirconium (OZ).'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'JAU'	,1	,2.55	,121.64	,0	,8.5	,'23633.jpg'	,''	,''	,'20211008 16:55:07'	,'20211008 16:55:07')	,
('23633W'	,'Bague en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Bague Femme en Oxydes de Zirconium (OZ).'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'BLA'	,1	,2.4	,114.48	,0	,8.5	,'23633W.jpg'	,''	,''	,'20211008 16:56:06'	,'20211008 16:56:06')	,
('23635W'	,'Bague en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Bague Femme avec Oxydes de Zirconium (OZ) avec un zircon central.'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'BLA'	,1	,1.9	,90.63	,0	,8.5	,'23635W.jpg'	,''	,''	,'20211008 16:56:07'	,'20211008 16:56:07')	,
('23636'	,'Bague en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Bague Femme & Oxydes de Zirconium (OZ).'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'JAU'	,1	,1.9	,90.63	,0	,8.5	,'23636.jpg'	,''	,''	,'20211008 16:55:08'	,'20211008 16:55:08')	,
('23636W'	,'Bague en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Bague Femme avec Oxydes de Zirconium (OZ).'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'BLA'	,1	,1.8	,85.86	,0	,8.5	,'23636W.jpg'	,''	,''	,'20211008 16:56:08'	,'20211008 16:56:08')	,
('23638'	,'Bague en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Bague Femme en Pavé avec Oxydes de Zirconium (OZ).'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'JAU'	,1	,3.5	,166.95	,0	,8.5	,'23638.jpg'	,''	,''	,'20211008 16:55:10'	,'20211008 16:55:10')	,
('23638W'	,'Bague en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Bague Femme  Pavé Oxydes de Zirconium (OZ).'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'BLA'	,1	,3.2	,152.64	,0	,8.5	,'23638W.jpg'	,''	,''	,'20211008 16:56:10'	,'20211008 16:56:10')	,
('23656'	,'Bague en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Bague Femme sertie avec des Oxydes de Zirconium (OZ) et un Zircon Central.'	,0	,'BG'	,'BGDIV'	,'F'	,7	,1	,'JAU'	,1	,2.2	,104.94	,0	,8.5	,'23656.jpg'	,''	,''	,'20211008 16:55:13'	,'20211008 16:55:13')	,
('23656DIA'	,'Bague en OR Jaune 18 Carats 750/°°° & Diamant'	,'OR Jaune 18 Carats 750/°°° Bague Femme sertie de Diamants de 0,45 Cts'	,1	,'BG'	,'BGDIV'	,'F'	,1	,1	,'JAU'	,2	,1.6	,470.00	,0	,407.28	,'23656DIA.jpg'	,''	,''	,'20211008 16:59:34'	,'20211008 16:59:34')	,
('23656DIAW'	,'Bague en OR Blanc750/°°° & Diamant'	,'OR Blanc 18 Carats 750/°°° Bague Femme sertie de Diamants de  0,45 Cts'	,1	,'BG'	,'BGDIV'	,'F'	,1	,1	,'BLA'	,2	,1.6	,470.00	,0	,407.28	,'23656DIAW.jpg'	,''	,''	,'20211008 16:59:33'	,'20211008 16:59:33')	,
('8109'	,'Bague OR Bicolore 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Bicolore 18 Carats 750/°°°  ,Bague Pavage Rhodiée sertie de 17 Oxydes de Zirconium.'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'BIC'	,1	,2.34	,113.96	,0	,8.5	,'8109.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('8208'	,'Bague OR Bicolore 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Bicolore 18 Carats 750/°°°  ,Marquise Rhodiée sertie Pavé de 21 Oxydes de Zirconium.'	,1	,'BG'	,'BGDIV'	,'F'	,7	,1	,'BIC'	,1	,1.89	,92.04	,0	,8.5	,'8208.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('8768'	,'Bague  en OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°.Bague Femme Maille Américaine de 9 mm de Largeur, Maille Entrelacée et Martelée.'	,1	,'BG'	,'BGDIV'	,'F'	,10	,1	,'JAU'	,1	,3.7	,176.49	,0	,8.5	,'8768.jpg'	,''	,''	,'20211008 16:55:00'	,'20211008 16:55:00')	,
('8768W '	,'Bague en OR Blanc 18 Carats 750/°°°'	,'OR Blanc 18 Carats 750/°°°.Bague Femme Américaine de 9 mm de Largeur. Maille Entrelacée et Martelée.'	,1	,'BG'	,'BGDIV'	,'F'	,10	,1	,'BLA'	,1	,3.35	,159.8	,0	,8.5	,'8768W .jpg'	,''	,''	,'20211008 16:57:12'	,'20211008 16:57:12')	,
('R155'	,'Bague en OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°.Bague Femme Maille Palmier Tressé de 7 mm de Largeur dégradé.'	,1	,'BG'	,'BGDIV'	,'F'	,10	,1	,'JAU'	,1	,2.45	,116.87	,0	,8.5	,'R155.jpg'	,''	,''	,'20211008 16:57:14'	,'20211008 16:57:14')	,
('9208'	,'Bague OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°°  ,Bague Jonc de 8 mm de Largeur et 1 centre en Oxyde de Zirconium de 4mm'	,1	,'BG'	,'CHV'	,'H'	,7	,1	,'JAU'	,1	,4.05	,197.24	,0	,8.5	,'9208.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('9214'	,'Chevalière en OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°.Chevalière Homme  9 Planetes avec Oxyde de Zirconium (OZ) Multicolores.'	,1	,'BG'	,'CHV'	,'H'	,7	,1	,'JAU'	,1	,4.8	,228.96	,0	,8.5	,'9214.jpg'	,''	,''	,'20211008 16:57:13'	,'20211008 16:57:13')	,
('14346'	,'Solitaire OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°°  ,Solitaire Femme avec Oxyde de Zirconium  , Centre OZ Rond de 6.2 mm '	,0	,'BG'	,'SOL'	,'F'	,7	,1	,'JAU'	,1	,1.44	,70.13	,0	,8.5	,'14346.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('14716'	,'Bague OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°°, Solitaire Femme Toi & Moi avec Oxydes de Zirconium, 2 Centres OZ Ronds de 2.8 mm.'	,1	,'BG'	,'SOL'	,'F'	,7	,1	,'JAU'	,1	,1.67	,81.09	,0	,8.5	,'14716.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('17496'	,'Bague OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°°  ,Solitaire Femme avec Oxyde de Zirconium  , Centre Ovale de 6*4 mm avec 2 Trapèzes de chaque côté.'	,1	,'BG'	,'SOL'	,'F'	,7	,1	,'JAU'	,1	,1.31	,63.55	,0	,8.5	,'17496.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('19844'	,'Solitaire OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°°  ,Solitaire OR Jaune Toi & Moi avec Oxyde de Zirconium  , 2 Centres OZ Ronds de 3 mm '	,1	,'BG'	,'SOL'	,'F'	,7	,1	,'JAU'	,1	,2.12	,103	,0	,8.5	,'19844.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('21376'	,'Solitaire OR Bicolore 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Bicolore 18 Carats 750/°°°  ,Solitaire Rhodié avec Oxyde de Zirconium  , Centre OZ Princesse de 3 mm '	,1	,'BG'	,'SOL'	,'F'	,7	,1	,'BIC'	,1	,2.12	,103	,0	,8.5	,'21376.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('8279'	,'Solitaire OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°°  ,Solitaire avec Oxyde de Zirconium  , Centre OZ Rond de 4 mm et 10 O.Z. Ronds Latéraux'	,0	,'BG'	,'SOL'	,'F'	,7	,1	,'JAU'	,1	,1.89	,92.04	,0	,8.5	,'8279.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('8282'	,'Solitaire OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°°  ,Solitaire avec Oxyde de Zirconium  , Centre OZ Rond de 4 mm et 10 OZ Ronds latéraux'	,1	,'BG'	,'SOL'	,'F'	,7	,1	,'BLA'	,1	,1.89	,92.04	,0	,8.5	,'8282.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('23055'	,'Boucles d''Oreilles Cœur  en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme en Coeur avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'JAU'	,1	,2.3	,109.71	,0	,8.5	,'23055.jpg'	,''	,''	,'20211008 16:55:02'	,'20211008 16:55:02')	,
('23055W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Coeur & Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'BLA'	,1	,2.2	,104.94	,0	,8.5	,'23055W.jpg'	,''	,''	,'20211008 16:55:59'	,'20211008 16:55:59')	,
('23714'	,'Boucles d''Oreilles en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme Papillon Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'JAU'	,1	,1.1	,52.47	,0	,8.5	,'23714.jpg'	,''	,''	,'20211008 16:55:20'	,'20211008 16:55:20')	,
('23714W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Papillon avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'BLA'	,1	,1.6	,76.32	,0	,8.5	,'23714W.jpg'	,''	,''	,'20211008 16:56:24'	,'20211008 16:56:24')	,
('23715'	,'Boucles d''Oreilles en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme en forme de Rond & Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'JAU'	,1	,1.5	,71.55	,0	,8.5	,'23715.jpg'	,''	,''	,'20211008 16:55:21'	,'20211008 16:55:21')	,
('23715W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Ronde avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'BLA'	,1	,1.8	,85.86	,0	,8.5	,'23715W.jpg'	,''	,''	,'20211008 16:56:25'	,'20211008 16:56:25')	,
('23718'	,'Boucles d''Oreilles en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme Cœur double avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'JAU'	,1	,1.8	,85.86	,0	,8.5	,'23718.jpg'	,''	,''	,'20211008 16:55:22'	,'20211008 16:55:22')	,
('23718W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Coeur avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'BLA'	,1	,1.8	,85.86	,0	,8.5	,'23718W.jpg'	,''	,''	,'20211008 16:56:26'	,'20211008 16:56:26')	,
('23720'	,'Boucles d''Oreilles Créoles en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme Créoles avec  Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'JAU'	,1	,2.4	,114.48	,0	,8.5	,'23720.jpg'	,''	,''	,'20211008 16:55:24'	,'20211008 16:55:24')	,
('23720W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Créoles avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'BLA'	,1	,2.4	,114.48	,0	,8.5	,'23720W.jpg'	,''	,''	,'20211008 16:56:28'	,'20211008 16:56:28')	,
('23721'	,'Boucles d''Oreilles en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme Créoles avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'JAU'	,1	,1.9	,90.63	,0	,8.5	,'23721.jpg'	,''	,''	,'20211008 16:55:25'	,'20211008 16:55:25')	,
('23721W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Créoles avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'BLA'	,1	,1.95	,93.02	,0	,8.5	,'23721W.jpg'	,''	,''	,'20211008 16:56:29'	,'20211008 16:56:29')	,
('23722'	,'Boucles d''Oreilles Créoles en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme Créoles avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'JAU'	,1	,2.2	,104.94	,0	,8.5	,'23722.jpg'	,''	,''	,'20211008 16:55:26'	,'20211008 16:55:26')	,
('23722W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Créoles avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'BLA'	,1	,2.1	,100.17	,0	,8.5	,'23722W.jpg'	,''	,''	,'20211008 16:56:30'	,'20211008 16:56:30')	,
('23724W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Feuille avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'BLA'	,1	,1.85	,88.25	,0	,8.5	,'23724W.jpg'	,''	,''	,'20211008 16:56:31'	,'20211008 16:56:31')	,
('23725 DIA'	,'Boucles d''Oreilles en OR Jaune 18 Carats 750/°°° & Diamant'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme  & Diamants de  0,04 Cts'	,1	,'BO'	,'BODIV'	,'F'	,1	,1	,'JAU'	,2	,1.25	,127.10	,0	,78.1	,'23725 DIA.jpg'	,''	,''	,'20211008 16:59:39'	,'20211008 16:59:39')	,
('23725 DIAW'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Diamant'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme & Diamants de 0,04Cts'	,1	,'BO'	,'BODIV'	,'F'	,1	,1	,'BLA'	,2	,1.25	,127.10	,0	,78.1	,'23725 DIAW.jpg'	,''	,''	,'20211008 16:59:40'	,'20211008 16:59:40')	,
('23725W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme  avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'BLA'	,1	,1.25	,59.63	,0	,8.5	,'23725W.jpg'	,''	,''	,'20211008 16:56:32'	,'20211008 16:56:32')	,
('23726'	,'Boucles d''Oreilles en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme & Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'JAU'	,1	,1	,47.7	,0	,8.5	,'23726.jpg'	,''	,''	,'20211008 16:55:27'	,'20211008 16:55:27')	,
('23726W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme  avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'BLA'	,1	,1.2	,57.24	,0	,8.5	,'23726W.jpg'	,''	,''	,'20211008 16:56:33'	,'20211008 16:56:33')	,
('23727'	,'Boucles d''Oreilles Goutte en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme en forme de Goutte avec  Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'JAU'	,1	,1.7	,81.09	,0	,8.5	,'23727.jpg'	,''	,''	,'20211008 16:55:28'	,'20211008 16:55:28')	,
('23727W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Goutte avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'BLA'	,1	,1.8	,85.86	,0	,8.5	,'23727W.jpg'	,''	,''	,'20211008 16:56:34'	,'20211008 16:56:34')	,
('23728'	,'Boucles d''Oreilles Fleur en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme  en forme de Fleur & Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'JAU'	,1	,1.4	,66.78	,0	,8.5	,'23728.jpg'	,''	,''	,'20211008 16:55:29'	,'20211008 16:55:29')	,
('23728W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'BLA'	,1	,1.4	,66.78	,0	,8.5	,'23728W.jpg'	,''	,''	,'20211008 16:56:35'	,'20211008 16:56:35')	,
('23729'	,'Boucles d''Oreilles en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme en forme de Coeur  avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'JAU'	,1	,1.7	,81.09	,0	,8.5	,'23729.jpg'	,''	,''	,'20211008 16:55:30'	,'20211008 16:55:30')	,
('23729 DIA'	,'Boucles d''Oreilles en OR Jaune 18 Carats 750/°°° & Diamant'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme Coeur & Diamants de 0,03 Cts'	,1	,'BO'	,'BODIV'	,'F'	,1	,1	,'JAU'	,2	,1.7	,143.35	,0	,76.71	,'23729 DIA.jpg'	,''	,''	,'20211008 16:59:41'	,'20211008 16:59:41')	,
('23729DIAW'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Diamant'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Coeur & Diamants de  0,03 Cts'	,1	,'BO'	,'BODIV'	,'F'	,1	,1	,'BLA'	,2	,1.7	,143.35	,0	,76.71	,'23729DIAW.jpg'	,''	,''	,'20211008 16:59:42'	,'20211008 16:59:42')	,
('23729W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Coeur avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'BLA'	,1	,1.7	,81.09	,0	,8.5	,'23729W.jpg'	,''	,''	,'20211008 16:56:36'	,'20211008 16:56:36')	,
('23730W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'BLA'	,1	,1.4	,66.78	,0	,8.5	,'23730W.jpg'	,''	,''	,'20211008 16:56:37'	,'20211008 16:56:37')	,
('23733'	,'Boucles d''Oreilles Trèfle en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme en forme de Trèfle avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'JAU'	,1	,1.5	,71.55	,0	,8.5	,'23733.jpg'	,''	,''	,'20211008 16:55:31'	,'20211008 16:55:31')	,
('23733W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Trèfle Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'BLA'	,1	,1.5	,71.55	,0	,8.5	,'23733W.jpg'	,''	,''	,'20211008 16:56:38'	,'20211008 16:56:38')	,
('23734'	,'Boucles d''Oreilles Trèfle en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme en forme de Trèfle avec Oxydes de Zirconium (OZ).'	,0	,'BO'	,'BODIV'	,'F'	,7	,1	,'JAU'	,1	,1.6	,76.32	,0	,8.5	,'23734.jpg'	,''	,''	,'20211008 16:55:32'	,'20211008 16:55:32')	,
('23734W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Trèfle avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'BLA'	,1	,1.4	,66.78	,0	,8.5	,'23734W.jpg'	,''	,''	,'20211008 16:56:39'	,'20211008 16:56:39')	,
('23735'	,'Boucles d''Oreilles en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'JAU'	,1	,1.6	,76.32	,0	,8.5	,'23735.jpg'	,''	,''	,'20211008 16:55:33'	,'20211008 16:55:33')	,
('23735W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'BLA'	,1	,1.6	,76.32	,0	,8.5	,'23735W.jpg'	,''	,''	,'20211008 16:56:40'	,'20211008 16:56:40')	,
('23736'	,'Boucles d''Oreilles en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme Coeur avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'JAU'	,1	,1.6	,76.32	,0	,8.5	,'23736.jpg'	,''	,''	,'20211008 16:55:34'	,'20211008 16:55:34')	,
('23736W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Coeur avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'BLA'	,1	,1.8	,85.86	,0	,8.5	,'23736W.jpg'	,''	,''	,'20211008 16:56:41'	,'20211008 16:56:41')	,
('23739'	,'Boucles d''Oreilles Coeur en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme en forme de Coeur avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'JAU'	,1	,1.7	,81.09	,0	,8.5	,'23739.jpg'	,''	,''	,'20211008 16:55:37'	,'20211008 16:55:37')	,
('23739W'	,'Boucles d''Oreilles Coeur en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Coeur avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'BLA'	,1	,1.7	,81.09	,0	,8.5	,'23739W.jpg'	,''	,''	,'20211008 16:56:44'	,'20211008 16:56:44')	,
('23740'	,'Boucles d''Oreilles en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'JAU'	,1	,1.6	,76.32	,0	,8.5	,'23740.jpg'	,''	,''	,'20211008 16:55:38'	,'20211008 16:55:38')	,
('23740W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'BLA'	,1	,1.7	,81.09	,0	,8.5	,'23740W.jpg'	,''	,''	,'20211008 16:56:45'	,'20211008 16:56:45')	,
('23752'	,'Boucles d''Oreilles Papillon en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme Papillon & Oxydes de Zirconium (OZ).'	,0	,'BO'	,'BODIV'	,'F'	,7	,1	,'JAU'	,1	,1.8	,85.86	,0	,8.5	,'23752.jpg'	,''	,''	,'20211008 16:55:40'	,'20211008 16:55:40')	,
('23752W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Papillon avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'BLA'	,1	,1.8	,85.86	,0	,8.5	,'23752W.jpg'	,''	,''	,'20211008 16:56:47'	,'20211008 16:56:47')	,
('23754'	,'Boucles d''Oreilles en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme & Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'JAU'	,1	,2.4	,114.48	,0	,8.5	,'23754.jpg'	,''	,''	,'20211008 16:55:41'	,'20211008 16:55:41')	,
('23754W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'BLA'	,1	,2.35	,112.10	,0	,8.5	,'23754W.jpg'	,''	,''	,'20211008 16:56:48'	,'20211008 16:56:48')	,
('23759'	,'Boucles d''Oreilles en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme & Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'JAU'	,1	,2.9	,138.33	,0	,8.5	,'23759.jpg'	,''	,''	,'20211008 16:55:42'	,'20211008 16:55:42')	,
('23759W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'BLA'	,1	,1.8	,85.86	,0	,8.5	,'23759W.jpg'	,''	,''	,'20211008 16:56:49'	,'20211008 16:56:49')	,
('23762W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Créoles avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'BLA'	,1	,2.1	,100.17	,0	,8.5	,'23762W.jpg'	,''	,''	,'20211008 16:56:51'	,'20211008 16:56:51')	,
('23831'	,'Boucles d''Oreilles en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme Créoles & Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'JAU'	,1	,1.75	,83.48	,0	,8.5	,'23831.jpg'	,''	,''	,'20211008 16:55:48'	,'20211008 16:55:48')	,
('23831W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Créoles avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'BLA'	,1	,1.75	,83.48	,0	,8.5	,'23831W.jpg'	,''	,''	,'20211008 16:57:00'	,'20211008 16:57:00')	,
('23845'	,'Boucles d''Oreilles en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme Créoles avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'JAU'	,1	,2.1	,100.17	,0	,8.5	,'23845.jpg'	,''	,''	,'20211008 16:55:50'	,'20211008 16:55:50')	,
('23845W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Créoles avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'BLA'	,1	,2.1	,100.17	,0	,8.5	,'23845W.jpg'	,''	,''	,'20211008 16:57:02'	,'20211008 16:57:02')	,
('23846'	,'Boucles d''Oreilles en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme Créoles & Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'JAU'	,1	,2	,95.4	,0	,8.5	,'23846.jpg'	,''	,''	,'20211008 16:55:51'	,'20211008 16:55:51')	,
('23846W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Créoles avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'BLA'	,1	,2.1	,100.17	,0	,8.5	,'23846W.jpg'	,''	,''	,'20211008 16:57:03'	,'20211008 16:57:03')	,
('23847'	,'Boucles d''Oreilles en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme Créoles & Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'JAU'	,1	,2.5	,119.25	,0	,8.5	,'23847.jpg'	,''	,''	,'20211008 16:55:52'	,'20211008 16:55:52')	,
('23847W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Créoles avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'BLA'	,1	,2.5	,119.25	,0	,8.5	,'23847W.jpg'	,''	,''	,'20211008 16:57:04'	,'20211008 16:57:04')	,
('23848'	,'Boucles d''Oreilles en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme & Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'JAU'	,1	,2.3	,109.71	,0	,8.5	,'23848.jpg'	,''	,''	,'20211008 16:55:53'	,'20211008 16:55:53')	,
('23848W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'BLA'	,1	,2.4	,114.48	,0	,8.5	,'23848W.jpg'	,''	,''	,'20211008 16:57:05'	,'20211008 16:57:05')	,
('23849'	,'Boucles d''Oreilles  Créoles en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme Créoles & Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'JAU'	,1	,2.7	,128.79	,0	,8.5	,'23849.jpg'	,''	,''	,'20211008 16:55:54'	,'20211008 16:55:54')	,
('23849W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Créoles avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'BLA'	,1	,3.2	,152.64	,0	,8.5	,'23849W.jpg'	,''	,''	,'20211008 16:57:06'	,'20211008 16:57:06')	,
('23852W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Créoles avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'BLA'	,1	,2.1	,103.32	,0	,10	,'23852W.jpg'	,''	,''	,'20211008 16:57:07'	,'20211008 16:57:07')	,
('23854W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'BLA'	,1	,2.3	,113.16	,0	,10	,'23854W.jpg'	,''	,''	,'20211008 16:57:08'	,'20211008 16:57:08')	,
('23861'	,'Boucles d''Oreilles  Créoles en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme Créoles & Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'JAU'	,1	,2	,95.40	,0	,8.5	,'23861.jpg'	,''	,''	,'20211008 16:55:55'	,'20211008 16:55:55')	,
('23861W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Créoles avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'BLA'	,1	,2.05	,97.79	,0	,8.5	,'23861W.jpg'	,''	,''	,'20211008 16:57:09'	,'20211008 16:57:09')	,
('23863'	,'Boucles d''Oreilles en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme & Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'JAU'	,1	,1.1	,52.47	,0	,8.5	,'23863.jpg'	,''	,''	,'20211008 16:55:56'	,'20211008 16:55:56')	,
('23863W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,1	,'BLA'	,1	,1.3	,62.01	,0	,8.5	,'23863W.jpg'	,''	,''	,'20211008 16:57:10'	,'20211008 16:57:10')	,
('23612W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Pendantes & Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BOPEN'	,'F'	,7	,1	,'BLA'	,1	,2	,95.40	,0	,8.5	,'23612W.jpg'	,''	,''	,'20211008 16:56:01'	,'20211008 16:56:01')	,
('23719'	,'Boucles d''Oreilles en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme Pendantes Femme & Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BOPEN'	,'F'	,7	,1	,'JAU'	,1	,1.9	,90.63	,0	,8.5	,'23719.jpg'	,''	,''	,'20211008 16:55:23'	,'20211008 16:55:23')	,
('23719W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Pendantes avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BOPEN'	,'F'	,7	,1	,'BLA'	,1	,1.9	,90.63	,0	,8.5	,'23719W.jpg'	,''	,''	,'20211008 16:56:27'	,'20211008 16:56:27')	,
('23737'	,'Boucles d''Oreilles en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme Pendantes Goutte & Oxydes de Zirconium (OZ).'	,0	,'BO'	,'BOPEN'	,'F'	,7	,1	,'JAU'	,1	,2.2	,104.94	,0	,8.5	,'23737.jpg'	,''	,''	,'20211008 16:55:35'	,'20211008 16:55:35')	,
('23737W'	,'Boucles d''Oreilles Goutte en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Pendantes en forme de Goutte avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BOPEN'	,'F'	,7	,1	,'BLA'	,1	,2.1	,100.17	,0	,8.5	,'23737W.jpg'	,''	,''	,'20211008 16:56:42'	,'20211008 16:56:42')	,
('23738'	,'Boucles d''Oreilles en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme Pendantes Goutte & Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BOPEN'	,'F'	,7	,1	,'JAU'	,1	,1.9	,90.63	,0	,8.5	,'23738.jpg'	,''	,''	,'20211008 16:55:36'	,'20211008 16:55:36')	,
('23738W'	,'Boucles d''Oreilles Goutte en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Pendantes en forme de Goutte avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BOPEN'	,'F'	,7	,1	,'BLA'	,1	,1.9	,90.63	,0	,8.5	,'23738W.jpg'	,''	,''	,'20211008 16:56:43'	,'20211008 16:56:43')	,
('23741'	,'Boucles d''Oreilles en OR Jaune 18 Carats 750/°°° Perle d''eau & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme Pendantes avec Perle d''eau douce & Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BOPEN'	,'F'	,7	,1	,'JAU'	,1	,2.1	,100.17	,0	,8.5	,'23741.jpg'	,''	,''	,'20211008 16:55:39'	,'20211008 16:55:39')	,
('23741W'	,'Boucles d''Oreilles Perle d''eau douce en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Pendantes Perle d''eau douce avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BOPEN'	,'F'	,7	,1	,'BLA'	,1	,2.5	,119.25	,0	,8.5	,'23741W.jpg'	,''	,''	,'20211008 16:56:46'	,'20211008 16:56:46')	,
('23761'	,'Boucles d''Oreilles en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme Pendantes & Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BOPEN'	,'F'	,7	,1	,'JAU'	,1	,5.5	,262.35	,0	,8.5	,'23761.jpg'	,''	,''	,'20211008 16:55:43'	,'20211008 16:55:43')	,
('23761W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Pendantes avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BOPEN'	,'F'	,7	,1	,'BLA'	,1	,5.5	,262.35	,0	,8.5	,'23761W.jpg'	,''	,''	,'20211008 16:56:50'	,'20211008 16:56:50')	,
('23766'	,'Boucles d''Oreilles en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme Pendantes avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BOPEN'	,'F'	,7	,1	,'JAU'	,1	,1.7	,81.09	,0	,8.5	,'23766.jpg'	,''	,''	,'20211008 16:55:44'	,'20211008 16:55:44')	,
('23766W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Pendantes avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BOPEN'	,'F'	,7	,1	,'BLA'	,1	,1.9	,90.63	,0	,8.5	,'23766W.jpg'	,''	,''	,'20211008 16:56:52'	,'20211008 16:56:52')	,
('23802W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Pendantes Cœur avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BOPEN'	,'F'	,7	,1	,'BLA'	,1	,1.8	,85.86	,0	,8.5	,'23802W.jpg'	,''	,''	,'20211008 16:56:59'	,'20211008 16:56:59')	,
('23841'	,'Boucles d''Oreilles en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme Pendantes & Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BOPEN'	,'F'	,7	,1	,'JAU'	,1	,1.8	,85.86	,0	,8.5	,'23841.jpg'	,''	,''	,'20211008 16:55:49'	,'20211008 16:55:49')	,
('23841W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Pendantes avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BOPEN'	,'F'	,7	,1	,'BLA'	,1	,2.3	,109.71	,0	,8.5	,'23841W.jpg'	,''	,''	,'20211008 16:57:01'	,'20211008 16:57:01')	,
('23864'	,'Boucles d''Oreilles en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme Pendantes & Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BOPEN'	,'F'	,7	,1	,'JAU'	,1	,4.9	,233.73	,0	,8.5	,'23864.jpg'	,''	,''	,'20211008 16:55:57'	,'20211008 16:55:57')	,
('23864W'	,'Boucles d''Oreilles en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Pendantes avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BOPEN'	,'F'	,7	,1	,'BLA'	,1	,4.9	,233.73	,0	,8.5	,'23864W.jpg'	,''	,''	,'20211008 16:57:11'	,'20211008 16:57:11')	,
('11536'	,'Boucles d''Oreilles en OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°  ,Boucles d''Oreilles Femme Créoles  , Tube Lisse Poli Miroir d''un Diamètre de 14 .5 mm avec Fermoirs à Charnières.'	,0	,'BO'	,'CREO'	,'F'	,10	,1	,'JAU'	,1	,0.99	,46.23	,0	,6.5	,'11536.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('21157'	,'Boucles d''Oreilles en OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°  ,Boucles d''Oreilles Créoles  , Tube Tressé Palmier d''un Diamètre de 18 .5 mm. Fermoirs à Charnières.'	,0	,'BO'	,'CREO'	,'F'	,10	,1	,'JAU'	,1	,1.17	,54.64	,0	,6.5	,'21157.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('21158'	,'Boucles d''Oreilles en OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°  ,Boucles d''Oreilles Créoles Tube Torsadé Large d''un Diamètre de 15 .5 mm. Fermoirs à Charnières.'	,0	,'BO'	,'CREO'	,'F'	,10	,1	,'JAU'	,1	,1.17	,54.64	,0	,6.5	,'21158.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22140'	,'Boucles d''Oreilles en OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°  ,Boucles d''Oreilles Créoles  , Tube Tressé Palmier d''un Diamètre de 11 .5 mm avec Fermoirs à Charnières.'	,0	,'BO'	,'CREO'	,'F'	,10	,1	,'JAU'	,1	,0.72	,33.62	,0	,6.5	,'22140.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('23767'	,'Pendentif en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Pendentif Femme en forme de Cœur & Oxydes de Zirconium (OZ).'	,1	,'BO'	,'PDTDIV'	,'F'	,7	,1	,'JAU'	,1	,1.1	,52.47	,0	,8.5	,'23767.jpg'	,''	,''	,'20211008 16:55:45'	,'20211008 16:55:45')	,
('2033'	,'Boucles d''Oreilles en OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°  ,Boucles d''Oreilles Boules Polies Miroir de 3 mm de Diamètre. Fermoirs à Poussettes.'	,0	,'BO'	,'PUCE'	,'F'	,10	,1	,'JAU'	,2	,0.19	,18.44	,0	,10.63	,'2033.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('2298'	,'Boucles d''Oreilles en OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°  ,Boucles d''Oreilles avec Oxyde de Zirconium  de 3 mm de Diamètre. Fermoirs à Poussettes.'	,0	,'BO'	,'PUCE'	,'M'	,7	,1	,'JAU'	,2	,0.24	,23.34	,0	,13.79	,'2298.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('26611'	,'Boucles d''Oreilles en OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°  ,Boucles d''Oreilles Boules Satinées de 4 mm de Diamètre. Fermoirs à Poussettes.'	,1	,'BO'	,'PUCE'	,'F'	,10	,1	,'JAU'	,2	,0.28	,24.85	,0	,13.59	,'26611.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('5028'	,'Boucles d''Oreilles 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°°.Boucles d''Oreilles Enfant avec Oxydes de Zirconium (OZ). Serti clos de 2 mm de Diamètre. Fermoirs à Poussettes.'	,1	,'BO'	,'PUCE'	,'E'	,7	,1	,'JAU'	,2	,0.21	,20.19	,0	,11.96	,'5028.jpg'	,''	,''	,'20211008 16:59:26'	,'20211008 16:59:26')	,
('R1012'	,'Boucles d''Oreilles  en OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°.Boucles d''Oreilles Enfant Boules Polies Miroir de 3 mm de Diamètre. Fermoirs à Poussettes.'	,1	,'BO'	,'PUCE'	,'E'	,10	,1	,'JAU'	,2	,0.35	,23.14	,0	,9.42	,'R1012.jpg'	,''	,''	,'20211008 16:59:51'	,'20211008 16:59:51')	,
('R1012-9K'	,'Boucles d''Oreilles  en OR Jaune 9 Carats 375/°°°'	,'OR Jaune 9 Carats 375/°°°.Boucles d''Oreilles Enfant Boules Polies Miroir de 3 mm de Diamètre. Fermoirs à Poussettes.'	,1	,'BO'	,'PUCE'	,'E'	,10	,1	,'JAU'	,2	,0.28	,19.68	,0	,8.7	,'R1012-9K.jpg'	,''	,''	,'20211008 16:59:52'	,'20211008 16:59:52')	,
('R1013'	,'Boucles d''Oreilles  en OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°.Boucles d''Oreilles Femme Boules Polies Miroir de 4 mm de Diamètre. Fermoirs à Poussettes.'	,1	,'BO'	,'PUCE'	,'E'	,10	,1	,'JAU'	,2	,0.4	,26.53	,0	,10.85	,'R1013.jpg'	,''	,''	,'20211008 16:59:53'	,'20211008 16:59:53')	,
('R1014'	,'Boucles d''Oreilles  en OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°.Boucles d''Oreilles Femme Boules Polies Miroir de 5 mm de Diamètre. Fermoirs à Poussettes.'	,1	,'BO'	,'PUCE'	,'F'	,10	,1	,'JAU'	,2	,0.45	,30.90	,0	,13.26	,'R1014.jpg'	,''	,''	,'20211008 16:59:54'	,'20211008 16:59:54')	,
('R1015'	,'Boucles d''Oreilles  en OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°.Boucles d''Oreilles Femme Boules Polies Miroir de 6 mm de Diamètre. Fermoirs à Poussettes.'	,1	,'BO'	,'PUCE'	,'F'	,10	,1	,'JAU'	,2	,0.52	,36.95	,0	,16.57	,'R1015.jpg'	,''	,''	,'20211008 16:59:55'	,'20211008 16:59:55')	,
('R1057'	,'Boucles d''Oreilles  en OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°.Boucles d''Oreilles Enfant avec Oxyde de Zirconium (OZ). serti clos de 2 mm de Diamètre. Fermoirs à Poussettes.'	,1	,'BO'	,'PUCE'	,'E'	,7	,1	,'JAU'	,2	,0.38	,21.00	,0	,6.1	,'R1057.jpg'	,''	,''	,'20211008 16:59:56'	,'20211008 16:59:56')	,
('R1058'	,'Boucles d''Oreilles  en OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°.Boucles d''Oreilles Enfant avec Oxyde de Zirconium (OZ). serti clos de 3 mm de Diamètre. Fermoirs à Poussettes.'	,1	,'BO'	,'PUCE'	,'E'	,7	,1	,'JAU'	,2	,0.42	,28.61	,0	,12.15	,'R1058.jpg'	,''	,''	,'20211008 16:59:57'	,'20211008 16:59:57')	,
('R1059'	,'Boucles d''Oreilles  en OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°.Boucles d''Oreilles Femme avec Oxyde de Zirconium (OZ). serti clos de 4 mm de Diamètre. Fermoirs à Poussettes.'	,1	,'BO'	,'PUCE'	,'F'	,7	,1	,'JAU'	,2	,0.46	,31.23	,0	,13.2	,'R1059.jpg'	,''	,''	,'20211008 16:59:58'	,'20211008 16:59:58')	,
('R1060'	,'Boucles d''Oreilles  en OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°.Boucles d''Oreilles Femme avec Oxyde de Zirconium (OZ). serti clos de 5 mm de Diamètre. Fermoirs à Poussettes.'	,1	,'BO'	,'PUCE'	,'F'	,7	,1	,'JAU'	,2	,0.62	,42.33	,0	,18.03	,'R1060.jpg'	,''	,''	,'20211008 16:59:59'	,'20211008 16:59:59')	,
('10588'	,'Bracelet avec pendentifs OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°  ,Bracelet Femme Maille Alternée 1+3  , Longueur 18.5 cm orné de 4 pendentifs Oursons de 10mm de Hauteur avec Fermoir Anneau  Ressort.'	,0	,'BR'	,'BRDIV'	,'F'	,10	,1	,'JAU'	,1	,1.99	,92.89	,0	,6.5	,'10588.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('10589'	,'Bracelet avec pendentifs OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°  ,Bracelet Femme Maille Alternée 1+3  , Longueur 18.5 cm orné de 4 pendentifs Coeurs de 7mm de Hauteur avec Fermoir Anneau Ressort.'	,1	,'BR'	,'BRDIV'	,'F'	,10	,1	,'JAU'	,1	,1.64	,76.49	,0	,6.5	,'10589.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('10589C'	,'Bracelet avec pendentifs en OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°  ,Chaîne de Cheville Femme Maille Alternée 1+3  , Longueur 24.5 cm ornée de 6 pendentifs Coeurs de 7mm de Hauteur avec Fermoir Anneau Ressort.'	,1	,'BR'	,'BRDIV'	,'F'	,10	,1	,'JAU'	,1	,2.24	,104.65	,0	,6.5	,'10589C.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('10591'	,'Bracelet avec Pendentifs OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°  ,Bracelet Maille Alternée 1+3  , Longueur 18.5 cm orné de 4 pendentifs Dauphins de 10mm de Hauteur avec Fermoir Anneau  Ressort.'	,0	,'BR'	,'BRDIV'	,'F'	,10	,1	,'JAU'	,1	,1.75	,81.54	,0	,6.5	,'10591.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('14129'	,'Bracelet Breloques en OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°  ,Bracelet Breloques Maille Torsadée Lisse et Godronnée. Pendentifs Dauphin  , Palmier  , Soleil  , Lune  , Roue.'	,0	,'BR'	,'BRDIV'	,'F'	,10	,1	,'JAU'	,1	,14.76	,689.29	,0	,6.5	,'14129.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('1808'	,'Bracelet Maille Haricot OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°  ,Bracelet Maille Haricot bombée d''une Longueur de 18.5 cm. Fermoir Mousqueton.'	,0	,'BR'	,'BRDIV'	,'F'	,10	,1	,'JAU'	,1	,3.6	,168.12	,0	,6.5	,'1808.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('1819'	,'Bracelet Maille Anglaise OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°  ,Bracelet Maille Anglaise bombée d''une Longueur de 18.5 cm. Fermoir Mousqueton.'	,0	,'BR'	,'BRDIV'	,'F'	,10	,1	,'JAU'	,1	,2.86	,133.36	,0	,6.5	,'1819.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('1830'	,'Bracelet Maille Surprise OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°  ,Bracelet Maille Surprise bombée d''une Longueur de 18.5 cm. Fermoir Mousqueton.'	,0	,'BR'	,'BRDIV'	,'F'	,10	,1	,'JAU'	,1	,3.67	,171.48	,0	,6.5	,'1830.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('1896'	,'Bracelet Chaîne Corde  OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°  ,Bracelet Chaîne Corde Laser Torsadée d''une Longueur de 18.5 cm avec Fermoir Anneau Ressort.'	,0	,'BR'	,'BRDIV'	,'F'	,10	,1	,'JAU'	,1	,0.99	,47.22	,0	,7.5	,'1896.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('1920'	,'Bracelet Maille Russe OR Jaune 18 Carats 750/°°° '	,'OR Jaune 18 Carats 750/°°°  ,Bracelet Maille Russe  , Largeur 5mm  , Longueur 19 cm  , Fermoir à Mousqueton.'	,1	,'BR'	,'BRDIV'	,'F'	,10	,1	,'JAU'	,1	,3.31	,157.98	,0	,7.5	,'1920.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('8775'	,'Bracelet Maille Américaine OR Jaune 18 Carats 750/°°° '	,'OR Jaune 18 Carats 750/°°°  ,Bracelet Maille Américaine Martelée  , Largeur 6.8 mm  , Longueur 18.8 cm  , Fermoir à Mousqueton.'	,0	,'BR'	,'BRDIV'	,'F'	,10	,1	,'JAU'	,1	,7.88	,376.07	,0	,7.5	,'8775.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('8689'	,'Bracelet Identité Bébé OR Jaune 18 Carats 750/°°° '	,'OR Jaune 18 Carats 750/°°°  ,Bracelet Identité Bébé/Enfant  , Maille Alternée 1+3 d''une Longueur de 14 cm avec Fermoir Anneau  Ressort.'	,1	,'BR'	,'BRID'	,'E'	,10	,1	,'JAU'	,1	,1.11	,51.7	,0	,6.5	,'8689.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('8875'	,'Bracelet Rigide OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°  , Bracelet Rigide Tube Lisse Poli de 2  ,8mm  , Diamètre intérieur 59mm  , extérieur 66 mm'	,1	,'BR'	,'BRRGD'	,'F'	,10	,1	,'JAU'	,1	,3.98	,189.75	,0	,7.5	,'8875.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('1897-42'	,' Collier Chaîne Corde OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°  ,Collier Chaîne Corde Laser Torsadée d''une Longueur de 42 cm. Fermoir Mousqueton.'	,0	,'CO'	,'BRDIV'	,'F'	,10	,1	,'JAU'	,1	,3.24	,154.55	,0	,7.5	,'1897-42.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('14093R'	,'Collier Pendant & Oxyde de Zirconium OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°  ,Collier Femme Maille Carrée Miroir ornée de 3 Fleurs Entourages en Oxyde de Zirconium blanc et d''un centre rouge  , Longueur 43 cm  , Fermoir à Mousqueton.'	,1	,'CO'	,'CHDIV'	,'F'	,7	,1	,'JAU'	,1	,5.57	,271.31	,0	,8.5	,'14093R.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('15900CO'	,'Collier Oxyde de Zirconium OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°  ,Collier Femme Maille Bis Mark ornée d''un centre ''V'' en Oxyde de Zirconium blanc  , Longueur 45 cm  , Fermoir à Mousqueton.'	,1	,'CO'	,'CHDIV'	,'F'	,7	,1	,'JAU'	,1	,7.27	,354.15	,0	,8.5	,'15900CO.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('17139'	,'Collier Pendant & Oxyde de Zirconium en OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°  ,Collier Femme Maille Carrée Miroir orné de 2 Cœurs en Oxyde de Zirconium blancs Pendants  , Longueur 43 cm  , Fermoir à Mousqueton.'	,1	,'CO'	,'CHDIV'	,'F'	,7	,1	,'JAU'	,1	,4.98	,242.38	,0	,8.5	,'17139.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('1215-45'	,'Collier Chaîne Singapour OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°  ,Chaîne Femme Maille Singapour d''une Longueur de 45 cm avec Fermoir Anneau Ressort.'	,0	,'CO'	,'CHFIN'	,'F'	,10	,1	,'JAU'	,1	,0.98	,45.94	,0	,6.5	,'1215-45.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('21769-45'	,' Collier Chaîne Vénitienne OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°  ,Collier Chaîne Vénitienne d''une Longueur de 42 cm avec Fermoir Anneau Ressort.'	,0	,'CO'	,'CHFIN'	,'F'	,10	,1	,'JAU'	,1	,0.72	,33.62	,0	,6.5	,'21769-45.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('9398'	,'Collier Boules OR Jaune 18 Carats 750/°°° '	,'OR Jaune 18 Carats 750/°°°  ,Collier Boules Polis en dégradé d''un centre de 6 mm  , Fermoir à Anneau  Ressort.'	,1	,'CO'	,'CO'	,'F'	,10	,1	,'JAU'	,1	,6.06	,310.12	,0	,11	,'9398.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('1808-45'	,' Collier Maille Haricot OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°  ,Collier Maille Haricot bombée d''une Longueur de 42 cm  , Fermoir Mousqueton.'	,0	,'CO'	,'CO '	,'F'	,10	,1	,'JAU'	,1	,7.26	,339.06	,0	,6.5	,'1808-45.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('1819-45'	,' Collier Maille Anglaise OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°  ,Collier Maille Anglaise bombée d''une Longueur de 42 cm  , Fermoir Mousqueton.'	,0	,'CO'	,'CO '	,'F'	,10	,1	,'JAU'	,1	,5.37	,250.84	,0	,6.5	,'1819-45.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('1830-45'	,'Collier Maille Surprise OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°  ,Collier Maille Surprise bombée d''une Longueur de 42 cm. Fermoir Mousqueton.'	,0	,'CO'	,'CO '	,'F'	,10	,1	,'JAU'	,1	,7.2	,350.64	,0	,8.5	,'1830-45.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('10542'	,'Pendentif Tête de Cheval OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°,Pendentif Homme Tête de cheval Poli Lisse  , Hauteur 13 mm  , Largeur 20 mm'	,0	,'PDT'	,'PDTDIV'	,'H'	,10	,1	,'JAU'	,1	,1.33	,62.2	,0	,6.5	,'10542.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('10550'	,'Pendentif Hippocampe OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°,Pendentif Femme Hippocampe Poli Lisse  , Hauteur 20 mm  , Largeur 12 mm'	,0	,'PDT'	,'PDTDIV'	,'H'	,10	,1	,'JAU'	,1	,1.21	,56.32	,0	,6.5	,'10550.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('10682'	,'Pendentif Main/Œil OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°,Pendentif Main/Œil Poli Brillant Hauteur 25 mm  , Largeur 20 mm'	,0	,'PDT'	,'PDTDIV'	,'M'	,10	,1	,'JAU'	,1	,1.5	,70.19	,0	,6.5	,'10682.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('12829'	,'Pendentif Perle de Culture d''eau douce montée sur OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°,Pendentif Femme avec Perle de Culture d''eau douce  , Diamètre 6 mm'	,1	,'PDT'	,'PDTDIV'	,'F'	,10	,1	,'JAU'	,2	,0.43	,29.45	,0	,12.08	,'12829.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('12830'	,'Pendentif Perle de Culture d''eau douce montée sur OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°,Pendentif Femme avec Perle de Culture d''eau douce  , Diamètre 7 mm'	,0	,'PDT'	,'PDTDIV'	,'F'	,10	,1	,'JAU'	,2	,0.7	,36.14	,0	,8	,'12830.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('1492'	,'Pendentif Chien OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°,Pendentif Chien Poli Lisse  , Hauteur 12 mm  , Largeur 12 mm'	,0	,'PDT'	,'PDTDIV'	,'M'	,10	,1	,'JAU'	,1	,0.88	,41.19	,0	,6.5	,'1492.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('1502'	,'Pendentif Cœur OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°,Pendentif Femme Cœur Lisse  , Hauteur 15 mm  , Largeur 12 mm'	,0	,'PDT'	,'PDTDIV'	,'F'	,10	,1	,'JAU'	,1	,1.19	,55.48	,0	,6.5	,'1502.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('1504'	,'Pendentif Cœur OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°,Pendentif  Femme Cœur Lisse  , Hauteur 10 mm  , Largeur 8 mm'	,0	,'PDT'	,'PDTDIV'	,'F'	,10	,1	,'JAU'	,1	,0.58	,26.9	,0	,6.5	,'1504.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('1505'	,'Pendentif Cœur  OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°, Pendentif Femme Cœur  Lisse  , Hauteur 10 mm  , Largeur 8 mm'	,0	,'PDT'	,'PDTDIV'	,'F'	,10	,1	,'JAU'	,1	,0.61	,28.58	,0	,6.5	,'1505.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22144'	,'Pendentif Cœur OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°,Pendentif Cœur Facetté  , Hauteur 16 mm  , Largeur 13 mm'	,0	,'PDT'	,'PDTDIV'	,'F'	,10	,1	,'JAU'	,1	,0.54	,25.76	,0	,7.5	,'22144.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22145'	,'Pendentif Cœur OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°,Pendentif Cœur Facetté  , Hauteur 12 mm  , Largeur 10 mm'	,0	,'PDT'	,'PDTDIV'	,'F'	,10	,1	,'JAU'	,1	,0.42	,20.18	,0	,7.5	,'22145.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('23018'	,'Pendentif Main  en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Pendentif Femme Main  avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,1	,'JAU'	,1	,2.2	,104.94	,0	,8.5	,'23018.jpg'	,''	,''	,'20211008 16:55:01'	,'20211008 16:55:01')	,
('23018W'	,'Pendentif en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Pendentif Femme en forme de Main avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,1	,'BLA'	,1	,2.2	,104.94	,0	,8.5	,'23018W.jpg'	,''	,''	,'20211008 16:55:58'	,'20211008 16:55:58')	,
('23678'	,'Pendentif Cœur en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Pendentif Femme en Cœur avec des Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,1	,'BLA'	,1	,1.35	,64.4	,0	,8.5	,'23678.jpg'	,''	,''	,'20211008 16:55:14'	,'20211008 16:55:14')	,
('23678W'	,'Pendentif en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Pendentif Femme en forme de Cœur avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,1	,'BLA'	,1	,1.3	,62.01	,0	,8.5	,'23678W.jpg'	,''	,''	,'20211008 16:56:13'	,'20211008 16:56:13')	,
('23679W'	,'Pendentif en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Pendentif Femme en forme de Cœur avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,1	,'BLA'	,1	,0.75	,35.78	,0	,8.5	,'23679W.jpg'	,''	,''	,'20211008 16:56:14'	,'20211008 16:56:14')	,
('23680W'	,'Pendentif en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Pendentif Femme Double Cœur avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,1	,'BLA'	,1	,1.1	,52.47	,0	,8.5	,'23680W.jpg'	,''	,''	,'20211008 16:56:15'	,'20211008 16:56:15')	,
('23681W'	,'Pendentif en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Pendentif Femme Double Cœur avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,1	,'BLA'	,1	,1.65	,78.71	,0	,8.5	,'23681W.jpg'	,''	,''	,'20211008 16:56:16'	,'20211008 16:56:16')	,
('23682W'	,'Pendentif en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Pendentif Femme en forme de Cœur avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,1	,'BLA'	,1	,2.4	,114.48	,0	,8.5	,'23682W.jpg'	,''	,''	,'20211008 16:56:17'	,'20211008 16:56:17')	,
('23684'	,'Pendentif Soleil en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Pendentif Femme Soleil avec des Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,1	,'JAU'	,1	,2.95	,140.72	,0	,8.5	,'23684.jpg'	,''	,''	,'20211008 16:55:15'	,'20211008 16:55:15')	,
('23684W'	,'Pendentif en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Pendentif Femme Soleil avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,1	,'BLA'	,1	,2.9	,138.33	,0	,8.5	,'23684W.jpg'	,''	,''	,'20211008 16:56:18'	,'20211008 16:56:18')	,
('23686'	,'Pendentif Papillon en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Pendentif Femme Papillon avec des Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,1	,'JAU'	,1	,2.1	,100.17	,0	,8.5	,'23686.jpg'	,''	,''	,'20211008 16:55:16'	,'20211008 16:55:16')	,
('23686DIA'	,'Pendentif en OR Jaune 18 Carats 750/°°° & Diamant'	,'OR Jaune 18 Carats 750/°°° Pendentif Femme  Papillon & Diamants de 0,58 Cts'	,1	,'PDT'	,'PDTDIV'	,'F'	,1	,1	,'JAU'	,2	,1	,498.92	,0	,459.72	,'23686DIA.jpg'	,''	,''	,'20211008 16:59:35'	,'20211008 16:59:35')	,
('23686DIAW'	,'Pendentif en OR Blanc 18 Carats 750/°°° & Diamant'	,'OR Blanc 18 Carats 750/°°° Pendentif Femme  Papillon & Diamants 0,58 Cts'	,1	,'PDT'	,'PDTDIV'	,'F'	,1	,1	,'BLA'	,2	,1	,498.92	,0	,459.72	,'23686DIAW.jpg'	,''	,''	,'20211008 16:59:36'	,'20211008 16:59:36')	,
('23686W'	,'Pendentif en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Pendentif Femme  Papillon avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,1	,'BLA'	,1	,2	,95.40	,0	,8.5	,'23686W.jpg'	,''	,''	,'20211008 16:56:19'	,'20211008 16:56:19')	,
('23687'	,'Pendentif Cœur en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Pendentif Femme Cœur avec des Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,1	,'JAU'	,1	,1	,47.70	,0	,8.5	,'23687.jpg'	,''	,''	,'20211008 16:55:17'	,'20211008 16:55:17')	,
('23687W'	,'Pendentif en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Pendentif Femme  Cœur avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,1	,'BLA'	,1	,1.1	,52.47	,0	,8.5	,'23687W.jpg'	,''	,''	,'20211008 16:56:20'	,'20211008 16:56:20')	,
('23689'	,'Pendentif en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Pendentif Femme & Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,1	,'JAU'	,1	,4.3	,205.11	,0	,8.5	,'23689.jpg'	,''	,''	,'20211008 16:55:18'	,'20211008 16:55:18')	,
('23689W'	,'Pendentif en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Pendentif Femme  avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,1	,'BLA'	,1	,2.1	,100.17	,0	,8.5	,'23689W.jpg'	,''	,''	,'20211008 16:56:21'	,'20211008 16:56:21')	,
('23690DIA'	,'Pendentif en OR Jaune 18 Carats 750/°°° & Diamant'	,'OR Jaune 18 Carats 750/°°° Pendentif Femme  Croix & Diamants de 0,41 Cts'	,1	,'PDT'	,'PDTDIV'	,'F'	,1	,1	,'JAU'	,2	,1.1	,442.30	,0	,399.18	,'23690DIA.jpg'	,''	,''	,'20211008 16:59:37'	,'20211008 16:59:37')	,
('23690DIAW'	,'Pendentif en OR Blanc 18 Carats 750/°°° & Diamant'	,'OR Blanc 18 Carats 750/°°° Pendentif Femme  Croix & Diamants de  0,41 Cts'	,1	,'PDT'	,'PDTDIV'	,'F'	,1	,1	,'BLA'	,2	,1.1	,442.30	,0	,399.18	,'23690DIAW.jpg'	,''	,''	,'20211008 16:59:38'	,'20211008 16:59:38')	,
('23690W'	,'Pendentif en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Pendentif Femme  Croix avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,1	,'BLA'	,1	,1.1	,52.47	,0	,8.5	,'23690W.jpg'	,''	,''	,'20211008 16:56:22'	,'20211008 16:56:22')	,
('23711'	,'Pendentif Perle en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Pendentif Femme avec Perle d''eau douce et Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,1	,'JAU'	,1	,1.2	,57.24	,0	,8.5	,'23711.jpg'	,''	,''	,'20211008 16:55:19'	,'20211008 16:55:19')	,
('23711W'	,'Pendentif en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Pendentif Femme  Perle d''eau douce avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,1	,'BLA'	,1	,1.6	,76.32	,0	,8.5	,'23711W.jpg'	,''	,''	,'20211008 16:56:23'	,'20211008 16:56:23')	,
('23767W'	,'Pendentif en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Pendentif Femme  Cœur avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,1	,'BLA'	,1	,1.15	,54.86	,0	,8.5	,'23767W.jpg'	,''	,''	,'20211008 16:56:53'	,'20211008 16:56:53')	,
('23773DIA'	,'Pendentif en OR Jaune 18 Carats 750/°°° & Diamant'	,'OR Jaune 18 Carats 750/°°° Pendentif Femme  Cœur & Diamants de  0,25 Cts'	,0	,'PDT'	,'PDTDIV'	,'F'	,1	,1	,'JAU'	,2	,1.8	,267.13	,0	,196.57	,'23773DIA.jpg'	,''	,''	,'20211008 16:59:43'	,'20211008 16:59:43')	,
('23773DIAW'	,'Pendentif en OR Blanc 18 Carats 750/°°° & Diamant'	,'OR Blanc 18 Carats 750/°°° Pendentif Femme  Cœur & Diamants de  0,25 Cts'	,0	,'PDT'	,'PDTDIV'	,'F'	,1	,1	,'BLA'	,2	,1.8	,267.13	,0	,196.57	,'23773DIAW.jpg'	,''	,''	,'20211008 16:59:44'	,'20211008 16:59:44')	,
('23773W'	,'Pendentif en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Pendentif Femme  Cœur avec Oxydes de Zirconium (OZ).'	,0	,'PDT'	,'PDTDIV'	,'F'	,7	,1	,'BLA'	,1	,1.8	,85.86	,0	,8.5	,'23773W.jpg'	,''	,''	,'20211008 16:56:54'	,'20211008 16:56:54')	,
('23775'	,'Pendentif en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Pendentif Femme Croix & Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,1	,'JAU'	,1	,0.65	,31.01	,0	,8.5	,'23775.jpg'	,''	,''	,'20211008 16:55:46'	,'20211008 16:55:46')	,
('23775W'	,'Pendentif en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Pendentif Femme  Croix avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,1	,'BLA'	,1	,0.7	,33.39	,0	,8.5	,'23775W.jpg'	,''	,''	,'20211008 16:56:55'	,'20211008 16:56:55')	,
('23776DIA'	,'Pendentif en OR Jaune 18 Carats 750/°°° & Diamant'	,'OR Jaune 18 Carats 750/°°° Pendentif Femme  Croix & Diamants de  0,19 Cts'	,1	,'PDT'	,'PDTDIV'	,'F'	,1	,1	,'JAU'	,2	,1.15	,274.12	,0	,229.04	,'23776DIA.jpg'	,''	,''	,'20211008 16:59:45'	,'20211008 16:59:45')	,
('23776DIAW'	,'Pendentif en OR Blanc 18 Carats 750/°°° & Diamant'	,'OR Blanc 18 Carats 750/°°° Pendentif Femme  Croix & Diamants de 0,19 Cts'	,1	,'PDT'	,'PDTDIV'	,'F'	,1	,1	,'BLA'	,2	,1.15	,274.12	,0	,229.04	,'23776DIAW.jpg'	,''	,''	,'20211008 16:59:46'	,'20211008 16:59:46')	,
('23776W'	,'Pendentif en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Pendentif Femme  Croix avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,1	,'BLA'	,1	,1.15	,54.86	,0	,8.5	,'23776W.jpg'	,''	,''	,'20211008 16:56:56'	,'20211008 16:56:56')	,
('23788'	,'Pendentif en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Pendentif Femme Papillon & Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,1	,'JAU'	,1	,3.85	,183.65	,0	,8.5	,'23788.jpg'	,''	,''	,'20211008 16:55:47'	,'20211008 16:55:47')	,
('23788W'	,'Pendentif en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Pendentif Femme  Papillon avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,1	,'BLA'	,1	,3.95	,188.42	,0	,8.5	,'23788W.jpg'	,''	,''	,'20211008 16:56:57'	,'20211008 16:56:57')	,
('23789W'	,'Pendentif en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Pendentif Femme  Cœur avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,1	,'BLA'	,1	,1	,47.7	,0	,8.5	,'23789W.jpg'	,''	,''	,'20211008 16:56:58'	,'20211008 16:56:58')	,
('8567'	,'Pendentif Gant de boxe OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°,Pendentif Gant de box Poli Lisse  , Hauteur 15 mm  , Largeur 10 mm'	,0	,'PDT'	,'PDTDIV'	,'H'	,10	,1	,'JAU'	,1	,0.91	,42.45	,0	,6.5	,'8567.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('8570'	,'Pendentif Eléphant OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°,Pendentif Eléphant Poli Lisse  , Hauteur 10 mm  , Largeur 13 mm'	,0	,'PDT'	,'PDTDIV'	,'M'	,10	,1	,'JAU'	,1	,0.45	,21.02	,0	,6.5	,'8570.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('8585'	,'Pendentif Fer à Cheval OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°,Pendentif Fer à Cheval Poli Lisse  , Hauteur 10 mm  , Largeur 10 mm'	,0	,'PDT'	,'PDTDIV'	,'H'	,10	,1	,'JAU'	,1	,0.56	,26.06	,0	,6.5	,'8585.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('8598'	,'Pendentif Palmier OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°,Pendentif Palmier Poli Lisse  , Hauteur 25 mm  , Largeur 14 mm'	,0	,'PDT'	,'PDTDIV'	,'M'	,10	,1	,'JAU'	,1	,1.28	,59.68	,0	,6.5	,'8598.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('8601'	,'Pendentif Trois Vertus OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°,Pendentif Cœur  , Croix  , Ancre marine Lisses  , Cœur  Ht: 8 mm  , Croix Ht: 10 mm  , ancre marine Ht: 10 mm  ,'	,0	,'PDT'	,'PDTDIV'	,'F'	,10	,1	,'JAU'	,1	,1.01	,48.08	,0	,7.5	,'8601.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('8603'	,'Pendentif Dauphin OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°  , Pendentif Dauphin Poli Lisse  , Hauteur 20 mm  , Largeur 15 mm'	,0	,'PDT'	,'PDTDIV'	,'E'	,10	,1	,'JAU'	,1	,1.41	,65.99	,0	,6.5	,'8603.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('8610'	,'Pendentif Cœur OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°,Pendentif Cœur Lisse en OR 18 carats  , Hauteur 13 mm  , Largeur 11 mm'	,0	,'PDT'	,'PDTDIV'	,'F'	,10	,1	,'JAU'	,1	,0.95	,44.13	,0	,6.5	,'8610.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('8611'	,'Pendentif cœur OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°, Pendentif Cœur Lisse  , Hauteur 8 mm  , Largeur 6 mm.'	,0	,'PDT'	,'PDTDIV'	,'F'	,10	,1	,'JAU'	,1	,0.42	,19.75	,0	,6.5	,'8611.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('9475'	,'Pendentif Œil OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°,Pendentif Œil Diamètre 13 mm'	,0	,'PDT'	,'PDTDIV'	,'M'	,10	,1	,'JAU'	,1	,0.99	,46.23	,0	,6.5	,'9475.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('P237b-10'	,'Pendentif Goutte Diamant en OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°,Pendentif Goutte Diamant de 10 Centièmes de Carat.'	,0	,'PDT'	,'PDTDIV'	,'F'	,1	,1	,'JAU'	,2	,0.23	,47.05	,0	,38	,'P237b-10.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('10678'	,'Pendentif Jeton Allah OR Jaune 18 Carats 750/°°° '	,'OR Jaune 18 Carats 750/°°°,Pendentif Allah Poli Brillant  , Diamètre 10 mm'	,0	,'PDT'	,'PDTRG'	,'M'	,10	,1	,'JAU'	,1	,0.54	,25.22	,0	,6.5	,'10678.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('18082'	,'Pendentif Croix Christ  OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°,Pendentif Croix Christ Facetté  , Hauteur 22 mm  , Largeur 13 mm'	,0	,'PDT'	,'PDTRG'	,'M'	,10	,1	,'JAU'	,1	,0.79	,38.57	,0	,8.5	,'18082.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('18084'	,'Pendentif Croix OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°,Pendentif Croix Facetté  , Hauteur 15 mm  , Largeur 15 mm'	,1	,'PDT'	,'PDTRG'	,'M'	,10	,1	,'JAU'	,1	,0.3	,14.46	,0	,8.5	,'18084.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('18487'	,'Pendentif Croix Christ  OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°,Pendentif Croix Christ Facetté  , Hauteur 22 mm  , Largeur 13 mm'	,0	,'PDT'	,'PDTRG'	,'M'	,10	,1	,'JAU'	,1	,0.56	,27.17	,0	,8.5	,'18487.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('18489'	,'Pendentif Croix OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°,Pendentif Croix Facetté  , Hauteur 27 mm  , Largeur 18 mm'	,1	,'PDT'	,'PDTRG'	,'M'	,10	,1	,'JAU'	,1	,0.65	,31.56	,0	,8.5	,'18489.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('18491'	,'Pendentif Croix Christ  OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°,Pendentif Croix Christ Facetté  , Hauteur 25 mm  , Largeur 15 mm'	,0	,'PDT'	,'PDTRG'	,'M'	,10	,1	,'JAU'	,1	,1.13	,54.79	,0	,8.5	,'18491.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('18492'	,'Pendentif Croix OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°,Pendentif Croix Facetté  , Hauteur 24 mm  , Largeur 13 mm'	,1	,'PDT'	,'PDTRG'	,'M'	,10	,1	,'JAU'	,1	,0.51	,24.98	,0	,8.5	,'18492.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('18493'	,'Pendentif Croix OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°,Pendentif Croix Facetté  , Hauteur 22 mm  , Largeur 12 mm'	,1	,'PDT'	,'PDTRG'	,'M'	,10	,1	,'JAU'	,1	,0.34	,16.66	,0	,8.5	,'18493.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('18494'	,'Pendentif Croix OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°,Pendentif Croix Facetté  , Hauteur 25 mm  , Largeur 16 mm'	,1	,'PDT'	,'PDTRG'	,'M'	,10	,1	,'JAU'	,1	,0.75	,36.38	,0	,8.5	,'18494.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('18495'	,'Pendentif Croix OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°,Pendentif Croix Facetté  , Hauteur 16 mm  , Largeur 9 mm'	,1	,'PDT'	,'PDTRG'	,'M'	,10	,1	,'JAU'	,1	,0.46	,22.35	,0	,8.5	,'18495.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('8462'	,'Pendentif Croix Christ en OR Bicolore 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°,Pendentif Croix Christ Bicolore  , Hauteur 30 mm  , Largeur 20 mm'	,0	,'PDT'	,'PDTRG'	,'M'	,10	,1	,'BIC'	,1	,0.86	,41.64	,0	,8.5	,'8462.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('8493'	,'Pendentif Tête du Christ  OR Jaune 18 Carats 750/°°°'	,'OR Jaune 18 Carats 750/°°°  ,Médaille Tête du Christ Satinée  , Hauteur 18 mm  , Largeur 12 mm'	,0	,'PDT'	,'PDTRG'	,'H'	,10	,1	,'JAU'	,1	,1.04	,48.33	,0	,6.5	,'8493.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('9506'	,'Pendentif Allah OR Jaune 18 Carats 750/°°° '	,'OR Jaune 18 Carats 750/°°°,Pendentif Allah Poli Brillant  , Hauteur 20 mm  , Largeur 16 mm'	,0	,'PDT'	,'PDTRG'	,'M'	,10	,1	,'JAU'	,1	,0.9	,42.03	,0	,6.5	,'9506.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('3557P'	,'Piercing en OR Jaune 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Piercing Nez avec Oxyde de Zirconium (OZ).'	,1	,'PG'	,'PGDIV'	,'F'	,7	,1	,'JAU'	,2	,0.07	,6.52	,0	,3.78	,'3557P.jpg'	,''	,''	,'20211008 16:59:47'	,'20211008 16:59:47')	,
('3557PW'	,'Piercing en OR Blanc 18 Carats 750/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Piercing Nez & Oxyde de Zirconium (OZ).'	,1	,'PG'	,'PGDIV'	,'F'	,7	,1	,'BLA'	,2	,0.07	,7.16	,0	,4.42	,'3557PW.jpg'	,''	,''	,'20211008 16:59:48'	,'20211008 16:59:48')	,
('3558P'	,'Piercing en OR Jaune 18 Carats 750/°°° '	,'OR Jaune 18 Carats 750/°°° Piercing Nez Boule.'	,1	,'PG'	,'PGDIV'	,'F'	,10	,1	,'JAU'	,2	,0.07	,6.68	,0	,3.94	,'3558P.jpg'	,''	,''	,'20211008 16:59:49'	,'20211008 16:59:49')	,
('A51350'	,'Piercing en OR Jaune 18 Carats 750/°°° '	,'OR Jaune 18 Carats 750/°°° Piercing Femme Langue 2 Boules.'	,1	,'PG'	,'PGDIV'	,'F'	,10	,1	,'JAU'	,2	,0.75	,49.40	,0	,20	,'A51350.jpg'	,''	,''	,'20211008 16:59:50'	,'20211008 16:59:50')	,
('23630W-9K'	,'Bague en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Alliance Femme sertie de deux Rangs en Oxyde de Zirconium (OZ).'	,1	,'BG'	,'ALL'	,'F'	,7	,2	,'BLA'	,1	,2.1	,62.16	,0	,10	,'23630W-9K.jpg'	,''	,''	,'20211008 16:57:21'	,'20211008 16:57:21')	,
('23631-9K'	,'Bague Alliance en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Alliance Femme sertie d''une Rangée d''Oxydes de Zirconium (OZ).'	,0	,'BG'	,'ALL'	,'F'	,7	,2	,'JAU'	,1	,1.6	,47.36	,0	,10	,'23631-9K.jpg'	,''	,''	,'20211008 16:57:22'	,'20211008 16:57:22')	,
('23631W-9K'	,'Bague en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Alliance Femme sertie d''une Rangée en Oxydes de Zirconium (OZ).'	,0	,'BG'	,'ALL'	,'F'	,7	,2	,'BLA'	,1	,1.6	,47.36	,0	,10	,'23631W-9K.jpg'	,''	,''	,'20211008 16:57:23'	,'20211008 16:57:23')	,
('23637-9K'	,'Bague Alliance en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Alliance Femme sertie d''une Rangée d''Oxydes de Zirconium (OZ).'	,1	,'BG'	,'ALL'	,'F'	,7	,2	,'JAU'	,1	,1.3	,38.48	,0	,10	,'23637-9K.jpg'	,''	,''	,'20211008 16:57:31'	,'20211008 16:57:31')	,
('23637W-9K'	,'Bague en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°°Alliance Femme sertie d''une Rangée d''Oxydes de Zirconium (OZ).'	,1	,'BG'	,'ALL'	,'F'	,7	,2	,'BLA'	,1	,1.3	,38.48	,0	,10	,'23637W-9K.jpg'	,''	,''	,'20211008 16:57:32'	,'20211008 16:57:32')	,
('23651-9K'	,'Bague Alliance en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°°Alliance Femme sertie d''une Rangée d''Oxydes de Zirconium (OZ).'	,1	,'BG'	,'ALL'	,'F'	,7	,2	,'JAU'	,1	,1.45	,42.92	,0	,10	,'23651-9K.jpg'	,''	,''	,'20211008 16:57:35'	,'20211008 16:57:35')	,
('23651W-9K'	,'Bague en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°°Alliance Femme sertie d''une Rangée d''Oxydes de Zirconium (OZ).'	,1	,'BG'	,'ALL'	,'F'	,7	,2	,'BLA'	,1	,1.45	,42.92	,0	,10	,'23651W-9K.jpg'	,''	,''	,'20211008 16:57:36'	,'20211008 16:57:36')	,
('23653-9K'	,'Bague Alliance en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Alliance Femme sertie d''une Rangée d''Oxydes de Zirconium (OZ).'	,1	,'BG'	,'ALL'	,'F'	,7	,2	,'JAU'	,1	,1.6	,47.36	,0	,10	,'23653-9K.jpg'	,''	,''	,'20211008 16:57:37'	,'20211008 16:57:37')	,
('23653W-9K'	,'Bague Alliance en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Alliance Femme sertie d''une Rangée d''Oxydes de Zirconium (OZ).'	,1	,'BG'	,'ALL'	,'F'	,7	,2	,'BLA'	,1	,1.6	,47.36	,0	,10	,'23653W-9K.jpg'	,''	,''	,'20211008 16:57:38'	,'20211008 16:57:38')	,
('23629W-9K'	,'Bague en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Bague Femme en Pavé avec Oxydes de Zirconium (OZ).'	,1	,'BG'	,'BGDIV'	,'F'	,7	,2	,'BLA'	,1	,2.9	,85.84	,0	,10	,'23629W-9K.jpg'	,''	,''	,'20211008 16:57:19'	,'20211008 16:57:19')	,
('23630-9K'	,'Bague Alliance en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Alliance Femme sertie de deux Rangs Oxydes de Zirconium (OZ).'	,1	,'BG'	,'BGDIV'	,'F'	,7	,2	,'JAU'	,1	,2.1	,62.16	,0	,10	,'23630-9K.jpg'	,''	,''	,'20211008 16:57:20'	,'20211008 16:57:20')	,
('23632-9K'	,'Bague en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Bague Femme Croisée avec Oxydes de Zirconium (OZ).'	,1	,'BG'	,'BGDIV'	,'F'	,7	,2	,'JAU'	,1	,2.1	,62.16	,0	,10	,'23632-9K.jpg'	,''	,''	,'20211008 16:57:24'	,'20211008 16:57:24')	,
('23632W-9K'	,'Bague en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Bague Femme Croisée avec Oxydes de Zirconium (OZ).'	,1	,'BG'	,'BGDIV'	,'F'	,7	,2	,'BLA'	,1	,1.2	,35.52	,0	,10	,'23632W-9K.jpg'	,''	,''	,'20211008 16:57:25'	,'20211008 16:57:25')	,
('23633-9K'	,'Bague en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Bague Femme avec Oxydes de Zirconium (OZ).'	,1	,'BG'	,'BGDIV'	,'F'	,7	,2	,'JAU'	,1	,1.7	,50.32	,0	,10	,'23633-9K.jpg'	,''	,''	,'20211008 16:57:26'	,'20211008 16:57:26')	,
('23633W-9K'	,'Bague en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Bague Femme avec Oxydes de Zirconium (OZ).'	,1	,'BG'	,'BGDIV'	,'F'	,7	,2	,'BLA'	,1	,1.7	,50.32	,0	,10	,'23633W-9K.jpg'	,''	,''	,'20211008 16:57:27'	,'20211008 16:57:27')	,
('23635W-9K'	,'Bague en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Bague Femme avec Oxydes de Zirconium (OZ) et Zircon Central.'	,1	,'BG'	,'BGDIV'	,'F'	,7	,2	,'BLA'	,1	,1.3	,38.48	,0	,10	,'23635W-9K.jpg'	,''	,''	,'20211008 16:57:28'	,'20211008 16:57:28')	,
('23636-9K'	,'Bague en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Bague Femme avec Oxydes de Zirconium (OZ).'	,1	,'BG'	,'BGDIV'	,'F'	,7	,2	,'JAU'	,1	,1.1	,32.56	,0	,10	,'23636-9K.jpg'	,''	,''	,'20211008 16:57:29'	,'20211008 16:57:29')	,
('23636W-9K'	,'Bague en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Bague Femme avec Oxydes de Zirconium (OZ).'	,1	,'BG'	,'BGDIV'	,'F'	,7	,2	,'BLA'	,1	,1.1	,32.56	,0	,10	,'23636W-9K.jpg'	,''	,''	,'20211008 16:57:30'	,'20211008 16:57:30')	,
('23638-9K'	,'Bague en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Bague Femme en Pavé avec Oxydes de Zirconium (OZ).'	,1	,'BG'	,'BGDIV'	,'F'	,7	,2	,'JAU'	,1	,2.6	,76.96	,0	,10	,'23638-9K.jpg'	,''	,''	,'20211008 16:57:33'	,'20211008 16:57:33')	,
('23638W-9K'	,'Bague en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Bague Femme en Pavé Oxydes de Zirconium (OZ).'	,1	,'BG'	,'BGDIV'	,'F'	,7	,2	,'BLA'	,1	,2.6	,76.96	,0	,10	,'23638W-9K.jpg'	,''	,''	,'20211008 16:57:34'	,'20211008 16:57:34')	,
('23656-9K'	,'Bague en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°°, Bague Femme sertie avec des Oxydes de Zirconium (OZ) et un Zircon Central.'	,1	,'BG'	,'BGDIV'	,'F'	,7	,2	,'JAU'	,1	,1.6	,47.36	,0	,10	,'23656-9K.jpg'	,''	,''	,'20211008 16:57:39'	,'20211008 16:57:39')	,
('8768-9k'	,'Bague en OR Jaune 9 Carats 375/°°°'	,'OR Jaune 9 Carats 375/°°°.Bague Femme Maille Américaine de 9 mm de Largeur. Maille Entrelacée et Martelée.'	,1	,'BG'	,'BGDIV'	,'F'	,10	,2	,'JAU'	,1	,2.8	,78.68	,0	,8.5	,'8768-9k.jpg'	,''	,''	,'20211008 16:59:22'	,'20211008 16:59:22')	,
('8768W-9k'	,'Bague en OR Blanc 9 Carats 375/°°°'	,'OR Blanc 9 Carats 375/°°°.Bague Femme Maille Américaine de 9 mm de Largeur. Maille Entrelacée et Martelée.'	,1	,'BG'	,'BGDIV'	,'F'	,10	,2	,'BLA'	,1	,2.8	,78.68	,0	,8.5	,'8768W-9k.jpg'	,''	,''	,'20211008 16:59:23'	,'20211008 16:59:23')	,
('R155-9k'	,'Bague en OR Jaune 9 Carats 375/°°°'	,'OR Jaune 9 Carats 375/°°°.Bague Femme Maille Palmier Tressée de 7 mm de Largeur dégradé.'	,1	,'BG'	,'BGDIV'	,'F'	,10	,2	,'JAU'	,1	,1.9	,53.39	,0	,8.5	,'R155-9k.jpg'	,''	,''	,'20211008 16:59:25'	,'20211008 16:59:25')	,
('9214-9K'	,'Chevalière en OR Jaune 18 Carats 750/°°° & Oxydes de Zirconium Multicolores'	,'OR Jaune 18 Carats 750/°°°.Chevalière Homme 9 Planetes avec Oxyde de Zirconium (OZ) Multicolores.'	,1	,'BG'	,'CHV'	,'H'	,7	,2	,'JAU'	,1	,3.9	,109.59	,0	,8.5	,'9214-9K.jpg'	,''	,''	,'20211008 16:59:24'	,'20211008 16:59:24')	,
('23055-9K'	,'Boucles d''Oreilles en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Boucles d''Oreilles Femme Coeur & Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'JAU'	,1	,1.6	,47.36	,0	,10	,'23055-9K.jpg'	,''	,''	,'20211008 16:57:15'	,'20211008 16:57:15')	,
('23055W-9K'	,'Boucles d''Oreilles en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Boucles d''Oreilles Femme Coeur & Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'BLA'	,1	,1.6	,47.36	,0	,10	,'23055W-9K.jpg'	,''	,''	,'20211008 16:57:16'	,'20211008 16:57:16')	,
('23714-9K'	,'Boucles d''Oreilles en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Boucles d''Oreilles Femme Papillon avec Oxydes de Zirconium (OZ).'	,0	,'BO'	,'BODIV'	,'F'	,7	,2	,'JAU'	,1	,1.15	,34.04	,0	,10	,'23714-9K.jpg'	,''	,''	,'20211008 16:57:56'	,'20211008 16:57:56')	,
('23714W-9K'	,'Boucles d''Oreilles en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Boucles d''Oreilles Femme Papillon avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'BLA'	,1	,1.15	,34.04	,0	,10	,'23714W-9K.jpg'	,''	,''	,'20211008 16:57:57'	,'20211008 16:57:57')	,
('23715-9K'	,'Boucles d''Oreilles en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Boucles d''Oreilles Femme Ronde avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'JAU'	,1	,1.4	,41.44	,0	,10	,'23715-9K.jpg'	,''	,''	,'20211008 16:57:58'	,'20211008 16:57:58')	,
('23715W-9K'	,'Boucles d''Oreilles en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Boucles d''Oreilles Femme Ronde avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'BLA'	,1	,1.4	,41.44	,0	,10	,'23715W-9K.jpg'	,''	,''	,'20211008 16:57:59'	,'20211008 16:57:59')	,
('23718-9K'	,'Boucles d''Oreilles Coeur en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Boucles d''Oreilles Femme Coeurs avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'JAU'	,1	,1.4	,41.44	,0	,10	,'23718-9K.jpg'	,''	,''	,'20211008 16:58:00'	,'20211008 16:58:00')	,
('23718W-9K'	,'Boucles d''Oreilles Coeur en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Boucles d''Oreilles Femme Coeur avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'BLA'	,1	,1.4	,41.44	,0	,10	,'23718W-9K.jpg'	,''	,''	,'20211008 16:58:01'	,'20211008 16:58:01')	,
('23720-9K'	,'Boucles d''Oreilles en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Boucles d''Oreilles Femme Créoles avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'JAU'	,1	,1.8	,53.28	,0	,10	,'23720-9K.jpg'	,''	,''	,'20211008 16:58:04'	,'20211008 16:58:04')	,
('23720W-9K'	,'Boucles d''Oreilles Créoles en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Boucles d''Oreilles Femme Créoles avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'BLA'	,1	,1.8	,53.28	,0	,10	,'23720W-9K.jpg'	,''	,''	,'20211008 16:58:05'	,'20211008 16:58:05')	,
('23721-9K'	,'Boucles d''Oreilles Créoles en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Boucles d''Oreilles Femme Créoles avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'JAU'	,1	,1.5	,44.40	,0	,10	,'23721-9K.jpg'	,''	,''	,'20211008 16:58:06'	,'20211008 16:58:06')	,
('23721W-9K'	,'Boucles d''Oreilles Créoles en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Boucles d''Oreilles Femme Créoles avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'BLA'	,1	,1.5	,44.40	,0	,10	,'23721W-9K.jpg'	,''	,''	,'20211008 16:58:07'	,'20211008 16:58:07')	,
('23722-9K'	,'Boucles d''Oreilles Créoles en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Boucles d''Oreilles Femme Créoles avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'JAU'	,1	,1.6	,47.36	,0	,10	,'23722-9K.jpg'	,''	,''	,'20211008 16:58:08'	,'20211008 16:58:08')	,
('23722W-9K'	,'Boucles d''Oreilles Créoles en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Boucles d''Oreilles Femme Créoles avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'BLA'	,1	,1.6	,47.36	,0	,10	,'23722W-9K.jpg'	,''	,''	,'20211008 16:58:09'	,'20211008 16:58:09')	,
('23724W-9K'	,'Boucles d''Oreilles en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Boucles d''Oreilles Femme Feuille avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'BLA'	,1	,1.4	,41.44	,0	,10	,'23724W-9K.jpg'	,''	,''	,'20211008 16:58:10'	,'20211008 16:58:10')	,
('23725W-9K'	,'Boucles d''Oreilles en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Boucles d''Oreilles Femme avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'BLA'	,1	,0.9	,26.64	,0	,10	,'23725W-9K.jpg'	,''	,''	,'20211008 16:58:11'	,'20211008 16:58:11')	,
('23726-9K'	,'Boucles d''Oreilles en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Boucles d''Oreilles Femme avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'JAU'	,1	,0.9	,26.64	,0	,10	,'23726-9K.jpg'	,''	,''	,'20211008 16:58:12'	,'20211008 16:58:12')	,
('23726W-9K'	,'Boucles d''Oreilles en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Boucles d''Oreilles Femme avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'BLA'	,1	,0.9	,26.64	,0	,10	,'23726W-9K.jpg'	,''	,''	,'20211008 16:58:13'	,'20211008 16:58:13')	,
('23727-9K'	,'Boucles d''Oreilles Goutte en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Boucles d''Oreilles Femme Goutte avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'JAU'	,1	,1.3	,38.48	,0	,10	,'23727-9K.jpg'	,''	,''	,'20211008 16:58:14'	,'20211008 16:58:14')	,
('23727W-9K'	,'Boucles d''Oreilles en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Boucles d''Oreilles Femme Goutte avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'BLA'	,1	,1.3	,38.48	,0	,10	,'23727W-9K.jpg'	,''	,''	,'20211008 16:58:15'	,'20211008 16:58:15')	,
('23728-9K'	,'Boucles d''Oreilles Fleur en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°°  Boucles d''Oreilles Femme Fleur avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'JAU'	,1	,0.95	,28.12	,0	,10	,'23728-9K.jpg'	,''	,''	,'20211008 16:58:16'	,'20211008 16:58:16')	,
('23728W-9K'	,'Boucles d''Oreilles Fleur en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Boucles d''Oreilles Femme Fleur avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'BLA'	,1	,0.95	,28.12	,0	,10	,'23728W-9K.jpg'	,''	,''	,'20211008 16:58:17'	,'20211008 16:58:17')	,
('23729-9K'	,'Boucles d''Oreilles Coeur en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Boucles d''Oreilles Femme Coeur avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'JAU'	,1	,1.2	,35.52	,0	,10	,'23729-9K.jpg'	,''	,''	,'20211008 16:58:18'	,'20211008 16:58:18')	,
('23729W-9K'	,'Boucles d''Oreilles Coeur en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Boucles d''Oreilles Femme Coeur avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'BLA'	,1	,1.2	,35.52	,0	,10	,'23729W-9K.jpg'	,''	,''	,'20211008 16:58:19'	,'20211008 16:58:19')	,
('23730W-9K'	,'Boucles d''Oreilles Fleur en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Boucles d''Oreilles Femme Fleur avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'BLA'	,1	,1.1	,32.56	,0	,10	,'23730W-9K.jpg'	,''	,''	,'20211008 16:58:20'	,'20211008 16:58:20')	,
('23733-9K'	,'Boucles d''Oreilles Trèfle en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Boucles d''Oreilles Femme Trèfle avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'JAU'	,1	,1.2	,35.52	,0	,10	,'23733-9K.jpg'	,''	,''	,'20211008 16:58:21'	,'20211008 16:58:21')	,
('23733W-9K'	,'Boucles d''Oreilles Trèfle en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Boucles d''Oreilles Femme Trèfle Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'BLA'	,1	,1.2	,35.52	,0	,10	,'23733W-9K.jpg'	,''	,''	,'20211008 16:58:22'	,'20211008 16:58:22')	,
('23734-9K'	,'Boucles d''Oreilles Trèfle en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Boucles d''Oreilles Femme Trèfle avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'JAU'	,1	,1	,29.60	,0	,10	,'23734-9K.jpg'	,''	,''	,'20211008 16:58:23'	,'20211008 16:58:23')	,
('23734W-9K'	,'Boucles d''Oreilles Trèfle en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°°  Boucles d''Oreilles Femme Trèfle Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'BLA'	,1	,1	,29.60	,0	,10	,'23734W-9K.jpg'	,''	,''	,'20211008 16:58:24'	,'20211008 16:58:24')	,
('23735-9K'	,'Boucles d''Oreilles en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Boucles d''Oreilles Femme avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'JAU'	,1	,1.1	,32.56	,0	,10	,'23735-9K.jpg'	,''	,''	,'20211008 16:58:25'	,'20211008 16:58:25')	,
('23735W-9K'	,'Boucles d''Oreilles en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'BLA'	,1	,1.1	,32.56	,0	,10	,'23735W-9K.jpg'	,''	,''	,'20211008 16:58:26'	,'20211008 16:58:26')	,
('23736-9K'	,'Boucles d''Oreilles Coeur en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Boucles d''Oreilles Femme Coeur avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'JAU'	,1	,1.3	,38.48	,0	,10	,'23736-9K.jpg'	,''	,''	,'20211008 16:58:27'	,'20211008 16:58:27')	,
('23736W-9K'	,'Boucles d''Oreilles Coeur en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Boucles d''Oreilles Femme Coeur avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'BLA'	,1	,1.3	,38.48	,0	,10	,'23736W-9K.jpg'	,''	,''	,'20211008 16:58:28'	,'20211008 16:58:28')	,
('23739-9K'	,'Boucles d''Oreilles en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Boucles d''Oreilles Femme Coeur avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'JAU'	,1	,1.2	,35.52	,0	,10	,'23739-9K.jpg'	,''	,''	,'20211008 16:58:33'	,'20211008 16:58:33')	,
('23739W-9K'	,'Boucles d''Oreilles Coeur en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Boucles d''Oreilles Femme Coeur avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'BLA'	,1	,1.2	,35.52	,0	,10	,'23739W-9K.jpg'	,''	,''	,'20211008 16:58:34'	,'20211008 16:58:34')	,
('23740-9K'	,'Boucles d''Oreilles en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Boucles d''Oreilles Femme avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'JAU'	,1	,1.4	,41.44	,0	,10	,'23740-9K.jpg'	,''	,''	,'20211008 16:58:35'	,'20211008 16:58:35')	,
('23740W-9K'	,'Boucles d''Oreilles en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Boucles d''Oreilles Femme avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'BLA'	,1	,1.4	,41.44	,0	,10	,'23740W-9K.jpg'	,''	,''	,'20211008 16:58:36'	,'20211008 16:58:36')	,
('23752-9K'	,'Boucles d''Oreilles Papillon en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Boucles d''Oreilles Femme Papillon avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'JAU'	,1	,1.3	,38.48	,0	,10	,'23752-9K.jpg'	,''	,''	,'20211008 16:58:39'	,'20211008 16:58:39')	,
('23752W-9K'	,'Boucles d''Oreilles Papillon en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Papillon Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'BLA'	,1	,1.3	,38.48	,0	,10	,'23752W-9K.jpg'	,''	,''	,'20211008 16:58:40'	,'20211008 16:58:40')	,
('23754-9K'	,'Boucles d''Oreilles en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Boucles d''Oreilles Femme avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'JAU'	,1	,1.8	,53.28	,0	,10	,'23754-9K.jpg'	,''	,''	,'20211008 16:58:41'	,'20211008 16:58:41')	,
('23754W-9K'	,'Boucles d''Oreilles en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Boucles d''Oreilles Femme avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'BLA'	,1	,1.8	,53.28	,0	,10	,'23754W-9K.jpg'	,''	,''	,'20211008 16:58:42'	,'20211008 16:58:42')	,
('23759-9K'	,'Boucles d''Oreilles en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Boucles d''Oreilles Femme avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'JAU'	,1	,1.1	,32.56	,0	,10	,'23759-9K.jpg'	,''	,''	,'20211008 16:58:43'	,'20211008 16:58:43')	,
('23759W-9K'	,'Boucles d''Oreilles en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'BLA'	,1	,1.1	,32.56	,0	,10	,'23759W-9K.jpg'	,''	,''	,'20211008 16:58:44'	,'20211008 16:58:44')	,
('23762W-9K'	,'Boucles d''Oreilles Créoles en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Boucles d''Oreilles Femme Créoles avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'BLA'	,1	,1.7	,50.32	,0	,10	,'23762W-9K.jpg'	,''	,''	,'20211008 16:58:47'	,'20211008 16:58:47')	,
('23831-9K'	,'Boucles d''Oreilles Créoles en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Boucles d''Oreilles Femme Créoles avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'JAU'	,1	,1.3	,38.48	,0	,10	,'23831-9K.jpg'	,''	,''	,'20211008 16:58:58'	,'20211008 16:58:58')	,
('23831W-9K'	,'Boucles d''Oreilles Créoles en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Créoles avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'BLA'	,1	,1.3	,38.48	,0	,10	,'23831W-9K.jpg'	,''	,''	,'20211008 16:58:59'	,'20211008 16:58:59')	,
('23845-9K'	,'Boucles d''Oreilles Créoles en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Boucles d''Oreilles Femme Créoles avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'JAU'	,1	,1.5	,44.40	,0	,10	,'23845-9K.jpg'	,''	,''	,'20211008 16:59:02'	,'20211008 16:59:02')	,
('23845W-9K'	,'Boucles d''Oreilles Créoles en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Boucles d''Oreilles Femme Créoles avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'BLA'	,1	,1.5	,44.40	,0	,10	,'23845W-9K.jpg'	,''	,''	,'20211008 16:59:03'	,'20211008 16:59:03')	,
('23846-9K'	,'Boucles d''Oreilles Créoles en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Boucles d''Oreilles Femme Créoles avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'JAU'	,1	,1.7	,50.32	,0	,10	,'23846-9K.jpg'	,''	,''	,'20211008 16:59:04'	,'20211008 16:59:04')	,
('23846W-9K'	,'Boucles d''Oreilles Créoles en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Boucles d''Oreilles Femme Créoles avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'BLA'	,1	,1.7	,50.32	,0	,10	,'23846W-9K.jpg'	,''	,''	,'20211008 16:59:05'	,'20211008 16:59:05')	,
('23847-9K'	,'Boucles d''Oreilles Créoles en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Boucles d''Oreilles Femme Créoles avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'JAU'	,1	,1.9	,56.24	,0	,10	,'23847-9K.jpg'	,''	,''	,'20211008 16:59:06'	,'20211008 16:59:06')	,
('23847W-9K'	,'Boucles d''Oreilles Créoles en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Boucles d''Oreilles Femme Créoles avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'BLA'	,1	,1.9	,56.24	,0	,10	,'23847W-9K.jpg'	,''	,''	,'20211008 16:59:07'	,'20211008 16:59:07')	,
('23848-9K'	,'Boucles d''Oreilles en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Boucles d''Oreilles Femme avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'JAU'	,1	,1.8	,53.28	,0	,10	,'23848-9K.jpg'	,''	,''	,'20211008 16:59:08'	,'20211008 16:59:08')	,
('23848W-9K'	,'Boucles d''Oreilles en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Boucles d''Oreilles Femme avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'BLA'	,1	,1.8	,53.28	,0	,10	,'23848W-9K.jpg'	,''	,''	,'20211008 16:59:09'	,'20211008 16:59:09')	,
('23849-9K'	,'Boucles d''Oreilles Créoles en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Boucles d''Oreilles Femme Créoles avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'JAU'	,1	,2.7	,79.92	,0	,10	,'23849-9K.jpg'	,''	,''	,'20211008 16:59:10'	,'20211008 16:59:10')	,
('23849W-9K'	,'Boucles d''Oreilles Créoles en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Boucles d''Oreilles Femme Créoles avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'BLA'	,1	,2.7	,79.92	,0	,10	,'23849W-9K.jpg'	,''	,''	,'20211008 16:59:11'	,'20211008 16:59:11')	,
('23852W-9K'	,'Boucles d''Oreilles Créoles en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Boucles d''Oreilles Femme Créoles avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'BLA'	,1	,1.6	,44.96	,0	,8.5	,'23852W-9K.jpg'	,''	,''	,'20211008 16:59:12'	,'20211008 16:59:12')	,
('23854W-9K'	,'Boucles d''Oreilles en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Boucles d''Oreilles Femme avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'BLA'	,1	,1.8	,53.28	,0	,10	,'23854W-9K.jpg'	,''	,''	,'20211008 16:59:13'	,'20211008 16:59:13')	,
('23861-9K'	,'Boucles d''Oreilles Créoles en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Boucles d''Oreilles Femme Créoles avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'JAU'	,1	,1.6	,47.36	,0	,10	,'23861-9K.jpg'	,''	,''	,'20211008 16:59:14'	,'20211008 16:59:14')	,
('23861W-9K'	,'Boucles d''Oreilles Créoles en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Boucles d''Oreilles Femme Créoles avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'BLA'	,1	,1.6	,47.36	,0	,10	,'23861W-9K.jpg'	,''	,''	,'20211008 16:59:15'	,'20211008 16:59:15')	,
('23863-9K'	,'Boucles d''Oreilles en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Boucles d''Oreilles Femme avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'JAU'	,1	,1	,29.60	,0	,10	,'23863-9K.jpg'	,''	,''	,'20211008 16:59:16'	,'20211008 16:59:16')	,
('23863W-9K'	,'Boucles d''Oreilles en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Boucles d''Oreilles Femme avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BODIV'	,'F'	,7	,2	,'BLA'	,1	,1	,29.60	,0	,10	,'23863W-9K.jpg'	,''	,''	,'20211008 16:59:17'	,'20211008 16:59:17')	,
('23719-9K'	,'Boucles d''Oreilles en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Boucles d''Oreilles Femme Pendantes avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BOPEN'	,'F'	,7	,2	,'JAU'	,1	,1.2	,35.52	,0	,10	,'23719-9K.jpg'	,''	,''	,'20211008 16:58:02'	,'20211008 16:58:02')	,
('23719W-9K'	,'Boucles d''Oreilles en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Boucles d''Oreilles Femme Pendantes avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BOPEN'	,'F'	,7	,2	,'BLA'	,1	,1.2	,35.52	,0	,10	,'23719W-9K.jpg'	,''	,''	,'20211008 16:58:03'	,'20211008 16:58:03')	,
('23737-9K'	,'Boucles d''Oreilles Goutte en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 18 Carats 750/°°° Boucles d''Oreilles Femme Pendantes Goutte avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BOPEN'	,'F'	,7	,2	,'JAU'	,1	,1.7	,50.32	,0	,10	,'23737-9K.jpg'	,''	,''	,'20211008 16:58:29'	,'20211008 16:58:29')	,
('23737W-9K'	,'Boucles d''Oreilles Goutte en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Boucles d''Oreilles Femme Pendantes Goutte avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BOPEN'	,'F'	,7	,2	,'BLA'	,1	,1.7	,50.32	,0	,10	,'23737W-9K.jpg'	,''	,''	,'20211008 16:58:30'	,'20211008 16:58:30')	,
('23738-9K'	,'Boucles d''Oreilles Goutte en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Boucles d''Oreilles Femme Pendantes Goutte avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BOPEN'	,'F'	,7	,2	,'JAU'	,1	,1.1	,32.56	,0	,10	,'23738-9K.jpg'	,''	,''	,'20211008 16:58:31'	,'20211008 16:58:31')	,
('23738W-9K'	,'Boucles d''Oreilles en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Boucles d''Oreilles Femme Pendantes avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BOPEN'	,'F'	,7	,2	,'BLA'	,1	,1.1	,32.56	,0	,10	,'23738W-9K.jpg'	,''	,''	,'20211008 16:58:32'	,'20211008 16:58:32')	,
('23741-9K'	,'Boucles d''Oreilles en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Boucles d''Oreilles Femme Pendantes Perle d''eau douce Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BOPEN'	,'F'	,7	,2	,'JAU'	,1	,2.1	,62.16	,0	,10	,'23741-9K.jpg'	,''	,''	,'20211008 16:58:37'	,'20211008 16:58:37')	,
('23741W-9K'	,'Boucles d''Oreilles Perle d''eau douce en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Boucles d''Oreilles Femme Pendantes Perle d''eau douce Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BOPEN'	,'F'	,7	,2	,'BLA'	,1	,2.1	,62.16	,0	,10	,'23741W-9K.jpg'	,''	,''	,'20211008 16:58:38'	,'20211008 16:58:38')	,
('23761-9K'	,'Boucles d''Oreilles en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Boucles d''Oreilles Femme Pendantes avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BOPEN'	,'F'	,7	,2	,'JAU'	,1	,3.9	,115.44	,0	,10	,'23761-9K.jpg'	,''	,''	,'20211008 16:58:45'	,'20211008 16:58:45')	,
('23761W-9K'	,'Boucles d''Oreilles en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 18 Carats 750/°°° Boucles d''Oreilles Femme Pendantes avec Oxydes de Zirconium (OZ) et un Zircon Central.'	,1	,'BO'	,'BOPEN'	,'F'	,7	,2	,'BLA'	,1	,3.9	,115.44	,0	,10	,'23761W-9K.jpg'	,''	,''	,'20211008 16:58:46'	,'20211008 16:58:46')	,
('23766-9K'	,'Boucles d''Oreilles en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Boucles d''Oreilles Femme Pendantes avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BOPEN'	,'F'	,7	,2	,'JAU'	,1	,1.4	,41.44	,0	,10	,'23766-9K.jpg'	,''	,''	,'20211008 16:59:20'	,'20211008 16:59:20')	,
('23766W-9K'	,'Boucles d''Oreilles en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°°Boucles d''Oreilles Femme Pendantes avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BOPEN'	,'F'	,7	,2	,'BLA'	,1	,1.4	,39.34	,0	,8.5	,'23766W-9K.jpg'	,''	,''	,'20211008 16:59:21'	,'20211008 16:59:21')	,
('23802W-9K'	,'Boucles d''Oreilles en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Boucles d''Oreilles Femme Pendantes Cœur avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BOPEN'	,'F'	,7	,2	,'BLA'	,1	,1.4	,41.44	,0	,10	,'23802W-9K.jpg'	,''	,''	,'20211008 16:58:57'	,'20211008 16:58:57')	,
('23841-9K'	,'Boucles d''Oreilles en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Boucles d''Oreilles Femme Pendantes avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BOPEN'	,'F'	,7	,2	,'JAU'	,1	,1.8	,53.28	,0	,10	,'23841-9K.jpg'	,''	,''	,'20211008 16:59:00'	,'20211008 16:59:00')	,
('23841W-9K'	,'Boucles d''Oreilles en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°°Boucles d''Oreilles Femme Pendantes avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BOPEN'	,'F'	,7	,2	,'BLA'	,1	,1.8	,53.28	,0	,10	,'23841W-9K.jpg'	,''	,''	,'20211008 16:59:01'	,'20211008 16:59:01')	,
('23864-9K'	,'Boucles d''Oreilles en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Boucles d''Oreilles Femme Pendantes avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BOPEN'	,'F'	,7	,2	,'JAU'	,1	,4.1	,121.36	,0	,10	,'23864-9K.jpg'	,''	,''	,'20211008 16:59:18'	,'20211008 16:59:18')	,
('23864W-9K'	,'Boucles d''Oreilles en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°°Boucles d''Oreilles Femme Pendantes avec Oxydes de Zirconium (OZ).'	,1	,'BO'	,'BOPEN'	,'F'	,7	,2	,'BLA'	,1	,4.1	,121.36	,0	,10	,'23864W-9K.jpg'	,''	,''	,'20211008 16:59:19'	,'20211008 16:59:19')	,
('R1013-9K'	,'Boucles d''Oreilles  en OR Jaune 9 Carats 375/°°°'	,'OR Jaune 9 Carats 375/°°°.Boucles d''Oreilles Enfant Boules Polies Miroir de 4 mm de Diamètre. Fermoirs à Poussettes.'	,1	,'BO'	,'PUCE'	,'E'	,10	,2	,'JAU'	,2	,0.35	,16.86	,0	,10	,'R1013-9K.jpg'	,''	,''	,'20211008 17:00:03'	,'20211008 17:00:03')	,
('R1014-9K'	,'Boucles d''Oreilles  en OR Jaune 9 Carats 375/°°°'	,'OR Jaune 9 Carats 375/°°°.Boucles d''Oreilles Femme Boules Polies Miroir de 5 mm de Diamètre. Fermoirs à Poussettes.'	,1	,'BO'	,'PUCE'	,'F'	,10	,2	,'JAU'	,2	,0.4	,20.64	,0	,12.8	,'R1014-9K.jpg'	,''	,''	,'20211008 17:00:04'	,'20211008 17:00:04')	,
('R1015-9K'	,'Boucles d''Oreilles  en OR Jaune 9 Carats 375/°°°'	,'OR Jaune 9 Carats 375/°°°.Boucles d''Oreilles Femme Boules Polies Miroir de 6 mm de Diamètre. Fermoirs à Poussettes.'	,1	,'BO'	,'PUCE'	,'F'	,10	,2	,'JAU'	,2	,0.48	,25.41	,0	,16	,'R1015-9K.jpg'	,''	,''	,'20211008 17:00:05'	,'20211008 17:00:05')	,
('R1057-9K'	,'Boucles d''Oreilles  en OR Jaune 9 Carats 375/°°°'	,'OR Jaune 9 Carats 375/°°°.Boucles d''Oreilles Femme avec Oxyde de Zirconium (OZ). serti clos de 2 mm de Diamètre. Fermoirs à Poussettes.'	,1	,'BO'	,'PUCE'	,'E'	,7	,2	,'JAU'	,2	,0.31	,11.10	,0	,5.02	,'R1057-9K.jpg'	,''	,''	,'20211008 17:00:06'	,'20211008 17:00:06')	,
('R1058-9K'	,'Boucles d''Oreilles  en OR Jaune 9 Carats 375/°°°'	,'OR Jaune 9 Carats 375/°°°.Boucles d''Oreilles Femme avec Oxyde de Zirconium (OZ). serti clos de 3 mm de Diamètre. Fermoirs à Poussettes.'	,1	,'BO'	,'PUCE'	,'E'	,7	,2	,'JAU'	,2	,0.3	,16.51	,0	,10.63	,'R1058-9K.jpg'	,''	,''	,'20211008 17:00:07'	,'20211008 17:00:07')	,
('R1059-9K'	,'Boucles d''Oreilles  en OR Jaune 9 Carats 375/°°°'	,'OR Jaune 9 Carats 375/°°°.Boucles d''Oreilles Femme avec Oxyde de Zirconium (OZ). serti clos de 4 mm de Diamètre. Fermoirs à Poussettes.'	,1	,'BO'	,'PUCE'	,'F'	,7	,2	,'JAU'	,2	,0.37	,19.19	,0	,11.94	,'R1059-9K.jpg'	,''	,''	,'20211008 17:00:08'	,'20211008 17:00:08')	,
('R1060-9K'	,'Boucles d''Oreilles  en OR Jaune 9 Carats 375/°°°'	,'OR Jaune 9 Carats 375/°°°.Boucles d''Oreilles Femme avec Oxyde de Zirconium (OZ). serti clos de 5 mm de Diamètre. Fermoirs à Poussettes.'	,1	,'BO'	,'PUCE'	,'F'	,7	,2	,'JAU'	,2	,0.46	,25.31	,0	,16.29	,'R1060-9K.jpg'	,''	,''	,'20211008 17:00:09'	,'20211008 17:00:09')	,
('23018-9K'	,'Pendentif en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Pendentif Femme en forme de Main & Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,2	,'JAU'	,1	,1.6	,47.36	,0	,10	,'23018-9K.jpg'	,''	,''	,'20211008 16:57:17'	,'20211008 16:57:17')	,
('23018W-9K'	,'Pendentif en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Pendentif Femme en forme de Main & Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,2	,'BLA'	,1	,1.6	,47.36	,0	,10	,'23018W-9K.jpg'	,''	,''	,'20211008 16:57:18'	,'20211008 16:57:18')	,
('23678-9K'	,'Pendentif en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Pendentif Femme  Cœur avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,2	,'BLA'	,1	,1	,29.60	,0	,10	,'23678-9K.jpg'	,''	,''	,'20211008 16:57:40'	,'20211008 16:57:40')	,
('23678W-9K'	,'Pendentif Coeur en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Pendentif Femme  Cœur avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,2	,'BLA'	,1	,1	,29.60	,0	,10	,'23678W-9K.jpg'	,''	,''	,'20211008 16:57:41'	,'20211008 16:57:41')	,
('23679W-9K'	,'Pendentif Coeur en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Pendentif Femme  Cœur avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,2	,'BLA'	,1	,0.55	,16.28	,0	,10	,'23679W-9K.jpg'	,''	,''	,'20211008 16:57:42'	,'20211008 16:57:42')	,
('23680W-9K'	,'Pendentif Coeur en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Pendentif Femme  Cœur Double avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,2	,'BLA'	,1	,0.8	,23.68	,0	,10	,'23680W-9K.jpg'	,''	,''	,'20211008 16:57:43'	,'20211008 16:57:43')	,
('23681W-9K'	,'Pendentif Coeur en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Pendentif Femme  Cœur Double avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,2	,'BLA'	,1	,1.3	,38.48	,0	,10	,'23681W-9K.jpg'	,''	,''	,'20211008 16:57:44'	,'20211008 16:57:44')	,
('23682W-9K'	,'Pendentif Coeur en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Pendentif Femme  Cœur avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,2	,'BLA'	,1	,1.7	,50.32	,0	,10	,'23682W-9K.jpg'	,''	,''	,'20211008 16:57:45'	,'20211008 16:57:45')	,
('23684-9K'	,'Pendentif Soleil en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Pendentif Femme  Soleil avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,2	,'JAU'	,1	,2.1	,62.16	,0	,10	,'23684-9K.jpg'	,''	,''	,'20211008 16:57:46'	,'20211008 16:57:46')	,
('23684W-9K'	,'Pendentif Soleil en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Pendentif Femme  Soleil avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,2	,'BLA'	,1	,2.1	,62.16	,0	,10	,'23684W-9K.jpg'	,''	,''	,'20211008 16:57:47'	,'20211008 16:57:47')	,
('23686-9K'	,'Pendentif Papillon en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Pendentif Femme  Papillon & Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,2	,'JAU'	,1	,1.6	,47.36	,0	,10	,'23686-9K.jpg'	,''	,''	,'20211008 16:57:48'	,'20211008 16:57:48')	,
('23686W-9K'	,'Pendentif Papillon en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Pendentif Femme  Papillon & Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,2	,'BLA'	,1	,1.6	,47.36	,0	,10	,'23686W-9K.jpg'	,''	,''	,'20211008 16:57:49'	,'20211008 16:57:49')	,
('23687-9K'	,'Pendentif  Coeur en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Pendentif Femme  Coeur avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,2	,'JAU'	,1	,0.8	,23.68	,0	,10	,'23687-9K.jpg'	,''	,''	,'20211008 16:57:50'	,'20211008 16:57:50')	,
('23687W-9K'	,'Pendentif Coeur en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Pendentif Femme  Cœur avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,2	,'BLA'	,1	,0.8	,23.68	,0	,10	,'23687W-9K.jpg'	,''	,''	,'20211008 16:57:51'	,'20211008 16:57:51')	,
('23689-9K'	,'Pendentif en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Pendentif Femme avec Oxydes de Zirconium (OZ) et un Zircon Central.'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,2	,'JAU'	,1	,1.6	,47.36	,0	,10	,'23689-9K.jpg'	,''	,''	,'20211008 16:57:52'	,'20211008 16:57:52')	,
('23689W-9K'	,'Pendentif en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Pendentif Femme avec Oxydes de Zirconium (OZ) et un Zircon Central.'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,2	,'BLA'	,1	,1.6	,47.36	,0	,10	,'23689W-9K.jpg'	,''	,''	,'20211008 16:57:53'	,'20211008 16:57:53')	,
('23690-9K'	,'Pendentif Croix en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Pendentif Femme  Croix avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,2	,'BLA'	,1	,0.8	,22.48	,0	,8.5	,'23690-9K.jpg'	,''	,''	,'20211008 16:57:54'	,'20211008 16:57:54')	,
('23711-9K'	,'Pendentif Perle d''eau douce en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Pendentif Femme  Perle d''eau douce Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,2	,'JAU'	,1	,1.1	,32.56	,0	,10	,'23711-9K.jpg'	,''	,''	,'20211008 16:57:55'	,'20211008 16:57:55')	,
('23767-9K'	,'Pendentif Coeur en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Pendentif Femme  Coeur avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,2	,'JAU'	,1	,0.85	,25.16	,0	,10	,'23767-9K.jpg'	,''	,''	,'20211008 16:58:48'	,'20211008 16:58:48')	,
('23767W-9K'	,'Pendentif Coeur en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Pendentif Femme  Cœur avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,2	,'BLA'	,1	,0.85	,25.16	,0	,10	,'23767W-9K.jpg'	,''	,''	,'20211008 16:58:49'	,'20211008 16:58:49')	,
('23773W-9K'	,'Pendentif Coeur en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Pendentif Femme  Cœur avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,2	,'BLA'	,1	,1.3	,38.48	,0	,10	,'23773W-9K.jpg'	,''	,''	,'20211008 16:58:50'	,'20211008 16:58:50')	,
('23775-9K'	,'Pendentif Croix en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Pendentif Femme  Croix avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,2	,'JAU'	,1	,0.55	,16.28	,0	,10	,'23775-9K.jpg'	,''	,''	,'20211008 16:58:51'	,'20211008 16:58:51')	,
('23775W-9K'	,'Pendentif Croix en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Pendentif Femme  Croix avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,2	,'BLA'	,1	,0.55	,16.28	,0	,10	,'23775W-9K.jpg'	,''	,''	,'20211008 16:58:52'	,'20211008 16:58:52')	,
('23776W-9K'	,'Pendentif Croix en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Pendentif Femme  Croix avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,2	,'BLA'	,1	,0.95	,28.12	,0	,10	,'23776W-9K.jpg'	,''	,''	,'20211008 16:58:53'	,'20211008 16:58:53')	,
('23788-9K'	,'Pendentif Papillon en OR Jaune 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Jaune 9 Carats 375/°°° Pendentif Femme  Papillon avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,2	,'JAU'	,1	,3.6	,106.56	,0	,10	,'23788-9K.jpg'	,''	,''	,'20211008 16:58:54'	,'20211008 16:58:54')	,
('23788W-9K'	,'Pendentif Papillon en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Pendentif Femme  Papillon & Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,2	,'BLA'	,1	,3.6	,106.56	,0	,10	,'23788W-9K.jpg'	,''	,''	,'20211008 16:58:55'	,'20211008 16:58:55')	,
('23789W-9K'	,'Pendentif Coeur  en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Pendentif Femme  Cœur avec Oxydes de Zirconium (OZ).'	,1	,'PDT'	,'PDTDIV'	,'F'	,7	,2	,'BLA'	,1	,0.7	,20.72	,0	,10	,'23789W-9K.jpg'	,''	,''	,'20211008 16:58:56'	,'20211008 16:58:56')	,
('3557PW-9K'	,'Piercing en OR Blanc 9 Carats 375/°°° & Oxyde de Zirconium'	,'OR Blanc 9 Carats 375/°°° Piercing Nez Femme avec Oxydes de Zirconium (OZ).'	,1	,'PG'	,'PGDIV'	,'F'	,7	,2	,'BLA'	,2	,0.06	,4.90	,0	,3.72	,'3557PW-9K.jpg'	,''	,''	,'20211008 17:00:00'	,'20211008 17:00:00')	,
('3558P-9K'	,'Piercing en OR 9 Carats 375/°°° '	,'OR Jaune 9 Carats 375/°°° Piercing Femme Nez Boule'	,1	,'PG'	,'PGDIV'	,'F'	,10	,2	,'JAU'	,2	,0.06	,4.01	,0	,2.83	,'3558P-9K.jpg'	,''	,''	,'20211008 17:00:01'	,'20211008 17:00:01')	,
('A51350-9K'	,'Piercing en OR 9 Carats 375/°°° '	,'OR Jaune 9 Carats 375/°°° Piercing Femme Langue 2 Boules.'	,1	,'PG'	,'PGDIV'	,'F'	,10	,2	,'JAU'	,2	,0.63	,28.93	,0	,16.58	,'A51350-9K.jpg'	,''	,''	,'20211008 17:00:02'	,'20211008 17:00:02')	,
('A7049'	,'Bague Argent 925/°°° '	,'Argent 925/°°°  , Bague Femme ''V'' Martelée'	,1	,'BG'	,'BGDIV'	,'F'	,10	,3	,''	,2	,1.52	,4.31	,0	,2.49	,'A7049.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A7050'	,'Bague Argent 925/°°° '	,'Argent 925/°°°  , Bague Femme ''V'' 3 Rangs'	,1	,'BG'	,'BGDIV'	,'F'	,10	,3	,''	,2	,2.6	,7.29	,0	,4.17	,'A7050.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6418'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme'	,0	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,4.87	,13.41	,0	,7.57	,'A6418.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6419'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme Facetté'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,4.2	,9.69	,0	,4.65	,'A6419.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6420'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme Facetté'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,3.44	,9.94	,0	,5.81	,'A6420.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6421'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme Facetté'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,4.91	,13.38	,0	,7.49	,'A6421.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6422'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme Facetté'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,4.09	,13.5	,0	,8.59	,'A6422.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6425'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme'	,0	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,4.05	,13.53	,0	,8.67	,'A6425.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6426'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme avec Oxyde de Zirconium'	,1	,'BG'	,'CHV'	,'H'	,7	,3	,''	,2	,4.45	,10.83	,0	,5.49	,'A6426.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6427'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme Fer à Cheval'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,5.82	,15.35	,0	,8.37	,'A6427.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6428'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme Ancre Marine'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,4.18	,10.76	,0	,5.74	,'A6428.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6944'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme avec Onyx'	,1	,'BG'	,'CHV'	,'H'	,8	,3	,''	,2	,3.95	,14.38	,0	,9.64	,'A6944.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6946'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme avec Onyx'	,1	,'BG'	,'CHV'	,'H'	,8	,3	,''	,2	,6.41	,23.11	,0	,15.42	,'A6946.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6948'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme avec Onyx'	,1	,'BG'	,'CHV'	,'H'	,8	,3	,''	,2	,9	,33.49	,0	,22.69	,'A6948.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6950'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme avec Onyx et Serpent'	,1	,'BG'	,'CHV'	,'H'	,8	,3	,''	,2	,4.23	,15.14	,0	,10.06	,'A6950.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6952'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme avec Onyx et Serpent'	,1	,'BG'	,'CHV'	,'H'	,8	,3	,''	,2	,6.64	,24.09	,0	,16.12	,'A6952.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6954'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme avec Onyx et Serpent'	,1	,'BG'	,'CHV'	,'H'	,8	,3	,''	,2	,4.14	,15.04	,0	,10.07	,'A6954.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6955'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme avec Onyx et Serpent'	,1	,'BG'	,'CHV'	,'H'	,8	,3	,''	,2	,5.67	,19.73	,0	,12.93	,'A6955.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6956'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme avec Onyx'	,1	,'BG'	,'CHV'	,'H'	,8	,3	,''	,2	,3.86	,14.21	,0	,9.58	,'A6956.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6957'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme avec Onyx'	,1	,'BG'	,'CHV'	,'H'	,8	,3	,''	,2	,5.41	,18.97	,0	,12.48	,'A6957.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6958'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme avec Onyx'	,1	,'BG'	,'CHV'	,'H'	,8	,3	,''	,2	,3.88	,14.39	,0	,9.73	,'A6958.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6959'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme avec Onyx'	,1	,'BG'	,'CHV'	,'H'	,8	,3	,''	,2	,5.6	,21.82	,0	,15.1	,'A6959.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6960'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme avec Onyx'	,1	,'BG'	,'CHV'	,'H'	,8	,3	,''	,2	,6.09	,20.6	,0	,13.29	,'A6960.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6961'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme'	,0	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,5.5	,15.03	,0	,8.43	,'A6961.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6962'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,8.77	,24.22	,0	,13.7	,'A6962.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6963'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,2.49	,7.39	,0	,4.4	,'A6963.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6964'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,4.06	,13.03	,0	,8.16	,'A6964.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6965'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,6.5	,18.39	,0	,10.59	,'A6965.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6966'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,2.25	,7.29	,0	,4.59	,'A6966.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6967'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,4.96	,13.41	,0	,7.46	,'A6967.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6968'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,4.13	,10	,0	,5.04	,'A6968.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6969'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,4.66	,12.64	,0	,7.05	,'A6969.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6970'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,5.36	,14.47	,0	,8.04	,'A6970.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6971'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,4.94	,12.49	,0	,6.56	,'A6971.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6972'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,4.4	,10.98	,0	,5.7	,'A6972.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6973'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,4.62	,11.27	,0	,5.73	,'A6973.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6974'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme Fer à Cheval'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,4.05	,10.71	,0	,5.85	,'A6974.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6975'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme Fer à Cheval'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,4.9	,13.86	,0	,7.98	,'A6975.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6976'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme Tête de Cheval'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,5.62	,15	,0	,8.26	,'A6976.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6977'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme Ancre Marine'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,5.64	,14.63	,0	,7.86	,'A6977.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6980'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme Facetté'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,2.45	,9.63	,0	,6.69	,'A6980.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6981'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Mixte Facettée'	,1	,'BG'	,'CHV'	,'M'	,10	,3	,''	,2	,1.78	,5.09	,0	,2.95	,'A6981.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6984'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,3.8	,10.58	,0	,6.02	,'A6984.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6985'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,3.48	,10.05	,0	,5.87	,'A6985.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6987'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme Facetté'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,5.49	,13.98	,0	,7.39	,'A6987.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6988'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme Facetté'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,4.35	,12.77	,0	,7.55	,'A6988.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6990'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme avec Oxyde de Zirconium'	,1	,'BG'	,'CHV'	,'H'	,7	,3	,''	,2	,5.7	,14.7	,0	,7.86	,'A6990.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6991'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme avec Oxyde de Zirconium'	,1	,'BG'	,'CHV'	,'H'	,7	,3	,''	,2	,4.58	,12.5	,0	,7	,'A6991.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6992'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme avec Oxyde de Zirconium'	,1	,'BG'	,'CHV'	,'H'	,7	,3	,''	,2	,2.2	,8.34	,0	,5.7	,'A6992.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6993'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme avec Oxyde de Zirconium'	,1	,'BG'	,'CHV'	,'H'	,7	,3	,''	,2	,2.2	,8.74	,0	,6.1	,'A6993.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6997'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Mixte'	,1	,'BG'	,'CHV'	,'M'	,10	,3	,''	,2	,1.23	,4	,0	,2.52	,'A6997.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A6998'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Mixte Facettée'	,1	,'BG'	,'CHV'	,'M'	,10	,3	,''	,2	,1.23	,4.05	,0	,2.57	,'A6998.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A7000'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Mixte'	,1	,'BG'	,'CHV'	,'M'	,10	,3	,''	,2	,1.15	,3.62	,0	,2.24	,'A7000.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A7001'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Mixte'	,1	,'BG'	,'CHV'	,'M'	,10	,3	,''	,2	,1.1	,3.7	,0	,2.38	,'A7001.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A7002'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Mixte'	,1	,'BG'	,'CHV'	,'M'	,10	,3	,''	,2	,0.73	,2.89	,0	,2.01	,'A7002.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A7003'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Mixte'	,1	,'BG'	,'CHV'	,'M'	,10	,3	,''	,2	,0.68	,2.58	,0	,1.76	,'A7003.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A7004'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Mixte'	,1	,'BG'	,'CHV'	,'M'	,10	,3	,''	,2	,1	,3.16	,0	,1.96	,'A7004.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A7031'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme Facetté'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,5.36	,13.41	,0	,6.98	,'A7031.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A7032'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,3.55	,9.12	,0	,4.86	,'A7032.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A7033'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,3.32	,8.59	,0	,4.61	,'A7033.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A7034'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme Facetté'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,5.45	,14.85	,0	,8.31	,'A7034.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A7035'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,5.77	,14.46	,0	,7.54	,'A7035.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A7036'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme Facetté'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,5.59	,14.72	,0	,8.01	,'A7036.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A7638'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme avec Carte de la "GUADELOUPE"'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,4.25	,13.8	,0	,8.7	,'A7638.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A7639'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme avec Carte de la "GUADELOUPE"'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,6.16	,20.78	,0	,13.39	,'A7639.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A7640'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme avec Carte de la "GUADELOUPE"'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,5.7	,14.34	,0	,7.5	,'A7640.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A7641'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme avec Carte de la "GUADELOUPE"'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,5.22	,13.87	,0	,7.61	,'A7641.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A7988'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme avec Pierre Rouge de synthèse et Serpent'	,1	,'BG'	,'CHV'	,'H'	,9	,3	,''	,2	,4.91	,25.31	,0	,19.42	,'A7988.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A7989'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme avec Pierre Rouge de synthèse et Serpent'	,1	,'BG'	,'CHV'	,'H'	,9	,3	,''	,2	,6.85	,25.41	,0	,17.19	,'A7989.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A7990'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme avec Pierre Rouge de synthèse'	,1	,'BG'	,'CHV'	,'H'	,9	,3	,''	,2	,6.4	,23.77	,0	,16.09	,'A7990.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A7991'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme avec Pierre Rouge de synthèse'	,1	,'BG'	,'CHV'	,'H'	,9	,3	,''	,2	,4.68	,17.57	,0	,11.95	,'A7991.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A7992'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme avec Pierre Bleue de synthèse et Serpent'	,1	,'BG'	,'CHV'	,'H'	,9	,3	,''	,2	,4.8	,21.21	,0	,15.45	,'A7992.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A7993'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme avec Pierre Bleue de synthèse'	,1	,'BG'	,'CHV'	,'H'	,9	,3	,''	,2	,4.51	,17.5	,0	,12.09	,'A7993.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A7994'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme avec Pierre Bleue de synthèse'	,1	,'BG'	,'CHV'	,'H'	,9	,3	,''	,2	,6.61	,24.13	,0	,16.2	,'A7994.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A7995'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme avec Pierre Bleue de synthèse et Serpent'	,1	,'BG'	,'CHV'	,'H'	,9	,3	,''	,2	,6.59	,24.63	,0	,16.72	,'A7995.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A8015'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme avec Carte de la "MARTINIQUE"'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,6.32	,17.96	,0	,10.38	,'A8015.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A8016'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme avec Carte de la "MARTINIQUE"'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,8.07	,22.48	,0	,12.8	,'A8016.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A8017'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme avec Carte de la "MARTINIQUE"'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,6.36	,18.66	,0	,11.03	,'A8017.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A8019'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme avec Carte de la "MARTINIQUE"'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,5.87	,15.31	,0	,8.27	,'A8019.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A8020'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme avec Carte de la "MARTINIQUE"'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,6.26	,7.51	,0	,10.21	,'A8020.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A8635'	,'Chevalière Argent 925/°°° '	,'Argent 925/°°°  , Chevalière Homme'	,1	,'BG'	,'CHV'	,'H'	,10	,3	,''	,2	,9.36	,20.41	,0	,9.18	,'A8635.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A7446'	,'Boucles d''Oreilles en Argent 925/°°° '	,'Argent 925/°°°  , Boucles d''Oreilles Créoles Torsadées en Chute Tressée d''un Diamètre de 20 mm. Fermoirs à Charnières.'	,0	,'BO'	,'CREO'	,'F'	,10	,3	,''	,2	,2.49	,5.56	,0	,2.57	,'A7446.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A8158'	,'Boucles d''Oreilles en Argent 925/°°° '	,'Argent 925/°°°  , Boucles d''Oreilles Créoles Tube Torsadé de 2.8 mm et Tressé d''un Diamètre de 22 mm. Fermoirs à Charnières.'	,0	,'BO'	,'CREO'	,'F'	,10	,3	,''	,2	,2.16	,5.23	,0	,2.64	,'A8158.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A8159'	,'Boucles d''Oreilles en Argent 925/°°° '	,'Argent 925/°°°  , Boucles d''Oreilles Créoles Tube Torsadé de 2.8 mm  et Tressé d''un Diamètre de 26 mm. Fermoirs à Charnières.'	,0	,'BO'	,'CREO'	,'F'	,10	,3	,''	,2	,2.46	,6.25	,0	,3.3	,'A8159.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A8160'	,'Boucles d''Oreilles en Argent 925/°°° '	,'Argent 925/°°°  , Boucles d''Oreilles Créoles Tube Torsadé de 2.8 mm Tressé d''un Diamètre de 37 mm. Fermoirs à Charnières.'	,0	,'BO'	,'CREO'	,'F'	,10	,3	,''	,2	,3.68	,8.98	,0	,4.56	,'A8160.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A8165'	,'Boucles d''Oreilles en Argent 925/°°° '	,'Argent 925/°°°  , Boucles d''Oreilles Créoles Tube Torsadé de 3.8 mm Tressé d''un Diamètre de 50 mm. Fermoirs à Charnières.'	,0	,'BO'	,'CREO'	,'F'	,10	,3	,''	,2	,8.76	,21.88	,0	,11.37	,'A8165.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A8773'	,'Boucles d''Oreilles en Argent 925/°°° '	,'Argent 925/°°°  , Boucles d''Oreilles Créoles Tube Torsadé de 4 mm Lisse d''un Diamètre de 50 mm. Fermoirs à Charnières.'	,0	,'BO'	,'CREO'	,'F'	,10	,3	,''	,2	,9.74	,23.05	,0	,11.36	,'A8773.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A8781'	,'Boucles d''Oreilles Créoles en Argent 925/°°° '	,'Argent 925/°°°  , Boucles d''Oreilles Créoles Tube Maille PALMIER de 5.4 mm  , Diamètre extérieur de 40 mm et intérieur de 30 mm Fermoir à Charnières.'	,0	,'BO'	,'CREO'	,'F'	,10	,3	,''	,2	,11.66	,40.21	,0	,26.21	,'A8781.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A10076'	,'Bracelet Maille JASERON en Argent 925/°°°'	,'Argent 925/°°°  , Bracelet Femme Maille JASERON d''une Largeur de 6.5 mm et d''une Longueur 19.5 cm  , avec un Fermoir à Mousqueton.'	,0	,'BR'	,'BRDIV'	,'F'	,10	,3	,''	,2	,8.1	,16.48	,0	,6.76	,'A10076.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A10080-20'	,'Bracelet Maille CORDE en Argent 925/°°°  ,'	,'Argent 925/°°°  , Bracelet Femme Maille CORDE d''une Largeur de 6.3 mm et d''une Longueur 20.5 cm  , avec un Fermoir à Mousqueton.'	,0	,'BR'	,'BRDIV'	,'F'	,10	,3	,''	,2	,10.65	,21.34	,0	,8.56	,'A10080-20.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A10498'	,'Bracelet Maille BOULES Satinées et Brillantes en Argent 925/°°°'	,'Argent 925/°°°  , Bracelet Femme Maille BOULES Satinées et Brillantes d''une Largeur de 4 mm et d''une Longueur 19 cm avec Fermoir à Mousqueton. '	,0	,'BR'	,'BRDIV'	,'F'	,10	,3	,''	,2	,5.8	,13.82	,0	,6.86	,'A10498.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A7284'	,'Bracelet Maille GRAIN DE CAFE en Argent 925/°°°'	,'Argent 925/°°°  , Bracelet Homme Maille GRAIN DE CAFE d''une Largeur de 7 mm et d''une Longueur 21.5 cm  , avec Fermoir à Mousqueton.'	,0	,'BR'	,'BRDIV'	,'H'	,10	,3	,''	,2	,8.49	,19.39	,0	,9.2	,'A7284.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A8227-20'	,'Bracelet Maille PALMIER en Argent 925/°°°'	,'Argent 925/°°°  , Bracelet Maille PALMIER d''une Largeur de 6  ,7 mm et d''une Longueur de 20.5 cm  , avec Fermoir à Mousqueton.'	,1	,'BR'	,'BRDIV'	,'F'	,10	,3	,''	,2	,17.5	,46.1	,0	,25.1	,'A8227-20.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A9143'	,'Bracelet Maille BOULES Brillantes en Argent 925/°°°'	,'Argent 925/°°°  , Bracelet Femme Maille BOULES Brillantes d''une Largeur de 6 mm et d''une Longueur de 19 cm avec un Fermoir à Mousqueton.'	,0	,'BR'	,'BRDIV'	,'F'	,10	,3	,''	,2	,5.2	,15.04	,0	,8.8	,'A9143.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A9405-21'	,'Bracelet Maille ANGLAISE en Argent 925/°°°  ,'	,'Argent 925/°°°  , Bracelet Femme Maille ANGLAISE d''une Largeur de 6.5 mm et d''une Longueur 20.5 cm avec un Fermoir à Mousqueton.'	,0	,'BR'	,'BRDIV'	,'F'	,10	,3	,''	,2	,8.2	,26.06	,0	,16.22	,'A9405-21.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A10084-16'	,'Bracelet Identité Maille Forçat en Argent 925/°°°'	,'Argent 925/°°°  ,Bracelet Identité Enfant Maille Forçat d''une Largeur de plaque de 5 mm et d''une Longueur 16 cm  , avec Fermoir à Mousqueton.'	,0	,'BR'	,'BRID'	,'E'	,10	,3	,''	,2	,2.09	,4.61	,0	,2.1	,'A10084-16.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A10086-16'	,'Bracelet Identité Maille Cheval en Argent 925/°°°'	,'Argent 925/°°°  , Bracelet Identité Enfant Maille Cheval d''une Largeur de plaque de 5 mm et d''une Longueur 16 cm  , avec Fermoir à Mousqueton.'	,0	,'BR'	,'BRID'	,'E'	,10	,3	,''	,2	,2.94	,5.84	,0	,2.32	,'A10086-16.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A10430'	,'Bracelet Identité Maille MARINE Plate en Argent 925/°°°'	,'Argent 925/°°°  , Bracelet Identité Homme Maille MARINE Plate d''une Largeur de plaque de 10 mm et d''une Longueur 23 cm  , avec Fermoir à Mousqueton.'	,0	,'BR'	,'BRID'	,'H'	,10	,3	,''	,2	,14.65	,27.93	,0	,10.34	,'A10430.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A7149'	,'Bracelet Rigide Argent 925/°°° '	,'Argent 925/°°°  , Bracelet Identité Homme Rigide ajustable  , Largeur 8 mm  , Diamètre intérieur de 65 mm.'	,1	,'BR'	,'BRID'	,'F'	,10	,3	,''	,2	,10.95	,27.4	,0	,14.26	,'A7149.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A7544'	,'Bracelet Identité Maille MARINE Plate en Argent 925/°°°'	,'Argent 925/°°°  , Bracelet Identité Mixte Maille MARINE Plate d''une Largeur de plaque de 6 mm et d''une Longueur 19.5 cm  , avec Fermoir à Mousqueton.'	,0	,'BR'	,'BRID'	,'M'	,10	,3	,''	,2	,4.45	,9.17	,0	,3.84	,'A7544.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A7547'	,'Bracelet Identité Maille Alterné 1+3 en Argent 925/°°°  ,'	,'Argent 925/°°°  , Bracelet Identité Mixte Maille Alternée 1+3 d''une Largeur de plaque de 5 mm et d''une Longueur 21.5 cm  , avec Fermoir à Mousqueton.'	,0	,'BR'	,'BRID'	,'M'	,10	,3	,''	,2	,7.26	,12.83	,0	,4.11	,'A7547.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A8778'	,'Bracelet Identité Maille GRAIN DE CAFE en Argent 925/°°°'	,'Argent 925/°°°  ,Bracelet Identité Mixte Maille GRAIN DE CAFE d''une Largeur de plaque de 6 mm et d''une Longueur 19 cm  , avec Fermoir à Mousqueton.'	,0	,'BR'	,'BRID'	,'M'	,10	,3	,''	,2	,9.27	,23.1	,0	,11.97	,'A8778.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A9858'	,'Bracelet Identité Maille Alterné 1+3 en Argent 925/°°°  ,'	,'Argent 925/°°°  , Bracelet Identité Enfant Maille Alternée 1+3d''une Largeur de plaque de 5 mm et d''une Longueur 20.5 cm  , avec Fermoir à Mousqueton.'	,0	,'BR'	,'BRID'	,'E'	,10	,3	,''	,2	,2.86	,6.99	,0	,3.55	,'A9858.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A10100'	,'Bracelet Rigide en Argent 925/°°°'	,'Argent 925/°°°   , Bracelet Femme Rigide Lisse  , Tube Rond Lisse de 8 mm  , Diamètre intérieur de 5 mm et extérieur de 78 mm.'	,0	,'BR'	,'BRRGD'	,'F'	,10	,3	,''	,2	,20.5	,51.83	,0	,27.23	,'A10100.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A5338'	,'Bracelet Rigide Torsadé en Argent 925/°°°'	,'Argent 925/°°°  , Bracelet Femme Rigide Torsadé Large et Lisse  , Tube de 5.2 mm  , Diamètre intérieur de 5.2 mm et extérieur de 70 mm.'	,0	,'BR'	,'BRRGD'	,'F'	,10	,3	,''	,2	,11.4	,34.28	,0	,20.6	,'A5338.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A5919'	,'Bracelet Rigide Argent 925/°°° '	,'Argent 925/°°°  , Bracelet Femme Rigide Tube Rond Lisse de 3 mm  , Diamètre intérieur de 58 mm et extérieur de 67 mm '	,0	,'BR'	,'BRRGD'	,'F'	,10	,3	,''	,2	,6.98	,16.69	,0	,8.31	,'A5919.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A7141'	,'Bracelet Rigide Argent 925/°°° '	,'Argent 925/°°°  , Bracelet Femme Rigide Tube Rond Lisse de 5 mm  , Diamètre intérieur de 60 mm et extérieur de 70 mm '	,1	,'BR'	,'BRRGD'	,'F'	,10	,3	,''	,2	,12	,26.58	,0	,12.18	,'A7141.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A7142'	,'Bracelet Rigide Argent 925/°°° '	,'Argent 925/°°°  , Bracelet Femme Rigide Tube Rond Lisse de 4 mm  , Diamètre intérieur de 60 mm et extérieur de 68 mm '	,1	,'BR'	,'BRRGD'	,'F'	,10	,3	,''	,2	,8.57	,21.24	,0	,10.96	,'A7142.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A9592'	,'Bracelet Rigide Torsadé en Argent 925/°°°'	,'Argent 925/°°°, Bracelet Femme Rigide Torsadé, Tube de 6 mm, Diamètre intérieur de 6 mm et extérieur de 70 mm.'	,0	,'BR'	,'BRRGD'	,'F'	,10	,3	,''	,2	,14.2	,43.15	,0	,26.11	,'A9592.jpg'	,''	,''	,'20210930 23:01:45'	,'20210930 23:01:45')	,
('A9593'	,'Bracelet Rigide Maille PALMIER en Argent 925/°°°'	,'Argent 925/°°°  , Bracelet Femme Rigide Maille PALMIER  , Tube de 5  ,7 mm  , Diamètre intérieur de 65 mm et extérieur de 75 mm.'	,0	,'BR'	,'BRRGD'	,'F'	,10	,3	,''	,2	,18.2	,52.28	,0	,30.44	,'A9593.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A10499-45'	,'Collier Maille BOULES Dégradées Satinées et Brillantes en Argent 925/°°°'	,'Argent 925/°°°  ,Collier Femme Maille BOULES Dégradées Satinées et brillantes d''une Longueur de 45 cm avec une Boule de Centre de 10 mm et un Fermoir à Mousqueton.'	,0	,'CO'	,'CO'	,'F'	,10	,3	,''	,2	,12.8	,35.27	,0	,19.91	,'A10499-45.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A7338-60'	,'Collier Maille Alternée 1+3 en Argent 925/°°°  ,'	,'Argent 925/°°°  , Collier Femme Maille Alternée 1+3 d''une Largeur de 7.5 mm et d''une Longueur 60 cm  , avec Fermoir à Mousqueton.'	,0	,'CO'	,'CO'	,'F'	,10	,3	,''	,2	,42.36	,71.44	,0	,20.6	,'A7338-60.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('A8759-50'	,'Collier Maille Alternée 1+3 en Argent 925/°°°  ,'	,'Argent 925/°°°  , Collier Femme Maille Alternée 1+3 d''une Largeur de 3.5 mm et d''une Longueur 50 cm  , avec Fermoir à Mousqueton.'	,0	,'CO'	,'CO'	,'F'	,10	,3	,''	,2	,3.38	,7.57	,0	,3.51	,'A8759-50.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22441'	,'Bracelet Acier '	,'Acier  , Bracelet Homme avec Fermoir à cliquet  , de Longueur 21 cm et de Largeur 12 mm'	,0	,'BR'	,'BRDIV'	,'H'	,10	,4	,''	,2	,0	,5.5	,0	,5.5	,'22441.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22491'	,'Bracelet Acier '	,'Acier  , Bracelet Homme avec Fermoir à cliquet  , de Longueur 22.5 cm et de 121 mm. de Largeur'	,0	,'BR'	,'BRDIV'	,'H'	,10	,4	,''	,2	,0	,4.5	,0	,4.5	,'22491.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22495'	,'Bracelet Acier '	,'Acier  , Bracelet Homme avec Fermoir à cliquet  , de Longueur 20.5 cm et de Largeur 6 mm'	,0	,'BR'	,'BRDIV'	,'H'	,10	,4	,''	,2	,0	,5.5	,0	,5.5	,'22495.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22506'	,'Bracelet Acier '	,'Acier Bicolore  , Bracelet Homme avec Fermoir à cliquet, de Longueur 20.5 cm et de Largeur 12 mm'	,0	,'BR'	,'BRDIV'	,'H'	,10	,4	,''	,2	,0	,5.5	,0	,5.5	,'22506.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22511'	,'Bracelet Acier '	,'Acier  , Bracelet Homme avec Fermoir à cliquet  , de Longueur 22 cm et de Largeur 12 mm'	,0	,'BR'	,'BRDIV'	,'H'	,10	,4	,''	,2	,0	,4.5	,0	,4.5	,'22511.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22540'	,'Bracelet Acier '	,'Acier  , Bracelet Homme avec Fermoir à cliquet  , de Longueur 22 cm et de Largeur 15.8 mm'	,0	,'BR'	,'BRDIV'	,'H'	,10	,4	,''	,2	,0	,5.5	,0	,5.5	,'22540.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22540-2'	,'Bracelet Acier '	,'Acier Bicolore  , Bracelet Homme avec Fermoir à cliquet  , de Longueur 20.5 cm et de Largeur 11  ,7 mm'	,0	,'BR'	,'BRDIV'	,'H'	,10	,4	,''	,2	,0	,5.5	,0	,5.5	,'22540-2.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22544'	,'Bracelet Acier '	,'Acier  , Bracelet Homme avec Fermoir à cliquet  , de Longueur 22 cm et de Largeur 10 mm'	,0	,'BR'	,'BRDIV'	,'H'	,10	,4	,''	,2	,0	,5.5	,0	,5.5	,'22544.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22547'	,'Bracelet Acier '	,'Acier  , Bracelet Homme avec Fermoir à cliquet  , de Longueur 21.5 cm et de Largeur 12.2 mm'	,0	,'BR'	,'BRDIV'	,'H'	,10	,4	,''	,2	,0	,5.5	,0	,5.5	,'22547.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22548'	,'Bracelet Acier '	,'Acier  , Bracelet Homme avec Fermoir à cliquet  , de Longueur 20.5 cm et de Largeur 10 .5 mm'	,0	,'BR'	,'BRDIV'	,'H'	,10	,4	,''	,2	,0	,5.5	,0	,5.5	,'22548.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22549'	,'Bracelet Acier '	,'Acier  , Bracelet Homme avec Fermoir à cliquet  , de Longueur 20.8 cm et de Largeur 11 mm'	,0	,'BR'	,'BRDIV'	,'H'	,10	,4	,''	,2	,0	,5.5	,0	,5.5	,'22549.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22550'	,'Bracelet Acier '	,'Acier  , Bracelet Homme avec Fermoir à cliquet  , de Longueur 22.5 cm et de Largeur 11 mm'	,0	,'BR'	,'BRDIV'	,'H'	,10	,4	,''	,2	,0	,5.5	,0	,5.5	,'22550.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22557'	,'Bracelet Acier '	,'Acier  , Bracelet Homme avec Fermoir à cliquet.'	,0	,'BR'	,'BRDIV'	,'H'	,10	,4	,''	,2	,0	,5.5	,0	,5.5	,'22557.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22561'	,'Bracelet Acier '	,'Acier  , Bracelet Homme avec Fermoir à cliquet  , de Longueur 20.8 cm et de Largeur 12 mm'	,0	,'BR'	,'BRDIV'	,'H'	,10	,4	,''	,2	,0	,5.5	,0	,5.5	,'22561.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22566'	,'Bracelet Acier '	,'Acier  , Bracelet Homme avec Fermoir à cliquet  , de Longueur 21 cm et de Largeur 13.75 mm'	,0	,'BR'	,'BRDIV'	,'H'	,10	,4	,''	,2	,0	,5.5	,0	,5.5	,'22566.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22569'	,'Bracelet Acier '	,'Acier  , Bracelet Homme avec Fermoir à cliquet  , de Longueur 22.5 cm et de Largeur 12 mm'	,0	,'BR'	,'BRDIV'	,'H'	,10	,4	,''	,2	,0	,5.5	,0	,5.5	,'22569.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22719'	,'Bracelet Acier '	,'Acier  , Bracelet Homme avec Fermoir à cliquet  , de Longueur 21.3 cm et de Largeur 13 mm'	,0	,'BR'	,'BRDIV'	,'H'	,10	,4	,''	,2	,0	,5.5	,0	,5.5	,'22719.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22737'	,'Bracelet Acier '	,'Acier Bicolore  , Bracelet Homme avec Fermoir à cliquet  , de Longueur 20.5 cm et de Largeur 9  ,25 mm'	,0	,'BR'	,'BRDIV'	,'H'	,10	,4	,''	,2	,0	,5.5	,0	,5.5	,'22737.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22740'	,'Bracelet Acier '	,'Acier Bicolore  , Bracelet Homme avec Fermoir à cliquet  , de Longueur 21 cm et de Largeur 10 mm'	,0	,'BR'	,'BRDIV'	,'H'	,10	,4	,''	,2	,0	,5.5	,0	,5.5	,'22740.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22748'	,'Bracelet Acier '	,'Acier Bicolore  , Bracelet Homme avec Fermoir à cliquet  , de Longueur 21.5 cm et de Largeur 16 mm'	,0	,'BR'	,'BRDIV'	,'H'	,10	,4	,''	,2	,0	,5.5	,0	,5.5	,'22748.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22779'	,'Bracelet Acier '	,'Acier  , Bracelet Homme avec Fermoir à cliquet  , de Longueur 20 cm et de Largeur 6 mm'	,0	,'BR'	,'BRDIV'	,'H'	,10	,4	,''	,2	,0	,5.5	,0	,5.5	,'22779.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22780'	,'Bracelet Acier '	,'Acier  , Bracelet Homme avec Fermoir à cliquet  , de Longueur 22 cm et de Largeur 10 mm'	,0	,'BR'	,'BRDIV'	,'H'	,10	,4	,''	,2	,0	,5.5	,0	,5.5	,'22780.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22794'	,'Bracelet Acier '	,'Acier  , Bracelet Homme avec Fermoir à cliquet  , de Longueur 20.5 cm et de Largeur 9 .5 mm'	,0	,'BR'	,'BRDIV'	,'H'	,10	,4	,''	,2	,0	,5.5	,0	,5.5	,'22794.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22818'	,'Bracelet Acier '	,'Acier  , Bracelet Homme avec Fermoir à cliquet  , de Longueur 21 cm et de Largeur 12.2 mm'	,0	,'BR'	,'BRDIV'	,'H'	,10	,4	,''	,2	,0	,5.5	,0	,5.5	,'22818.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22848'	,'Bracelet Acier '	,'Acier  , Bracelet Homme avec Fermoir à cliquet  , de Longueur 21 cm et de Largeur 10 mm'	,0	,'BR'	,'BRDIV'	,'H'	,10	,4	,''	,2	,0	,5.5	,0	,5.5	,'22848.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22849'	,'Bracelet Acier '	,'Acier  , Bracelet Homme avec Fermoir à cliquet  , de Longueur 20.5 cm et de Largeur 8 mm'	,0	,'BR'	,'BRDIV'	,'H'	,10	,4	,''	,2	,0	,5.5	,0	,5.5	,'22849.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22850'	,'Bracelet Acier '	,'Acier  , Bracelet Homme avec Fermoir à cliquet  , de Longueur 22.5 cm et de Largeur 13 mm'	,0	,'BR'	,'BRDIV'	,'H'	,10	,4	,''	,2	,0	,5.5	,0	,5.5	,'22850.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22851'	,'Bracelet Acier '	,'Acier  , Bracelet Homme avec Fermoir à cliquet  , de Longueur 22 cm et de Largeur 12 mm'	,0	,'BR'	,'BRDIV'	,'H'	,10	,4	,''	,2	,0	,5.5	,0	,5.5	,'22851.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22852'	,'Bracelet Acier '	,'Acier Bicolore  , Bracelet Homme avec Fermoir à cliquet  , de Longueur 21 cm et de Largeur 6 mm'	,0	,'BR'	,'BRDIV'	,'H'	,10	,4	,''	,2	,0	,5.5	,0	,5.5	,'22852.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22853'	,'Bracelet Acier '	,'Acier  , Bracelet Homme avec Fermoir à cliquet  , de Longueur 22 cm et de Largeur 13 mm'	,0	,'BR'	,'BRDIV'	,'H'	,10	,4	,''	,2	,0	,5.5	,0	,5.5	,'22853.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22854'	,'Bracelet Acier '	,'Acier Bicolore  , Bracelet Homme avec Fermoir à cliquet  , de Longueur 21 cm et de Largeur 9 mm'	,0	,'BR'	,'BRDIV'	,'H'	,10	,4	,''	,2	,0	,5.5	,0	,5.5	,'22854.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22855'	,'Bracelet Acier '	,'Acier Bicolore  , Bracelet Homme avec Fermoir à cliquet  , de Longueur 22 cm et de Largeur 12 mm'	,0	,'BR'	,'BRDIV'	,'H'	,10	,4	,''	,2	,0	,5.5	,0	,5.5	,'22855.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22484'	,'Bracelet Acier '	,'Acier  , Bracelet Homme avec Fermoir à cliquet  , de Longueur 21.5 cm et de Largeur 11 .5 mm'	,0	,'BR'	,'BRID'	,'H'	,10	,4	,''	,2	,0	,5.5	,0	,5.5	,'22484.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	,
('22565'	,'Bracelet Acier '	,'Acier  , Bracelet Homme avec Fermoir à cliquet  , de Longueur 22 cm et de Largeur 12 mm'	,0	,'BR'	,'BRID'	,'H'	,10	,4	,''	,2	,0	,5.5	,0	,5.5	,'22565.jpg'	,''	,''	,'20210929 23:08:28'	,'20210929 23:08:28')	
Go



-- Drop Proc P_Update_Cptcli_Actif
Create proc P_Update_Cptcli_Actif
@Cptcli_Num_ID int
As
Update [dbo].[Comptes_Clients]
Set Cptcli_Actif = 1
Where Cptcli_Num_ID = @Cptcli_Num_ID
Go
/* Exec P_Update_Cptcli_Actif 2

go
select * from Comptes_Clients
go*/


--Drop Proc P_Update_Cptcli_Actif_Email

Create proc P_Update_Cptcli_Actif_Email
@Cptcli_Email_Id varchar(70)
As
Update Comptes_Clients
Set Cptcli_Actif = 1
Where Cptcli_Email_Id = @Cptcli_Email_Id 
Go
--Exec P_Update_Cptcli_Actif_Email 'cerybel@yahoo.fr'

/*Select * from Comptes_Clients
go
*/

--Drop Proc P_Select_Cptcli

Create proc P_Select_Cptcli
@Cptcli_Num_ID int
As
Select * from Comptes_Clients
Where Cptcli_Num_ID = @Cptcli_Num_ID
Go
--Exec P_Select_Cptcli 2
/*
declare @Cptcli_Num_ID int
set @Cptcli_Num_ID =2
select * from Comptes_Clients
Where Cptcli_Num_ID = @Cptcli_Num_ID
Go
*/