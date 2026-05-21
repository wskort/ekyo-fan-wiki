---
tags:
  - Archief/NVWA
aliases:
  - BVAV (Basis Voorziening Afhandelen Aanvragen)
---
# Basis Voorziening Afhandelen Aanvragen (BVAV)
De [[BVAV|BVAV (Basis Voorziening Afhandelen Aanvragen)]] is een eenvoudige voorziening voor het afhandelen van aanvragen waarvoor het back office proces nog niet op orde is (lees: nog niet aangesloten op het landschap van administratie- en register componenten). De [[BVAV]] leunt sterk op combinatie van de volgende reeds bestaande componenten:
- [[TripleForms]] aanvraagformulieren (N.B. de algemene voorziening bestaat, de interactiemechanismen ook, maar de specifieke formulieren zijn uiteraard telkens anders);
- Aanvraag administratie (generiek)
- Zaakadministratie
- Contactmomenten administratie
- Documentadministratie
- [[PDC]] (Producten- en diensten catalogus)

Daarnaast ontstaan er twee specifieke componenten:
- [[BVAA]] Afhandelapplicatie; dit zal een [[APEX]] applicatie zijn omdat de opzet voornamelijk informatiecentrisch is, met eenvoudige statusafhankelijke processturing.
- Aanvragen administratie (specifiek): een administratie waarin aanvragen als specialisatie van een zaak worden vastgelegd (net zoals Meldingen, Monsters e.d.). Deze administratie zal ook alle extra gegevensstructuren bevatten (voor eenvoudige processturing, en voor vastleggen van extra gegevens bij aanvraag).

De voorziening is in het leven geroepen om te voorkomen dat er noodgedwongen workarounds ontstaan bij het aansluiten van 'oude' back office processen op de 'nieuwe' klantinteractie voorzieningen ([[MijnNVWA]], TripleForms). Deze workarounds zijn dan geen stap op weg naar de doelarchitectuur, maar een stap opzij. Het werk dat erin wordt gestopt moet in een later stadium dan opnieuw worden gedaan. Bovengenoemde componenten van de [[BVAV]] zijn volledig in lijn met/onderdeel van de doelarchitectuur. Alleen de APEX applicatie kan t.z.t. vervallen als de betreffende back office processen een eigen oplossing onder architectuur krijgen (vergelijkbaar met de [[BVM|BVM (Basis Voorziening Meldingen)]]).

Globaal kan deze voorziening een willekeurige aanvraag vanuit [[TripleForms]] ontvangen in de Aanvraag administratie. Randvoorwaarde is wel dat het bericht dat [[TripleForms]] stuurt voldoet aan een aantal structuurafspraken (conform de [[BVM]]). Vanuit de Aanvraag administratie wordt daarop volgend een Zaak aangemaakt in de Zaakadministratie, met daarbij opgenomen de relevante zaakbetrokken Relaties, Locaties en/of Medewerkers die uit het bericht kunnen worden gehaald (dit kan dus generiek van opzet zijn als er afspraken zijn over TripleForms berichtformaat). Deze Zaak is dan zichtbaar in de [[BVAV]] afhandelapplicatie; daarin kan een medewerker de aanvraag- en zaakgegevens zien, zelf zaakbetrokken relaties/locaties/medewerkers zoeken en koppelen, extra bijlagen koppelen, statusovergangen in de zaak triggeren, termijnen inzien, opschuiven of verwijderen, en output (mails) genereren naar aanvragers en contactmomenten (laten) vastleggen.