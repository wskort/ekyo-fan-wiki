---
tags: Archief/ECT
---
# Upgrade flow
Permissie "subscriptions" nodig (via [[AccessManagement]]) om in [[MyProfile]] de nieuwe tab 'Subscriptions' te mogen zien.

Design flow is in [[Figma]].

If billing address info is complete, questions aren't shown and data isn't updated.

Upon upgrade, two API's are called: 
- Update billing info
- Mollie / direct (bank transfer)

-------------
# Free feature versions
Local storage: 
| key            | value      |
| -------------- | ---------- |
| features-light | ["Import", "ObjectSchedule"] |

-------------
# Force company has-active-subscription=false
In the company address, housenumber addition, make sure that the entry ends in `nosub` to simulate a free subscriber after go-live.

-----------
# Premium banner
Datum & user permission group(s)


------------
# API-Profile
## Subscription
### Payment methods
| id  | Name         | MinimalAmount | Note                           |
| --- | ------------ | ------------- | ------------------------------ |
| 1   | CreditCard   | 0,00          |                                |
| 2   | IDeal        | 0,01          |                                |
| 3   | Giropay      | 1,00          |                                |
| 4   | Bancontact   | 0,02          | N/A; pending Mollie acceptance |
| 5   | EPS          | 1,00          |                                |
| 20  | BankTransfer | 0,00          |                                |

### Payment periods
| id  | Name  |
| --- | ----- |
| 1   | Month |
| 2   | Year  |

### Transaction types
| id  | name      | notes                                   |
| --- | --------- | --------------------------------------- |
| 1   | First     | De x-cent transactie voor mandaat geven |
| 2   | Recurring |                                         |
| 3   | One off   |                                         |

### Transaction statuses
| id  | Name     |
| --- | -------- |
| 1   | New      |
| 2   | Pending  |
| 3   | Paid     |
| 4   | Expired  |
| 5   | Failed   |
| 6   | Canceled | 

### Products
| id  | Name                                       |
| --- | ------------------------------------------ |
| 1   | Premium                                    |
| 2   | Premium deepsea operator large             |
| 3   | Premium deepsea operator medium            |
| 4   | Premium deepsea operator small             |
| 5   | Premium feeder operator                    |
| 6   | Premium barge / rail operator              |
| 7   | Premium barge / rail continentaal operator |

### Subscription free period statuses
| id  | Name      |
| --- | --------- |
| 1   | New       |
| 2   | Processed |

### Log event types
| id  | Name                    |
| --- | ----------------------- |
| 1   | Start subscription      |
| 2   | Stop subscription       |
| 3   | Change payment method   |
| 4   | Change period           |
| 5   | Add free period         |
| 6   | Invoice not collectable |
| 7   | Invoice created         |
| 8   | Reactivate subscription |

