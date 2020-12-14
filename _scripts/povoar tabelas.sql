use dbSeplag

SELECT * FROM dbo.USUARIOS

SELECT * FROM dbo.SERVIDORES
SELECT * FROM dbo.CATEGORIASDOCUMENTOS
SELECT * FROM dbo.LOCAISTRAMITACAO
SELECT * FROM dbo.BENEFICIOS
SELECT * FROM dbo.DOCUMENTOSBENEFICIOS
SELECT * FROM dbo.TRAMITACAO


--begin transaction
insert into USUARIOS (NomeUsuario) values
('Usu�rio Teste')
go
--commit
--rollback



--begin transaction
insert into SERVIDORES (CPF, Nome, Orgao) values
('11122233301', 'Jos� da Silva', 'DETRAN'),
('22233344402', 'Luis Fernando Matos', 'DETRAN'),
('33344455503', 'Ana Cl�udia Fonseca', 'UECE'),
('44455566604', 'Reginaldo Trindade', 'UECE'),
('55566677705', 'Beatriz dos Santos Gadelha', 'SEAD')
go
--commit
--rollback

--begin transaction
insert into CATEGORIASDOCUMENTOS (AbreviacaoCategoria, DescricaoCategoria) values
('Identifica��o', 'Documentos de identifica��o do(a) servidor(o)'),
('Vida funcional', 'Documentos de vida funcional do(a) servidor(a)'),
('Contagem de tempo', 'Documentos de contagem de tempo de servi�o/contribui��o do(a) servidor(a)'),
('Remunera��o', 'Documentos de remunera��o, gratifica��es, verbas e de defini��o do valor dos proventos do(a) servidor(a)')
go
--commit
--rollback

--begin transaction
insert into LOCAISTRAMITACAO (DescricaoLocalTramitacao) values
('PGE - An�lise'),
('TCE - Gestor'),
('Cprev - Gestor'),
('Secret�rio SEPLAG'),
('Setorial Servidor')
go
--commit
--rollback

--begin transaction
insert into BENEFICIOS (DescricaoBeneficio, Matricula) values
('benef�cio teste-1', 1),
('benef�cio teste-2', 2)
go
--commit
--rollback

-- N�o inseri nada em DOCUMENTOSBENEFICIOS

--begin transaction
insert into TRAMITACAO (IdBeneficio, DtTramitacao, IdLocalTramitacaoOrigem, IdLocalTramitacaoDestino) values
(1, '2020-01-01', 1, 2),
(1, '2020-02-01', 2, 3),
(2, '2020-03-01', 1, 2),
(1, '2020-01-31', 3, 4),
(2, '2020-04-15', 2, 3)
go
--commit
--rollback

