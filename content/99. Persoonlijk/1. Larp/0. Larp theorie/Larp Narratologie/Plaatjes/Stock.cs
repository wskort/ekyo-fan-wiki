using System;
using System.IO;
using System.Collections.Generic;

namespace code {	
	public class Stock {
		// Resource counters
		public int Unu //Unubtanium
		{ get; private set; }		
		public int Sur //Surilium
		{ get; private set; }		
		public int Dal //Dalium
		{ get; private set; }		
		public int Bla //Blarnium
		{ get; private set; }		
		public int Pro //Propanisatol
		{ get; private set; }		
		public int Bol //Bolinogeen
		{ get; private set; }		
		public int Ami //Aminoterazine
		{ get; private set; }		
		public int Ino //Inositoprinofaat
		{ get; private set; }		
		public int Son //Sonuren
		{ get; private set; }
		
		// Log data
		public string Log
		{ get; private set; }
		public string Clock
		{ get; private set; }
		
		// Corp-level data
		public string StockOwner
		{ get; private set; }
		public string CID
		{ get; private set; }
		public Roster Corp
		{ get; private set; }
		
		public List<Product> productList = new List<Product>();		
		
		// Initialise a stock record with starting values, product list and staff.
		public Stock(int unu=0, int sur=0, int dal=0, int bla=0, int pro=0, int bol=0, int ami=0, int ino=0, int son=0, string owner="EO") {
			this.Update(unu,sur,dal,bla,pro,bol,ami,ino,son,v:false);
			switch (owner) {
				case "EO":
					StockOwner = "Executive Outcomes";
					CID = "EO";
					break;
				case "AM":
					StockOwner = "Aquilan Military";
					CID = "AM";
					break;
				case "ICC":
					StockOwner = "Portal";
					CID = "ICC";
					break;
				default:
					StockOwner = owner;
					CID = owner; 
					break;
			}
			Log = $" ---------------\n {StockOwner}'s Logfile\n ---------------\n";
			this.InitProducts();
			if (CID != "ICC") { Corp = new Roster(owner); }
		}
		
