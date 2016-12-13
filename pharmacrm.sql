-- DROP TABLE [PHARMACRM].[dbo].[Authentication]
CREATE TABLE [PHARMACRM].[dbo].[Authentication] (
   Vendedor nchar(3) NOT NULL PRIMARY KEY,
   Email varchar(254) NOT NULL,
   Password varchar(128) NOT NULL
);

INSERT INTO [PHARMACRM].[dbo].[Authentication] VALUES ('1', 'filipedias@gmail.com', '123456');
INSERT INTO [PHARMACRM].[dbo].[Authentication] VALUES ('2', 'luisneves@gmail.com', '123456');
INSERT INTO [PHARMACRM].[dbo].[Authentication] VALUES ('3', 'martacarvalho@gmail.com', '123456');
INSERT INTO [PHARMACRM].[dbo].[Authentication] VALUES ('5', 'vitorgoncalves@gmail.com', '123456')