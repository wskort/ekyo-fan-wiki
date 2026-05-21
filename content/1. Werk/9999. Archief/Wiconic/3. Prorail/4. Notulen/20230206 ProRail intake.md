---
tags:
  - Archief/ProRail
  - Archief/Wiconic
  - Work/Intakes
aliases:
  - ProRail intake
---
# ProRail intake
Huud - Product owner
	21y prorail, dev > Naiade > NISI hulp gevraagd > Wiconic [[1. Werk/2. Technische kennis/Test (automatisering)/TA]] opzet. (good! :D) > Dagelijks operational issue overleg kon gestopt worden. <:D 
Gaston - Operational testlead 
	Na Java training gestart als funct. tester bij Naiade, meer vertechnischd bij de opzet van Aegle.
	4,5y Naiade met steeds nieuwe uitdagingen, grote regressieset handmatig (bluehh) omgezet naar automated set met meer verschillende testcases per keer, code induiken, meer bugs opsporen, etc etc. Deel van [[1. Werk/2. Technische kennis/Test (automatisering)/TA]] inrichten & onderhouden, af en toe beetje uitbreiden. 
		[[BDD]] met [[SpecFlow]] test strategie verder uitbouwen en ook devs meer in meetrekken. 

-----

[[Naiade Legacy|Naiade 1.0]] monoliet met weinig aanpassingsruimte, veel afhankelijkheden. 
[[Naiade Legacy|Naiade 2.0]] nieuwbouw nieuw project :D 
* Met nieuwe [[Aegle]]
	* Verweven in [[Naiade Legacy]] codebase of los? Hoe gaat die infrastructuur/architectuur werken? 
	* Aparte release tracks per module. 
		* DOCUMENTATIE
- Opgedeeld in modules
	- Verdeeld over kleine ontwikkelteams
- Ook modulair & volledig getest
- Ook 1.0 werkend houden
- Nieuw framework met veel van dezelfde components maar andere interactiewijze
- Team met 3 testers onder zich. 
- 2.0 nog in architectuur fase. 
- Traject gaat langzaam op gang, backlog vullen gaat nu stroef, Epics & Features zijn er maar US nog niet. 
	- Servers inrichten, opzetten, etc. 
	- Uitvoerende [[VM]]s hergebruiken? Hebben zelf geen uitvoerende software, die doen wat de pipelines zeggen. 
		- Dev rechten op de testserver?

RAPPORT: Naiade 1.0 kan ERTMS niet aan. Punt. ZSM voor de 7 ERTMS trajecten dekkend Naiade 2.0 uitwerken. 
- Liefst kan 2.0 per direct beginnen
- [[US]] is pas ready met Scenario's uitgewerkt (Given When Then). 
- 1.0 grotendeels bevroren (maintenance mode)
	- Moet nieuwe releases nog regressietest op kunnen doen. 
- [[API]] opzet nog onbekend
- [[IMX]] Agent hergebruiken
- UI/UX traject met nieuwe [[FE]] plannen: dus UI tests kunnen van de grond op herstart worden
	- [[Playwright]]? Is inmiddels mature genoeg. vs [[Selenium]]. 
- (nieuwe) Coding standards binnen Aegle; unit tests worden uitgevoerd en moeten slagen per build. 

Nu 1 centraal testteam, gaat mogelijk uitgesplitst worden over de verschillende ontwikkelteams, maar misschien ook niet. Huidig idee: Given When Then ook al op Dev gebied, en dan als test-team er achteraan. 

[[Naiade Legacy]] en [[Aegle]]
Data driven applicatie met FE bap, gevoerd door '[[IMX]]' ([[XML]]) bestand. 
Ontwerpers kunnen deel van het spoornet oppakken, vormgeven en uitwerken. [[Naiade Legacy]] valideert dit ontwerp ten opzichte van hele landschap. 
- Project met objecten (spoorobjecten, rails, schakels, slagbomen). 
Ingenieurs sturen een current-future plaat ter acceptatie, waar ook weer allerlei systemen naar kijken om hun huidige stand van zake plaat te updaten. 

Testframework grotendeels aan de grondslag van enerzijds oplossen van issues en anderzijds vastleggen waar issues in de keten ontstaan. 

Er is nu (eindelijk) goedkeuring om de monoliet te gaan lostrekken naar aparte, beheerbare blokken. Wordt in eerste instantie los gebouwd naast de live systemen. I/O blijft gelijk. 

Angular.js met [[TypeScript]] frontend, [[dotNET|.NET]] framework, mogelijk omzet naar [[dotNET|.NET]] core backend. Draait on-premise. 

Workflow & bugtracking in [[Azure DevOps]], gebruik van [[Azure TestPlans]]. Strak afgebakend door [[MS|Microsoft]] guidelines om te werken, look into that. 

Aegle doet een beetje [[UI]] testing met [[Selenium]] met een facade ertussen. `null`-webelement pattern. Single page applicatie met variant object model. 

[[BDD]] met [[SpecFlow]] feature files. Per testrun wordt VM deployed en gerund. 
[[RestSharp|Rest#]] (sluit aan op C#) library voor [[API]] calls. 

[[XML]]s 'wasbord' bestand genereren in Aegle met module die 'donor' bestanden waar stukjes uit gejat kunnen worden, met een versie-onafhankelijke mix aan bruikbare componenten. 

Voor [[NC|Naiade 2]] wordt ook [[Aegle|Aegle 2.0]] neergezet met waar toepasselijk lenen van 1.0. 
- Poging tot visual testing door Isa doorgezet, nu op laag pitje (probably). 

Isa heeft vooral geholpen met uitbreiden van Naiade 1.0.  [[NC|Naiade 2]] staat nu in de startblokken. Gros van de effort zal zitten in het opzetten en uitwerken van dit nieuwe systeem. Er komt ook maatwerk training voor engineers over [[BDD]]. Hooguit een maand overlap. Startdatum wsl 6 maart. 

--------
[[InTraffic]] = [[PRL]]

