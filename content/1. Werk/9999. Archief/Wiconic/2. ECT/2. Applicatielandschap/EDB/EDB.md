---
aliases: [EDB (Enterprise DataBase), Enterprise Database]
tags: Archief/ECT
---
# Enterprise Database (EDB)

hangt samen met 
`V_EDBLG_*` in de [[ECT Databases]]

Voor livezetten moet er gecoördineerd worden met [[UDV]] zodat de API's niet omvallen. 

- Customs (documents)
- Logistics (containers)
- Bookings
- Objecten
- CID = order administration

(zoiets? later uitwerken want volgens mij klopt de verdeling niet helemaal)

Fun fact: owner "UNK" = unknown

## Oracle Database testing
[Walkthrough for connecting ODB to Cypress](https://developers.ascendcorp.com/connecting-oracle-database-in-cypress-project-cbcd3bfabdbd) 

Note: the incoming data does *not* come over an API, but is inserted directly into a staging area table. So to mock this, we'll need
* An environment that is *not* mirroring production data, flooding the input
* Direct database inserts into the staging area ([[SAEDB|SAEDB (Staging Area EDB)]])

## EDB Logistics
### Priority matrix
For each column, determine which data source is most reliable and therefore takes precedence when multiple sources are available. It consists of 6 tables, defining all the colums, data sources, which data sources have which information, and then how much priority that specific source has, what to do with `null` information and whether that counts as reliable, etc. 

#### Update schedule
When a system detects a specific container being changed, the `contnr` is added to `cont4update` to be picked up by a process that runs every 10 seconds to update all the data for those specific containers (and then removes them from the list). 

#### Example order of trust
LHG = Logistics handling = [[TOS|TOS (Terminal Operating System)]]
ACO = acceptance order
PUO = pick-up order
RLO = release order
CSM = customs document system

#### Reference tables
ADT = change history
SRC = per column, which source has been used (in accordance with priority matrix). 

### Data streams
#### Logistics handling
- Container action
	- Registration
	- Arrival
		- can be deleted (paperwork missing, come back later!)
	- Move
	- Change 
		- full/empty
		- Renumber (manual error correction, happens about 1/hour)
		- Destination
	- Departure
		- can be deleted (oh look, it's still here!)
	- (Un)block container (should be moved to CID in future, but currently stored in TOS)
	- Booking (difference in plan based on real-time information; shown in addition to original info so user can decide for themselves)

#### Enterprise Order Administration (CID)
* LogisticOrder
	* Arrival
		* Discharge order (deepsea & feeder) (large contracts that mean that the terminal will take whatever they bring)
		* Delivery order (barge, rail, truck) (each delivery must match an acceptance order or [[ESA|ESA (Empty Storage Agreement)]])
	* Departure
		* Load order (deepsea & feeder)
		* Pickup order (barge, rail, truck)
* Control
	* Acceptance (we intend to collect this container)
	* Release (you are allowed to collect this container)
	* [[ESA|ESA (Empty Storage Agreement)]]  (here is an empty box for whoever)
* Stowage
	* Layout of the ship's loadout. Received from previous port and/or passed to next port. 
		* Remain on board
		* Shift (move aside to grab other container)
		* Restow (take off then put back later)
* VGM = Verified Gross Mass 
* Voyage information
	* Scheduled visits (excl. trucks)
		* Partner visit with *own* voyage number (matching their administration)
		* Call reference number from port authority (customs)
			* `NLRTM22.....` NL + Rotterdam + year + number
		* ECT internal reference
		* Call sign (license plate) 

! Main operator is ship operator, partner operators piggy-back with their own containers. 

Transhipment = ship to ship transfer. 

##### Booking status
| Nr  | Size | Orders | Operator | ship_visit    | 
| --- | ---- | ------ | -------- | ------------- | 
| ABC | 40'  | 5      | DCD      | Evergiven 12w |
| ABC | 20'  | 3      | DCD      |               |
* How many known, announced, arrived, etc
* Out of Gauge (container steekt uit van de basismaat)
* Dangerous goods
* Damaged container
* How will it get here (modality, id, etc)

Updated when one of the containers is altered. (so based on contstatus updating, the matching bookingnumber gets flagged for update as well)

A container can have different arrival/departure bookings, but we are not the booking office; we need the bookingnumber for export containers but don't care for import containers; then acceptance orders are what's important. 

Booking info comes from the container operator. 

#### SAEDBLOGORDER
Realtime copy of CID `EDBLOGORDER`  so it can be queries within EDB without needing to connect to external database every time. CID pushes updates when there are changes. 
Updates are temporarily paused when recompiling or it will keep getting overwritten. 

#### [[ECS|Export Customs System]] 
Een van de bronsystemen van [[EDB|EDB (Enterprise DataBase)]]. Dit is het bronsysteem van waaruit [[Export]] gegevens over containers worden ingezonden. Containernummers, documentnummers, documenttypes, etc. 

#### [[MRN|Master Reference Number]]
> (Import) documenten administratie.

Een van de bronsystemen van [[EDB|EDB (Enterprise DataBase)]]. Dit is het bronsysteem van waaruit [[Import]] gegevens over containers worden ingezonden. Containernummers, documentnummers, documenttypes, etc. 


-----

## EDB Objects
### Data model
KlantOrders van [[EOA|EOA (Enterprise Order Administratie)]], Planning en Uitvoering van [[TOS|Express]]. 
![[ECT EDB.png]]
| View     | Table                                          | Data               | Notes                                                                                                                      |
| -------- | ---------------------------------------------- | ------------------ | -------------------------------------------------------------------------------------------------------------------------- |
| Operator | ScheduledMeansOfTransportOperatorVisit         | ETA, ETD           | Vooraanmelding van geplande reis, waar ze willen aanmeren, waar ze daarna heen willen, etc. (operatorid = vessel operator) |
| Operator | /ScheduledMeansOfTransportPartnerOperatorVisit | Lostijdvoorspeller | per partner, wat zij vervolgens weten/vinden van de containers op in die visit (operatorid = container operator)           |
| ECT plan | PlannedMeansOfTransportVisit                   | PlTA, PlTD         | Delta's plan for receiving the visit                                                                                       |
| ECT plan | /PlannedMeansOfTransportTerminalVisit          | PlTA, PlTD         | per subterminal                                                                                                            |
| Reality  | ActualMeansOfTransportVisit                    | ATA, ATD           | actual data log                                                                                                            |
| Reality  | /ActualMeansOfTransportTerminalVisit           | ATA, ATD           | per subterminal                                                                                                            |

PartnerOperators send discharge & load orders (logistics orders) from [[Coprar]] (rederij/feeder) or delivery & pickup orders [[Copino]] (rail/barge/truck). [[CID]] processes these for EDB. 
ControlOrder: Delivery orders must match Acceptance orders in a booking. Pickup orders must match Release orders in a booking. Discharge & load orders do not need control orders. 


Evergreen has a vessel, and announces it. 
The vessel has several partner operators, they are the container operators and they are ECT's customers. 
For each container, the *container operator= paying customer of ECT* sends a discharge order for each container that needs to leave the ship, and a load order for each container that needs to be collected. A partner that is not a container operator, like a feeder operator, behaves like the hinterland operator. 
Hinterland operators come to help. They are not ECT's customers. 
For each container that they bring to be loaded onto the vessel, they send a delivery order to bring it to the terminal. For each container that they are collecting after the vessel discharges it, they send a pickup order to get it from the terminal. 
The container operators must validate the delivery orders and pickup orders, by matching the delivery orders with acceptance orders and pickup orders and release orders. 
Delivery & acceptance order must match on booking number. 
Pickup & release order must match on release reference = pincode. 
Acceptance and release orders can only be sent by the container operator = paying customer.

Whenever *anyone* comes to bring or collect a container, they have to be a paying customer or a paying customer has to validate it. It is *not* based on whether it's deepsea or hinterland, but *purely* on whether they are a customer. 


----

Acceptance orders and bookings are *only* used in practice for the delivery of containers to our terminal. Once all containers are delivered to the terminal, the acceptance orders can be deleted. In CID, they are deleted as soon as the container arrives. The data is now in Express and can be read from there. But for MyTerminal, we still need that info. The container is now present in the bookingstatus, because it is matched to the booking status. 

There are three types of booking number:
1. Acceptance order (from CID)
2. Express (can override CID))
3. Loadlist (not for arrival but for departure)




---

Document in ECS unpublished gezet en later weer op published teruggezet: 
Documentnummer `22NLL6OZ51AKCCWD53` voor container `TLLU2569245`
| documentnummer     | containernummer | notities                       |
| ------------------ | --------------- | ------------------------------ |
| 22NLL6UKYSAY8PWD52 | TCNU7860798     | alle (un)published tijden leeg |
| 22NLL6OZ51AKCCWD53 | TLLU2569245     | alle (un)published tijden leeg |

Workflow ECS: published en unpublished kunnen allebei gevuld zijn; meest recente tijd is geldend. Dus een published later dan unpublished = (re)published. 



----
### EDB Bookings

Doorgerolde containers op basis van acceptance order waarop het oorspronkelijk is aangeleverd. 

* Indien dangerous, temp or out-of-gauge
* Total: aantal containers in acceptance order (som per size type)
* Known: o.b.v. acceptance order bekend contnr 
	* Is announced ook automatisch known of juist echt alleen via acceptance order?
* Announced: *gematchte* aanleveropdrachten worden getoond
* Gate-in: heeft een gate-in tijd. Het kan voorkomen dat deze niet een voormelding hebben, zijn ze dan automatisch voorgemeld door dat ze gate-in hebben?
	* Container is verkeerd genummerd, voormelding wordt automatisch hernummerd.
	* Overlos (surplus geleverd), wordt handmatig toegevoegd bij gate-in *maar heeft geen connectie met acceptance order* dus zou in *theorie* niet in deze booking getoond moeten worden?
	* Container wordt geleverd met totaal ander nummer zonder verdere uitleg, heeft geen bookingnr, wat nu?
* Ready: Coprar load = definitieve laadlijst voor vertrek. O.b.v. acceptance order, per container, als het *ergens* op een laadlijst staat, dan telt het. 
	* Andere containers op diezelfde laadlijst *maar niet voor dit acceptance order* worden hier NIET meegeteld. 
* Loaded: O.b.v. acceptance order, per container, als het *ergens* geladen is, dan telt het. (schip hoeft nog niet weg te zijn).
	* Als de laadtijd van de container (vertrektijd container, niet schip) wordt gewist, dan is de container *bij nader inzien* niet geladen en gaat de teller omlaag. 
	* Voor trucks: hoe krijgen die containers de status loaded? Want dat het op een truck ligt betekent nog niet dat de container met die truck weggaat, daar kan nog vanalles gebeuren totdat de truck daadwerkelijk met een container het terrein verlaat. 
	* Indien geladen *op een trein, barge of truck* dan is het niet geladen?

Continentaal/Domestic:
Wat dan? Wat gebeurt er met 'loaded' voor trein/barge/truck? Is dat hetzelfde scherm of wordt dat anders getoond? bv. 'loaded' is dan mogelijk niet de correcte kolomnaam, 'departed' is dan informatiever.

Stel: 
1. Alle containers in acceptance order hebben contnr. 
2. Voormelding van vervoerder heeft afwijkend contnr.
3. Zou dit een probleem zijn? Tonen we dit, en zo ja hoe?

Stel: 
1. Er zijn meer containers in aanleveropdracht (voormelding) dan in de acceptance order zijn aangekondigd. 
2. Willen we dit tonen, en zo ja hoe?
3. Gebeurt dit in de praktijk alleen voor specifieke soorten boekingen, of kan dit voor alle soorten boekingen voorkomen?
4. Moet het totaal in de acceptance order worden opgehoogd?

Stel: 
1. Container wordt geladen, maar wordt weer ontladen en is dus toch maar niet loaded. 

Stel: 
1. Vertrek wordt ontkend, dus vertrektijd wordt gewist. Is het nu toch maar niet loaded?

Bookingtypes: 
- met/zonder contnr in ac
- met/zonder imo
- met/zonder temp
- wel/niet al vertrokken
- wel/niet doorgerold (mismatch departureobject cont&booking)
- wel/niet toegevoegd via laadlijst (via laadlijst = geen acocontrolorder maar wel matching arrivalbookingnr)


Known: = alleen via ACCORDER bekend, wel geteld maar geen containerdetail tonen
Announced: = match met CONTROLORDER, nu wel containerdetail tonen (= release? of delivery?)



