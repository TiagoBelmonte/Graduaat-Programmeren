# Startpunt Carwash PG3 "Security" en AutoMapper

**Link:** [https://classroom.github.com/](https://classroom.github.com/a/abrYXBDX)

## Wie ben je?

#### Voornaam en naam: 

#### IOEM (JA / NEE):

## Algemene richtlijnen

### Wat is toegelaten en niet toegelaten tijdens het afleggen van de test?

Je gebruik van je Github repository en het eindresultaat dat je indient onder Chamilo tijdens de test geldt als aanwezigheidsregistratie.

Heb je *individuele onderwijs- en examenmaatregelen (IOEM)* maak deze dan *vóór de start van de test* kenbaar aan je lector - zie hierboven.

Tijdens de test mag je **niet communiceren met je medestudenten of met derden**, noch online, noch offline, tenzij met je lector. Mobiele telefoons, smartwatches, enzovoort, moeten uitgeschakeld zijn (niet op stil, vliegtuigstand). Je mag ze ook niet gebruiken om de tijd te raadplegen. 

Als je met een Windows emulator werkt, dan switch je niet naar je hoofd-OS (vb. Windows 11 onder MacOS). Je neemt straks met Panopto het hele scherm op.

Op je laptop moeten alle voor de test niet noodzakelijke programma's uitgeschakeld zijn; zijn met andere woorden toegelaten:

- Docker Desktop met SQLServer
- Visual Studio 2022 of Visual Studio Code of Rider (je moet kiezen)
- SSMS
- een browser
- Acrobat Reader.

Via het netwerk mag je raadplegen:

- Chamilo
- Google.com, StackOverflow (of gelijkaardig)
- ChatGPT (of gelijkaardig).

Chat-applicaties en email worden uiteraard niet toegelaten (dit valt onder "contact met derden"). Het is ten stelligste verboden source code te bezorgen en te ontvangen aan en van een andere partij dan je lector.

Plagiaat plegen is evenmin toegelaten en dus verboden (weersta bijvoorbeeld de verleiding om broncode te copiëren uit een github project dat niet deel uitmaakt van de cursus).

Het niet volgen van deze regels wordt gesanctioneerd als examenfraude. Je krijgt dan een nul voor de test.

Installeer **Docker Desktop bovenop WSL2** en start een **SQLServer container op (Linux)**. Dit doe je **vooraleer de test start**: je kan dit thuis voorbereiden.

## Je startpunt: assemblies

### Assignment.Api

Je REST web service. Voor deze applicatie zet je onder andere REST security op zoals verderop beschreven. 

### Assignment.Api.Client

Je C# REST client: via deze applicatie toon je aan dat je je REST web service kan gebruiken.

### Assignment.Repository

Bevat onder andere alle reeds op basis van de beschikbare databank gegenereerde EF Core code welke je kan isoleren (zie GenericRepository).

### Algemeen

1. Gebruik VS2022, .NET 8.
2. Gebruik de git repository die je van de lector toegewezen kreeg via GitHub Classroom voor je opdracht.
3. Een method kan volledig op je scherm getoond worden.
4. Per klasse voorzie je een apart bestand.
5. De namespaces van je klassen komen overeen met je folderstructuur.

### Specifiek

Vertrek van het opstartpunt en respecteer bij het implementeren van je oplossing de verschillende lagen die in het opstartpunt voorzien zijn.

- De databank-DLL voor SQLServer vind je in Database/Carwash.sql; het png bestand "Carwash.png" toont de relaties tussen de tabellen visueel. 
- Inspiratie voor de EF Core commando's die je eventueel kan inzetten, vind je in Database/Commands.txt. 
- Je ontwikkelt een REST controller die toelaat de diensten ("Diensten") van de carwash te beheren:
  * toon alle diensten (met ondersteuning voor paging, filtering, sorting en searching, inclusief ondersteuning voor X-Pagination header)
  * toon een specifieke dienst aan de hand van diens DienstId
  * voeg een dienst toe
  * verwijder een dienst aan de hand van diens DienstId
  * pas de prijs van een dienst aan aan de hand van diens DienstId
  * voorzie de noodzakelijke ASP.NET Core tags en respecteer de afgesproken naming conventions inzake je REST "verbs".
- Zie bestand Database/queries.txt. Zorg ervoor dat je REST controller een "GET" aanbiedt voor query 4 én query 5:
  * (4) Toon het totale bedrag van alle bestellingen per klant
  * (5) Toon alle diensten en het aantal keren dat elke dienst besteld is
  * Let op: de SQL queries mogen alleen gebruikt worden om je resultaat te controleren; implementeer je methods met behulp van de EF Core laag: je moet precies dezelfde gegevens tonen via swagger als de queries doen.
- Maak gebruik van DTO's wanneer je in je REST controller interageert met de buitenwereld.
- Integreer SeriLog logging naar Seq en een log bestand in je REST API.
- Configureer als Kestrel poorten in je REST API: http 7040, https 7045.
- Bouw volgende security elementen in op het niveau van je REST API:
  * CORS
  * Rate limiter
  * HSTS en HTTPS redirection
  * Headers via eigen middleware: X-Frame-Options, X-Xss-Protection, X-Content-Type-Options, Referrer-Policy, X-Permitted-Cross-Domain-Policies, Permissions-Policy en ForwardedHeaders
  * Health check via url /working met UI
  * JWT token.
