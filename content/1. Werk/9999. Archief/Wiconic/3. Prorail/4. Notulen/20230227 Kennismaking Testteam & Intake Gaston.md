---
tags: Archief/ProRail
aliases: [Kennismaking Testteam & Bila Gaston, Kennismaking Testers, Intake Gaston]
---
# Kennismaking Testteam

Aanwezig: 
- Gaston Haagmans
- Bas Horneman (automation aanvulling, dev achtergrond, [[Aegle|Aegle 1.0]])
- Julia Kasainova (funct+auto tester, geluidsynthese achtergrond)
- Willeke Kort
Afwezig:
- Burhan Koçak (dev achtergrond, vooral automation)

note: collega Edwin beheert historische kostuums. :D

Sprintwissels op donderdagen. 
Elke maandag na de sprintwissel: meeting voor nieuwe sprint teststories inschatten en meedenken. 

---
# Intake Gaston
Eerste opzet taken: 
In DevOps project [[Opslag en Samenstellen]] taak voor opzetten [[TAF|TAF]]. > Verwerkt in [[Opzet Aegle 2.0]]

Branching strategie opzetten?
- Development
- Main (per sprint merge vanuit Dev). 

Gebruiken uit [[Aegle|Aegle 1.0]]: [[IMXAgent]] component. Framework krijgt [[XML]] als input en moet een [[XML]] terug kunnen leveren. 

Naam voor [[Aegle|Aegle 2.0]]? :P

[[Naiade Legacy]] gaat steeds verder modulair uitgebreid worden, met bijvoorbeeld meer modules die in [[API]]'s al wel werken maar nog geen [[FE]] hebben. 

Plan procesomschrijving voor werken met de [[TAF|TAF]]. 

Uiteindelijk 1 Portal met de [[GUI]]. 

Product: 
* [[Aegle]] 
	* [[1. Werk/2. Technische kennis/Languages/CS|C#]] & [[dotNET|.NET]]
	* [[SpecFlow]]
	* [[Selenium]]? 
	* [[LivingDoc]] (met [[SpecFlow]] en [[Azure DevOps]])

Plan:
* Smoke tests
* Regressietests (o.b.v. nieuwe specs in [[BDD]] opzet)
* Systeem integratie testen?
* Alles via [[REST|REST API]] calls
* Benaderen [[Database]] via [[ArcGIS]] server naar [[SQL]] database (queries uitvoeren via services) (nu ook in [[Aegle|Aegle 1.0]]) voor verwerkingscontrole (rechtstreeks SQL queries niet mogelijk)
* [[RestSharp|Rest#]] plugin voor [[REST]] calls in [[1. Werk/2. Technische kennis/Languages/CS|C#]]?
* Als het goed is: straks zelfde [[BDD]] input als devs voor test stories. 
* 3 amigo --> Requirements workshop
* Documentatie en handleiding [[TAF|TAF]] werkwijzen/aanpakken voor uitbreiden en globale architectuur actief bijhouden. ([[Wiki]])
* Direct refactoring als deel van ontwikkelcyclus om grote refactoring achterstand te voorkomen. 

Momenteel ook:
* Azure agents voeren pipelines en testruns uit. 
- [[Naiade Legacy]] heeft een service account met perma-wachtwoord hiervoor; die zou ook de 2.0 pipelines en testruns kunnen doen. 

Einddoel van [[TAF|TAF]] is dat het hele pakket in beheer van [[ProRail]] kan komen en ze het zelf verder kunnen bijhouden. 

! 'product' wiki met branching en pull requests, ook een main/development divisie. 

[[LivingDoc]] koppelen aan daadwerkelijke testresultaten. 

----

## Werkschema 
Di - "AHL" (Daar zit ook Operation Control vanuit [[ProRail]], [[Arriva]] en [[NS]]) op de 5e verdieping 
	Architectuur/ontwerp overleg elke di-ochtend over de hoog-over plannen. 
Do - "Inktpot" (variabele seating)
Testers vrij weinig aanwezig, maar ontwikkelaars (juist) wel. 
ma-mid 14:00-14:30 bijpraten met Gaston
wo-och 10:00-10:30 bijpraten met Gaston