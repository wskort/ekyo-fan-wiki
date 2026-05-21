---
tags: Archief/ProRail
---

## Doelstelling
[[TAF|TAF (Test Automation Framework)]] uitwerken voor het nieuwe [[NC|Naiade Continuous]], zodat deze conform [[BDD|Behavior Driven Development (BDD)]] testdekking heeft voor alle opgeleverde scenario's en voorbeelden. 

## Stakeholders
1. Responsible
   In eerste instantie Willeke, dan ook test team, op termijn overdracht aan developers
2. Accountable
   Saskia met ondersteuning Gaston
3. Consulted
   Huud (certificeringen? eisen?), Developers, Security?, Architectuur?, Rob Pladet ([[TCC]])
4. Informed
   Wilco ([[Wiconic]]), [[ProRail]] algemeen, P.O. Marjon/new

## Risico's
* Kennisverlies door gebruik externen
	* Documentatie strategie: borging (in [[Wiki]]?) niet als later project, maar systematisch onderdeel van oplevering [[TAF]].
* Tool veroudering en/of code wildgroei tijdens de levensloop van Aegle 2.0
	* Refactoring structureel in opleverproces opnemen.
	* Mogelijk overstap naar [[UI]] testen via [[Playwright]] (werkt in [[dotNET|.NET]]) ipv voortzetten [[Selenium]]. (SMARTer maken)
* Toegankelijkheid voor nieuwe gebruikers Aegle
	* Quick-start guide(s) in documentatie opnemen
* Verlies overzicht relatie tussen tests en functionaliteit
	* Wederzijdse links tussen [[Wiki]] en [[LivingDoc]]
		* Uitzoeken mogelijkheden
* Technische integratie met [[Naiade Legacy]] software
	* Onderdeel van dev modules of losstaand framework? (SMARTer maken)
* Incomplete communicatie met dev teams 
	* Deels ondervangen door gebruik [[BDD]] methodiek
	* Deelname dev standup(s)/refinements door tester(s)?
	* Gezamelijk demo-moment
	* Samenwerken op locatie
	* Onderdeel zelfde [[US]] 
* Incomplete overdracht testwerkwijze aan ontwikkelaars
	* Onderweg meenemen in proces? (SMARTer maken)
		* Test automation door devs laten reviewen
	* Educatie & gewenning
	* [[TDD|TDD (Test-Driven Development)]] aanmoedigen?
- Traagheid door het delen van build&deployment agents met development 

## Afhankelijkheden 
- Tijdslijn ontwikkeling van [[NC|Naiade Continuous]] zelf
	- [[API]] endpoints
		- Indien via Azure: [[Swagger]] files ophalen uit portal voor actuele overzichten?
	- Stories op volgorde van oppakken door dev teams
- Azure inrichting?
	- Hoe werkt deployment? 
		- 1 eigen pipeline of onderdeel van development pipelines?
	- Zijn daar rechten voor nodig?
- Service accounts & authenticatie
	- Richting [[NC]]
	- Richting [[Azure DevOps]]
