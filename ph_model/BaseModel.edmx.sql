
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/19/2016 09:32:20
-- Generated from EDMX file: C:\Dev\ph_contingency\ph_model\BaseModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ph_contingency];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserCorporation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CorporationSet] DROP CONSTRAINT [FK_UserCorporation];
GO
IF OBJECT_ID(N'[dbo].[FK_ClusterCorporation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CorporationSet] DROP CONSTRAINT [FK_ClusterCorporation];
GO
IF OBJECT_ID(N'[dbo].[FK_ClusterStar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CelestialBodySet_Star] DROP CONSTRAINT [FK_ClusterStar];
GO
IF OBJECT_ID(N'[dbo].[FK_StarPlanet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CelestialBodySet_Planet] DROP CONSTRAINT [FK_StarPlanet];
GO
IF OBJECT_ID(N'[dbo].[FK_PlanetMoon]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CelestialBodySet_Moon] DROP CONSTRAINT [FK_PlanetMoon];
GO
IF OBJECT_ID(N'[dbo].[FK_StarAsteroid]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CelestialBodySet_Asteroid] DROP CONSTRAINT [FK_StarAsteroid];
GO
IF OBJECT_ID(N'[dbo].[FK_StarNebula]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CelestialBodySet_Nebula] DROP CONSTRAINT [FK_StarNebula];
GO
IF OBJECT_ID(N'[dbo].[FK_ClassCorporation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CorporationSet] DROP CONSTRAINT [FK_ClassCorporation];
GO
IF OBJECT_ID(N'[dbo].[FK_ClassSkill]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SkillSet] DROP CONSTRAINT [FK_ClassSkill];
GO
IF OBJECT_ID(N'[dbo].[FK_SkillSkillAssignment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SkillAssignmentSet] DROP CONSTRAINT [FK_SkillSkillAssignment];
GO
IF OBJECT_ID(N'[dbo].[FK_CorporationSkillAssignment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SkillAssignmentSet] DROP CONSTRAINT [FK_CorporationSkillAssignment];
GO
IF OBJECT_ID(N'[dbo].[FK_FeatureFeatureAssignment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FeatureAssignmentSet] DROP CONSTRAINT [FK_FeatureFeatureAssignment];
GO
IF OBJECT_ID(N'[dbo].[FK_CorporationFeatureAssignment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FeatureAssignmentSet] DROP CONSTRAINT [FK_CorporationFeatureAssignment];
GO
IF OBJECT_ID(N'[dbo].[FK_StationStationModuleAssignment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StationModuleAssignmentSet] DROP CONSTRAINT [FK_StationStationModuleAssignment];
GO
IF OBJECT_ID(N'[dbo].[FK_StationModuleStationModuleAssignment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StationModuleAssignmentSet] DROP CONSTRAINT [FK_StationModuleStationModuleAssignment];
GO
IF OBJECT_ID(N'[dbo].[FK_StationCelestialBody]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StationSet] DROP CONSTRAINT [FK_StationCelestialBody];
GO
IF OBJECT_ID(N'[dbo].[FK_FleetCelestialBody]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FleetSet] DROP CONSTRAINT [FK_FleetCelestialBody];
GO
IF OBJECT_ID(N'[dbo].[FK_FleetShip]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShipSet] DROP CONSTRAINT [FK_FleetShip];
GO
IF OBJECT_ID(N'[dbo].[FK_ShipTypeShip]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShipSet] DROP CONSTRAINT [FK_ShipTypeShip];
GO
IF OBJECT_ID(N'[dbo].[FK_StationTypeStation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StationSet] DROP CONSTRAINT [FK_StationTypeStation];
GO
IF OBJECT_ID(N'[dbo].[FK_CelestialBodyFleet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FleetSet] DROP CONSTRAINT [FK_CelestialBodyFleet];
GO
IF OBJECT_ID(N'[dbo].[FK_Star_inherits_CelestialBody]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CelestialBodySet_Star] DROP CONSTRAINT [FK_Star_inherits_CelestialBody];
GO
IF OBJECT_ID(N'[dbo].[FK_Planet_inherits_CelestialBody]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CelestialBodySet_Planet] DROP CONSTRAINT [FK_Planet_inherits_CelestialBody];
GO
IF OBJECT_ID(N'[dbo].[FK_Moon_inherits_CelestialBody]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CelestialBodySet_Moon] DROP CONSTRAINT [FK_Moon_inherits_CelestialBody];
GO
IF OBJECT_ID(N'[dbo].[FK_Asteroid_inherits_CelestialBody]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CelestialBodySet_Asteroid] DROP CONSTRAINT [FK_Asteroid_inherits_CelestialBody];
GO
IF OBJECT_ID(N'[dbo].[FK_Nebula_inherits_CelestialBody]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CelestialBodySet_Nebula] DROP CONSTRAINT [FK_Nebula_inherits_CelestialBody];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ClusterSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClusterSet];
GO
IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[CorporationSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CorporationSet];
GO
IF OBJECT_ID(N'[dbo].[ClassSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClassSet];
GO
IF OBJECT_ID(N'[dbo].[SkillSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SkillSet];
GO
IF OBJECT_ID(N'[dbo].[FeatureSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FeatureSet];
GO
IF OBJECT_ID(N'[dbo].[CelestialBodySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CelestialBodySet];
GO
IF OBJECT_ID(N'[dbo].[SkillAssignmentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SkillAssignmentSet];
GO
IF OBJECT_ID(N'[dbo].[FeatureAssignmentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FeatureAssignmentSet];
GO
IF OBJECT_ID(N'[dbo].[FleetSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FleetSet];
GO
IF OBJECT_ID(N'[dbo].[ShipSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ShipSet];
GO
IF OBJECT_ID(N'[dbo].[StationSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StationSet];
GO
IF OBJECT_ID(N'[dbo].[ShipTypeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ShipTypeSet];
GO
IF OBJECT_ID(N'[dbo].[StationModuleSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StationModuleSet];
GO
IF OBJECT_ID(N'[dbo].[StationModuleAssignmentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StationModuleAssignmentSet];
GO
IF OBJECT_ID(N'[dbo].[StationTypeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StationTypeSet];
GO
IF OBJECT_ID(N'[dbo].[JobStatusInfoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JobStatusInfoSet];
GO
IF OBJECT_ID(N'[dbo].[CelestialBodySet_Star]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CelestialBodySet_Star];
GO
IF OBJECT_ID(N'[dbo].[CelestialBodySet_Planet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CelestialBodySet_Planet];
GO
IF OBJECT_ID(N'[dbo].[CelestialBodySet_Moon]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CelestialBodySet_Moon];
GO
IF OBJECT_ID(N'[dbo].[CelestialBodySet_Asteroid]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CelestialBodySet_Asteroid];
GO
IF OBJECT_ID(N'[dbo].[CelestialBodySet_Nebula]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CelestialBodySet_Nebula];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ClusterSet'
CREATE TABLE [dbo].[ClusterSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ExtentX] int  NOT NULL,
    [ExtentY] int  NOT NULL
);
GO

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [PasswordSalt] nvarchar(max)  NOT NULL,
    [RoleType] int  NOT NULL
);
GO

-- Creating table 'CorporationSet'
CREATE TABLE [dbo].[CorporationSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Users_Id] int  NOT NULL,
    [Cluster_Id] int  NOT NULL,
    [Class_Id] int  NOT NULL
);
GO

-- Creating table 'ClassSet'
CREATE TABLE [dbo].[ClassSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SkillSet'
CREATE TABLE [dbo].[SkillSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Class_Id] int  NOT NULL
);
GO

-- Creating table 'FeatureSet'
CREATE TABLE [dbo].[FeatureSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CelestialBodySet'
CREATE TABLE [dbo].[CelestialBodySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [X] float  NOT NULL,
    [Y] float  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Dimension] int  NOT NULL,
    [Angle] float  NULL,
    [Radius] float  NULL,
    [CssClass] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SkillAssignmentSet'
CREATE TABLE [dbo].[SkillAssignmentSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SkillId] int  NOT NULL,
    [CorporationId] int  NOT NULL
);
GO

-- Creating table 'FeatureAssignmentSet'
CREATE TABLE [dbo].[FeatureAssignmentSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FeatureId] int  NOT NULL,
    [CorporationId] int  NOT NULL
);
GO

-- Creating table 'FleetSet'
CREATE TABLE [dbo].[FleetSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Origin_Id] int  NOT NULL,
    [Destination_Id] int  NULL
);
GO

-- Creating table 'ShipSet'
CREATE TABLE [dbo].[ShipSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Fleet_Id] int  NOT NULL,
    [ShipType_Id] int  NOT NULL
);
GO

-- Creating table 'StationSet'
CREATE TABLE [dbo].[StationSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] int  NOT NULL,
    [CelestialBody_Id] int  NOT NULL,
    [StationType_Id] int  NOT NULL
);
GO

-- Creating table 'ShipTypeSet'
CREATE TABLE [dbo].[ShipTypeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'StationModuleSet'
CREATE TABLE [dbo].[StationModuleSet] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'StationModuleAssignmentSet'
CREATE TABLE [dbo].[StationModuleAssignmentSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [StationId] int  NOT NULL,
    [StationModuleId] int  NOT NULL
);
GO

-- Creating table 'StationTypeSet'
CREATE TABLE [dbo].[StationTypeSet] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'JobStatusInfoSet'
CREATE TABLE [dbo].[JobStatusInfoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Key] uniqueidentifier  NOT NULL,
    [Progress] int  NOT NULL,
    [Message] nvarchar(max)  NULL,
    [Succeded] bit  NULL
);
GO

-- Creating table 'CelestialBodySet_Star'
CREATE TABLE [dbo].[CelestialBodySet_Star] (
    [Type] int  NOT NULL,
    [Id] int  NOT NULL,
    [Cluster_Id] int  NOT NULL
);
GO

-- Creating table 'CelestialBodySet_Planet'
CREATE TABLE [dbo].[CelestialBodySet_Planet] (
    [Type] int  NOT NULL,
    [Id] int  NOT NULL,
    [Star_Id] int  NOT NULL
);
GO

-- Creating table 'CelestialBodySet_Moon'
CREATE TABLE [dbo].[CelestialBodySet_Moon] (
    [Type] int  NOT NULL,
    [Id] int  NOT NULL,
    [Planet_Id] int  NOT NULL
);
GO

-- Creating table 'CelestialBodySet_Asteroid'
CREATE TABLE [dbo].[CelestialBodySet_Asteroid] (
    [Type] int  NOT NULL,
    [Id] int  NOT NULL,
    [Star_Id] int  NOT NULL
);
GO

-- Creating table 'CelestialBodySet_Nebula'
CREATE TABLE [dbo].[CelestialBodySet_Nebula] (
    [Type] int  NOT NULL,
    [Id] int  NOT NULL,
    [Star_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ClusterSet'
ALTER TABLE [dbo].[ClusterSet]
ADD CONSTRAINT [PK_ClusterSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CorporationSet'
ALTER TABLE [dbo].[CorporationSet]
ADD CONSTRAINT [PK_CorporationSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ClassSet'
ALTER TABLE [dbo].[ClassSet]
ADD CONSTRAINT [PK_ClassSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SkillSet'
ALTER TABLE [dbo].[SkillSet]
ADD CONSTRAINT [PK_SkillSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FeatureSet'
ALTER TABLE [dbo].[FeatureSet]
ADD CONSTRAINT [PK_FeatureSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CelestialBodySet'
ALTER TABLE [dbo].[CelestialBodySet]
ADD CONSTRAINT [PK_CelestialBodySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SkillAssignmentSet'
ALTER TABLE [dbo].[SkillAssignmentSet]
ADD CONSTRAINT [PK_SkillAssignmentSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FeatureAssignmentSet'
ALTER TABLE [dbo].[FeatureAssignmentSet]
ADD CONSTRAINT [PK_FeatureAssignmentSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FleetSet'
ALTER TABLE [dbo].[FleetSet]
ADD CONSTRAINT [PK_FleetSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ShipSet'
ALTER TABLE [dbo].[ShipSet]
ADD CONSTRAINT [PK_ShipSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StationSet'
ALTER TABLE [dbo].[StationSet]
ADD CONSTRAINT [PK_StationSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ShipTypeSet'
ALTER TABLE [dbo].[ShipTypeSet]
ADD CONSTRAINT [PK_ShipTypeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StationModuleSet'
ALTER TABLE [dbo].[StationModuleSet]
ADD CONSTRAINT [PK_StationModuleSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StationModuleAssignmentSet'
ALTER TABLE [dbo].[StationModuleAssignmentSet]
ADD CONSTRAINT [PK_StationModuleAssignmentSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StationTypeSet'
ALTER TABLE [dbo].[StationTypeSet]
ADD CONSTRAINT [PK_StationTypeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'JobStatusInfoSet'
ALTER TABLE [dbo].[JobStatusInfoSet]
ADD CONSTRAINT [PK_JobStatusInfoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CelestialBodySet_Star'
ALTER TABLE [dbo].[CelestialBodySet_Star]
ADD CONSTRAINT [PK_CelestialBodySet_Star]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CelestialBodySet_Planet'
ALTER TABLE [dbo].[CelestialBodySet_Planet]
ADD CONSTRAINT [PK_CelestialBodySet_Planet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CelestialBodySet_Moon'
ALTER TABLE [dbo].[CelestialBodySet_Moon]
ADD CONSTRAINT [PK_CelestialBodySet_Moon]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CelestialBodySet_Asteroid'
ALTER TABLE [dbo].[CelestialBodySet_Asteroid]
ADD CONSTRAINT [PK_CelestialBodySet_Asteroid]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CelestialBodySet_Nebula'
ALTER TABLE [dbo].[CelestialBodySet_Nebula]
ADD CONSTRAINT [PK_CelestialBodySet_Nebula]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Users_Id] in table 'CorporationSet'
ALTER TABLE [dbo].[CorporationSet]
ADD CONSTRAINT [FK_UserCorporation]
    FOREIGN KEY ([Users_Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserCorporation'
CREATE INDEX [IX_FK_UserCorporation]
ON [dbo].[CorporationSet]
    ([Users_Id]);
GO

-- Creating foreign key on [Cluster_Id] in table 'CorporationSet'
ALTER TABLE [dbo].[CorporationSet]
ADD CONSTRAINT [FK_ClusterCorporation]
    FOREIGN KEY ([Cluster_Id])
    REFERENCES [dbo].[ClusterSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClusterCorporation'
CREATE INDEX [IX_FK_ClusterCorporation]
ON [dbo].[CorporationSet]
    ([Cluster_Id]);
GO

-- Creating foreign key on [Cluster_Id] in table 'CelestialBodySet_Star'
ALTER TABLE [dbo].[CelestialBodySet_Star]
ADD CONSTRAINT [FK_ClusterStar]
    FOREIGN KEY ([Cluster_Id])
    REFERENCES [dbo].[ClusterSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClusterStar'
CREATE INDEX [IX_FK_ClusterStar]
ON [dbo].[CelestialBodySet_Star]
    ([Cluster_Id]);
GO

-- Creating foreign key on [Star_Id] in table 'CelestialBodySet_Planet'
ALTER TABLE [dbo].[CelestialBodySet_Planet]
ADD CONSTRAINT [FK_StarPlanet]
    FOREIGN KEY ([Star_Id])
    REFERENCES [dbo].[CelestialBodySet_Star]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StarPlanet'
CREATE INDEX [IX_FK_StarPlanet]
ON [dbo].[CelestialBodySet_Planet]
    ([Star_Id]);
GO

-- Creating foreign key on [Planet_Id] in table 'CelestialBodySet_Moon'
ALTER TABLE [dbo].[CelestialBodySet_Moon]
ADD CONSTRAINT [FK_PlanetMoon]
    FOREIGN KEY ([Planet_Id])
    REFERENCES [dbo].[CelestialBodySet_Planet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlanetMoon'
CREATE INDEX [IX_FK_PlanetMoon]
ON [dbo].[CelestialBodySet_Moon]
    ([Planet_Id]);
GO

-- Creating foreign key on [Star_Id] in table 'CelestialBodySet_Asteroid'
ALTER TABLE [dbo].[CelestialBodySet_Asteroid]
ADD CONSTRAINT [FK_StarAsteroid]
    FOREIGN KEY ([Star_Id])
    REFERENCES [dbo].[CelestialBodySet_Star]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StarAsteroid'
CREATE INDEX [IX_FK_StarAsteroid]
ON [dbo].[CelestialBodySet_Asteroid]
    ([Star_Id]);
GO

-- Creating foreign key on [Star_Id] in table 'CelestialBodySet_Nebula'
ALTER TABLE [dbo].[CelestialBodySet_Nebula]
ADD CONSTRAINT [FK_StarNebula]
    FOREIGN KEY ([Star_Id])
    REFERENCES [dbo].[CelestialBodySet_Star]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StarNebula'
CREATE INDEX [IX_FK_StarNebula]
ON [dbo].[CelestialBodySet_Nebula]
    ([Star_Id]);
GO

-- Creating foreign key on [Class_Id] in table 'CorporationSet'
ALTER TABLE [dbo].[CorporationSet]
ADD CONSTRAINT [FK_ClassCorporation]
    FOREIGN KEY ([Class_Id])
    REFERENCES [dbo].[ClassSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClassCorporation'
CREATE INDEX [IX_FK_ClassCorporation]
ON [dbo].[CorporationSet]
    ([Class_Id]);
GO

-- Creating foreign key on [Class_Id] in table 'SkillSet'
ALTER TABLE [dbo].[SkillSet]
ADD CONSTRAINT [FK_ClassSkill]
    FOREIGN KEY ([Class_Id])
    REFERENCES [dbo].[ClassSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClassSkill'
CREATE INDEX [IX_FK_ClassSkill]
ON [dbo].[SkillSet]
    ([Class_Id]);
GO

-- Creating foreign key on [SkillId] in table 'SkillAssignmentSet'
ALTER TABLE [dbo].[SkillAssignmentSet]
ADD CONSTRAINT [FK_SkillSkillAssignment]
    FOREIGN KEY ([SkillId])
    REFERENCES [dbo].[SkillSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SkillSkillAssignment'
CREATE INDEX [IX_FK_SkillSkillAssignment]
ON [dbo].[SkillAssignmentSet]
    ([SkillId]);
GO

-- Creating foreign key on [CorporationId] in table 'SkillAssignmentSet'
ALTER TABLE [dbo].[SkillAssignmentSet]
ADD CONSTRAINT [FK_CorporationSkillAssignment]
    FOREIGN KEY ([CorporationId])
    REFERENCES [dbo].[CorporationSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CorporationSkillAssignment'
CREATE INDEX [IX_FK_CorporationSkillAssignment]
ON [dbo].[SkillAssignmentSet]
    ([CorporationId]);
GO

-- Creating foreign key on [FeatureId] in table 'FeatureAssignmentSet'
ALTER TABLE [dbo].[FeatureAssignmentSet]
ADD CONSTRAINT [FK_FeatureFeatureAssignment]
    FOREIGN KEY ([FeatureId])
    REFERENCES [dbo].[FeatureSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FeatureFeatureAssignment'
CREATE INDEX [IX_FK_FeatureFeatureAssignment]
ON [dbo].[FeatureAssignmentSet]
    ([FeatureId]);
GO

-- Creating foreign key on [CorporationId] in table 'FeatureAssignmentSet'
ALTER TABLE [dbo].[FeatureAssignmentSet]
ADD CONSTRAINT [FK_CorporationFeatureAssignment]
    FOREIGN KEY ([CorporationId])
    REFERENCES [dbo].[CorporationSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CorporationFeatureAssignment'
CREATE INDEX [IX_FK_CorporationFeatureAssignment]
ON [dbo].[FeatureAssignmentSet]
    ([CorporationId]);
GO

-- Creating foreign key on [StationId] in table 'StationModuleAssignmentSet'
ALTER TABLE [dbo].[StationModuleAssignmentSet]
ADD CONSTRAINT [FK_StationStationModuleAssignment]
    FOREIGN KEY ([StationId])
    REFERENCES [dbo].[StationSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StationStationModuleAssignment'
CREATE INDEX [IX_FK_StationStationModuleAssignment]
ON [dbo].[StationModuleAssignmentSet]
    ([StationId]);
GO

-- Creating foreign key on [StationModuleId] in table 'StationModuleAssignmentSet'
ALTER TABLE [dbo].[StationModuleAssignmentSet]
ADD CONSTRAINT [FK_StationModuleStationModuleAssignment]
    FOREIGN KEY ([StationModuleId])
    REFERENCES [dbo].[StationModuleSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StationModuleStationModuleAssignment'
CREATE INDEX [IX_FK_StationModuleStationModuleAssignment]
ON [dbo].[StationModuleAssignmentSet]
    ([StationModuleId]);
GO

-- Creating foreign key on [CelestialBody_Id] in table 'StationSet'
ALTER TABLE [dbo].[StationSet]
ADD CONSTRAINT [FK_StationCelestialBody]
    FOREIGN KEY ([CelestialBody_Id])
    REFERENCES [dbo].[CelestialBodySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StationCelestialBody'
CREATE INDEX [IX_FK_StationCelestialBody]
ON [dbo].[StationSet]
    ([CelestialBody_Id]);
GO

-- Creating foreign key on [Origin_Id] in table 'FleetSet'
ALTER TABLE [dbo].[FleetSet]
ADD CONSTRAINT [FK_FleetCelestialBody]
    FOREIGN KEY ([Origin_Id])
    REFERENCES [dbo].[CelestialBodySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FleetCelestialBody'
CREATE INDEX [IX_FK_FleetCelestialBody]
ON [dbo].[FleetSet]
    ([Origin_Id]);
GO

-- Creating foreign key on [Fleet_Id] in table 'ShipSet'
ALTER TABLE [dbo].[ShipSet]
ADD CONSTRAINT [FK_FleetShip]
    FOREIGN KEY ([Fleet_Id])
    REFERENCES [dbo].[FleetSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FleetShip'
CREATE INDEX [IX_FK_FleetShip]
ON [dbo].[ShipSet]
    ([Fleet_Id]);
GO

-- Creating foreign key on [ShipType_Id] in table 'ShipSet'
ALTER TABLE [dbo].[ShipSet]
ADD CONSTRAINT [FK_ShipTypeShip]
    FOREIGN KEY ([ShipType_Id])
    REFERENCES [dbo].[ShipTypeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ShipTypeShip'
CREATE INDEX [IX_FK_ShipTypeShip]
ON [dbo].[ShipSet]
    ([ShipType_Id]);
GO

-- Creating foreign key on [StationType_Id] in table 'StationSet'
ALTER TABLE [dbo].[StationSet]
ADD CONSTRAINT [FK_StationTypeStation]
    FOREIGN KEY ([StationType_Id])
    REFERENCES [dbo].[StationTypeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StationTypeStation'
CREATE INDEX [IX_FK_StationTypeStation]
ON [dbo].[StationSet]
    ([StationType_Id]);
GO

-- Creating foreign key on [Destination_Id] in table 'FleetSet'
ALTER TABLE [dbo].[FleetSet]
ADD CONSTRAINT [FK_CelestialBodyFleet]
    FOREIGN KEY ([Destination_Id])
    REFERENCES [dbo].[CelestialBodySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CelestialBodyFleet'
CREATE INDEX [IX_FK_CelestialBodyFleet]
ON [dbo].[FleetSet]
    ([Destination_Id]);
GO

-- Creating foreign key on [Id] in table 'CelestialBodySet_Star'
ALTER TABLE [dbo].[CelestialBodySet_Star]
ADD CONSTRAINT [FK_Star_inherits_CelestialBody]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[CelestialBodySet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'CelestialBodySet_Planet'
ALTER TABLE [dbo].[CelestialBodySet_Planet]
ADD CONSTRAINT [FK_Planet_inherits_CelestialBody]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[CelestialBodySet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'CelestialBodySet_Moon'
ALTER TABLE [dbo].[CelestialBodySet_Moon]
ADD CONSTRAINT [FK_Moon_inherits_CelestialBody]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[CelestialBodySet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'CelestialBodySet_Asteroid'
ALTER TABLE [dbo].[CelestialBodySet_Asteroid]
ADD CONSTRAINT [FK_Asteroid_inherits_CelestialBody]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[CelestialBodySet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'CelestialBodySet_Nebula'
ALTER TABLE [dbo].[CelestialBodySet_Nebula]
ADD CONSTRAINT [FK_Nebula_inherits_CelestialBody]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[CelestialBodySet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------