---
tags: Archief/NVWA
---
# Scenario library
## FrontPage
### .ScenarioLibrary
- use ONT7004
- use ONT7003
- use test
- use acc
- use schaduw
- use prod
`use ${testenv}`

### .IntergratieTest
#### .ScenarioLibrary
- Controleer melding `value` (tekst aanwezig op scherm)
- Controleer of tekst aanwezig is `value` (tekst aanwezig op scherm)

#### .ChromeTest
##### .CAT.ScenarioLibrary
- vul IBP productgroep in met `value`
- vul grensovergang in met `value`
- vul permit in met `value`
- vul identificatie markering in met `value`
- vul lc nummer in met `value`
- vul keuringsdienstnummer in met `value`
- vul ordernummer in met `value`
- vul awbnummer in met `value`
- vul BoLnummer in met `value`
- vul aanvraag door keuringsdienst in met `value`
- vul nummer in voor WAARDEPAPIER_NUMMER in met `value`
- Zoek op botanische naam `value`

##### .CEV.ScenarioLibrary
- Uitgeven documenten CEV

##### .CLH.ScenarioLibrary
- Doorvoerland: `antwoord`
- Datum en tijd laden: `datum`
- Partij staat klaar vanaf (datum en tijd): `antwoord`
- Duur van vervoer (aantal uur): `antwoord`

##### .CME.ScenarioLibrary
- Valideer exportwaardigheid `value`
- Inspectie document toevoegen

#### .SchaduwomgevingRvdm.VDM.ScenarioLibrary
- Ga naar documenten tabblad