- Beschikbare tools
	- [[RestSharp|Rest#]] plugin om [[REST|REST API]] calls binnen [[1. Werk/2. Technische kennis/Languages/CS|C#]] aan te roepen.
	- [[GUI]]-testtool ([[Selenium]] of [[Playwright]] for [[dotNET|.NET]])
	- [[SpecFlow]]
		- [[LivingDoc]]
	- [[Azure DevOps]] en verwante tools (testplans, wiki, etc). 
- Testserver(s)
	- Container per module deployment?
	- Hoe dan ketentesten?
- Testdatamanagement
	- [[ArcGIS]] koppeling? Mogelijk niet gebruikt in [[NC]] maar verdeeld over kleinere [[Database]]s. 
	- Mock data? 
	- Clean data per deployment of connectie met gedeelde testdatabase?
		- Zorgen dat benodigde testdata gevonden/gemaakt wordt
		- Indien gedeeld: systematisch resetten van data
		- Indien gedeeld: mogelijke interference van gelijktijdige tests
		  !TODO: Huud weet hier meer van

## Deliverables
- Branching strategie nieuwe repository/repositories (gelijk aan dev? > TODO Bart Staats vragen)
- Advies losstaande repository vs. geïntegreerde implementatie
	- Overzicht pro's/con's los framework vs verweven in dev modules
- Basisarchitectuur nieuw framework
	- Koppeling [[LivingDoc]] met actuele statusinformatie
	- Koppeling tussen [[Wiki]] en [[LivingDoc]]
	- Integratie met deployment pipeline(s)
	- Hergebruik IMXAgent 
		- Losse module van maken?
- Documentatie richtlijnen en template(s)
- Procedure testaanpak per nieuwe dev story
- Presentatie aan ontwikkelteams
- Inspraaksessies met dev teams

### Hoe rapporteren?
Volgend incheckmoment 

 Schetsen 2.0 framework
 > Tot 23 maart: voorbereiden tot hapklare US's. 
 > 23 maart - 13 april US meedraaien in refinements en strandups.
> 13 april demo van nieuwe plannen voor [[TAF]]; 14 april start nieuwe sprint.


## Tijdslijn
### Voorbereiding
- Nieuwe naam voor Framework.
- Evt. nieuwe repository met Main en Developement branching (Branching strategy opzetten).
	- Overdraagbaarheid framework: Maken we een los framework of komt het in dezelfde codebase (zitten de testen in de modules verweven? Hoe zit dan met de regressietesten die meerdere modulus moeten aanroepen (kleine keten)?
- Nieuwe [[TAF|TAF]] wordt [[1. Werk/2. Technische kennis/Languages/CS|C#]] ([[dotNET|.NET]]) met [[SpecFlow]] [[BDD]]. 
	- [[SpecFlow]] centraal in de architectuur; alles vloeit vanuit de [[US]]
- Herbruikbare delen [[Aegle|Aegle 1.0]] implementeren 
	- (vooral herbruikbaar: IMXAgent component, dat is de [[IMX]] bewerk-module). 
	- Losse projectmodule(s) van maken?
- Documentatie strategy opzetten voor het nieuwe [[TAF]]
	- Verschillende werkwijzes/uitbereidingen op framework, quick start guide en architectuur beschrijven. 
	- ([[Wiki]], borgen dat [[Wiki]] op juiste manier bijgewerkt wordt etc).
- [[LivingDoc]] koppelen aan daadwerkelijker testresultaten of runs, of releases (strategy of analyse voor doen, wat is er mogelijk?)
- Refactoring als onderdeel van ontwikkeling (korter op ontwikkelcyclus om grote refactoringen te voorkomen.

### Begin development
- Service accounts en authenticatie (opzetten zodra bekend is hoe de rollen en rechten ingericht etc.)
- Azure Agents voor runnen pipelines en testruns etc, mogelijk kan die zowel voor Aegle als voor [[NC]] op zelfde agents
- Meerdere modules met [[API]] Endpoints waarop wij met [[TAF]] moeten kunnen aansluiten en uitbouwen.
- Implementatie van testen
	- Smoketesten, systeem(integratie)testen, regressietesten  --- [[REST|REST API]]'s.
	- Wordt nieuwe epic met stories die door testteam opgepakt worden.
- Framework krijgt [[XML]] als input en moet die kunnen verwerken en een [[XML]] terug kunnen leveren (IMXAgent).
-   Mogelijke [[ArcGIS]] Server - Services om database queries etc te doen (aanvullende controles).
	- Mogelijk meerdere kleinere [[SQL]] databases 
		- Read only? Write?

### Later uitbouwen
- Portaal ([[GUI]]) wordt vrij laat opgeleverd, dus ondersteuning daarvan heeft geen haast.
	- [[Aegle|Aegle 1.0]] is met [[Selenium]] opgezet; voor nieuwe verhaal nog uitzoeken of we [[Selenium]] of iets anders willen gebruiken voor [[GUI]] testen (eventueel [[Playwright]] verkennen, [[Cypress]] (niet compatible is met [[1. Werk/2. Technische kennis/Languages/CS|C#]]; wordt FE ook in [[1. Werk/2. Technische kennis/Languages/CS|C#]]/[[dotNET]]?)).

## Overzicht mapstructuur
- Test
	- Features
	- Steps
	- 