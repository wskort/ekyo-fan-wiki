---
aliases:
  - PRL.PBH.ALG.3 Weergavegedrag
tags: Archief/InTraffic
---
# [[PRL]].[[PBH]].ALG.3 Weergavegedrag
1. Scrollen van de navigatiekolom en de instellingenpagina moet onafhankelijk van elkaar plaatsvinden.
2. Onderdelen in de navigatiekolom moeten worden gekenmerkt afhankelijk ervan of ze wel of niet subonderdelen bevatten.
	1. Als ze subonderdelen bevatten, moeten ze zijn gekenmerkt met een indicatie voor in- / uitgeklapt zijn.
	2. In andere gevallen moet er géén kenmerk zijn.
3. Als in de navigatiekolom een (sub)onderdeel wordt gekozen, moet het volgende gebeuren.
	1. Als een onderdeel gekozen is, moet een eventueel al geopend ander onderdeel worden gesloten.
	2. Als een onderdeel gekozen is dat subonderdelen bevat, dan moet het worden uitgeklapt.
	3. In de instellingenpagina moeten voor dat (sub)onderdeel de op dat moment van toepassing zijnde instellingen worden getoond.
	4. De getoonde instellingen moeten kunnen worden gewijzigd indien de gebruiker wijzigingsrechten voor de betreffende instellingen heeft.
4. Voor (sub)onderdelen waarvoor nog geen instellingen aanwezig zijn, moeten de symbolen worden weergegeven met een rood kruis erover.
5. De instellingenpagina moet als volgt tussen weergeven en wijzigen (kunnen) schakelen.
	1. Initieel moeten alleen instellingen weergegeven worden.
	2. Voor elke (groep/lijst van) instelling(en) die mag worden gewijzigd door de gebruiker, moeten de volgende knoppen worden gegeven.
		1. "Wijzig instelling(en)".
		2. "Toevoegen": bij een (hoofd- of sub-) tabel indien er nog een regel aan kan/mag worden toegevoegd.
		3. "Verwijderen": bij een (hoofd- of sub-) tabel indien een bestaande regel is geselecteerd.
	3. Als op deze knop wordt geklikt, moet het volgende gebeuren.
		1. Elke instelling (van die tabelregel c.q. groep van instellingen) wordt getoond in een wijzigbaar veld.
		2. De knop "Wijzig instelling(en)" moet worden vervangen door de volgende twee knoppen.
			1. "Opslaan".
			2. "Annuleren".
		3. Als op "Opslaan" wordt geklikt, moeten de wijzigingen naar het betreffende deelsysteem worden gestuurd ter controle en opslag en weer worden teruggegaan naar het weergeven van de geactualiseerde instelling.
		4. Als op "Annuleren" wordt geklikt, moet zonder verdere actie worden teruggegaan naar het weergeven van de eerder opgehaalde instelling.
6. Verplichte invulvelden moeten als zodanig herkenbaar zijn.
7. Resultaten van opdrachten en inputcontroles.
	1. Melding van succesvolle uitvoering van een opdracht moet met een groene tekstkleur plaatsvinden.
	2. Melding van niet-succesvolle uitvoering van een opdracht moet met een rode tekstkleur plaatsvinden.
	3. De volgende velden moeten na inputcontrole met rood worden geaccentueerd.
		1. _Niet_ ingevulde _verplichte_ velden.
		2. Alle _verkeerd_ ingevulde velden.

```
Toelichting:
Ad a: De navigatiekolom moet vast blijven staan als alle informatie ervan op het scherm past en in de instellingenpagina gescrolld wordt en andersom.
Ad b en d: Gebruikelijk in tree views is een box met '+' erin voor een ingeklapt item met subitems en met '–' erin voor een uitgeklapt (dus weer in te klappen) item met subitems. Items zonder subitem mogen geen +/- box hebben. Samen met de symbolen voor subitems leidt dit tot de weergave zoals hiernaast.
Ad c1: Er mag niet meer dan één onderdeel tegelijk geopend zijn.
Ad c2: Omdat er maximaal twee niveaus zijn, hoeft er niets over "volledig uitklappen" (of niet) te worden gezegd.
Ad e2: Voor de knop "Wijzig instelling(en)" is gekozen voor symbool van een potlood.
Ad e2a: Indien er sprake is van tabellen moet met de knop “Wijzig instelling(en)” de gehele tabelinhoud tegelijk wijzigbaar worden. Indien er sprake is van meervoudige (geneste) tabellen moet de knop “Wijzig instelling(en)” alleen bij de hoofdtabel worden getoond, door de knop vervolgens te selecteren moet de inhoud van de hoofdtabel en van alle bijbehorende subtabellen wijzigbaar worden.
Ad e2b: Aangezien er normaliter geen maximum aantal regels is, zal deze knop in principe altijd getoond moeten worden.
Ad e3b: Voor deze knoppen is gekozen voor een groen vinkje en een rood niet-parkeren symbool.
Ad e3c: In geval van geneste tabellen worden de wijzigingen aan hoofd- en subtabellen gezamenlijk opgeslagen.
Ad f: Op websites gebruikelijk is na de titel/beschrijving van het veld een sterretje ('\*') erbij te zetten en onderaan de pagina een verklarende tekst, zoals "\*: Verplicht veld".
```