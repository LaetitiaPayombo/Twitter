DROP TABLE tweeto;
Drop TABLE classement;
Drop TABLE image;

--Table Pour les utilisateurs, commentaires, thematiques, forum
CREATE TABLE tweeto(
id int PRIMARY KEY IDENTITY(1,1),
title varchar(200) not null,
description text not null,
classement_id int not null
);

CREATE TABLE classement(
id int PRIMARY KEY IDENTITY(1,1),
title varchar(200) not null
);

CREATE TABLE image(
id int PRIMARY KEY IDENTITY(1,1),
url varchar(MAX) not null,
tweeto_id int not null
);





