---
aliases:
  - Geo-zone-redundant storage (GZRS)
  - GZRS (Geo-zone-redundant storage)
tags: Techniek
---
# Geo-zone-redundant storage (GZRS)
GZRS combines the high availability provided by redundancy across availability zones with protection from regional outages provided by geo-replication. Data in a GZRS storage account is copied across three Azure availability zones in the primary region (similar to [[ZRS]]) and is also replicated to a secondary geographic region, using [[LRS]], for protection from regional disasters. Microsoft recommends using GZRS for applications requiring maximum consistency, durability, and availability, excellent performance, and resilience for disaster recovery.

![Diagram showing GZRS, with primary region ZRS replicating data to LRS in a second region.](https://learn.microsoft.com/en-gb/training/wwl-azure/describe-azure-storage-services/media/geo-zone-redundant-storage-138ab5af.png)
