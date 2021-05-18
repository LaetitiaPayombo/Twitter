Drop TABLE Utilisateur;
Drop TABLE commentaire;
Drop TABLE thematique;
Drop TABLE forum;
/*
 * Création table Utilisateur
 */
CREATE TABLE [dbo].[Utilisateur]
(
	[Id] INT IDENTITY (1, 1) NOT NULL, 
    [pseudo] VARCHAR(50) NOT NULL, 
    [email] VARCHAR(50) NOT NULL,
    [avatar] VARCHAR(MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
)

/*
 * Création table Commentaire
 */
 
CREATE TABLE [dbo].[commentaire]
(
	[id] INT IDENTITY (1, 1) NOT NULL,
    [date_commentaire] DATETIME     NOT NULL,
    [com]      VARCHAR (500) NOT NULL,
    [image] VARCHAR(MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
)
/*
 * Création table Theme
 */
CREATE TABLE [dbo].[thematique]
(
	[id] INT IDENTITY (1, 1) NOT NULL,       
    [sujet]  VARCHAR(100) NOT NULL,
    
    PRIMARY KEY CLUSTERED ([id] ASC)
)
/*
 * Création table Forum
 */
CREATE TABLE [dbo].[forum]
(
	[id] INT IDENTITY (1, 1) NOT NULL, 
    [id_user]       INT    NOT NULL,    
    [id_thematique]       INT    NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
)

