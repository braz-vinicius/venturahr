IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Usuarios] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(100) NULL,
    [Email] nvarchar(30) NULL,
    [Senha] nvarchar(100) NULL,
    [Endereco] nvarchar(200) NULL,
    [Telefone] nvarchar(20) NULL,
    [Tipo] int NOT NULL,
    [CPF] nvarchar(max) NULL,
    [CNPJ] nvarchar(max) NULL,
    [RazaoSocial] nvarchar(max) NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Vagas] (
    [Id] int NOT NULL IDENTITY,
    [EmpresaId] int NOT NULL,
    [Cargo] nvarchar(45) NULL,
    [Cidade] nvarchar(45) NULL,
    [FormaContratacao] nvarchar(45) NULL,
    [DataExpiracao] datetime2 NOT NULL,
    CONSTRAINT [PK_Vagas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Vagas_Usuarios_EmpresaId] FOREIGN KEY ([EmpresaId]) REFERENCES [Usuarios] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Respostas] (
    [Id] int NOT NULL IDENTITY,
    [CandidatoId] int NOT NULL,
    [RespostaData] datetime2 NOT NULL,
    [Indice] decimal(18,2) NOT NULL,
    [VagaId] int NULL,
    CONSTRAINT [PK_Respostas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Respostas_Usuarios_CandidatoId] FOREIGN KEY ([CandidatoId]) REFERENCES [Usuarios] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Respostas_Vagas_VagaId] FOREIGN KEY ([VagaId]) REFERENCES [Vagas] ([Id])
);
GO

CREATE TABLE [VagaCriterios] (
    [Id] int NOT NULL IDENTITY,
    [Descricao] nvarchar(45) NULL,
    [Perfil] int NOT NULL,
    [Peso] int NOT NULL,
    [VagaId] int NOT NULL,
    CONSTRAINT [PK_VagaCriterios] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_VagaCriterios_Vagas_VagaId] FOREIGN KEY ([VagaId]) REFERENCES [Vagas] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [RespostaCriterios] (
    [Id] int NOT NULL IDENTITY,
    [RespostaId] int NOT NULL,
    CONSTRAINT [PK_RespostaCriterios] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_RespostaCriterios_Respostas_RespostaId] FOREIGN KEY ([RespostaId]) REFERENCES [Respostas] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_RespostaCriterios_RespostaId] ON [RespostaCriterios] ([RespostaId]);
GO

CREATE INDEX [IX_Respostas_CandidatoId] ON [Respostas] ([CandidatoId]);
GO

CREATE INDEX [IX_Respostas_VagaId] ON [Respostas] ([VagaId]);
GO

CREATE INDEX [IX_VagaCriterios_VagaId] ON [VagaCriterios] ([VagaId]);
GO

CREATE INDEX [IX_Vagas_EmpresaId] ON [Vagas] ([EmpresaId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220807140900_InitialDatabaseCommit', N'6.0.7');
GO

COMMIT;
GO

