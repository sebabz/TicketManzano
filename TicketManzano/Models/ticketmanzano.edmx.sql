
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/13/2023 21:50:43
-- Generated from EDMX file: C:\Users\sebas\source\repos\sebabz\TicketManzano2\TicketManzano\TicketManzano\Models\ticketmanzano.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [HelpdeskManzano];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Comentari__IDTic__5165187F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comentarios] DROP CONSTRAINT [FK__Comentari__IDTic__5165187F];
GO
IF OBJECT_ID(N'[dbo].[FK__Comentari__IDUsu__52593CB8]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comentarios] DROP CONSTRAINT [FK__Comentari__IDUsu__52593CB8];
GO
IF OBJECT_ID(N'[dbo].[FK__Imagenes__IDTick__5535A963]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Imagenes] DROP CONSTRAINT [FK__Imagenes__IDTick__5535A963];
GO
IF OBJECT_ID(N'[dbo].[FK__Tickets__IDUsuar__4E88ABD4]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK__Tickets__IDUsuar__4E88ABD4];
GO
IF OBJECT_ID(N'[dbo].[FK__Usuarios__id_tip__4BAC3F29]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuarios] DROP CONSTRAINT [FK__Usuarios__id_tip__4BAC3F29];
GO
IF OBJECT_ID(N'[dbo].[FK_Tickets_AsuntoTickets]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_Tickets_AsuntoTickets];
GO
IF OBJECT_ID(N'[dbo].[FK_Tickets_EstadoTickets]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_Tickets_EstadoTickets];
GO
IF OBJECT_ID(N'[dbo].[FK_Tickets_PrioridadTickets]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_Tickets_PrioridadTickets];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AsuntoTickets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AsuntoTickets];
GO
IF OBJECT_ID(N'[dbo].[Comentarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comentarios];
GO
IF OBJECT_ID(N'[dbo].[EstadoTickets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EstadoTickets];
GO
IF OBJECT_ID(N'[dbo].[Imagenes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Imagenes];
GO
IF OBJECT_ID(N'[dbo].[PrioridadTickets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PrioridadTickets];
GO
IF OBJECT_ID(N'[dbo].[Tickets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tickets];
GO
IF OBJECT_ID(N'[dbo].[TipoUsuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoUsuario];
GO
IF OBJECT_ID(N'[dbo].[Usuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuarios];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AsuntoTickets'
CREATE TABLE [dbo].[AsuntoTickets] (
    [IDAsunto] int IDENTITY(1,1) NOT NULL,
    [NombreAsunto] varchar(100)  NULL
);
GO

-- Creating table 'Comentarios'
CREATE TABLE [dbo].[Comentarios] (
    [IDComentario] int IDENTITY(1,1) NOT NULL,
    [IDTicket] int  NULL,
    [IDUsuario] int  NULL,
    [Contenido] varchar(255)  NULL,
    [FechaCreacion] datetime  NULL
);
GO

-- Creating table 'EstadoTickets'
CREATE TABLE [dbo].[EstadoTickets] (
    [IDEstado] int IDENTITY(1,1) NOT NULL,
    [NombreEstado] varchar(50)  NOT NULL
);
GO

-- Creating table 'Imagenes'
CREATE TABLE [dbo].[Imagenes] (
    [IDImagen] int IDENTITY(1,1) NOT NULL,
    [IDTicket] int  NULL,
    [RutaImagen] varchar(255)  NULL
);
GO

-- Creating table 'PrioridadTickets'
CREATE TABLE [dbo].[PrioridadTickets] (
    [IDPrioridad] int IDENTITY(1,1) NOT NULL,
    [NombrePrioridad] varchar(50)  NOT NULL
);
GO

-- Creating table 'Tickets'
CREATE TABLE [dbo].[Tickets] (
    [IDTicket] int IDENTITY(1,1) NOT NULL,
    [IDUsuario] int  NULL,
    [Asunto] varchar(100)  NULL,
    [Descripcion] varchar(255)  NULL,
    [Estado] varchar(20)  NULL,
    [FechaCreacion] datetime  NULL,
    [IDAsunto] int  NOT NULL,
    [IDEstado] int  NOT NULL,
    [IDPrioridad] int  NOT NULL
);
GO

-- Creating table 'TipoUsuario'
CREATE TABLE [dbo].[TipoUsuario] (
    [id_tipousuario] int IDENTITY(1,1) NOT NULL,
    [nombretipo] varchar(50)  NULL
);
GO

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [IDUsuario] int IDENTITY(1,1) NOT NULL,
    [Nombre] varchar(50)  NULL,
    [Apellido] varchar(50)  NULL,
    [CorreoElectronico] varchar(100)  NULL,
    [Password] varchar(100)  NULL,
    [id_tipousuario] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IDAsunto] in table 'AsuntoTickets'
ALTER TABLE [dbo].[AsuntoTickets]
ADD CONSTRAINT [PK_AsuntoTickets]
    PRIMARY KEY CLUSTERED ([IDAsunto] ASC);
GO

-- Creating primary key on [IDComentario] in table 'Comentarios'
ALTER TABLE [dbo].[Comentarios]
ADD CONSTRAINT [PK_Comentarios]
    PRIMARY KEY CLUSTERED ([IDComentario] ASC);
GO

-- Creating primary key on [IDEstado] in table 'EstadoTickets'
ALTER TABLE [dbo].[EstadoTickets]
ADD CONSTRAINT [PK_EstadoTickets]
    PRIMARY KEY CLUSTERED ([IDEstado] ASC);
GO

-- Creating primary key on [IDImagen] in table 'Imagenes'
ALTER TABLE [dbo].[Imagenes]
ADD CONSTRAINT [PK_Imagenes]
    PRIMARY KEY CLUSTERED ([IDImagen] ASC);
GO

-- Creating primary key on [IDPrioridad] in table 'PrioridadTickets'
ALTER TABLE [dbo].[PrioridadTickets]
ADD CONSTRAINT [PK_PrioridadTickets]
    PRIMARY KEY CLUSTERED ([IDPrioridad] ASC);
GO

-- Creating primary key on [IDTicket] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [PK_Tickets]
    PRIMARY KEY CLUSTERED ([IDTicket] ASC);
GO

-- Creating primary key on [id_tipousuario] in table 'TipoUsuario'
ALTER TABLE [dbo].[TipoUsuario]
ADD CONSTRAINT [PK_TipoUsuario]
    PRIMARY KEY CLUSTERED ([id_tipousuario] ASC);
GO

-- Creating primary key on [IDUsuario] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([IDUsuario] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IDAsunto] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_Tickets_AsuntoTickets]
    FOREIGN KEY ([IDAsunto])
    REFERENCES [dbo].[AsuntoTickets]
        ([IDAsunto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tickets_AsuntoTickets'
CREATE INDEX [IX_FK_Tickets_AsuntoTickets]
ON [dbo].[Tickets]
    ([IDAsunto]);
GO

-- Creating foreign key on [IDTicket] in table 'Comentarios'
ALTER TABLE [dbo].[Comentarios]
ADD CONSTRAINT [FK__Comentari__IDTic__5165187F]
    FOREIGN KEY ([IDTicket])
    REFERENCES [dbo].[Tickets]
        ([IDTicket])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Comentari__IDTic__5165187F'
CREATE INDEX [IX_FK__Comentari__IDTic__5165187F]
ON [dbo].[Comentarios]
    ([IDTicket]);
GO

-- Creating foreign key on [IDUsuario] in table 'Comentarios'
ALTER TABLE [dbo].[Comentarios]
ADD CONSTRAINT [FK__Comentari__IDUsu__52593CB8]
    FOREIGN KEY ([IDUsuario])
    REFERENCES [dbo].[Usuarios]
        ([IDUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Comentari__IDUsu__52593CB8'
CREATE INDEX [IX_FK__Comentari__IDUsu__52593CB8]
ON [dbo].[Comentarios]
    ([IDUsuario]);
GO

-- Creating foreign key on [IDEstado] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_Tickets_EstadoTickets]
    FOREIGN KEY ([IDEstado])
    REFERENCES [dbo].[EstadoTickets]
        ([IDEstado])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tickets_EstadoTickets'
CREATE INDEX [IX_FK_Tickets_EstadoTickets]
ON [dbo].[Tickets]
    ([IDEstado]);
GO

-- Creating foreign key on [IDTicket] in table 'Imagenes'
ALTER TABLE [dbo].[Imagenes]
ADD CONSTRAINT [FK__Imagenes__IDTick__5535A963]
    FOREIGN KEY ([IDTicket])
    REFERENCES [dbo].[Tickets]
        ([IDTicket])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Imagenes__IDTick__5535A963'
CREATE INDEX [IX_FK__Imagenes__IDTick__5535A963]
ON [dbo].[Imagenes]
    ([IDTicket]);
GO

-- Creating foreign key on [IDPrioridad] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_Tickets_PrioridadTickets]
    FOREIGN KEY ([IDPrioridad])
    REFERENCES [dbo].[PrioridadTickets]
        ([IDPrioridad])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tickets_PrioridadTickets'
CREATE INDEX [IX_FK_Tickets_PrioridadTickets]
ON [dbo].[Tickets]
    ([IDPrioridad]);
GO

-- Creating foreign key on [IDUsuario] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK__Tickets__IDUsuar__4E88ABD4]
    FOREIGN KEY ([IDUsuario])
    REFERENCES [dbo].[Usuarios]
        ([IDUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Tickets__IDUsuar__4E88ABD4'
CREATE INDEX [IX_FK__Tickets__IDUsuar__4E88ABD4]
ON [dbo].[Tickets]
    ([IDUsuario]);
GO

-- Creating foreign key on [id_tipousuario] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [FK__Usuarios__id_tip__4BAC3F29]
    FOREIGN KEY ([id_tipousuario])
    REFERENCES [dbo].[TipoUsuario]
        ([id_tipousuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Usuarios__id_tip__4BAC3F29'
CREATE INDEX [IX_FK__Usuarios__id_tip__4BAC3F29]
ON [dbo].[Usuarios]
    ([id_tipousuario]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------