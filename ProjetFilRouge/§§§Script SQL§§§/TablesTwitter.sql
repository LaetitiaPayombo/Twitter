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
    PRIMARY KEY CLUSTERED ([id] ASC)
)

----Test utilisateur
--INSERT INTO [dbo].[Utilisateur] ([pseudo],[email])
--VALUES ('Titi','titi@yahoo.fr')

/*
 * Création table Commentaire
 */
 
CREATE TABLE [dbo].[commentaire]
(
	[Id] INT IDENTITY (1, 1) NOT NULL,
    [dateCommentaire] DATETIME     NOT NULL,
    [commentaire]      VARCHAR (500) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
)
/*
 * Création table Theme
 */
CREATE TABLE [dbo].[thematique]
(
	[Id] INT IDENTITY (1, 1) NOT NULL,       
    [sujet]  VARCHAR(100) NOT NULL,
    
    PRIMARY KEY CLUSTERED ([id] ASC)
)
/*
 * Création table Forum
 */
CREATE TABLE [dbo].[forum]
(
	[Id] INT IDENTITY (1, 1) NOT NULL, 
    [idUser]       INT    NOT NULL,    
    [idThematique]       INT    NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
)

