-- Tabel voor Uitgeverijen
CREATE TABLE Uitgeverij (
    id INT IDENTITY(1,1) PRIMARY KEY,
    naam VARCHAR(255) NOT NULL,
    adres VARCHAR(255) NOT NULL
);

-- Tabel voor Reeksen
CREATE TABLE Reeks (
    id INT IDENTITY(1,1) PRIMARY KEY,
    naam VARCHAR(255) NOT NULL UNIQUE
);

-- Tabel voor Auteurs
CREATE TABLE Auteur (
    id INT IDENTITY(1,1) PRIMARY KEY,
    naam VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL
);

-- Tabel voor Strips
CREATE TABLE Strip (
    id INT IDENTITY(1,1) PRIMARY KEY,
    titel VARCHAR(255) NOT NULL,
    uitgeverij_id INT NOT NULL,
    reeks_id INT,
    reeksNR INT,
    FOREIGN KEY (uitgeverij_id) REFERENCES Uitgeverij(id),
    FOREIGN KEY (reeks_id) REFERENCES Reeks(id)
);

-- Relatietabel voor Strip-Auteur (een strip kan meerdere auteurs hebben)
CREATE TABLE Strip_Auteur (
    strip_id INT,
    auteur_id INT,
    PRIMARY KEY (strip_id, auteur_id),
    FOREIGN KEY (strip_id) REFERENCES Strip(id),
    FOREIGN KEY (auteur_id) REFERENCES Auteur(id)
);
