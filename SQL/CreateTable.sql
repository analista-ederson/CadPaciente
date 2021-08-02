CREATE TABLE [dbo].[Paciente] (
    [IdPaciente]        INT           IDENTITY (1, 1) NOT NULL,
    [Prontuario]        VARCHAR (150) NOT NULL,
    [Nome]              VARCHAR (150) NOT NULL,
    [Sobrenome]         VARCHAR (150) NOT NULL,
    [DataNascimento]    DATETIME      NOT NULL,
    [Genero ]           VARCHAR (150) NOT NULL,
    [CPF]               VARCHAR (150) NOT NULL,
    [RG]                VARCHAR (150) NOT NULL,
    [UfRg]              VARCHAR (150) NOT NULL,
    [Email]             VARCHAR (150) NOT NULL,
    [Celular]           VARCHAR (150) NOT NULL,
    [Telefone]          VARCHAR (150) NOT NULL,
    [convenio]          VARCHAR (150) NOT NULL,
    [NumConvenio]       VARCHAR (150) NOT NULL,
    [validadeConvenio ] VARCHAR (150) NOT NULL,
    PRIMARY KEY CLUSTERED ([IdPaciente] ASC)
);

CREATE TABLE [dbo].[Convenio] (
    [IdConvenio]   INT            IDENTITY (1, 1) NOT NULL,
    [NomeConvenio] NVARCHAR (150) NOT NULL,
    PRIMARY KEY CLUSTERED ([IdConvenio] ASC)
);

