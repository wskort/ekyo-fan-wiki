---
tags: Archief/InTraffic
---

Dit is een [[VM]] in [[Linux]]. 
Er zit een [[Certificate]] op geïnstalleerd en het is verbonden met de [[GIT]] repository van InTraffic. Daarmee haal ik de code binnen om een [[Local deployment]] op te zetten.

```bash 
# sudo 							Run command as root
# ./localdeploy.sh 				Dit shell script, hierzo
# -l DEV4 						Op de omgeving DEV4
# -a wpk 						Applicatie is wpk (werkplek)
# -n 16 						Naam (wpknr) is 16
# -s 							Update van een bestaande deployment
# -x NB3717.INTRAFFIC.LOCAL		Dit is mijn systeemnaam

sudo ./localdeploy.sh -l DEV4 -a wpk -n 16 -s -x NB3717.INTRAFFIC.LOCAL
```

## Login
Username: `prl`
Password: `prl`