---
aliases:
  - Read-access geo-zone-redundant storage (RA-GZRS)
  - RA-GZRS (Read-access geo-zone-redundant storage)
tags: Techniek
---
# Read-access geo-zone-redundant storage (RA-GZRS)
By default, [[GZRS|Geo-zone-redundant storage (GZRS)]] replicates your data to another physical location in the secondary region to protect against regional outages. However, that data is available to be read only if the customer or Microsoft initiates a failover from the primary to secondary region. However, if you enable read access to the secondary region, your data is always available, even when the primary region is running optimally. 

Remember that the data in your secondary region may not be up-to-date due to RPO.