## NVWAPoC
### .ScenarioLibrary
- voor de eerste keer inloggen op `omgeving` met gebruiker `gebruiker` en voor sector `sector`
- inloggen op `omgeving` met gebruiker `gebruiker` en voor sector `sector`
- inloggen op check certificate `omgeving` met kvknummer `kvk` en met vestigingnummer `vestigingnummer`
- Navigeer naar tabblad Order
- Navigeer naar tabblad Verklaringen
- Navigeer naar tabblad Orderregel
- Navigeer naar tabblad Samenstelling Vracht
- Navigeer naar tabblad Zekerheden
- Navigeer naar tabblad Inspecties
- Navigeer naar tabblad Documenten
- Bewaar aanpassingen succesvol
- Bewaar aanpassingen NIET succesvol
- Annuleer aanpassingen en Niet bewaren
- Annuleer aanpassingen en Bewaren
- maak een nieuwe standaard aanvraag aan voor `datum` naar `land` met eis `eis`
- Kopieer huidige aanvraag `datum`
- Sla nieuw aanvraagnummer op
- maak een nieuwe zonder land aanvraag aan voor `datum` met eis `eis`
- maak een nieuwe zonder eis aanvraag aan voor `datum` naar `land`
- Maak replacement als reden `reden` met `datum`
- zoek aanvraag `aanvraagnummer`
- open aanvraag `aanvraagnummer`
- open huidige aanvraag
- Maak nieuwe orderregel aan
- Open orderregel met regelnummer `nummer`
- Wacht totdat je weer op het orderregel overzicht bent
- Aanvraag intrekken
- Zekerheden nagaan
- Documenten Inspecteren
- Documenten Uitgeven
- Navigeer naar tabblad Te wijzigen
- navigeer naar tabblad bedrijfsgegevens
- meld kenteken defect `kenteken`
- meld kenteken gerepareerd `kenteken`
- vul bewaartemperatuur in met 	`temperatuur`
- vul vrijelijk doorvoerland in met `doorvoorland`
- vul plaats van vertrek in met `vertrek`
- vul Identificerende markering in met `identificatie`
- vul vrijelijk verzendplaats in met `verzendplaats`
- vul transport temperatuur in met `temperatuur`
- maak een nieuwe zonder eis en transport aanvraag aan voor `datum` naar `land`
- Maak nieuwe orderregel aan voor het ophalen van partijen
- Haal partijen op
- Selecteer partij met gewicht `gewicht`
- Valideer tekst `value`
- Controleer of bewaarknop disabled is
- selecteer huidige aanvraag
- Controleer of intrekken niet mogelijk is
- navigeer naar tabblad rollen en rechten
- selecteer notificatie `notificatie`
- stel vast dat notificatie disabled is `notificatie`
- stel vast dat knop niet aanwezig is `knop`
- open de aanvraag
- voeg nieuwe losplaats toe `code` met postcode `postcode` met land `land`
- voeg een eigen code toe van een loslocatie
- annuleer het toevoegen van een eigen code
- ververs pagina `url` en wacht op `id`
- klik op sector `sector`
- Kopieer aanvraag `datum`
- Controleer of intrekken niet mogelijk is in een geopende aanvraag
- zoek huidige aanvraag
- navigeer naar transportmiddel
- controleer aanwezigheid voertuig `voertuig`
- stel vast dat veld niet aanwezig is `veld`
- wis de invoer
- stel vast dat het veldid `veldid` gevuld is met `vulling`
- stel vast dat de veldnaam `veldnaam` gevuld is met `vulling`
- voer waarde in veldid `veldid` met vulling `vulling`
- voer waarde exportdatum(t/m) in `exportdatumtm`
- stel vast dat exportdatum(t/m) gevuld is met `exportdatumtm`
- selecteer eerste waarde in veldnaam `veldnaam`
- stel vast dat veldid disabled is `veldid`
- optie 2 stel vast dat veldid disabled is `veldid`
- verwijder de eis
- Controleer of kopieren niet mogelijk is
- Controleer of kopieren niet mogelijk is in een geopende aanvraag
- Controleer of opvolgen niet mogelijk is in een geopende aanvraag
- Bewaar aanpassingen succesvol rollen en rechten
- Controleer of opvolgen mogelijk is in een geopende aanvraag
- volg huidige aanvraag op in geopende aanvraag
- open de geselecteerde aanvraag
- open de geselecteerde aanvraag
- stel vast dat veldid enabled is `veldid`
- stel vast dat veld aanwezig is `veld`
- stel vast dat tekst niet aanwezig is `tekst`
- wacht totdat veldid getoond is `veldid`
- annuleer aanpassingen
- bewaar aanvraagnummer
- maak veldid leeg `veldid`
- open het aanvragenoverzicht
- controleer zending status `zendingstatus`
- controleer afnemer `afnemer`
- controleer leverancier `leverancier`
- controleer of veldnaam als verplicht is aangegeven `veldnaam`
- geef product op `product` en percentage `percentage` op regel min 1 `regelMin1`

### .CAT.ScenariosOrderregelTab
- Orderregel lvi_Nummer `nummer`
- Orderregel Origine bij FKK: `land`
- valideer op orderregelniveau dat lvi_Nummer: `nummer`
- valideer op orderregelniveau dat Origine bij FKK: `land`

### .CEV.ScenarioLibrary
- vul tabblad zending in met standaard waarden
- vul Orderregel in met standaard waarden

### .CEV.ScenariosOrderTab
- Aanvrager verklaart dat het product vrij verhandelbaar is in: `land`
- Herkomst van eindproduct: `land`
- valideer dat herkomst van eindproduct is: `land`

### .CEV.ScenariosOrderregelTab
- Orderregel Aanvrager verklaart dat het product vrij verhandelbaar is in: `land`
- Orderregel Herkomst van eindproduct: `land`
- valideer op orderregelniveau dat het product vrij verhandelbaar is in: `land`
- valideer op orderregelniveau dat herkomst van eindproduct is: `land`

### .CME.ScenarioLibrary
- vul tabblad zending in met standaard waarden
- vul Samenstelling vracht in met standaard waarden
- valideer dat mestafnemer gevuld is `waarde`

