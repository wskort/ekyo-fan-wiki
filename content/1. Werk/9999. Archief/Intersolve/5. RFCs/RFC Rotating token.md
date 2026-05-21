---
tags:
  - Archief/Intersolve
software:
  - "[[Connect]]"
  - "[[ConnectHub]]"
  - "[[RTS|Rotating Token Store (RTS)]]"
---
De rotating tokens en [[RTS|Rotating Token Store (RTS)]] zijn ontwikkeld door het [[Transactions team]]; wij voegen hier de benodigde schermen aan toe. 

Onder brands / brandtypes / detail komt een tab "Beveiliging" met een vinkje "Dynamisch" voor wel/niet rotating token gebruiken. 

Daarbij is ook in te stellen:
- Hoeveel rotating tokens tegelijk? (bv 2e voor partner)
- Interval (sec)? (hoe vaak verversen) (wsl valideren tegen ISO8601 standaard format)
- Algoritme: SHA1/SHA256/SHA512 (enum)
- checkbox: original allowed (werkt de vaste pas met oude prefix nog?)
- Aantal dynamische tekens: bv 2 (vaste ID + *x* rotating tekens)
- Prefix: bv "01"

Nieuw: de tab, het tonen, het editen. Informatie wordt pas opgehaald bij openen tab (dus indien tab niet actief, data niet verzonden)

Voor eindgebruikers: niet zichtbaar of editbaar. Alle Intersolve medewerkers mogen dit zien (admin, support & config). Alleen Intersolve administrators(+edit) mogen dit editen. 

Brand prefix + brandtype prefix + vast nummer
Brand prefix + dynamic brandtype prefix + vast nummer + rotating symbols
--> moet vervolgens binnen max lengte passen. 

de volledige prefix moet uniek zijn, anders komt er een waarschuwing (niet blokkerend)

Indien RTS een fout geeft, dan geeft ConnectHub een 500. 

----

Authorized call met extra info: 
- brand type key
- supports rotating tokens y/n
- is rotating token y/n