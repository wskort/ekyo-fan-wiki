---
tags: Archief/NVWA
---
# e-CertNL
Dit is de applicatie voor certificering van landbouwproducten voor export. 24/7 gebruikte applicatie. 

URL naar applicatie
`http://I1052t0016.cicapp.nl:7003` = testomgeving (oranje kleur header)
Relatienummer NVWA: `1595140`
Sector code: `VDM` (er zijn er 20, wij zijn voor specifiek deze).


## Totstandkoming e-CertNL
Oorspronkelijke naam was "CLIENT Export", ontwikkeld door Mediaan (business transformatie data-driven organisatie). Per 2013 overgedragen aan DICTU. Sinds 2017 [[DevOps]] team(s) ervoor opgericht. 

## Koppelingen
- Authenticatie en identificatie EHerkenning (TVS)
- MOS verleende erkenning (NVWA)
- Centrale Gegevens Ontsluiting (CGO-Mest) (RVO)
- Verifieer Registratie Mest (RVO)
- Verifieer Gewogen gewicht (RVO)
- Inspectieplannen (COKZ)
- Geregistreerd product (COKZ)
- Afgifte documentnummer (COKZ)
- Gekeurde partijen (NAK)
- Ketenregister (NAKT-BKD)
- Inspectiesysteem IBP (KCP)
- ... en meer, zie slides? hopelijk?

## Componenten
### Certificate Mastering System (CMS)
Module om elektronisch certificaat te verwerken. 

### APEX
- Dierziekte status
- Permit register
- Export inspecties
- Onafhankelijke monster(af)name (mest)
- CLIENT Rest product (past niet in een sector)
- Rapportagetool
- Informatietool
- rVDM

Gebruikt door:
- Keuringsdiensten
	- KCB
	- NAKT
	- NAK
	- BKD
	- RVO
	- COKZ
	- NVWA

### Java
- Veterinaire sectoren
- Mest sectoren
- Fyto sectoren (plant) 
- Eerstelijns ondersteuning keuringsdiensten

### Webservices
- CLE (algemeen gebruik)
- B2G (voor alle sectoren m.u.v. mest & pootaardappelen)
- pootaardappelen
- Floricode (fyto m.u.v. pootaardappelen)
- Onafhankelijke monsternamen
- mest export
- mest import
- opendata
- mest generiek (rVDM)

#### Berichten B2G
- put certificate (aanvraag)
- get inspectie (inspectie)
- get status (status opvragen)
- get asynchrone status
- get certificate documenten (afgifte)
- get certificate cancel (intrekken)

#### CLE berichten
- bepaal zending status
- afgifte documenten
- productboom
- landen & gebieden
- verzoeken
- bindende afspraken
- domein waarde opvragen
- test connectie
- inspectie aanvraag
- asynchrone raadplegen zending status
- intrekken aanvraag
- ontgrendelen

## Vooraanmelding
Specifiek voor [[VDM]] 
(Andere mest-sectoren: CME (export), CMI (import), CRO (?)). 
(Overnemen aanmelding uit CME/CMI wordt ontwikkeld voor het stuk binnen NL). 

### Vooraanmelding
Knop voor nieuwe aanvraag maken
Lijst huidige vooraanmeldingen met filterblok

Vooraanmeldingsnummer & rVDM nummer

ID verzender = K.V.K.-nummer + vestigingsnummer

BRS-nummer indien geen KVK-nummer bekend maar wel bedrijfsrelatienummer

Particulieren hebben alleen BRS, geen KVK. 

### Nieuwe vooraanmelding
Vooraanmeldingsnummer (int.length(8))
rVDM nummer (int.length(10)) > pas na vrijgave document
#### Vervoer 
Laad/losplaatsen postcode, UBN (Uniek BedrijfsNummer), registratienummer opslag. 

Opmerkingscodes (pruned obv afwikkelstroom). 

Vervoermiddelen met (GR) zijn geregistreerde set opties. 
#### Samenstelling mest
#### Zekerheden
I Solemny Swear!
Knop: controleer eisen (geen controles ingesteld op ontwikkel/test). 
Uitstaande wens: ook controles op test! verdorie

#### Documenten
Gegenereerd na controle zekerheden (wordt door externe partij ontwikkeld)

Document afgifte = start vervoer

#### Laden/lossen
Scherm wordt nog aangepast. 

### Lopend vervoer
### Afgerond vervoer
### Berichten
## Eisen/Dekkingen
## Bedrijfsgegevens
Exportrol: 
* Exporteur (ook intranationaal)
* Gemachtigde (gebruiken we niet)
### Uw bedrijf
Erkenningen: bekende bedrijven die geselecteerd mogen worden. 
### Contact en berichten
Export/import certificaat
Verzendwijze
Wachtwoord voor noodprocedure & webservices (gaat uitgesplitst worden)
### Eigen codes
### Lijsten
### Voertuigen



## Afkortingen
FM (Feitelijke Mestvervoerder) (hiervan mag er maar 1 per relatienummer zijn)
MO (Mestvervoerder Overig)
ML (Mestleverancier)
MA (Mestaanvrager)
XO (exporteur)
AGR/GPS (laad/los/weging/monster data kastje)
GR - voertuig met AGR/GPS (en dus geregistreerd kastje)
DDV (dierenarts verklaring)

## Quirks
Acceptatieomgeving heeft exportdatum max 7 dagen in de toekomst, O/T is dat 14. GPS doorgeven kan alleen op acceptatie. 

3 soorten afwikkelstroom:
- volledig rVDM-app (voor individuele boeren; geen weegmelding e.d.)
- volledig BMS (api's)
- deels via AGR/GPS


Laatste stap: forward data to RVO via VDI koppeling (?). 