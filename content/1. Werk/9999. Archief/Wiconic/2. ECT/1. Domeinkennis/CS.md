---
aliases: [ContainerStatus (CS), ContainerStatus]
tags: Archief/ECT
---
# Container Status
Wordt opgehaald uit [[EDB]].

## Hinterland doelgoep
### Known
Alleen ordertype aanwezig:
Import Tab
Release order: Only release present
[[Copino|Copino Pickup]]: Only pre-announcement present
[[Coprar|Coprar Discharge]]: NIET TONEN (omdat expected)
[[Baplie]]: NIET TONEN (omdat expected)

## Rederij doelgroep
### Known
MyContainers
Release order: Tonen dat er alleen een release aanwezig is, de beschikbare velden vullen in MyContainers (let op: Uitsplitsing in Import Release aanwezig en Release on loadlist, in kolommen en in container detail)
Status: Niet gevuld in MyContainers (Want is nog niet expected, is slechts known)
[[Copino|Copino Pickup]]: Tonen dat er alleen een pre-announcement is, de beschikbare velden vullen in MyContainers
Status: Niet gevuld in MyContainers
[[Copino|Copino Delivery]]: De beschikbare velden vullen in MyContainers
Status: Niet gevuld in MyContainers
[[Coprar|Coprar Discharge]]: NIET TONEN (omdat expected)
[[Coprar|Coprar Load]]: NIET TONEN (omdat expected)
[[Baplie]]: NIET TONEN (omdat expected)
Acceptance order: NIET TONEN (wens business, omdat hij bij Export wordt getoond)

Export:
Daar tonen we alle container informatie die beschikbaar is in de ContainerStatus.

### Cancelled 
Er uit filteren in alle situaties.