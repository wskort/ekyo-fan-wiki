---
tags:
  - Archief/Intersolve
---
- ProgramManagerAdministrationCodes 
	- SetProgramManagerAccountCodeFeature
		- AsAProgramManagerICanMakeAFinancialCorrectionWhenISetTheAccountForAMerchant
		  Error: bij aanroepen DataWarehouseAPI wordt "type" weggelaten, dit is een verplicht veld. DWA geeft 400, CH geeft 500. 
- ProgramManagerAssets
	- RegisterSavingAssetFeature
		- AsAProgramManagerICannotCreateADuplicateSavingAsset
		  message mismatch; fixed it
- ProgramManagerCampaigns
	- GetCampaignBasicsFeature
	  ITS 500 error: `Message-program-manager (GetCampaignTests) does not belong to BrandType-Brand-ProgramManager (specfCampaignTests)`
	  Trace-id ONTBREEKT in de 500 message van ITS
- 