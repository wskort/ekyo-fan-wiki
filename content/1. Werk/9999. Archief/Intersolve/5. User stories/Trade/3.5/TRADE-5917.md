---
tags:
  - Archief/Intersolve
  - Work/UserStory
aliases:
  - Als ProductOwner wil ik orderdata verwijderen
  - Als ProductOwner wil ik orderdata verwijderen (TRADE-5917)
software: "[[Trade]]"
---
# [TRADE-5917](https://support.intersolve.nl/browse/TRADE-5917) Als ProductOwner wil ik orderdata verwijderen
Gaat over [[Trade]].
## Criteria
Nieuwe verwijder functionaliteit voor orders
- Creëer opschoonactie-record
	- Orderdatum t/m
		- Extra controle (GUI en save flow) dat orders met orderdatum die ligt ~~voor~~ ***na*** een instelbare threshold periode (constante) niet verwijderd mogen worden 
		  ![[Trade-5917 eerst mogelijke datum.png]]
	- Y/N: particuliere klant verwijderen als er geen orders & archived orders meer zijn
		- Webshop account wordt mee verwijderd
	- Y/N: zakelijke klant verwijderen als er geen orders & archived orders & transacties meer zijn
		- Optie niet tonen als [[BuyerAPI]] account gekoppeld & actief is (zie andere story)
		- Klant wordt niet verwijderd als er een [[BuyerAPI]] account gekoppeld is
	- Verplicht filter toepassen op zakelijk en/of particuliere klanten
	  ![[Pasted image 20230908144445.png]]
	- Optioneel filter aanmaakdatum klant
	- Status checkfilter met multi-checklist. 
		- Minstens één status moet geselecteerd zijn
		  ![[Pasted image 20230908104256.png]]
		- ~~Alle statussen zijn beschikbaar~~ Alle geconfigureerde statussen zijn beschikbaar (admin > systeembeheer > systeeminstellingen > data opschoning)
- Opschoonactie in db vastleggen met timestamp en gebruiker
- Nacht na opschoonactie aanmaken worden in batch orders gekoppeld aan de opschoonactie
- Opschoonactie heeft status
	- Nieuw
	- Aangevraagd
	- Goedgekeurd
	- Data verwijderd
	- Afgewezen
- Bij elke statuswijziging wordt tijdstip gelogd. 
- Elke wijziging van de opschoonactie wordt ook vastgelegd in de auditlog
- Goedkeuring moet door andere gebruiker (vgl anonimisatie)
- Na goedkeuring is een instelbare grace period 
	- Tijdens grace period kunnen alleen Intersolve Beheerder en Intersolve Customer Support nog annuleren (onder Beheer > Data opschoning)
	  ![[Trade-5917 Admin wijzigen orderbeheer verzoek.png]]
	  ![[Trade-5917 Cancelled by Intersolve on request of Product Owner.png]]
	- Na grace period worden de records definitief verwijderd in nachtelijke batch. > Status=Data verwijderd.
- Rol ProductOwner/Customer support (FunctioneelBeheerderProducteigenaar/CustomersupportIntersolve) krijgt een overzicht van opschoonacties (menu Opschoning). Hierin staan ook de acties van reeds verwijderde orders (historie). 

Out of scope:
- Geen check op expiratiedatum kaarten
- Geen extra export functionaliteit voor te-verwijderen-orders
- Geen opschoonacties via de API

Te verwijderen records: 
- order,
- ordernote
- orderattachment
- orderedbyinfo
- ordersurcharge
- downloadlink
- orderproduct (=orderregel)
- cardimage (orderproduct)
- attachment (orderproduct)
- bulkfile (orderproduct)
- orderlineactivateschedule
- statushistory
- tracktracedata
- card
- Fulfillmentpickup
- ReportExport
- WebserviceRequest
- PDFOrderCheck

- privatecustomer
- addressusage (privatecustomer)
- commission (privatecustomer)
- businesscustomer
- addressusage (businesscustomer)
- commission (businesscustomer)
- customerdocument (businesscustomer)
- contactperson
- retailchain

## Aanpak

Export data voor en na verwijdering, want met een [[Mendix]] applicatie kan je niet rechtstreeks de database inzien of aanpassen.

Batch events forceren kan hier: 
`Systeembeheerder` > `Conversies&Data Mngmt.` > `ScheduledEvents Forceren`

Let op!! De versie met deze functionaliteit (3.5) staat nog niet op test

grace period staat op 1 dag
delete threshold staat op 1 dag (order is niet vandaag aangemaakt)
