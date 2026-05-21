---
tags: Techniek
---

[[SpecFlow]] uitleg sessie [[BDD|Behavior Driven Development (BDD)]] voor in combinatie met [[1. Werk/2. Technische kennis/Languages/CS|C#]]. 

## Tabellen
Tabel kan toegevoegd worden op [[SpecFlow#Scenario]] niveau of [[SpecFlow#Example]] niveau. Datatype is Table (gedefinieerd in [[SpecFlow]]). 
Op scenario niveau: voor elke run van deze test, gebruik deze waardes. 
Op example niveau: voer een run uit per rij in deze tabel met de genoemde waardes. 

Vervolgens aan de [[SpecFlow#StepDefinition]] kant zijn de opties CreateSet / CreateInstance of CompareSet / CompareToInstance. 

## Hooks
Hier kun je setup/teardown doen die specifieker getimed is dan de scenario background die voor elk scenario afspeelt. 

```cs
BeforeScenario("@tag")
BeforeScenario(Order = 1) //before first
BeforeFeature()
BeforeRun()
BeforeScenarioBlock()
AfterScenario()
AfterFeature()
AfterRun()
AfterScenarioBlock()

/**
 * Dit is vooral nuttig voor de klassieke setup/teardown die je wilt uitvoeren voor b.v. alles dat een bepaalde
 * feature raakt. Bijvoorbeeld: Voor start UI tests de browser 1x opstarten. Voor start algehele run checken of de 
 * server up is. Na elke database test de connectie afsluiten. Etc. 
 * Een 'after' hook gebeurt ook als de test faalt. 
**/
```

Leuk idee: Je kunt met objectcontainers een langer durende context opzetten die data vasthoudt of injecteert. 

## Onderhoud
- Scenario
	- Nieuw gedrag
	- Aanpassing aan taal/grammatica
- Step definitions
	- Uitbreiden test opties
	- Aanpassing aan taal/grammatica
	- Refactoren en verbeteren testen
	- Fixen test bugs
- Driver, Page object
	- Applicatie is veranderd
	- Refactoren, verbeteren en simpeler maken automation
- Infrastructuur
	- Uitbreiden opties
	- Aanpassingen omgeving
	- Refactoren, verbeteren en simpeler maken infrastructuur