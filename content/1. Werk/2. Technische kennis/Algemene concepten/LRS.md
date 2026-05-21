---
aliases:
  - Locally redundant storage (LRS)
  - LRS (Locally redundant storage)
tags: Techniek
---
# Locally redundant storage (LRS)
Locally redundant storage (LRS) replicates your data three times within a single data center in the primary region. LRS provides at least 11 nines of durability (99.999999999%) of objects over a given year.

![Diagram showing the structure used for locally redundant storage.](https://learn.microsoft.com/en-gb/training/wwl-azure/describe-azure-storage-services/media/locally-redundant-storage-37247957.png)

LRS is the lowest-cost redundancy option and offers the least durability compared to other options. LRS protects your data against server rack and drive failures. However, if a disaster such as fire or flooding occurs within the data center, all replicas of a storage account using LRS may be lost or unrecoverable. To mitigate this risk, Microsoft recommends using [[ZRS|Zone-redundant storage (ZRS)]], [[GRS|Geo-redundant storage (GRS)]], or [[GZRS|Geo-zone-redundant storage (GZRS)]]. 