---
tags:
  - Archief/Intersolve
aliases:
  - TRADE
team: Portals
---
# Trade
[[Mendix]] applicatie voor bulk orders van kadokaarten voor bijvoorbeeld kerstpakketten. Heeft (nog) geen [[1. Werk/2. Technische kennis/Test (automatisering)/TA|Testautomatisering]]. Database is [[Merchant]]. 

Webshops bestellen vaak via bijbehorende API zoals [[BuyerAPI]] hun verkochte kaarten, om deze naar hun klant(en) te kunnen sturen.

Bevat ook een facturatie module ([[EOS]]) die momenteel ook voor andere zaken gebruikt wordt, maar niet ideaal want extern beheerd en dubbele administratie. 

- Order
- Product (kan aan meerdere OrderProducten hangen)
	- Card (token)
- OrderProduct koppeltabel met orderregels

Uitgave na aanmaak via post (via [[API]] + fulfilment center, meestal vanuit card stock), email of batch

Praat met [[1. Werk/9999. Archief/Intersolve/1. Product/Transactions/TA|TA (Transaction Authorizer)]] om kaarten te issuen (creëren van tokens) of activeren (waarde op zetten) of blokkeren (vaak geblokkeerd tijdens postverzending, met activatiecode via ander kanaal of timed unblock *unless* interrupted)
	> plannen om dit batch-based te maken

Zoekfuncties zijn erg langzaam (10-12 seconden), en men start vaak meerdere searches tegelijk. Ook is er een 'sluiproute' om via de klant-tab gedeeltelijk zoeken te gebruiken om orders te vinden. Ook kunnen de SQL queries erg complex worden door (meerdere) beheerbare rollen op 1 account. Dat gaat al uit, dus dat zou moeten helpen. 

Nieuwe [[API]] om te verbinden met [[Connect]] toegevoegd, zodat [[1. Werk/9999. Archief/Intersolve/3. Organisatie/2. Intersolve Technologies/CS|CS]] niet in [[Trade]] hoeft te werken. 

Gekoppeld met [[FlowMailer]] voor bulk emailverzenden. Nu zit er een bottleneck in het genereren van [[PDF]] bestanden. Dit wordt beheerd in een [[PDF Hub]] met eigen status dashboard. 

-----
## Presentatie
### Platform overzicht
![[Platform overzicht.png]]

Waar de [[1. Werk/9999. Archief/Intersolve/1. Product/Transactions/TA|Transaction Authorizer]] alleen weet of een specifieke call over een specifieke token verwerkt mag worden. 

[[Trade]] heeft daadwerkelijk productinformatie (kaart, code, e-card, etc), klantinformatie, en werkt als winkelomgeving. 

Kadokaart flow kan worden geconfigureerd in [[Trade]]. Er zijn ook webshop integratie mogelijkheden, en er is een 'white label' bestelportaal om bulkorders aan te maken. Eventueel kan [[Trade]] ook de facturatie verwerken. 

Voor kaarten binnen [[Trade]] verkocht, kan er customer service worden uitgevoerd binnen [[Trade]]. Let op: kaarten die anders verkocht zijn, moeten via de helpdeskportal van de [[1. Werk/9999. Archief/Intersolve/1. Product/Transactions/TA|Transaction Authorizer]]. 

### Brands & Artikelen
![[Brands & Artikelen.png]]
In de 'brandtype' zijn de business rules vastgelegd, zoals value range, geldigheidsduur, deelverzilvering Y/N, etc.

Binnen [[Trade]] is er onderscheid tussen artikelen en producten. Per brandtype wordt automatisch een matching artikel aangemaakt. De onderliggende producten zijn vervolgens creatieve uitvoeringen van de artikelen, zoals fysieke en digitale varianten, andere ontwerpen, etc. 

### Gift card process flow
![[Gift card process flow.png]]

Happy flow:
0. Inactive > Activate & set value
1. Normal (active) > Purchase (balance above 0)
2. Normal (active) > Purchase (balance = 0)
3. Normal (redeemed)

Stel: je wilt een verlopen kaart verlengen, kan dat? Nee, dan moet er een nieuwe kaart uitgegeven worden. 

### Opbouw orders
![[opbouw orders.png]]

Voor een e-card is de 'verpakking' de bijbehorende HTML-template. 

ExtItemReference is een nummer dat gebruikt kan worden om een set items onder dezelfde order te scharen, zoals een gratis bonusproduct. 

#### Verwerkingsproces fysiek
![[orderverwerkingsproces.png]]

Fysieke orders staan een tijdje op 'in progress', omdat de specifieke kaartnummers door de fulfillment provider moeten worden aangeleverd om de bestelling te kunnen afronden. 

#### Verwerkingsproces e-cards
![[verwerkingsproces e-cards.png]]

Bij het aanmaken van een product in [[Trade]] moet worden ingesteld of de kaartnummers wel of niet vanuit de fulfillment provider moeten worden aangeleverd. 

Medewerker geslacht M/V/O

Rechten: 
- Functioneel Beheerder Producteigenaar
- Email Viewer
- Bulkbestand Verwerker

Uitgebreide handleiding, recente release notes en quick reference guides beschikbaar onder Support. 

## Trade platform

Product moet gekoppeld zijn aan een productcategorie. Vooral relevant bij website koppeling. 
Indien landen gedefiniëerd zijn, kunnen alleen klanten uit die landen geaccepteerd worden. 
Onder communicatietalen kunnen meerdere taalvarianten ingesteld worden. 
Email sjablonen (templates) gaat over 'transactionele' emails, die verzonden worden op een bepaald punt in het verwerkingsproces (niet de email delivery van de kaart zelf). Bijvoorbeeld nuttig is de orderbevestiging. Inhoud kan per geconfigureerde taal worden ingesteld. (displaynaam=afzender alias). Optionele tokens als klantnummer, ordernummer, etc. 

### Artikel instellingen
![[toon artikel.png]]

### Product instellingen
![[wijzig product.png]]

Let op: Voor aflevermethode=email moet altijd uitgifte=trade worden ingesteld 

### Product assortimenten
Hier kun je subgroepen maken en bijvoorbeeld instellen dat alle producten van restaurantketen A alleen binnen restaurantketen A mogen worden verkocht of verzilverd, zodat je dat niet per product hoeft te doen. 

### Verpakkingen en sjablonen
Een email-verpakking is effectief een template, voor de rest is een titel van de verpakking. ('geen verpakking' kan ook). 
In deze templates zijn ook content tokens beschikbaar, aanzienlijk meer dan in de procesmails. 
Bijlage opties: 
- geen
- mail als PDF
- apart PDF sjabloon