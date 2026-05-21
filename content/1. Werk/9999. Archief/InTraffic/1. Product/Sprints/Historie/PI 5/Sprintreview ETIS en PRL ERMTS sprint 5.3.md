---
tags: Archief/InTraffic
---
[[EMS]] reconnect gedrag afgerond

Conversie treinposities o.b.v. [[MA]] of indien niet beschikbaar [[infratoestand]]. 

[[Blue/green switch]] nog niet geïmplementeerd. 

[[I_ETIS_ACTPAS]] "active-passive interface"

[[ASTRIS-AAP]] repeterende logmeldingen verholpen

---

[[MBT]] raakt nu bijna 95% van eisen. 

[[1. Werk/99. Archief/0. InTraffic/3. Organisatie/Document-types/SRS]]s gebruikt om [[MBT]] scenario's uit te breiden. 

--- 

[[IRS]] of [[1. Werk/99. Archief/0. InTraffic/3. Organisatie/Document-types/SRS]] 

Er komt een [[ISA]] van [[TÜV]]. 

Status [[SonarQube]] geeft code coverage van [[Unit-testing]] aan. 

--- 

Demo [[infraconversie]] [[Treinpositie]]. Trein met [[MA]] voor [[1. Werk/99. Archief/1. Wiconic/99. Archief/3. Prorail/2. Domein/SMB]] 539. [[Treinkop]] en [[Treinstaart]] posities aangegeven, met [[KTL]]. De [[Treinlengte]] en [[Veilige Treinlengte]] zijn niet gelijk, die tweede is een stukje langer. 

[[MA]] wordt vermeld vanaf [[Treinkop]] met afstand en meter en geplande spoorsecties. 

[[Balise]] is een... plek op het spoor...?

Wanneer een trein de [[Wisselstraat]] voorbij is, worden de wissels vrijgegeven. 

[[ETIS]] heeft de [[MA]] in geheugen en zoekt de trein vanaf laatst gepasseerde [[Balise]] over dat spoor, ondanks dat de wissels vrij staan en dus niet meer gegarandeerd kan worden welke route de trein zou moeten volgen. Maar! Als je [[ETIS]] herstart dan kan deze tussen [[Balise]] en vrije wissel geen [[Treinstaart]] vinden, dan weet [[ETIS]] niet meer waar de trein is gebleven. Dit kan niet vanaf de [[MA]] worden teruggerekend. 
Als dit toch gebeurt, dan herstelt de situatie vanzelf zodra de trein een nieuwe [[Balise]] gepasseerd is. Dan wordt er een nieuwe [[MA]] opgebouwd voor de route vanaf daar. 

--- 

[[Ansible Tower]] tower.intraffic.local doet iets met scripts draaien, op VM's, denk ik. Er wordt hier een [[Playbook]] afgespeeld; ik weet niet wat dat betekent. 

[[AB-switch]] is wissel tussen twee software versies. De [[I_ETIS_ACTPAS]] actief/passief switch is dat er twee tegelijk draaien, waarbij er 1 actief is, en als die uitvalt dan wordt de ander actief. (en de uitgevallen herstart in passieve staat?). 

ETIS beheer [[Playbook]] ondersteunt de actie 'restart'; meer in de backlog. 

ETIS kan enabled of disabled zijn. Disabled is niet volledig uit. 

---

[[RT]] alleen accepteren als [[TROTS]] en [[ETIS]] posities overeenkomen. 

[[STS-route]] instellen niet langer beperkt. 

[[PBH]] aangescherpte wachtwoordeisen en autorisatiecontrole. 

[[TAF]] 16 nieuwe testen, 2 aangepast. Positieoverlap nu volledig geautomatiseerd.

---

Als je vanuit [[ETIS]] aan [[PRL]] doorgeeft dat een trein stilstaat, dan gaat dat treinnummer knipperen op het scherm. 

[[Eindsein]] reservering wordt met een groen blokje aangegeven. [[Startsein]] reservering wordt als groen pijltje aangegeven. De iconen overlappen als dit hetzelfde sein is. 

[[Treinkop]] wordt door weergegeven met geel bolletje voor of achter de naam (voor richting), treinbezetting met gele streep. 

---

[[ETIS Stub]] wordt aangepast; dit is een [[Testautomatisering]] ding. Ook worden [[Selenium]] testen uitgebreid. 

[[Actieve werkzone]] wordt niet geclassificeerd als [[Ongebruikelijke locatie voor stilstand]]. 

[[Rijweg]] paars tonen indien geen [[MA]]. 

[[SNMP-traps]] monitoring interface voor [[ETIS]]. 

[[Refinement]] van [[PI]]-6. [[1. Werk/99. Archief/0. InTraffic/3. Organisatie/Document-types/SRS]] registreren in [[Traceability sheet]]. 

[[ASTRIS-AAP]] interface uitbreiden door [[Axini]], en dan overdracht aan [[Afdeling PRL]] team. 