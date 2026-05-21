---
tags:
  - Archief/Intersolve
software:
  - "[[Financials]]"
team: "[[Bluetale]]"
---

isRemote: true  betekent dat de data in de applicatie (frontend) read-only is. 


---
Trade maakt een order aan, op basis van ordernummer, wat direct kan worden omgezet in:
- debetfactuur (invoice)
- creditfactuur (creditinvoice)
- offerte (quote)
Als je een order instuurt *zonder* invoice/creditinvoice/quotesync opdracht, dan wordt het geparkeerd als een periodieke invoice (debet). 

Een invoiced order kun je ophalen met invoicenr, niet meer met ordernr. 
\
Orders zijn 'vergankelijke' gegevens; je kunt hem niet aanpassen maar wel in het geheel overschrijven wanneer er een nieuwe orderstatus is. Dus POST over POST heen op hetzelfde ordernr. Ook om regels toe te voegen of wijzigen stuur je het *gehele* order opnieuw. 