DROP TABLE IF EXISTS personne;

CREATE TABLE personne
(
	id			INTEGER PRIMARY KEY,
	nom			TEXT	NOT NULL,
	prenom		TEXT	NOT NULL,
	telephone	TEXT	NOT NULL
);

INSERT INTO personne VALUES (NULL, 'Carnaval', 'Bonhomme', '418-123-4567');
INSERT INTO personne VALUES (NULL, 'Gratton', 'Bob', '450-659-8854');
INSERT INTO personne VALUES (NULL, 'Troudeau', 'Justun', '514-465-4785');
INSERT INTO personne VALUES (NULL, 'Doué', 'Jél', '819-567-0191');
INSERT INTO personne VALUES (NULL, 'Ndong', 'Saliou', '819-123-4567');