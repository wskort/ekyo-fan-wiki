---
tags: Archief/ProRail
---
# Proces [[BDD]]
[[BDD|Behavior Driven Development (BDD)]] implementatie en de bijbehorende processen. 

## Rollen
- Product Owner
- Scrum Master
- Testers
- Developers
- Analisten
- Acceptanten

> **First time right, by testing first**

Onderscheid tussen foutief testgeval, bug, en negatieve test. 
1. Foutief testgeval: met de gegeven input kán het pad niet slagen
2. Negatieve test: met de gegeven input mág het pad niet slagen
3. Goedpad: met de gegeven input móet het pad slagen
4. Bug: Onverwachte uitkomst van goede test.

Focus bij scenario's/examples verzinnen:
1. Normale werking
2. Bijzondere werking (uitzonderingen)
3. Wanneer moet het *niet* werken

Stappen:
1. **Globale refinement** met hele groep User Story helder maken
2. **Detail refinement** 3-amigo sessies voor details, alles naar [[BDD]] format, tijdsinschatting.
3. **Sprint** 
	1. Bouw (O-omgeving)
	2. Test (T-omgeving)
	3. Regressietest (T-omgeving)
4. **DOD** release naar A-omgeving

New > Ready for refinement > Ready for specification > Ready to start > In progress > etc.