		// Populate the initial the product list.
		private void InitProducts() {
			// Goods
			productList.Add(new Product(
				name:"Supply kit",
				category: "Goods",
				skill:"Engineer",
				skillLevel:3,
				defaultPrice:40,
				ourPrice:30,
				matUnu:1,
				matPro:1,
				description:"Bevoorrading nodig voor het leven op de kolonie. Een typische bevoorrading bevat allerhande dingen die een kolonist in het dagelijkse leven nodig heeft, van voedselrantsoenen tot diverse veel gebruikte gereedschappen en simpele reserveonderdelen.",
				physrep:"Een kit met daarin voedselrantsoenen en kleine gereedschappen, survival kit, etc"
			));
			productList.Add(new Product(
				name:"Energy cell",
				category: "Goods",
				skill:"Chemist",
				skillLevel:3,
				defaultPrice:200,
				ourPrice:150,
				matBol:2,
				description:"Een energy cell is een draagbare krachtige batterij die in korte tijd zeer veel energie kan leveren aan diverse apparaten in het veld. Energycells worden gebruikt om schildgeneratoren van kracht te voorzien. Een vaardig ingenieur kan ook andere projecten van energie voorzien met een energy cell.",
				physrep:"Een accu of battery pack die aan een schildgenerator gekoppeld kan worden. Een enkele energy cell is ongeveer ter grote van je vuist.",
				extra: "Gebruikte energy cells verliezen hun waarde en kunnen niet overnieuw opgeladen worden. Lever de kaartjes van gebruikte energy cells in."
			));
			productList.Add(new Product(
				name:"Repair kit",
				category: "Goods",
				skill:"Engineer",
				skillLevel:3,
				defaultPrice:200,
				ourPrice:150,
				matUnu:1, 
				matPro:1,
				description:"Een repair kit is een handige verzameling van veel gebruikte reserveonderdelen, een breed scala aan draden en diverse elektronische onderdelen. In combinatie met een paar busjes snel uithardende lijmen en polymeer schuimen en de onmisbare rol hitte bestendige tape, is het voor een ingenieur mogelijk om met een repair kit kleine apparaten en voorwerpen te repareren.\nEen vaardig ingenieur kan ook andere toepassingen hebben voor een repair kit, zoals noodreparaties.",
				physrep:"Een gereedschapskist met diverse technische onderdelen, zoals printplaten, draadjes, schroefjes en moertjes en klein gereedschap om het te assembleren.",
				extra: "Hoewel een repair kit een breed scala aan diverse types reserve onderdelen bevat, gebruikt je 1 repair kit per reparatie, ongeacht wat voor type voorwerp je repareert. Lever de kaartjes van gebruikte repair kits in."
			));
										
			// Medicine
			productList.Add(new Product(
				name:"Stim (Drug)",
				category: "Medicine",
				skill:"Chemist",
				skillLevel:5,
				defaultPrice:200,
				ourPrice:180,
				matDal:1, 
				matAmi:1,
				description:"Een stim is een medische cocktail van bloedstollers, pijnstillers, hormonen en kunstmatige adrenaline. Een stim herstelt tijdelijk (tot de volgende maaltijd) 2hp op een persoon. Een gemiddeld persoon kan 1 stim per dag aan, maar dit kan verhoogd worden door de vaardigheid uithoudingsvermogen.",
				physrep:"Een injectiespuit of medisch ampul met daarin een vloeistof.",
				extra: "Zodra je over je daglimiet van stims heen gaat, val je na 10 minuten bewusteloos aan een overdosis en zal een arts je moeten helpen."
			));
			productList.Add(new Product(
				name:"Hybernation (Drug)",
				category: "Medicine",
				skill:"Chemist",
				skillLevel:7,
				defaultPrice:400,
				ourPrice:340,
				matDal:1, 
				matAmi:1,
				description:"Dit exotische medicijn zorgt ervoor dat je gedurende 10 minuten klinisch dood lijkt. Je lichaam bloedt niet verder, en giffen hebben geen invloed. Je hebt geen meetbare hartslag en je wordt niet geregistreerd door sensoren die levensvormen kunnen detecteren.",
				physrep:"Een injectiespuit of medisch ampul met daarin een vloeistof.",
				extra: "Gedurende de 10 minuten dat je klinisch dood lijkt, kan je niets anders doen dan doodstil liggen."
			));
			productList.Add(new Product(
				name:"Medicare (Drug)",
				category: "Medicine",
				skill:"Chemist",
				skillLevel:7,
				defaultPrice:500,
				ourPrice:355,
				matPro:2, 
				matAmi:1,
				description:"De combinatie van bloedstollers en en diverse pijnstillers hebben op het eerste oog wat weg van stims, maar de medicare cocktail is veel milder voor de patiënt en heeft veel minder extreme bijwerkingen. Vanaf het toedienen van dit medicijn, stopt het doodbloeden voor 10 minuten.",
				physrep:"Een injectiespuit of medisch ampul met daarin een vloeistof.",
				extra: "Als het medicijn uitgewerkt is na 10 minuten, gaat het doodbloeden verder waar het gebleven is."
			));
			productList.Add(new Product(
				name:"Antibiotics (Drug)",
				category: "Medicine",
				skill:"Chemist",
				skillLevel:3,
				defaultPrice:400,
				ourPrice:180,
				matPro:1,
				matBol:2,
				matAmi:1,
				description:"Antibiotica komt in diverse soorten, maar degene die in kolonies en op slagvelden het meest voorkomt is de breedspectrum variant die effectief is tegen zowat alle bacteriële infecties. Deze medicatie wordt gebruikt om acute bacteriologische ziektes te bestrijden.",
				physrep:"Een injectiespuit of medisch ampul met daarin een vloeistof.",
				extra: "Werkt niet tegen virale ziektes."
			));
			productList.Add(new Product(
				name:"Antitoxin, radiation (Drug)",
				category: "Medicine",
				skill:"Chemist",
				skillLevel:3,
				defaultPrice:500,
				ourPrice:195,
				matSur:1,
				matPro:3,
				matAmi:1,
				description:"Straling ligt altijd op de loer in de buurt van grote generatoren en op ruimteschepen. Deze antitoxine helpt zowel bij chronische als bij acute stralingsziekte. Hoewel het niet de schade geneest die al reeds gedaan is, is het wel de eerste stap bij het behandelen van stralingsziekte.",
				physrep:"Een injectiespuit of medisch ampul met daarin een vloeistof.",
				extra: "Antitoxines werken alleen tegen een specifieke vergif, in dit geval radioactief materiaal en radioactieve straling."
			));
			productList.Add(new Product(
				name:"Antitoxin, Cholinesterase (Drug)",
				category: "Medicine",
				skill:"Chemist",
				skillLevel:3,
				defaultPrice:500,
				ourPrice:195,
				matSur:2,
				matAmi:1,
				matIno:2,
				description:"Daar er bij acute vergiftiging vaak te weinig tijd is om de precieze herkomst van de giffen te herleiden, is cholinesterase op de markt gebracht. Deze antitoxine wordt gebruikt als behandeling tegen neurotoxines, apoptose vergiftiging en zware metalen vergiftiging. Alles wat men zo op zou kunnen lopen in een industriële omgeving.",
				physrep:"Een injectiespuit of medisch ampul met daarin een vloeistof.",
				extra: "Antitoxines werken alleen tegen een specifieke vergif, in dit geval chemische giffen."
			));
										
			// Tools
			productList.Add(new Product(
				name:"Drill",
				category: "Tools",
				skill:"Engineer",
				skillLevel:3,
				defaultPrice:400,
				ourPrice:180,
				matUnu:1,
				matSur:1,
				matDal:2,
				description:"Een drill is het gereedschap wat je in staat stelt om geologische grondstoffen te delven. Geologische drills zijn een losse verzamelterm voor al het industriële gereedschap wat gebruikt wordt om grondstoffen, vaak met bruut geweld, uit de grond te kunnen winnen.",
				physrep:"Een pneumatische hamer, automatisch pikhouweel of ander groot stuk gereedschap geschikt om mijnschachten te graven. De drill is draagbaar door een enkel persoon, maar is te onhandig om effectief in een gevecht te gebruiken.",
				extra: "Geologische bots kunnen uitgerust worden met dit gereedschap."
			));
			productList.Add(new Product(
				name:"Mech tool",
				category: "Tools",
				skill:"Engineer",
				skillLevel:4,
				defaultPrice:600,
				ourPrice:250,
				matUnu:1,
				matSur:2,
				matDal:2,
				matPro:1,
				description:"De gereedschappen die een ingenieur nodig kan hebben, zijn talrijk en divers. De ontwikkeling van de veelzijdige mech-tools heeft ervoor gezorgd dat geen monteur of ingenieur ooit nog het probleem heeft van niet het juiste gereedschap bij de hand te hebben.Een Mech Tool is het gereedschap wat je in staat stelt om mechanische handelingen van de vaardigheid ingenieur te gebruiken.",
				physrep:"Mech-tools zijn erg divers en verschillen per factie. Uiteenlopend van een gereedschapskoffer met allerhande verschillende bijeengeraapte gereedschappen, tot plasma schroevendraaiers met een paar dozijn accessoires en extra functies.",
				extra: "<VOORSTEL CvK>: Een beginnend personage met ten minste level x ingenieur krijgt de keuze om te starten met een Tech Tool of een Mech Tool."
			));
			productList.Add(new Product(
				name:"Tech tool",
				category: "Tools",
				skill:"Engineer",
				skillLevel:3,
				defaultPrice:600,
				ourPrice:210,
				matUnu:1,
				matSur:2,
				matDal:2,
				matPro:1,
				description:"De gereedschappen die een ingenieur nodig kan hebben, zijn talrijk en divers. De ontwikkeling van de veelzijdige tech-tools heeft ervoor gezorgd dat geen monteur of ingenieur ooit nog het probleem heeft van niet het juiste gereedschap bij de hand te hebben.Een Tech Tool is het gereedschap wat je in staat stelt om mechanische handelingen van de vaardigheid ingenieur te gebruiken.",
				physrep:"Tech-tools zijn erg divers en verschillen per factie. Uiteenlopend van een gereedschapskoffer met allerhande verschillende bijeengeraapte gereedschappen, tot plasma schroevendraaiers met een paar dozijn accessoires en extra functies.",
				extra: "<VOORSTEL CvK>: Een beginnend personage met ten minste level x ingenieur krijgt de keuze om te starten met een Tech Tool of een Mech Tool."
			));
										
			// Melee weapons
			productList.Add(new Product(
				name:"Short weapon: 'Falcata'",
				category: "Melee weapons",
				skill:"Engineer",
				skillLevel:1,
				defaultPrice:400,
				ourPrice:100,
				matUnu:2,
				matSur:2,
				description:"Een kort melee wapen van maximaal 45 cm lang. Er gaat niets boven een goed stuk scherp staal tussen jou en de vijand, en dit soort korte wapens kunnen het verschil tussen leven en dood betekenen.",
				physrep:"Een veilig LARP wapen van maximaal 45 cm lang totaal ( incluis handvat).",
				extra: "Dit korte wapen mag je gebruiken als je tenminste niveau 1 hebt in de vaardigheid melee."
			));
			productList.Add(new Product(
				name:"Mid weapon: 'Spathae'",
				category: "Melee weapons",
				skill:"Engineer",
				skillLevel:3,
				defaultPrice:400,
				ourPrice:180,
				matUnu:1,
				matSur:1,
				matDal:2,
				description:"Een gemiddeld lang melee wapen van maximaal 85 cm lang. De perfecte combinatie van dodelijk en wendbaar, dit type wapens is door de kortere lengte erg populair bij mariniers, die in de nauwe gangen van ruimteschepen langere wapens nauwelijks effectief kunnen gebruiken.",
				physrep:"Een veilig Larp-wapen van maximaal 85 cm lang totaal (incluis handvat).",
				extra: "Dit middellange wapen mag je gebruiken als je tenminste niveau 2 hebt in de vaardigheid melee."
			));
			productList.Add(new Product(
				name:"Long weapon: 'Bastard'",
				category: "Melee weapons",
				skill:"Engineer",
				skillLevel:4,
				matUnu:2,
				matSur:2,
				matDal:2,
				description:"Een van de meest traditionele verschijningsvormen van het zwaard, en deze blijft ongekend populair. Dit melee wapen van maximaal 115 cm lang is een wapen wat veel in formele duels gebruikt wordt, maar ook op het slagveld is het terug te vinden als bijvoorbeeld officier wapen.",
				physrep:"Een veilig Larp-wapen van maximaal 115 cm lang totaal (incluis handvat).",
				extra: "Dit lange wapen mag je gebruiken als je tenminste niveau 3 hebt in de vaardigheid melee."
			));
			productList.Add(new Product(
				name:"Two-handed weapon: 'Claymore'",
				category: "Melee weapons",
				skill:"Engineer",
				skillLevel:5,
				matUnu:1,
				matPro:1,
				description:"In de lijn “Bigger is better” zijn tweehandige wapens in de handen van een vaardig gebruiker uitermate dodelijk. Een tweehandig melee wapen is maximaal 160 cm lang en moet met twee handen worden gebruikt. Het grotere bereik van dit wapen geeft de gebruiker een duidelijke voorsprong op de tegenstander.",
				physrep:"Een veilig Larp-wapen van maximaal 160 cm lang totaal (incluis handvat) welke met twee handen gehanteerd moet worden.",
				extra: "Dit tweehandige wapen mag je gebruiken als je tenminste niveau 4 hebt in de vaardigheid melee."
			));
			productList.Add(new Product(
				name:"Staff weapon",
				category: "Melee weapons",
				skill:"Engineer",
				skillLevel:5,
				defaultPrice:600,
				ourPrice:290,
				matUnu:1,
				matSur:1,
				matDal:2,
				matBla:1,
				matIno:1,
				description:"Stafwapens zijn zowel de moeilijkst te gebruiken melee wapens en tegelijk ook de meest dodelijke in de handen van een meester. Een stafwapen is een melee wapen van maximaal 250 cm lang.",
				physrep:"Een Larp-veilig wapen van maximaal 250 cm lang totaal, welke met twee handen gehanteerd moet worden.",
				extra: "Een stafwapen mag je gebruiken als je tenminste niveau 5 hebt in de vaardigheid melee."
			));
										
			// Firearms
			productList.Add(new Product(
				name:"Pistol",
				category: "Firearms",
				skill:"Engineer",
				skillLevel:1,
				defaultPrice:300,
				ourPrice:85,
				matUnu:2,
				matSur:1,
				description:"Een pistool is een niet automatisch vuurwapen met een magazijn van 1-3 patronen. Pistolen zijn de kleinste categorie vuurwapens. Wat ze missen in magazijn formaat en effectief bereik maken ze goed in compact formaat.",
				physrep:"Een geverfd Nerf wapen met een maximaal magazijn van 3 patronen."
			));
			productList.Add(new Product(
				name:"Revolver",
				category: "Firearms",
				skill:"Engineer",
				skillLevel:3,
				defaultPrice:400,
				ourPrice:180,
				matUnu:1,
				matSur:1,
				matDal:2,
				description:"Een revolver is een niet geautomatiseerd vuurwapen met een magazijn van maximaal 8 kogels.",
				physrep:"Een geverfd Nerf wapen met een magazijn van maximaal 8 patronen. Nerf wapens met een los magazijn zijn ook toegestaan.",
				extra:"Dit wapen kan geupgrade worden om automatisch of semi-automatisch te worden."
			));
			productList.Add(new Product(
				name:"Rifle",
				category: "Firearms",
				skill:"Engineer",
				skillLevel:3,
				defaultPrice:600,
				ourPrice:210,
				matUnu:2,
				matSur:2,
				matDal:2,
				description:"Het geweer was vroeger de ruggengraat van het moderne leger, en hoewel automatische versies veel meer vuurkracht geven aan de infanterist, is het veel goedkopere geweer zeker nog niet uitgefaseerd. Een geweer is een niet automatisch vuurwapen met een magazijn van maximaal 18 kogels.",
				physrep:"Een geverfd nerf wapen met een magazijn van maximaal 18 kogels.",
				extra:"Dit wapen kan geupgrade worden om automatisch of semi-automatisch te worden."
			));
			productList.Add(new Product(
				name:"Carbine",
				category: "Firearms",
				skill:"Engineer",
				skillLevel:3,
				defaultPrice:600,
				ourPrice:210,
				matUnu:1,
				matSur:1,
				matDal:6,
				description:"Een karabijn is een niet geautomatiseerd vuurwapen met een magazijn van maximaal 26 kogels. Karabijnen zijn verkorte versies van geweren, die tegenwoordig vooral gebruikt worden door wetshandhavers en mariniers. De kortere loop van een karabijn maakt het wapen veel wendbaarder en bruikbaarder in krappe ruimtes of in stedelijke omgevingen.",
				physrep:"Een geverfd nerf wapen met een magazijn van maximaal 26 kogels.",
				extra:"Dit wapen kan geupgrade worden om automatisch of semi-automatisch te worden."
			));
			productList.Add(new Product(
				name:"Machine gun",
				category: "Firearms",
				skill:"Engineer",
				skillLevel:4,
				defaultPrice:600,
				ourPrice:250,
				matUnu:1,
				matSur:1,
				matDal:2,
				matBla:1,
				description:"Een niet automatisch vuurwapen met een magazijn van maximaal 35 kogels.",
				physrep:"Een geverfd Nerf wapen met een magazijn van maximaal 35 kogels.",
				extra:"Dit wapen kan geupgrade worden om automatisch of semi-automatisch te worden."
			));
									
			// Protection
			productList.Add(new Product(
				name:"Armour",
				category: "Protection",
				skill:"Engineer",
				skillLevel:3,
				defaultPrice:400,
				ourPrice:180,
				matDal:4,
				description:"Een harnas beschermt de drager tegen letsel, en moderne harnassen zijn gemaakt van de sterkste materialen om dit te bewerkstelligen. Een harnas geeft beschermingspunten (AP), afhankelijk van de vaardigheid in bescherming. Het extra gewicht van een harnas kan vrij bewegen echter bemoeilijken.",
				physrep:"Een harnas bestaat uit verschillende delen, en deze verzameling voor alle lichaamsdelen telt als een enkel harnas. Kogelvrije vesten, keramische platen en exo-skeletten met beplating tellen alleen als harnas.",
				extra:"Een harnas kan gerepareerd worden met een repair kit."
			));
									
			// Upgrades
			productList.Add(new Product(
				name:"Gun reload semi-automization",
				category: "Upgrade",
				defaultPrice:500,
				matUnu:1, 
				matSur:2,
				matDal:1,
				matPro:1,
				description:"Dit proces laat toe van een wapen semi-automatisch te maken. De nodige level om dit uit te voeren = de level om het basis wapen te maken + 1 levels.",
				physrep:"Je moet het wapen zelf OC kunnen voorzien.",
				extra:"Tijdens de crafting procedure moet je naast het gebruik van de grondstoffen ook een  te modificeren vuurwapen verwerken."
			));
			productList.Add(new Product(
				name:"Gun reload automization",
				category: "Upgrade",
				defaultPrice:700,
				matUnu:2, 
				matSur:3,
				matDal:1,
				matPro:1,
				description:"Dit proces laat toe van een wapen volautomatisch te maken. De nodige level om dit uit te voeren = de level om het basis wapen te maken + 2 levels.",
				physrep:"Je moet het wapen zelf OC kunnen voorzien.",
				extra:"Tijdens de crafting procedure moet je naast het gebruik van de grondstoffen ook een  te modificeren vuurwapen verwerken."
			));
		}
		
