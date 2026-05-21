---
aliases: [EAN (European Article Numbering), European Article Numbering, Barcode]
tags: Archief/ECT
---
# European Article Numbering (EAN)
De EAN-code (European Article Numbering) is een uitbreiding van de UPC-code die werd ontwikkeld door George Laurer en die in de Verenigde Staten en Canada nog steeds wordt gebruikt. De EAN-code bestaat in principe uit een reeks van dertien cijfers, in tegenstelling tot de twaalfcijferige UPC-code, die door middel van een barcode worden weergegeven. De scanner leest de bits door de barcode in vakjes op te delen en te bepalen welke delen wit (code 0) en zwart (code 1) zijn. Door deze barcode in te lezen verkrijgt de computer een dertiencijferige code die het verder kan interpreteren.

De eerste twee cijfers van de EAN-code zijn een systeemcode. Het geeft aan welk land de code heeft uitgegeven. Voor Nederland gaat het om de code 87. De volgende vijf cijfers vormen het aansluitnummer van de aanvragen van de EAN-code. Samen worden deze zeven cijfers het bedrijfsnummer genoemd. Voor [[ECT|ECT (Europe Container Terminal)]] zijn alle relevante EAN codes uitgegeven door [[Secure Logistics]], dus is het volledige bedrijfsnummer altijd `8713755`.

Daarop volgen er opnieuw vijf cijfers. Het zijn deze vijf cijfers die naar het artikel verwijzen. Dit wordt ook wel eens een volgnummer genoemd. Op basis van het toegewezen bedrijfsnummer kan je vervolgens controlenummers aanmaken om je producten te identificeren. 

Het laatste getal is ten slotte een controlegetal. Dit controlegetal wordt door kassasystemen gebruikt om na te gaan of de barcode wel juist werd ingelezen, bijvoorbeeld wanneer een streepje beschadigd zou zijn. Slimme kassasystemen zijn in staat om bij een correct uitgelezen controlegetal een fout uitgelezen waarde te achterhalen en geven op basis daarvan een voorgesteld product. Hiervoor wordt ieder cijfer op een oneven positie met elkaar opgeteld. Dit wordt vervolgens opgeteld met de som van het drievoud van ieder cijfer op een even positie. Het controlegetal is vervolgens het cijfer dat bij het verkregen resultaat moet worden opgeteld om er een tienvoud van te maken.

Voorbeeld EAN voor test-doeleindes: `8713755` - `024154` 