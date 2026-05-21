---
tags: Archief/ECT
---
Het release proces voor het live zetten van nieuwe functionaliteiten gaat als volgt: 

1. Elke story bevat een "live" taak. Hierin staat vermeld welke releases er live moeten voor de story. Als hier iets met "Oracle views" in staat, moeten er nog een aantal extra stappen doorlopen worden, zie kopje "Uitrollen Oracle view". Zo niet, kun je door naar stap 2. 
2. Als één van de volgende dingen gewijzigd is, zet dan daarbij ook de rest van die groep live: 
::: mermaid
 graph TD;
 A[OrderRelay-AzureCloud] --> B[OrderRelay-Function];
 B --> A;
 C[API-MyTerminal] --> D[MyTerminal-AzureFunctions];
 D --> E[MyTerminal-Functions];
 E --> C;
 F[API-Profiles] --> G[API-Profiles-Functions];
 G --> F;
:::
 
3. Als er alleen een kleine frontend wijziging is, hoeft er geen aanvraag te worden gedaan en kun je door naar stap 5. Ook voor hotfixes met spoed kun je door naar stap 5. 
4. De release dient aangevraagd te worden door Application Services. Hiervoor kun je bij Sven van der Voorn of Jeroen Struijk terecht. In de aanvraag meld je om welke releases het gaat en welke stories daarbij horen, inclusief de link naar Azure DevOps. Een release aanvraag kan er bijvoorbeeld zo uitzien: 

```
Stories: 
- [User Story 15917](https://dev.azure.com/ectteam/Phoenix/_workitems/edit/15917): Verwijderen objecten - Tracked Objects

Releases:
- MyTerminal FE
- MyTerminal API

Views:
- VWDPS_API_CS.V_CONTSTATUS
```

5. Controleer of er in de release met de juiste code nog andere commits zitten die niet live moeten. Hiervoor kun je desgewenst een moment inplannen met het ontwikkelteam om de mogelijke risico's van meegenomen wijzigingen door te nemen. 
6. Deploy de benodigde release naar de Acceptatie-omgeving en controleer of de automatische testen slagen.
7. Afhankelijk van de complexiteit van de release kun je een moment inplannen om met het ontwikkelteam de mogelijke risico's van de release door te nemen. Bij een verwachte eenvoudige release kan de software in één keer door naar productie. 
8. Voer de livegang naar productie uit in samengang met eventuele Oracle wijzigingen, en controleer ook hier of de automatische testen slagen. 
9. Koppel terug aan Application Services wanneer de livegang is voltooid. 
10. Zet tenslotte een kopie van de release aanvraag in MS Teams - MyTerminal - General met de boodschap dat deze release zojuist live is gegaan. 

# Uitrollen met wijzigingen in Oracle views
1. Achterhaal welke views er gewijzigd moeten worden. Je kunt dit met de ontwikkelaar bespreken of kijken naar de commits die gedaan zijn en bij de story horen. Als hier .sql bestanden in zitten, zijn die de viewdefinities die live moeten. Download de viewdefinitie en geef het bestand een naam met UPGRADE erin, zodat je weet dat dit het upgrade script is. 
2. Bekijk welke view er nu live staat op de productieomgeving. Dit kan in Azure DevOps door in de history van de te wijzigen views te kijken, of door de view op te zoeken in de Oracle omgeving van P9DIGAGE. Download de viewdefinitie als .sql bestand en geef het bestand een naam met ROLLBACK erin. 
3. Controleer dat zowel de upgrade als rollback scripts beginnen met `CREATE OR UPDATE`.
4. Lever de upgrade en rollback scripts aan bij iemand van het UDV team en vraag of het upgrade script uitgevoerd kan worden op A5DIGAGE. 
5. Deploy de benodigde release naar de Acceptatie-omgeving en controleer of de automatische testen slagen. Om zeker te weten dat de view juist is uitgerold, zou je nog een handmatige test kunnen uitvoeren voor de nieuwe functionaliteit die afhankelijk is van de viewwijziging. 
6. Stem met het ontwikkelteam af of de volgorde van uitrol views en software van belang is. Als er bijvoorbeeld een kolom aan de view is toegevoegd, kun je beter eerst de view uitrollen en dan pas de software. 
7. Stem met UDV af wanneer de release kan plaatsvinden. 

UDV-team: Fred Odijk, Marson Valks. 