		// Prepare stock values for printing.
		public override string ToString() {
			string snippet;
			string text = $" ---------------\n {StockOwner}'s Stock inventory\n ---------------\n";
			snippet = LeadingSpace($"{Unu}");
			text = $"{text} {snippet}x Unubtanium\n";
			snippet = LeadingSpace($"{Sur}");
			text = $"{text} {snippet}x Surilium\n";
			snippet = LeadingSpace($"{Dal}");
			text = $"{text} {snippet}x Dalium\n";
			snippet = LeadingSpace($"{Bla}");
			text = $"{text} {snippet}x Blarnium\n";
			snippet = LeadingSpace($"{Pro}");
			text = $"{text} {snippet}x Propanisatol\n";
			snippet = LeadingSpace($"{Bol}");
			text = $"{text} {snippet}x Bolinogeen\n";
			snippet = LeadingSpace($"{Ami}");
			text = $"{text} {snippet}x Aminoterazine\n";
			snippet = LeadingSpace($"{Ino}");
			text = $"{text} {snippet}x Inositoprinofaat\n";
			text = $"{text} ---------------\n";
			foreach (var product in this.productList) {
				if (product.Qty>0) { 
					snippet = LeadingSpace($"{product.Qty}");
					text = $"{text} {snippet}x {product.Name}\n"; 
				}
			}
			text = $"{text} ---------------\n {Son} Sonuren\n";
			
			return text;
		}
		
