---
tags:
  - Archief/NVWA
aliases:
  - GRV (Generiek Register Verleningen)
  - NGRV
  - NGRV (NVWA Generiek Register Verleningen)
---
# ([[NVWA]]) Generiek Register Verleningen (GRV)
Dataopslag voor (o.a.) [[BVAV]]. [[e-CertNL]] haalt hier informatie uit op. 

[[FoVo|FoVo (Formulieren Voorzieningen)]] team voor de voorkant

[[BVAV|BVAV (Basis Voorziening Afhandelen Aanvragen)]] in Blueriq of Oracle. 


```
client id kS6A_odwuihBPkmFgB0fkw..
client secret 3VZo-yDppd71QWXseHIZlQ..

ngrv_test/sP6VrTer0m5ZN5nLtbHI@t1051123_apx_srv

https://apex-ota.dictu.intern/ords/tngrv/r/ngrv/ngrv/login_desktop?request=APEX_AUTHENTICATION%3DApplication+Express+Authentication
NGRV_TEST_APEX met zelfde ww a;s de database gebruiker
```


PreChecks 
- Is medewerkerreferentie gevuld NGRV-00007
- Is verleningnummer gevuld en volgnummer niet (of andersom) NGRV-0008
- Is verleningnummer gevuld en volgnummer gevuld, maar verleningindicatie is leeg NGRV-00009
- Is zaaknummer leeg NGRV-00010
- Is bronzaaknummer leeg NGRV-00011
- Is KVKnumer leeg NGRV-00012
- Is vestigingsnummer leeg NGRV-00013
- Is begindatum of einddatum leeg NGRV00018/NGRV-00019
- Is soort/type leeg NGRV-00020, NGRV-00021
- Is zaaknummer een al bestaande zaak? NGRV-00023
- Verlening-Soort en verlening-Type moeten bestaan in NGRV configuratie! NGRV-00028/NGRV-00029

FOUTCODES
https://confluence.nvwa.intern/spaces/BLAC/pages/1061357368/9.6+Foutcodes+GRV