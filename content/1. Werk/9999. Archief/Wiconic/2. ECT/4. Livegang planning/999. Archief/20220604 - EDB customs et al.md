---
tags: Archief/ECT
---
# Views op ACC
* EDB Customs
	* V_CONTDOCUMENT
	* V_CONTAINER_SEARCH
	* V_VOYAGE_CONTAINERS_V20


# Master op TST

| API                        | Release | Team     | ACC                                   | TST results                     |
| -------------------------- | ------- | -------- | ------------------------------------- | ------------------------------- |
| API-Masterdata             | 73      | ect-team | Known issues in `lengte/hoogte` + 500 | Known issue in `lengte/hoogte`. |
| ECT.IsApiOk                | 51      | ect-team | OK                                    | OK                              |
| API-MyTerminal             | 775     | phoenix  | OK; warnings                          | Contains errors; TODO           |
| API-Authorization          | 292     | phoenix  | 404 in `Add all profiles to company`  | OK                              |
| API-ContainerStatus        | 522     | phoenix  | OK                                    | Contains errors; TODO           |
| API-ObjectStatus           | 120     | phoenix  | OK                                    | OK                              |
| API-OperatorDashboard      | 294     | phoenix  | null in `get release order`           | Contains errors; TODO           |
| API-Profiles               | 393     | phoenix  | OK                                    | OK                              |
| API-UploadCustomsDocuments | 103     | phoenix  | OK; time-out errors                   | OK                              |
| IAM-ClientApps             | 399     | phoenix  | OK; gaat goed in hertest              | Contains errors; TODO           |
| MyTerminal TAP             | 1313    | phoenix  | OK; testdata missing on ACC           | Contains errors; TODO           |
| MyTerminal-AzureFunctions  | 199     | phoenix  | OK                                    | OK                              |
| MyTerminal-Functions       | 201     | phoenix  | OK                                    | OK                              |
| OrderRelay-AzureCloud      | 145     | phoenix  | OK                                    | OK                              |
| OrderRelay-Function        | 176     | phoenix  | OK                                    | OK                              |
* 2E: my-containers.feature
	* missing container data in environment
	* fixed URL reference 
* 2E: operator-dashboard.feature
	* missing voyage data in environment x2
* 1E: upload-customs-documents.feature
	* ACC-specific timeout problem. 

## Revert hotfixes
In frontend moet er een streepje aangepast worden bij livegang, dat pakken we nu ook mee zodat het juiste endpoint (operatorcodes vs operator-codes) wordt aangeroepen. Juist is *na livegang* zonder streepje. 
* Frontend src config index.tsx
* e2e cypress support exportCommands.js
En iets met PartnerVoyNrs is ook een revert teruggedraaid per deze livegang. 

Hiervoor is een nieuwe change gedaan, die meegaat met de volledige bak aan updates. 

Pull Request !6315