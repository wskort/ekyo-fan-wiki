---
tags:
  - Archief/Intersolve
aliases: 
software:
  - "[[ConnectHub]]"
team: Portals
---
# Merchant database
Bereikbaar via [[SQL Server|SQL Server Management Studio]].
- Programma manager (bv. VVV)
	- Brand (b.v. VVVGiftCard) 
		- BrandType (b.v. diverse vaste waardes, 1 flexibele waarde)
			- Card is individuele token met geld, maar ook punten, vouchers, etc.
	- Asset kan aan meerdere BrandTypes toegewezen worden, met dingen als spaarpunten i.p.v. geld

* Merchant (Hele franchise met evt onderliggende franchised merchant)
	* Location
		* Point of Sales (kassa/terminal/etc.)

* Authorisation koppeling tussen Merchants en Brands. (oud)
* Authorisation group koppeling tussen Brands, Assets en Merchants, Locations, etc. (nieuw)

* Account treestructure in beheer van PM om locaties te beheren, locatie moet in PM's account-structuur hebben. 