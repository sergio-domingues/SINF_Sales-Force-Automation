-- DROP TABLE [PHARMACRM].[dbo].[Authentication]
CREATE TABLE [PHARMACRM].[dbo].[Authentication] (
   Vendedor nchar(3), -- null é admin
   Email varchar(254) NOT NULL PRIMARY KEY,
   Password varchar(128) NOT NULL
);

INSERT INTO [PHARMACRM].[dbo].[Authentication] VALUES ('1', 'filipedias@gmail.com', '123456');
INSERT INTO [PHARMACRM].[dbo].[Authentication] VALUES ('2', 'luisneves@gmail.com', '123456');
INSERT INTO [PHARMACRM].[dbo].[Authentication] VALUES ('3', 'martacarvalho@gmail.com', '123456');
INSERT INTO [PHARMACRM].[dbo].[Authentication] VALUES ('5', 'vitorgoncalves@gmail.com', '123456');
INSERT INTO [PHARMACRM].[dbo].[Authentication] VALUES ('___', 'admin@ad.min', '123456');

-- DROP TABLE [PHARMACRM].[dbo].[ObjetivoVendedor]
CREATE TABLE [PHARMACRM].[dbo].[ObjetivoVendedor] (
    VendedorID nchar(3) NOT NULL PRIMARY KEY,
	Objetivo float(3) NOT NULL
)

INSERT INTO [PHARMACRM].[dbo].[ObjetivoVendedor] VALUES ('1', 123);
INSERT INTO [PHARMACRM].[dbo].[ObjetivoVendedor] VALUES ('2', 456);
INSERT INTO [PHARMACRM].[dbo].[ObjetivoVendedor] VALUES ('3', 789);
INSERT INTO [PHARMACRM].[dbo].[ObjetivoVendedor] VALUES ('5', 1011);