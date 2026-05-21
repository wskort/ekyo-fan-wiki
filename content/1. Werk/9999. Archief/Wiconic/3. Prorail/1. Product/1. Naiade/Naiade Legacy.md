---
aliases: [Naiade 1.0]
tags: Archief/ProRail
---
# Naiade
Deze software genereert [[IMX|Infrastructure Model Exchange (IMX)]] bestanden van het Nederlandse sporennet en alle vaste materieel (geen treinen). Overige software zoals [[PRL|Procesleiding (PRL)]] kan dit gebruiken als basis om actuele kaarten in te laden. 

De huidige/oude versie is [[Naiade Legacy|Naiade 1.0]] Nieuwbouw is [[NC|Naiade Continue]]. Bijbehorend testframework is [[Aegle]], met de versies [[Aegle|Aegle 1.0]] en [[Aegle|Aegle 2.0]]. 

## Doel
[[ProRail]] beheert een cyclus van werkzaamheden. 
1. **Aanleggen** (nieuw spoor, nieuwe stations)
2. **Verdelen** (van de ruimte op het spoor)
3. **Regelen** (van alle treinverkeer)
4. **Informeren** (van vervoerders)
5. **Beheren** (van stations)
6. **Onderhouden** (bestaand spoor)

Hierbinnen speelt Naiade een rol in elke stap van het proces. 
1. **Aanleggen:** Opslaan wijzigingen: bv. nieuwe wisselkast.
2. **Verdelen:** Planning: Levering [[DONNA]]
3. **Regelen:** Ligging en data: Baan en trein beveiliging
4. **Informeren:** Ligging en data: [[Treinlengte]] bordel; Levering aan [[Geopoort]]/[[Geopublicatie]]
5. **Beheren:** Ligging en data: bv. passagiers informatie paneel
6. **Onderhouden:** Ligging en data: bv. wisselkast vervangen. 

## Pre-Naiade
- [[IA|InfraAtlas]]
	- Topologie
	- Foutieve data
	- Veel handwerk
	- End of life
- [[PUIC]]
	- Unieke IDs
- [[Geopoort|Geopoort (OG BBK-PRGIS)]] uit [[SpoorData]]
	- Geografische data
- Diverse excel bestanden
	- Overige data

## Ontwerp [[Naiade Legacy]]
Enkelvoudige bron met zowel topologische als geografische data. Mogelijk maken van data uitwisseling in modern, aanpasbaar formaat ([[XML]]). Geen foutieve data meer in de applicatie. 

Nieuw datamodel = [[IMSpoor|Informatie Model Spoor (IMSpoor)]] in [[XML]]-format. 

Situatie is altijd consistent door ingebouwde validatie. 

## [[Naiade Legacy]] in de praktijk
[[IMSpoor]] hernoemd(?) naar [[OTL Spoor]]. 

Wordt gebruikt als bron voor: 
- [[DDIO]]
- [[SchemaService]]
- [[GebiedenTool]]
- [[Geopublicatie]]/[[Geopoort]]
- etc. etc. 

Validatie service is erg streng. 
Verificatie en ontwerp zijn vermengd geraakt, waardoor het te veel gefocust is op een specifieke klantsoort. 

### Nachtvenster
Dit is een langdurige 'tijdelijke oplossing' die is gebouwd om de benodigde data toch uit de pre-Naiade bronsystemen binnen te halen en om te zetten naar de nieuwe output. 

1. Ophalen ontwerpdata uit:
	1. [[IA|IA (InfraAtlas)]]
	2. [[Geopoort|Geopoort (OG BBK-PRGIS)]] 
	3. [[PUIC]] koppeling en matching
	4. Excel bestanden met aanvullende data
2. **Harmony proces:** Conversie van ontwerpdata via [[FME Converters]] naar [[IMX]]-format. 

Output is dus een geografische landelijke [[IMX]] van heel Nederland. Bij elke wijziging wordt de gehele kaart opnieuw gegenereerd. 

### Knopen takken model
![[ProRail Naiade Legacy.png]]
Hier een ruw overzicht van hoe de data gestructureerd is.

- [[RailInfrastructure]] 
	- [[RailTopology]] = Topologisch deel. Knopen-en-takken model. [[Grafentheorie]]
		- [[Micronode]] met verwijzing naar [[Junction]] ref
			- [[Jumper]] = de 'sprong' van het ene wisselbeentje (passage) naar de andere om de route voort te zetten. Kan (on)begaanbaar en 1/2 richting zijn. Een micronode kan 0+ jumpers hebben. 
		- [[MicroLink]] met [[RailConnection]] ref
			- From[[MicroNode]] ref
			- To[[MicroNode]] ref
	- [[RailImplementation]] (Het IJzer)
		- [[Tracks]] Fysiek spoor met coördinaten, beheerstatus, etc.
		- [[Junction]] = Spoor begrensers, wissels (knoop- of eindpunten) met coördinaten, beheerstatus, etc.
		- [[RailConnection]] = Functionele spoortak (knoop tot knoop; set aangrenzende tracks) (= abstract)
	- [[TrackAssets]]
		- Assets die bij het functionele spoor horen, met referentie naar de functionele spoortak ([[RailConnection]])