		// Small formatting tool.
		public string LeadingSpace(string text, int maxLength=3) {
			while (text.Length < maxLength)
			{ text = $" {text}"; }
			return text;
		}
		
		// Log dateheader.
		public void DateHeader(int day, int month, int year=240) {
			Log = $"{Log} ---------------\n Log for {day}/{month} {year}NT\n ---------------\n"; 
			SetClock("09:00");
		}
		
		// Return list of products and our price for each. 
		public string PriceList() {
			string priceList=$" ---------------\n {StockOwner}'s Price list\n ---------------";
			foreach (var product in this.productList) {
				if (CID == "EO") { 
					priceList = $"{priceList}\n {product.Print(true)}(max +{XMore(product.Name)})";
				} 
				else { priceList = $"{priceList}\n {product.Print()}"; }
			}
			priceList = $"{priceList}\n";
			return priceList;
		}
		
		// Print all files to the console and/or a separate .txt file
		public void PrintAll(string target="both", string content="") {
			if (content == "prices" || content=="") {
				PrintPriceList(target);
			}
			if (content == "roster" || content=="") {
				if (CID!="ICC") { Corp.PrintStaff(target); }
			}
			if (content == "log" || content=="") {
				if (CID!="ICC") { PrintLog(target); }
			}
			if (content == "inventory" || content=="") {
				PrintStock(target);
			}
		}
		
