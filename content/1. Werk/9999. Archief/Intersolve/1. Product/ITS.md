---
tags:
  - Archief/Intersolve
aliases:
  - ITS (Integrated Transaction Store)
  - Integrated Transaction Store
---
# Integrated Transaction Store (ITS)
Soort klein datawarehouse tussen [[Connect]] en [[Merchant]] dat asynchroon gevuld wordt vanuit o.a. [[1. Werk/9999. Archief/Intersolve/1. Product/Transactions/TA|Transaction Authorizer]] met update messages. Wordt verwerkt met hulp van [[RabbitMQ]] (queue manager) om in [[ITS]] te belanden. Zo kunnen klanten veel queries uitvoeren zonder de database te overbelasten. 

Heeft ook een 'dead message queue' waar onverwerkbare berichten geparkeerd worden voor manual review, maar dat gaf te veel resultaten. 

Redelivery-flag moet gebruikt worden om eerst te kijken of een message inderdaad al eerder is verwerkt, en zo ja, weggooien. 

Vervolgens kan dan de error van dubbele verzending weer op error worden gezet ipv warning. 