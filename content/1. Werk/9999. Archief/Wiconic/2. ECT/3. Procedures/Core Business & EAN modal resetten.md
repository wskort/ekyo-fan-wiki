---
tags: Archief/ECT
---
# Core Business & EAN modal resetten 
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