---
tags: Archief/ECT
---

* VWDPS_API_CS containerstatus
* VWDPS_API_MD masterdata 
* VWDPS_API_ORDERSTATUS boekingen
* VWDPS_API_OS objectstatus
* VWDPS_API_STATUSAGGREGATION ook boekingen. 

Je inlognaam is KORTW


## Date uitlezen als datetime
```sql
ALTER SESSION SET NLS_DATE_FORMAT = 'DD-MM-YYYY HH24:MI:SS';
```

## Wachtwoord wijzigen
```sql
ALTER USER KORTW IDENTIFIED BY NewPWD;
```

## Core Business & EAN modal resetten 
1. Ga met de [[VDI]] en met [[RDCMan|RDCMan (Remote Desktop Connection Manager)]] naar machine 55 op Acc. 
2. Open met [[SQL Server]] de database `mstcen007.centralarea.acc` met windows credentials
3. Navigeer naar RPPRofiles > Tables > dbo.Company
4. Voer de volgende query uit:
```sql
update [RPProfiles].[dbo].[Company]
set EANisValid = null,
	BusinessTypesValidatedByCustomer = 0,
	EAN = ''
where name like '%Uniquorn%';
```
(of met andere bedrijfsnaam)

## EDB
### Customs
- T1EDBCUS
- A3EDBCUS
- P6EDBCUS

### Logistics
* A3EDBLG
* P6EDBLG
* T1EDBLG

---
