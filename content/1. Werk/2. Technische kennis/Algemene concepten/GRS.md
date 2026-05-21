---
aliases:
  - Geo-redundant storage (GRS)
  - GRS (Geo-redundant storage)
tags: Techniek
---
# Geo-redundant storage (GRS)
GRS copies your data synchronously three times within a single physical location in the primary region using [[LRS]]. It then copies your data asynchronously to a single physical location in the secondary region (the region pair) using [[LRS]]. GRS offers durability for Azure Storage data objects of at least 16 nines (99.99999999999999%) over a given year.

![Diagram showing GRS, with primary region LRS replicating data to LRS in a second region.](https://learn.microsoft.com/en-gb/training/wwl-azure/describe-azure-storage-services/media/geo-redundant-storage-3432d558.png)
