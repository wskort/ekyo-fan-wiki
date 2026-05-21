---
tags:
  - Archief/Intersolve
aliases: []
---
Configuratie van 
- algemene adapters (nu in [[CMA]])
- [[Merchant]] configuratie (nu vaak in AttributeMapping tabel, soms XmlConfig)

Nieuwe situatie:
- [[0. Adapter Hive|Adapter Hive]] haalt configuratie per adapter op uit [[ConnectHub]] 
	- Moet weten of dit per merchant uniek is
	- Elke config heeft ook een [[Regex]] om validatiemethode vast te leggen.
- [[CMA]] wordt niet meer aangeroepen
- [[ConnectHub]] bewaart config
	- per adapter
	- per merchant
	- per brand
	- per 
- [[Connect]] config schermpje voor instellen 'switching' target ("Is dit via de [[1. Werk/9999. Archief/Intersolve/1. Product/SSS]] of een specifieke adapter?")
	- krijgt [[JSON]] config informatie binnen en toont dit mooi(er)
	- of! krijgt een [[API]] met key/value pair strings (effectief niet anders dan json)
	- validatie binnen [[Connect]] 