		// Print the stock inventory to the console and/or a separate .txt file
		public void PrintStock(string target="both") {
			// Error catching: Portal doesn't get a stocklist.
			if (StockOwner == "Portal") { return; }
			
			// Write to file.
			if (target == "file" || target == "both") {
				string fileName = $"{CID}_StockInventory.txt";
				using (StreamWriter sw = new StreamWriter(fileName)) 
					{ sw.WriteLine(this); }
			}
			// Write to console.
			if (target == "console" || target == "both") {
				Console.WriteLine(this); 
			}
		}
		
		// Print the price list to the console and/or a separate .txt file
		public void PrintPriceList(string target="both") {
			// Error catching: Only EO and the portal get a price list.
			if (CID != "EO" && CID != "ICC") { return; }
			
			// Write to file.
			if (target == "file" || target == "both") {
				string fileName = $"{CID}_PriceList.txt";
				using (StreamWriter sw = new StreamWriter(fileName)) 
					{ sw.WriteLine(this.PriceList()); }
			}
			// Write to console.
			if (target == "console" || target == "both") {
				Console.WriteLine(this.PriceList()); 
			}
		}
		
		// Print the logfile to the console and/or a separate .txt file
		public void PrintLog(string target="both") {
			// Error catching: Portal doesn't get a logfile.
			if (StockOwner == "Portal") { return; }

			// Write to file.
			if (target == "file" || target == "both") {
				string fileName = $"{CID}_LogFile.txt";
				using (StreamWriter sw = new StreamWriter(fileName)) 
					{ sw.WriteLine(this.Log); }
			}
			// Write to console.
			if (target == "console" || target == "both") {
				Console.WriteLine(this.Log); 
			}
		}
		
