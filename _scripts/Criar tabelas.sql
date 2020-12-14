USE dbSeplag
--> ConnectionString de conexão: dbSeplag: Data Source=den1.mssql7.gear.host; Initial Catalog=dbSeplag;User ID=sa;Password=Zl4HXrr~!oCE;


DROP TABLE IF EXISTS dbo.USUARIOS

DROP TABLE IF EXISTS dbo.TRAMITACAO
DROP TABLE IF EXISTS dbo.DOCUMENTOSBENEFICIOS
DROP TABLE IF EXISTS dbo.BENEFICIOS
DROP TABLE IF EXISTS dbo.LOCAISTRAMITACAO
DROP TABLE IF EXISTS dbo.CATEGORIASDOCUMENTOS
DROP TABLE IF EXISTS dbo.SERVIDORES
GO

------------------------------------------------------------------------------------------------------------------------------------------------------
-- Tabela: USUARIOS
------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE dbo.USUARIOS(
	IdUsuario     INT NOT NULL IDENTITY (1,1),
	NomeUsuario   VARCHAR(50),
	Senha         VARCHAR(50)
) --ON PRIMARY
GO

ALTER TABLE dbo.USUARIOS ADD CONSTRAINT PK_USUARIOS PRIMARY KEY (IdUsuario)

------------------------------------------------------------------------------------------------------------------------------------------------------
-- Tabela: SERVIDORES
------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE dbo.SERVIDORES(
	Matricula   INT NOT NULL IDENTITY (1,1),
	CPF         VARCHAR(11),
	Nome        VARCHAR(50),
	Orgao       VARCHAR(20)
) --ON PRIMARY
GO

ALTER TABLE dbo.SERVIDORES ADD CONSTRAINT PK_SERVIDORES PRIMARY KEY (Matricula)

------------------------------------------------------------------------------------------------------------------------------------------------------
-- Tabela: CATEGORIAS DOS DOCUMENTOS
------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE dbo.CATEGORIASDOCUMENTOS(
	IdCategoriaDocumento   INT NOT NULL IDENTITY (1,1),
	AbreviacaoCategoria    VARCHAR(20),
	DescricaoCategoria     VARCHAR(150)
) --ON PRIMARY
GO

ALTER TABLE dbo.CATEGORIASDOCUMENTOS ADD CONSTRAINT PK_CATEGORIASDOCUMENTOS PRIMARY KEY (IdCategoriaDocumento)

------------------------------------------------------------------------------------------------------------------------------------------------------
-- Tabela: LOCAIS DE TRAMITACAO
------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE dbo.LOCAISTRAMITACAO(
	IdLocalTramitacao          INT NOT NULL IDENTITY (1,1),
	DescricaoLocalTramitacao   VARCHAR(50)
) --ON PRIMARY
GO

ALTER TABLE dbo.LOCAISTRAMITACAO ADD CONSTRAINT PK_LOCAISTRAMITACAO PRIMARY KEY (IdLocalTramitacao)

------------------------------------------------------------------------------------------------------------------------------------------------------
-- Tabela: BENEFICIOS
------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE dbo.BENEFICIOS(
	IdBeneficio          INT NOT NULL IDENTITY (1,1),
	DescricaoBeneficio   VARCHAR(50),
	Matricula            INT NOT NULL
) --ON PRIMARY
GO

ALTER TABLE dbo.BENEFICIOS ADD CONSTRAINT PK_BENEFICIOS PRIMARY KEY (IdBeneficio)
ALTER TABLE dbo.BENEFICIOS ADD CONSTRAINT FK_BENEFICIOS FOREIGN KEY (Matricula) REFERENCES dbo.SERVIDORES (Matricula)

------------------------------------------------------------------------------------------------------------------------------------------------------
-- Tabela: DOCUMENTOS DOS BENEFICIOS
------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE dbo.DOCUMENTOSBENEFICIOS(
	IdDocumentoBeneficio   INT NOT NULL IDENTITY (1,1),
	IdBeneficio            INT NOT NULL,
	IdCategoriaDocumento   INT NOT NULL,
	DocumentoPDF           VARCHAR(MAX)
) --ON PRIMARY
GO

ALTER TABLE dbo.DOCUMENTOSBENEFICIOS ADD CONSTRAINT PK_DOCUMENTOSBENEFICIOS PRIMARY KEY (IdDocumentoBeneficio)
ALTER TABLE dbo.DOCUMENTOSBENEFICIOS ADD CONSTRAINT FK_DOCUMENTOSBENEFICIOS01 FOREIGN KEY (IdBeneficio) REFERENCES dbo.BENEFICIOS (IdBeneficio)
ALTER TABLE dbo.DOCUMENTOSBENEFICIOS ADD CONSTRAINT FK_DOCUMENTOSBENEFICIOS02 FOREIGN KEY (IdCategoriaDocumento) REFERENCES dbo.CATEGORIASDOCUMENTOS (idCategoriaDocumento)

------------------------------------------------------------------------------------------------------------------------------------------------------
-- Tabela: TRAMITACAO
------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE TABLE dbo.TRAMITACAO(
	IdTramitacao               INT NOT NULL IDENTITY (1,1),
	IdBeneficio                INT NOT NULL,
	DtTramitacao               DATETIME,
	IdLocalTramitacaoOrigem    INT  NOT NULL,
	IdLocalTramitacaoDestino   INT  NOT NULL
) --ON PRIMARY
GO

ALTER TABLE dbo.TRAMITACAO ADD CONSTRAINT PK_TRAMITACAO PRIMARY KEY (IdTramitacao)
ALTER TABLE dbo.TRAMITACAO ADD CONSTRAINT DtTramitacaoDefaultTramitacao DEFAULT GETDATE() FOR DtTramitacao
ALTER TABLE dbo.TRAMITACAO ADD CONSTRAINT FK_TRAMITACAO01 FOREIGN KEY (IdBeneficio) REFERENCES dbo.BENEFICIOS (IdBeneficio)
ALTER TABLE dbo.TRAMITACAO ADD CONSTRAINT FK_TRAMITACAO02 FOREIGN KEY (IdLocalTramitacaoOrigem) REFERENCES dbo.LOCAISTRAMITACAO (IdLocalTramitacao)
ALTER TABLE dbo.TRAMITACAO ADD CONSTRAINT FK_TRAMITACAO03 FOREIGN KEY (IdLocalTramitacaoDestino) REFERENCES dbo.LOCAISTRAMITACAO (IdLocalTramitacao)

--****************************************************************************************************************************************************

GO
