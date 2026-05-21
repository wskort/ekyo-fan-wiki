---
tags:
  - Archief/Intersolve
software:
  - "[[0. Payment Instrument|Payment Instrument]]"
  - "[[1. Werk/2. Technische kennis/Languages/CS|C#]]"
  - "[[API]]"
team: Portals
---
## Authorization

Voor elke [[Visa]] betaling die wij moeten autoriseren stuurt [[Enfuce]] authorization berichten met de ``messagecategory`` : ``REQUEST``  (zie hieronder een voorbeeld)

```json
{
	"metadata": {
		"id": "27775386900",
		"traceId": "9730900a-0987-4223-bda8-6a7bdfb38404",
		"linkId": "27775386900",
		"messageCategory": "REQUEST"
	},
	"customer": {
		"customerId": "449479400"
	},
	"account": {
		"accountId": "1134667600",
		"availableAmount": {
			"amount": 0,
			"currency": "EUR"
		}
	},
	"card": {
		"cardId": "1134667800",
		"expiration": {
			"year": 2026,
			"month": 8
		}
	},
	"transactionData": {
		"transactionType": "RETAIL",
		"transactionAmount": {
			"amount": 10.94,
			"currency": "EUR"
		},
		"settlementAmount": {
			"amount": 10.94,
			"currency": "EUR"
		},
		"transactionDateTime": "2024-02-16T14:09:31",
		"cardEntryMode": "CONTACTLESS",
		"cardholderPresent": true,
		"retrievalReferenceNumber": "404714021955",
		"merchantInitiated": false,
		"cardholderVerifications": [],
		"transactionFees": []
	},
	"merchantData": {
		"merchantId": "256052 ",
		"merchantName": "PLUS Nieuwland",
		"merchantCity": "SCHIEDAM",
		"merchantCountry": "NLD",
		"acquirerCountry": "NLD",
		"merchantCategory": {
			"code": "5411",
			"codeDescription": "5411 Grocery Stores,supermarkets",
			"group": "RETAIL"
		},
		"acquirerId": "487500",
		"terminalId": "08C26F ",
		"partialApprovalCapable": false
	}
}
```

In de body van een dergelijk bericht staan alle details waarmee de [[0. Payment Instrument|PI]] service moet bepalen:

- Of de transactie mag plaatsvinden op basis van `merchantData` en `merchantCategory`.
- Welke `intersolveTokenCode`  gebruikt moet worden obv van `customerId`, `acccountId`, en `cardId`.

Als bovenstaande bepalingen succesvol waren  zal de de [[0. Payment Instrument|PI]] service via onze [[POS-API]] de daadwerkelijke charge authorisatie uitvoeren op het intersolve token code.

Resultaat van een [[Enfuce]] authorization wordt teruggekoppeld middels een `responseCode` (`00` = Approved, `51`=Not sufficient funds, `05`= Declined, `57`=Transaction not permitted to cardholder)

## Notification

[[Enfuce]] stuurt van diverse card events op hun platform notifications naar ons via een aparte webhook. Een aantal hiervan zijn gerelateerd aan een uitegevoerde transactie (`Type`=`TRANSACTION`). Notificaties van type `TRANSACTION`  kennen ook een `responseCode`, waarmee het resultaat van de transactie mee wordt doorgegeven zoals [[Enfuce]] deze zal vastleggen cq terug zal melden aan [[Visa]].  

Voorbeelden hiervan zijn:

- Er is een verkeerde Pin ingevoerd tijdens een transactie (responsecode `70`)
- Het maximaal aan Pin pogingen is overschreden (responsecode `75`)
- Issuer heeft niet tijdig gereageerd op een authorizatie verzoek  (responsecode `91`)
- Transactie succesvol geautoriseerd (responsecode `00`)
- Transactie niet toegestaan voor kaarthouder (response code `57`)

Wij als [[Intersolve]] zijn voor [[Enfuce]] een Issuer waar zij betaal authorizaties van kaarten die wij hosten op doorsturen. Authorisatie verzoeken  dienen wij altijd binnen 1 seconde te hebben teruggekoppeld aan [[Enfuce]] met een `responseCode`  (al dan niet succesvol).

Notificaties kunnen los van autorisaties naar ons toe worden gestuurd . Als het gaat om notificaties van het type `TRANSACTION` dienen wij deze goed in de gaten te houden aangezien hier response codes in gemeld kunnen worden die bepalend zijn voor een autorisatie verzoek die bij ons op datzelfde moment in progress is of pas later bij ons binnen komt door netwerk vertragingen.

Als je kijkt naar bovenstaande nofificatie voorbeelden , dan zijn de codes `70` en `75` bepaald door [[Visa]]/[[Enfuce]] zelf. In een dergelijk scenario zullen wij helemaal niet aangeroepen worden  voor een autorisatie omdat de [[Visa]] PIN al incorrect is beoordeeld door [[Visa]]/[[Enfuce]].

De code `00` en `57` zijn feitelijk de codes die wij als [[Intersolve]] hebben terug gemeld na het afhandelen van een authorisatie. Dergelijk notificaties zie je ook pas binnekomen nadat wij de autorisatie hebben gedaan. Hierbij is het TransactionId wat in het notificatie bericht staat te correleren aan het linkId van het autorisatie bericht. Behalve loggen in [[Elastic]] doen wij verder niets met deze notificatie berichten.

Code `91` is wel belangrijk voor ons om op te vangen en vast te leggen, omdat deze code ons vertelt dat [[Enfuce]] de transactie zal afkeuren omdat wij niet of niet tijdig genoeg hebben gereageerd op het bijbehorende autorisatie bericht van de transactie. Hierbij is het `TransactionId` wat in het notificatie bericht staat ook te correleren aan het `linkId` van het autorisatie bericht dat we hebben verwerkt …of nog gaan moeten verwerken.

We zien regelmatig dat wij als Intersolve een autorisatie verzoek met reponsecode `00` hebben teruggemeld , maar dat de tijd die hiervoor nodig was langer duurde dan 1 seconde. Ook is het wel eens gebeurt dat het netwerk tussen [[Enfuce]] en [[Intersolve]] voor vertraging zorgde wat resulteerde dat een autorisatie verzoek vanuit [[Enfuce]] veel later bij [[Intersolve]] ontvangen werd. In dit soort situaties zal [[Enfuce]] besluiten om,  na 1 seconde nadat zij het verzoek hebben uitgestuurd zonder response , de authorisatie zelf af te keuren met reponse code `91` (Issue not responsive). Daarvan sturen zij dan ook een notificatie naar ons toe.

In geval van notificatie reponsecode `91` zal een authorisatie bij Intersolve :

- Geannuleerd moeten worden als we deze wel hebben uitgevoerd
- Niet geaccepteerd (meer) mogen worden als we deze nog niet hadden uitgevoerd.  in de [[0. Payment Instrument|PI]] authorsation webhook zitten controles zover ik weet die rekening houden met een (tussendoor) binnenkomende notificatie `91` om ervoor te zorgen dat de authorisatie wordt afgekeurd voordat deze wordt teruggemeld naar Enfuce.

Ik hoop dat jullie hier zo voldoende aan hebben . We kunnnen dat nog even bespreken als  nog zaken niet duidelijk zijn.