		// Print a full description and list of capable crafters for a specific product.
		public void PrintProduct(string product, string target="console") {
			
			// Write to console.
			if (target == "console" || target == "both") {
				foreach (var item in this.productList) {
					if (item.Name == product) {
						int xMore=XMore(product);					
						Console.WriteLine($" ---------------\n {item.Name} ({item.Category}), {item.Skill} {item.SkillLevel}");
						Console.WriteLine($" {StockOwner} has {item.Qty} in stock and has enough resources to make {xMore} more.");
						Console.WriteLine($" ---------------\n {item.Description}\n {item.Physrep}\n {item.Extra}");
						Corp.PrintStaff("console", item.Skill, item.SkillLevel);
					}
				}
			}
		}
		
		public int XMore (string product) {
			foreach (var item in this.productList) {
				if (item.Name == product) {
					List<int> array = new List<int>();
					if (item.MatUnu>0) { array.Add(Unu/item.MatUnu); }
					if (item.MatSur>0) { array.Add(Sur/item.MatSur); }
					if (item.MatDal>0) { array.Add(Dal/item.MatDal); }
					if (item.MatBla>0) { array.Add(Bla/item.MatBla); }
					if (item.MatPro>0) { array.Add(Pro/item.MatPro); }
					if (item.MatBol>0) { array.Add(Bol/item.MatBol); }
					if (item.MatAmi>0) { array.Add(Ami/item.MatAmi); }
					if (item.MatIno>0) { array.Add(Ino/item.MatIno); }
					int min=9999;
					foreach (var n in array) { 
						if (n<min) { min = n; }
					}
					if (min == 9999) { min = 0; }
					return min;
				}
			}
			return 0;
		}
		
