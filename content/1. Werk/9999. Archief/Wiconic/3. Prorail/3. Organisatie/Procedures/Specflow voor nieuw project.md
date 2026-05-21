---
tags:
  - Archief/ProRail
  - Techniek
---
# [[SpecFlow]] koppeling voor nieuw project

## Voorbereiding
1. Indien nodig, "SpecFlow for Visual Studio" extension installeren in [[Visual Studio]]. 
   Hiervoor ga je naar "Extensions --> Manage Extensions --> Online" en zoek je naar "SpecFlow". Klik op "Download" om de installatie te beginnen, sluit dan Visual Studio en laat de installatie afronden. 
2. Open in [[Visual Studio]] de solution van je [[SUT|SUT (System Under Test)]]. Als het een nieuw project is, clone het met git. 
3. Maak een nieuwe branch aan voor je wijzigingen. 

## Project koppelen
1. **Right-click** op het Solution item in de Solution Explorer en selecteer "Add --> New Project..."
   ![[SpecFlowHowTo1.png]]
2. Zoek naar "SpecFlow", selecteer het "SpecFlow Project" template en klik op next. 
3. Vernoem het project naar het originele code project, plus 'Specs'. Bijvoorbeeld: "SamenstellerPipelines" wordt "SamenstellerPipelinesSpecs". 
4. Selecteer het Test Framework (Runner) dat je wilt gebruiken. Wij gebruiken MSUnit, wat ook voor de unit tests wordt gebruikt. Klik "Create". 
5. Je nieuwe project staat nu in de Solution Explorer. Klap het open, right-click op "Dependencies" en selecteer "Add Project Reference..."
   ![[SpecFlowHowTo2.png]]
6. Selecteer het bronproject en klik OK. 
7. Je zult zien dat er onder Features een voorbeeld-feature "Calculator.feature" is aangemaakt, en onder StepDefinitions ook een voorbeeldbestand "CalculatorStepDefinitions" staat. Deze kun je allebei verwijderen.
8. Tenslotte heb je een plugin nodig op dit nieuwe project om voor [[LivingDoc|SpecFlow+ LivingDoc]] actuele resultaten te kunnen genereren. Open je Developer PowerShell terminal onderaan je scherm, en navigeer naar je nieuwe projectmap.
   ![[SpecFlowHowTo17.png]]
9. Voer hier het volgende commando uit: `dotnet add package SpecFlow.Plus.LivingDocPlugin`

## Feature file aanmaken
1. Klap het TAF project uit en right-click op "Features". Selecteer "Add --> New item..."
2. Selecteer in het linkermenu "SpecFlow" en kies dan de template "Feature File for SpecFlow". Klick "Add". 
   ![[SpecFlowHowTo3.png]]]]
3. Je hebt nu een basis template voor een feature file. 

## Step Definitions aanmaken
1. Open je Feature file. 
2. Maak een nieuwe build aan om de step-definition koppelingen te updaten. Dit doe je met "Build --> Build Solution"
3. Right-click op een ongedefinieerde stap en selecteer "Define Steps..."
   ![[SpecFlowHowTo4.png]]
4. Als de bijbehorende class het bestand nog niet bestaat, klik op "Create". Als het bestand al wél bestaat, klik op "Copy to clipboard".
   ![[SpecFlowHowTo5.png]]
4. Je (template) step definitions kun je vinden onder StepDefinitions. Als je in de vorige stap "Copy to clipboard" hebt gebruikt, plak de methodes dan in de bestaande StepDefinitions class erbij. 


## Koppeling met [[Azure DevOps]]
1. Indien nodig, "Azure DevOps Test Connector" extension installeren in [[Visual Studio]]. 
   Hiervoor ga je naar "Extensions --> Manage Extensions --> Online" en zoek je naar "Azure DevOps Test Connector". Klik op "Download" om de installatie te beginnen, sluit dan Visual Studio en laat de installatie afronden. 
2. Als je nog niet eerder testcases gekoppeld hebt, dan moet je de Azure Test Connector configureren. 
   Ga naar "Tools > Options", en dan naar "AzureDevOps Test Connector > Settings". Vul in: 
   "AzureDevops instance URL" = `https://dev.azure.com/ProRail`
   "Current Project name" = `Opslag en Samenstellen`
   ![[SpecFlowHowTo14.png]]\
3. Open "Test > Test Explorer", zoek je testgeval in de lijst en **right-click**. Klik op "Associate to Test Case". 
   ![[SpecFlowHowTo15.png]]
4. Vul nu het test case id in uit Azure DevOps om de connectie aan te maken. Let op: het moet echt een work item van type "Test Case" zijn. 
   ![[SpecFlowHowTo16.png]]

## SpecFlow+LivingDoc toevoegen aan build pipeline
1. Ga naar het overzicht van de pipelines van dit project. 
   ![[SpecFlowHowTo6.png]]
2. Kies vervolgens de relevante pull-request pipeline.
   ![[SpecFlowHowTo7.png]]
3. Op het lijstoverzicht van recente builds, klik rechtboven op "Edit"
   ![[SpecFlowHowTo8.png]]
4. Zoek vervolgens in de takenlijst rechts naar "SpecFlow" en klik op de optie "SpecFlow+LivingDoc".
   ![[SpecFlowHowTo9.png]]
5. Er worden nu opties uitgevraagd. Selecteer de radio button "Feature folder" en typ in het bijbehorende tekstvak het pad naar de relevante folder, bijvoorbeeld `src/SamenstellerPipelineSpecs`. Open "Advanced opties" en typ bij de "Work Item Prefix" de tekst "WI".  
   ![[SpecFlowHowTo10.png]]
6. Klik op "Add". Er wordt nu automatisch de juiste code toegevoegd, maar nog niet op de juiste plaats. Knip de code van deze eerste positie:
   ![[SpecFlowHowTo11.png]]
7. ... plak de code onderaan in het kopje `steps:`...
   ![[SpecFlowHowTo12.png]]
8. ... en geef alle regels van de geplakte code een `TAB` extra om uit te lijnen met de voorgaande stappen.
   ![[SpecFlowHowTo13.png]]
