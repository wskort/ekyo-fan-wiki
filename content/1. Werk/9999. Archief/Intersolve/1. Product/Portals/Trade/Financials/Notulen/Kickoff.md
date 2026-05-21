---
tags:
  - Archief/Intersolve
team: "[[Bluetale]]"
software:
  - "[[Financials]]"
---
Veel schermen nog vanuit [[Trade]] met [[API]]-sync richting de nieuwe functionele module. 

Het stuk "financieel" voor facturen aanmaken en verwerken wordt uit [[Trade]] getrokken en apart gezet. Er is nu nog veel data duplicaat in [[Trade]] en [[Financials]]. [[Financials]] moet straks onafhankelijk kunnen draaien met eigen datamodellen, zodat er een andere bron of zelfstandige unit gebruikt kan worden voor facturering van niet alleen Trade. 

Data wordt overgehaald met [[API]]'s, vooral [[REST|REST API]] en een beetje [[oData]]. Data wordt (voorlopig) as needed opgehaald uit Trade. 

Product Owners / Klanten / Inrichtingen met [[NAWT]]-achtige berichten, deels ook nodig in [[Financials]]. Instellingenkaart heeft ook een tab Financieel waarvan diverse gegevens nodig zijn voor [[Financials]]. 

[[SSO|SSO (Single Sign-On)]] ('app to app switching') bij klikken op logo. (nog geen echte [[SSO]] via b.v. [[AD|AD (Active Directory)]].) 

Users ook overhalen naar [[Financials]]. 

Voorlopig wordt alle data beheerd in [[Trade]] en kan dit niet in [[Financials]] aangepast worden. In [[Financials]] wordt data aangemerkt als extern of intern (extern = read only). 

Via [[SFTP]] worden transacties in nachtproces binnengehaald en verwerkt. Meenemen naar [[Financials]] en dan het export/import proces aanpassen zodat we b.v. rechtstreeks in data warehouse kunnen kijken voor relevante data ipv alles exporteren en importeren. 

Orders in [[Trade]] worden direct bij aanmaken verstuurd naar [[Financials]]; dit verdeelt ook de load beter. Er zijn hierbij retry-mechanismes van toepassing indien [[Financials]] tijdelijk uitstaat, of records kunnen direct in de log gezet worden om als queue te gebruiken. Idealiter vrijwel alles asynchroon laten draaien zodat [[Trade]] nooit hoeft te wachten op data synchronisatie, factuur generatie, etc. 


Nu: Per inrichting een administratie
Doel: meerdere inrichtingen voor klant(onderdelen) met 1 achterliggende administratie. Dus niet gelijk aan een werkomgeving maar een data-situatie. 

Trade "management" api gaat trade api heten, en "governance" api gaat management api heten. En hier hebben we dan de [[Financials Management API]]. 