		// Override price if the source is specified.
		public int CheckPrice(string product, string preset, int price=0) {
			if (preset!="") {
				foreach (var item in this.productList) {
					if (product == item.Name) { 
						switch (preset) {
							case "EO":
								price = item.OurPrice; 
								break;
							case "portal":
								price = item.DefaultPrice;
								break;
							case "free":
								price = 0;
								break;
							case "raw":
								price = item.MatCost();
								break;
							case "craft":
								price = item.OurPrice - item.MatCost();
								break;
							case "contract":
								price = item.SkillLevel*10;
								break;
							default:
								break;
						}
					}
				}
			}
			return price;
		}
		
		// Update resource values.
		public bool Update(int unu=0, int sur=0, int dal=0, int bla=0, int pro=0, int bol=0, int ami=0, int ino=0, int son=0, bool v=true, string time="") {			
			// Update clock.
			SetClock(time);
			
			// Error catching: first check for sufficient resources.
			if (
				Unu+unu < 0 || 
				Sur+sur < 0 || 
				Dal+dal < 0 ||
				Bla+bla < 0 ||
				Pro+pro < 0 ||
				Bol+bol < 0 ||
				Ami+ami < 0 ||
				Ino+ino < 0 ||
				Son+son < 0
			) {
				Comment("Insufficient resources to process order.");
				return false;
			}
			
			
			// Update the stock values.
			Unu += unu;
			Sur += sur;
			Dal += dal;
			Bla += bla;
			Pro += pro;
			Bol += bol;
			Ami += ami;
			Ino += ino;
			Son += son;
			if (v == true) {					// v = verbose mode.
				Comment("Updated stock records as follows:");
				if (unu>0) { Comment($" * {unu} Unubtanium added", blank:true); }
				if (unu<0) { Comment($" * {-unu} Unubtanium removed.", blank:true); }
				if (sur>0) { Comment($" * {sur} Surilium added.", blank:true); }
				if (sur<0) { Comment($" * {-sur} Surilium removed.", blank:true); }
				if (dal>0) { Comment($" * {dal} Dalium added.", blank:true); }
				if (dal<0) { Comment($" * {-dal} Dalium removed.", blank:true); }
				if (bla>0) { Comment($" * {bla} Blarnium added.", blank:true); }
				if (bla<0) { Comment($" * {-bla} Blarnium removed.", blank:true); }
				if (pro>0) { Comment($" * {pro} Propanisatol added.", blank:true); }
				if (pro<0) { Comment($" * {-pro} Propanisatol removed.", blank:true); }
				if (bol>0) { Comment($" * {bol} Bolinogeen added.", blank:true); }
				if (bol<0) { Comment($" * {-bol} Bolinogeen removed.", blank:true); }
				if (ami>0) { Comment($" * {ami} Aminoterazine added.", blank:true); }
				if (ami<0) { Comment($" * {-ami} Aminoterazine removed.", blank:true); }
				if (ino>0) { Comment($" * {ino} Inositoprinofaat added.", blank:true); }
				if (ino<0) { Comment($" * {-ino} Inositoprinofaat removed.", blank:true); }
				if (son>0) { Comment($" * {son} Sonuren added.", blank:true); }
				if (son<0) { Comment($" * {-son} Sonuren removed.", blank:true); }
			}
			return true;
		}
		