### .CME.ScenariosOrderTab
- Aanvrager verklaart dat het product `waarde`
- Aanvrager verklaart dat markering transportmiddel `waarde`
- Aanvrager verklaart dat reiniging transportmiddel `waarde`
- Aanvrager verklaart dat levensmiddelen transportmiddel `waarde`
- Aanvrager verklaart dat vervoer `waarde`
- Origine product `waarde`
- Vul mestafnemer in `locatie`
- valideer dat Aanvrager verklaart dat het product `waarde`
- valideer dat Aanvrager verklaart dat markering transportmiddel `waarde`
- valideer dat Aanvrager verklaart dat reiniging transportmiddel `waarde`
- valideer dat Aanvrager verklaart dat levensmiddelen transportmiddel `waarde`
- valideer dat Origine product `waarde`

### .CMI.ScenarioLibrary
- vul tabblad zending in met standaard waarden

### .COV.ScenarioLibrary
- Vul certificaat nummer in met `value`
- Vul verificatie nummer in met `value`
- Wissel naar Spaanse taal
- Wissel naar Engelse taal
- Download certificaat
- 

### .CZU.ScenariosOrderTab
- Order number: `number`
- Behandeling: `behandeling`
- Diersoort: `diersoort`
- Herkomst van eindproduct: `land`
- Zuivel_Vetgehalte: `vetgehalte`
- Vul certificaat ordernummer in: `ordernummer`
- Vul lc nummer in: `LC_NUMMER`
- Vul lc omschrijving in: `LC_OMSCHRIJVING`
- Vul certificaat herkomst in: `GRENSOVERGANG`
- Vul factuur nummer in: `FACTUURNUMMER`
- Vul referentie nummer in: `REFERENTIENUMMER`
- Vul verschepingsteken nummer in: `VERSCHEPINGSTEKEN`
- Vul identificatie nummer in: `IDENTIFICATIE`
- Vul merk nummer: `MERK`
- Herkomst van kaassoort: `kaassoort`
- valideer dat ordernummer is `nummer`
- valideer dat behandeling is `behandeling`
- valideer dat diersoort is `diersoort`
- valideer dat herkomst van eindproduct is: `land`
- CZU prompt NL HERKOMST_GRONDSTOF: `herkomst`
- Zuivelproductsoort: `productsoort`
- Toon artikelcode: `artikelcode`
- Voldoet aan vrije verkooopclausule: `clausule`
- valideer dat CZU prompt NL HERKOMST_GRONDSTOFis `herkomst`
- valideer dat zuivelproductsoort is `productsoort`
- valideer dat vrije verkoopclausule `clausule`

### .CST.ScenarioLibrary
- vul deelzending Exporteiskenmerken ARTIFICIALLY_DWARFED in met `referentie`

### .CVI.ScenarioLibrary
- Wilt u het vetinaire certificaat aanvragen? `code`
- Vul vangstcertificaat aantal in met `code`
- Vul in plaats van bestemming in met `code`
- Vul diersoort vis (wetenschappelijke naam) in met `code`
- Vul naam vissersvaartuig in met `code`
- Vul thuishaven vissersvaartuig in met `code`
- Vul registratienummer thuishaven in met

### .CZU.ScenariosOrderregelTab
- Orderregel Order number: `nummer`
- Orderregel Behandeling: `behandeling`
- Orderregel Diersoort: `diersoort`
- Orderregel Herkomst van eindproduct: `land`
- Orderregel Herkomst van eindproduct-kaas: `kaas`
- Vetgehalte zuivel: `zuivel`
- Herkomst van kaassoort deelzending: `kaassoort`
- Vul taric code in: `taric`
- Vul bewaartemperatuur in: `BEWAARTEMPERATUUR`
- Vul bewaarwijze in: `BEWAARWIJZE`
- Orderregel valideer dat ordernummer is `nummer`
- Orderregel valideer dat behandeling is `behandeling`
- Orderregel valideer dat diersoort is `diersoort`
- Orderregel valideer dat herkomst van eindproduct is: `land`
- Orderregel CZU prompt NL HERKOMST_GRONDSTOF: `herkomst`
- Orderregel Zuivelproductsoort: `productsoort`
- Orderregel Voldoet aan vrije verkooopclausule: `clausule`