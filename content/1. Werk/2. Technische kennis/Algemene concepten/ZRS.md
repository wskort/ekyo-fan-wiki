---
aliases:
  - Zone-redundant storage (ZRS)
  - ZRS (Zone-redundant storage)
tags: Techniek
---
# Zone-redundant storage (ZRS)
For Availability Zone-enabled Regions, zone-redundant storage (ZRS) replicates your Azure Storage data synchronously across three Azure availability zones in the primary region. ZRS offers durability for Azure Storage data objects of at least 12 nines (99.9999999999%) over a given year.

![Diagram showing ZRS, with a copy of data stored in each of three availability zones.](https://learn.microsoft.com/en-gb/training/wwl-azure/describe-azure-storage-services/media/zone-redundant-storage-6dd46d22.png)

With ZRS, your data is still accessible for both read and write operations even if a zone becomes unavailable. No remounting of Azure file shares from the connected clients is required. If a zone becomes unavailable, Azure undertakes networking updates, such as [[DNS]] repointing. These updates may affect your application if you access data before the updates have completed.

Microsoft recommends using ZRS in the primary region for scenarios that require high availability. ZRS is also recommended for restricting replication of data within a country or region to meet data governance requirements.