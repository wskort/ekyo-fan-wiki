---
aliases:
  - NVWA (Nederlandse Voedsel- en Warenautoriteit)
tags:
  - Archief/Wiconic
  - Archief/NVWA
  - Work/Intakes
---
[[Wiconic]] [[NVWA]]
# Nederlandse Voedsel- en Warenautoriteit (NVWA) 
## Aanvraag
Inrichten van automatisch testen met behulp van de tool fitnesse voor de applicatie [[e-CertNL]] en daarbinnen specifiek de wijzigingen voor het project [[rVDM|rVDM (realtime Vervoer Dierlijke Mestsoorten)]] (Nationale mest transporten). Er zijn drie gebruikers van het automatisch testen, elk vanuit een ander aspect:
- Het verder ontwikkelen van de technische testen door het [[DevOps]] Team (1).
- Uitbreiden van de functionaliteiten die automatisch technisch getest worden in de [[rVDM]] flows. Installatie van automatische testen ook op de schaduwdraai omgeving. Dit zorgt ervoor dat deze omgeving goed blijft functioneren na wijzigingen. Daarmee kan, na een nieuwe oplevering, automatisch getest worden of het systeem zich nog gedraagt zoals verwacht.
- Snellere identificatie van fouten in de database. Direct testen op de database, een check of de business rules goed gevolgd worden.
- Inzicht hoe het systeem zich gedraagt bij belasting, nader af te stemmen met [[DICTU|DICTU (Dienst ICT Uitvoering)]] (zij zijn ook bezig met een aanpak m.b.t. performance testen). Uitvoeren van performance testen met duizenden gebruikers tegelijk. Voorbeelden daarvan zijn hoe snel de gebruiker van tabblad naar tabblad kan gaan of hoe lang een intensieve transactie duurt.
- Het testen of de juiste content (vulling) aanwezig is en voldoet aan vooraf gestelde eisen, inclusief de bijbehorende invoercontroles. Dit wordt uitgevoerd door het contentteam (2).
- Het ontwikkelen van functionele testen: de huidige testbeschrijvingen van de regressietestset van het [[rVDM]] test team worden omgezet naar automatische tests en geactualiseerd indien nodig op initiatief van het [[rVDM]] testteam (3).
- De keuze van de geautomatiseerde functionele testgevallen zijn gebaseerd op de requirements en zijn vastgelegd in de testdocumentatie van het [[rVDM]] testteam en worden bepaald op basis van stabiliteit en niet gewijzigde functionaliteit. De implementatie zal beginnen met de happy flow van het hoofdspoor-proces en met de tijd uitgebreid worden naar alternatieve scenario’s en maatwerkvervoer.
- Het [[rVDM]] test team hoeft minder regressietests door te voeren en kan zich meer focussen op de aanpassingen: van de requirements, het systeem of opleveringen van nieuwe functionaliteiten.
- Door de testautomatisering kan snel worden vastgesteld of een oplevering geen degradatie van functionaliteit in zich heeft. (testen niet gewijzigde software, akkoord bevonden in vorige oplevering).

Veel nieuwe systemen zijn momenteel opgebouwd uit bouwstenen of zijn standaardapplicaties waarvan de parameters zodanig zijn ingesteld dat de standaardapplicatie geschikt wordt gemaakt voor een specifieke situatie. De betrokkenheid van (eind)gebruikers en de wijze van testen zijn hierop aangepast. Daarnaast is door de invoering van [[SCRUM|Agile Scrum]] en [[TDD|TDD (Test-Driven Development)]] veel meer de nadruk komen te liggen op zoveel mogelijk geautomatiseerde testen door de systemen zelf. De laatste ontwikkelingen in testmanagement liggen op het vlak van testengineering.

## Pre-intake
*Wouter van As & Wijnand Wolfis, SimSolutions*

Intern devops team voor applicatie voor inspectieondersteuning

[[e-CertNL]] is de applicatie voor certificering van landbouwproducten voor export. 24/7 gebruikte applicatie. 

[[Java]], Oracle Apex, PostGres?

[[FitNesse]], moeilijk in te vullen (eerder stuk gelopen op geen recente ervaring)

Het gesprek wordt met Johan (scrummaster) + 2 testers en actief FitNesse script doorwerken. 

## Intake
- Testmanager Cor Kingma
- Tester & automatiseerder Ying Wai (nadruk [[rVDM]])

Testteam achter 4 devops teams met synchrone sprints, testcyclus loopt 1 week achteraan vanwege acceptatie omgeving updates. 

Fosfaat & stikstof boekhouding, mestproductie van vee via leverancier naar afnemer moet geregistreerd worden ivm wetgeving (pending). 

Veel requirements nog in beweging want wet nog niet definitief. 

33 soorten mest die geregistreerd worden (fluctuerend tot stabiele samenstelling). 
Geautomatiseerde vrachtwagens die zichzelf wegen en meten. 

miljoen transporten per jaar, vooral hoofdspoor, rest maatwerkvervoer. 5 a 6 soorten. Bijvoorbeeld meerdere ritten om bulk transport te doen, of juist simpeler vervoer voor 'boer-tot-boer'. (grenspercelen e.d.)
14 processtappen van vooraanmelding transport 
- mestsoort(en) (max 4/mix)
- transportsoort(en)
- controles
- vrachtwagen 
	- moment van laden 
	- monster(s) afname voor lab
	- gps
	- timestamp
	- weging
	- losbericht
	- bevestiging afnemer
- Overdracht van NVWA naar RVO 
- Tonen aan geautoriseerde gebruikers

Webschermen, pakketbouwers ([[BMS|BMS (Bedrijfsmanagementsysteem)]]) 

Progressive webapps met wrappers voor de app (web-based). 


Schaduwdraaien met eindgebruikers en feedback daar. 

DevOps zit in Jira, werken zelf in Excel. 