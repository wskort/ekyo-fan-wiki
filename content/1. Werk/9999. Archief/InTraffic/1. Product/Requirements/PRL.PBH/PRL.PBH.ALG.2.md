---
aliases:
  - PRL.PBH.ALG.2 Indeling scherm
tags: Archief/InTraffic
---
# [[PRL]].[[PBH]].ALG.2 Indeling scherm
De applicatie voor post- en planbeheer moet na inloggen als volgt zijn ingedeeld.

1. Aan de bovenzijde van het scherm moet een "Systeem" strook met de volgende items worden gegeven.
	1. Een vermelding van welke post beheerd wordt.
		1. Naam van de post.
		2. Versie van Procesleiding Rijwegen.
	2. Een vermelding van de ingelogde gebruiker.
		1. De volledige naam van de gebruiker.
		2. De rol waarmee deze gebruiker ingelogd is.
	3. Keuzemogelijkheden voor de volgende interactie met PBH zelf.
		1. Postbeheer openen voor een andere treindienstleidingpost.
		2. Gebruikersbeheer.
		3. Weergeven van logging.
		4. Uitloggen.
2. Hieronder moet een "Hoofdmenu" strook met ("tabs" voor) de volgende verschillende categorieën instellingen worden gegeven.
	1. Categorieën voor beheer van plangegevens.
		1. Planbeheer.
		2. WBI-beheer.
	2. Categorieën voor beheer van systeeminstellingen.
		1. PPR.
		2. ARI.
		3. ABT.
		4. DVM.
		5. BIF.
		6. WVD.
	3. Categorieën voor operationele ingrepen.
		1. ARI Noodstop.
	4. Categorieën voor technisch beheer.
		1. Monitoring en beheer van PRL-instanties.
		2. Import / export van postinstellingen.
3. Als op een ("tab" voor een) categorie wordt geklikt, moet onder de strook aan de linker zijde een "Categoriemenu" navigatiekolom worden getoond met de volgende hoofdonderdelen.
	1. Voor categorieën voor beheer van procesplannen en WBI-gegevens:
		1. De voor de categorie van toepassing zijnde beheertaken.
	2. Voor categorieën voor beheer van instellingen:
		1. Postbrede instellingen.
		2. Overzicht(en).
		3. Voor elk PPLG in de post een item met de naam van het PPLG.
	3. Voor een operationele ingreep moet er slechts één anoniem onderdeel zijn dat automatisch wordt gekozen.
4. De navigatiekolom mag maximaal twee niveaus bevatten, met de genoemde weergave:
	1. Onderdelen. Hierbij moet een map-symbool worden weergegeven.
	2. Subonderdelen. Hierbij moet een symbool worden weergegeven dat een indicatie geeft waar het om gaat.
5. Rechts van de navigatiekolom moeten de instellingen en acties voor het gekozen categorie-(sub)onderdeel worden getoond.
6. Initieel moet het hoofdonderdeel van de meest linkse categorie geselecteerd zijn.


          


```
Toelichting:
Ad b2c: Eventuele verdere onderverdeling is specifiek voor de categorie. Zie daarvoor de eisen in de daarop van toepassing zijnde paragraaf.
Ad b3: Voor ARI Proces Stoppen is geen navigatie van toepassing.
Ad c: Voor ARI Proces Stoppen hoeft geen actie te worden uitgevoerd om het enige onderdeel te kiezen; voor andere categorieën moet op een onderdeel worden geklikt.
Ad d: Instellingen zijn per post (= onderdeel), per PPLG (= onderdeel) of per sein-in-een-PPLG (= subonderdeel); er zijn geen instellingen voor subonderdelen van subonderdelen. Denk voor symbolen van subonderdelen aan een blaadje voor een overzicht en een seinsymbool voor een sein.
Ad f: Wijzigen doe je nadat je hebt kunnen zien wat de huidige instelling is en dat moet met exact dezelfde pagina als alleen raadplegen. Dit suggereert de oplossing om op de pagina bij elke instelling die je als gebruiker mag wijzigen een knop "Wijzig instelling" aan te brengen.
```