		// Purchase {amount}x {product} for {price} each. 
		public bool Buy(string product, string source="", int amount=1, int price=0, string preset="", string time="") {
			// Update clock.
			SetClock(time);
			
			// Set price if specified, or use default. 
			if (price==0 && preset=="") { preset = "portal"; }
			price = CheckPrice(product, preset, price);
			
			// Error catching.
			if (amount <= 0) { 
				Comment($"Cannot purchase 0 or less items. Could not buy {amount}x {product}."); 
				return false; 
			}
			if (price < 0) { 
				Comment($"Cannot purchase anything for less than 0 SON per item. Could not buy {amount}x {product}."); 
				return false; 
			}
			if (Son < amount*price) { 
				Comment($"Insufficient funds to buy {amount}x {product}."); 
				return false; 
			}
			
			// Cycle through the productlist and process payment upon success. Log result.
			foreach (var item in this.productList) {
				if (product == item.Name) {// Only request purchase if the name matches.
					// Process & report purchase.
					item.BuyProduct(amount);
					Son -= amount*price;
					string presetLog="";
					if (preset !="") {presetLog = $" (preset \"{preset}\")";}
					string sourceLog="";
					if (source!="") {sourceLog = $" from {source}";}
					Comment($"Bought {amount}x {product}{sourceLog} for {price} SON each{presetLog}.");
					return true;  
				}
			}
			
			// Report unsuccessful purchase.
			Comment($"Could not buy {amount}x {product}.");
			return false;
		}
		
		// Sell {amount}x {product} for {price} each. 
		public bool Sell(string product, string buyer="", int amount=1, int price=0, string preset="", string time="") {
			// Update clock.
			SetClock(time);
			
			// Set price if specified, or use default. 
			if (price==0 && preset=="") { preset = "EO"; }
			price = CheckPrice(product, preset, price);
			
			// Error catching.
			if (amount <= 0) 
			{ Comment($"Cannot sell 0 or less items. Could not sell {amount}x {product}."); return false; }
			if (price < 0)
			{ Comment($"Cannot sell for less than 0 SON per item. Could not sell {amount}x {product}."); return false; }
			
			// Cycle through the productlist to find the right item.
			foreach (var item in this.productList) {
				if (product == item.Name) { // Only sell if the name matches.
					// Error catching.
					if ( item.Qty < amount) 
					{ Comment($"Not enough {product} to sell {amount}."); return false; }
					
					// Process & report sale.
					item.BuyProduct(-amount);
					Son += amount*price;
					string presetLog = "";
					string buyerLog="";
					if (buyer!="") {buyerLog = $" to {buyer}";}
					if (preset !="") {presetLog = $" (preset \"{preset}\")";}
					Comment($"Sold {amount}x {product}{buyerLog} for {price} SON each{presetLog}.");
					return true;
				}
			}
			
			// Report unsuccessful sale
			Comment($"Could not sell {amount}x {product}.");
			return false;
		}
		
		// Craft {amount}x {product} using resources from storage.
		public bool Craft(string product, int amount=1, bool payroll=true, string time="") {
			// Update clock.
			SetClock(time);
			
			// Error catching;
			if (amount <= 0)
			{ Comment($"Cannot craft 0 or less items. Could not craft {amount}x {product}."); return false; }
			
			// Cycle through the productlist to find the right item.
			foreach (var item in this.productList) {
				if (product == item.Name) { // Only craft if the name matches.
					// Set crafting cost for contractor. 
					int craftCost = 0;
					if (payroll == false) 
					{ craftCost = CheckPrice(product, "contract"); }
				
					// Error catching.
					if ( 
						Unu < item.MatUnu *amount ||
						Sur < item.MatSur *amount ||
						Dal < item.MatDal *amount ||
						Bla < item.MatBla *amount ||
						Pro < item.MatPro *amount ||
						Bol < item.MatBol *amount ||
						Ami < item.MatAmi *amount ||
						Ino < item.MatIno *amount ||
						Son <   craftCost *amount )
					{ Comment($"Insufficient resources to make {amount}x {product}."); return false; }
					
					// Process & report product creation.
					this.Update(
						-item.MatUnu *amount, 
						-item.MatSur *amount,
						-item.MatDal *amount,
						-item.MatBla *amount,
						-item.MatPro *amount,
						-item.MatBol *amount,
						-item.MatAmi *amount,
						-item.MatIno *amount,
						-craftCost   *amount,
						time:time);
					item.BuyProduct(amount);
					string payrollLog = "";
					if (payroll == false) { payrollLog = $" for {craftCost} Son each"; }
					Comment($"Created {amount}x {product} from the materials above{payrollLog}.", blank:true);
					return true;
				}
			}
			
			// Report crafting failure.
			Comment($"Could not craft {amount}x {product}.");
			return false;
		}
		
		// Set time on clock
		public void SetClock(string time="") {
			if (time.Length == 5) { Clock = time; }
		}
		
		// Insert timestamp.
		public void TimeStamp(string time="", bool blank=false) {
			SetClock(time);
			if (blank==false) { Log = $"{Log} {Clock}  "; }
			else { Log = $"{Log}        "; }
		}
		
		// Add comment to logfile.
		public void Comment(string comment="", string time="", bool blank=false) {
			TimeStamp(time, blank);
			Log = $"{Log}{comment}\n";
		}
		
		
	}
}