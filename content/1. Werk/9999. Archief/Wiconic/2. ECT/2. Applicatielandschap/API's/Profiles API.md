---
tags: Archief/ECT
---
Deze [[API|API (Application Programming Interface)]] wordt direct door de [[FE|FE (Front-end)]] van [[MyTerminal]] aangeroepen. Daarom heeft het naast een `ocp_apim_subscription key` header ook een `Bearer` token nodig als Authorization header. 

Om het aanmaken van een access token via de [[1. Werk/99. Archief/1. Wiconic/99. Archief/2. ECT/2. Applicatielandschap/STS]] ingewikkelder is dan een paar API calls met credentials uitvoeren, is er een applicatie in [[1. Werk/2. Technische kennis/Languages/CS|CS (C#)]] geschreven voor het ophalen van de token. Deze is hier te vinden:
https://dev.azure.com/ectteam/Phoenix/_git/AccessTokenRetriever. 

Zie ook: https://dev.azure.com/ectteam/Phoenix/_wiki/wikis/Information-Portal.wiki/593/ReadyAPI-Access-token-aanmaken