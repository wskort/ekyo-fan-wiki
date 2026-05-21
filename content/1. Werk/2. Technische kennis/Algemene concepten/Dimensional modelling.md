---
tags:
  - Techniek
---
# Dimensional modelling
Systeem van [[Database|Data Warehouse]] ontwerp. 

Uitgangspunt is altijd een business process. Aan de hand van de 'value chain' analyse wordt uitgezocht waar en wanneer de [[OLTP]] systemen data vastleggen, de granulariteit en de beschrijvende context. Aan de hand van deze analyse worden analytical requirements ontwikkeld. Dus: reporting requirements zijn op zichzelf geen goed startpunt. 

## Dimension tables

| Type of Dim table                        | description                                                     |
| ---------------------------------------- | --------------------------------------------------------------- |
| Type 0                                   | Values cannot change (ex: DimDate)                              |
| Type 1                                   | Any value which changes is overwritten; no history is preserved |
| Type 2 a.k.a. Slowly Changing Dimensions |                                                                 |
| Type 6                                   | Hybrid model                                                    |
## Fact tables
![[Dimensional modelling.png]]

