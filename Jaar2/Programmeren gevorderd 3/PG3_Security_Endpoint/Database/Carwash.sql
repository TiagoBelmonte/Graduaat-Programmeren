CREATE DATABASE Carwash;
GO

USE Carwash;
GO

-- Maak de tabel voor klanten aan
CREATE TABLE Klanten (
    KlantID INT PRIMARY KEY IDENTITY(1,1),
    Naam NVARCHAR(100) NOT NULL,
    Adres NVARCHAR(200) NOT NULL,
    Telefoon NVARCHAR(15) NOT NULL,
    Email NVARCHAR(100) NOT NULL
);
GO

-- Maak de tabel voor voertuigen aan
CREATE TABLE Voertuigen (
    VoertuigID INT PRIMARY KEY IDENTITY(1,1),
    KlantID INT NOT NULL,
    Kenteken NVARCHAR(20) NOT NULL,
    Merk NVARCHAR(50) NOT NULL,
    Model NVARCHAR(50) NOT NULL,
    FOREIGN KEY (KlantID) REFERENCES Klanten(KlantID)
);
GO

-- Maak de tabel voor diensten aan
CREATE TABLE Diensten (
    DienstID INT PRIMARY KEY IDENTITY(1,1),
    Naam NVARCHAR(100) NOT NULL,
    Beschrijving NVARCHAR(500),
    Prijs DECIMAL(10, 2) NOT NULL
);
GO

-- Maak de tabel voor bestellingen aan
CREATE TABLE Bestellingen (
    BestellingID INT PRIMARY KEY IDENTITY(1,1),
    KlantID INT NOT NULL,
    VoertuigID INT NOT NULL,
    BestelDatum DATE NOT NULL,
    TotaalBedrag DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (KlantID) REFERENCES Klanten(KlantID),
    FOREIGN KEY (VoertuigID) REFERENCES Voertuigen(VoertuigID)
);
GO

-- Maak de tabel voor bestellingsregels aan
CREATE TABLE Bestellingsregels (
    BestellingsregelID INT PRIMARY KEY IDENTITY(1,1),
    BestellingID INT NOT NULL,
    DienstID INT NOT NULL,
    Aantal INT NOT NULL,
    PrijsPerStuk DECIMAL(10, 2) NOT NULL,
    TotaalPrijs DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (BestellingID) REFERENCES Bestellingen(BestellingID),
    FOREIGN KEY (DienstID) REFERENCES Diensten(DienstID)
);
GO

-- Voeg voorbeeldgegevens toe aan de tabellen
INSERT INTO Klanten (Naam, Adres, Telefoon, Email)
VALUES
    ('Jan Jansen', 'Hoofdstraat 1, 1000 AB Amsterdam', '0612345678', 'jan.jansen@example.com'),
    ('Piet Pietersen', 'Dorpsstraat 5, 2000 CD Rotterdam', '0612345679', 'piet.pietersen@example.com');

INSERT INTO Voertuigen (KlantID, Kenteken, Merk, Model)
VALUES
    (1, 'AB-123-CD', 'Volkswagen', 'Golf'),
    (2, 'EF-456-GH', 'BMW', '3 Series');

INSERT INTO Diensten (Naam, Beschrijving, Prijs)
VALUES
    ('Buitenwassen', 'Exterieur reiniging', 15.00),
    ('Binnen en Buitenwassen', 'Interieur en exterieur reiniging', 25.00);

INSERT INTO Bestellingen (KlantID, VoertuigID, BestelDatum, TotaalBedrag)
VALUES
    (1, 1, '2023-06-14', 15.00),
    (2, 2, '2023-06-15', 25.00);

INSERT INTO Bestellingsregels (BestellingID, DienstID, Aantal, PrijsPerStuk, TotaalPrijs)
VALUES
    (1, 1, 1, 15.00, 15.00),
    (2, 2, 1, 25.00, 25.00);

GO

-- Voeg meer voorbeeldgegevens toe
INSERT INTO Klanten (Naam, Adres, Telefoon, Email)
VALUES
    ('Klaas Klaassen', 'Laan van Vrede 10, 3000 EF Den Haag', '0612345680', 'klaas.klaassen@example.com'),
    ('Sara Smit', 'Kerkstraat 20, 4000 GH Utrecht', '0612345681', 'sara.smit@example.com'),
    ('Anna de Vries', 'Brugstraat 15, 5000 IJ Eindhoven', '0612345682', 'anna.de.vries@example.com'),
    ('Mark de Boer', 'Stationsweg 50, 6000 KL Maastricht', '0612345683', 'mark.de.boer@example.com');


INSERT INTO Voertuigen (KlantID, Kenteken, Merk, Model)
VALUES
    (3, 'IJ-789-KL', 'Audi', 'A4'),
    (4, 'MN-012-OP', 'Mercedes', 'C-Class'),
    (5, 'QR-345-ST', 'Toyota', 'Corolla'),
    (6, 'UV-678-WX', 'Ford', 'Focus');


INSERT INTO Diensten (Naam, Beschrijving, Prijs)
VALUES
    ('Polijsten', 'Lak polijsten en waxen', 50.00),
    ('Dieptereiniging', 'Grondige interieur reiniging', 75.00);


INSERT INTO Bestellingen (KlantID, VoertuigID, BestelDatum, TotaalBedrag)
VALUES
    (3, 3, '2023-06-16', 50.00),
    (4, 4, '2023-06-17', 75.00),
    (5, 5, '2023-06-18', 40.00),
    (6, 6, '2023-06-19', 90.00);


INSERT INTO Bestellingsregels (BestellingID, DienstID, Aantal, PrijsPerStuk, TotaalPrijs)
VALUES
    (3, 3, 1, 50.00, 50.00),
    (4, 4, 1, 75.00, 75.00),
    (5, 1, 2, 15.00, 30.00),
    (6, 2, 1, 25.00, 25.00),
    (6, 3, 1, 50.00, 50.00),
    (6, 1, 1, 15.00, 15.00);

GO