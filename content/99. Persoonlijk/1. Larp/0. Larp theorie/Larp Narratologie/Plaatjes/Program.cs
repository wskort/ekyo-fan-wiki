using System;
using System.IO;
using System.Collections.Generic;

namespace code {
    class Program {
		public static void Main() {
			// Initial setup.
			Stock icc = new Stock(owner:"ICC");
			Stock eo = new Stock(owner:"EO");
			Stock am = new Stock(owner:"AM");
			Stock[] stockList = { icc, eo, am };	
			// This should be complete!
			
			/*  Here are the available log options:
			
			SetDate(stockList, day, month, year=240);
			PrintAll(stockList, target ("console"/"log"/"both"), content="");
			Comment(stockList, comment, time="");
			Stock.Comment(comment, time="");
						
			TransferResources(origin, destination, unu=0, sur=0, dal=0, bla=0, pro=0, bol=0, ami=0, ino=0, son=0, v=true, time="");
			TransferProduct(origin, destination, product, amount=1, preset="EO",time="");
			CommissionProduct(client, supplier, crafter, product, amount=1, payroll=true, preset="EO", time="");
						
			Stock.Update(unu=0, sur=0, dal=0, bla=0, pro=0, bol=0, ami=0, ino=0, son=0, v=true, time=""); 
			Stock.Buy(product, source="", amount=1, price=0, preset="", time="");
			Stock.Sell(product, buyer="", amount=1, price=0, preset="", time="");
			Stock.Craft(product, amount=1, payroll=true, time="");
			
			There are a number of product price presets to choose from:
				"portal"	Import through portal; default for buying.
				"EO"		The set price for EO sales; default for selling.
				"free"		No cost! 
				"raw"		Just material cost (EO resource prices)
				"craft"		Cost of processing your mats by EO employees.   
				"contract" 	Salary for processing our mats by outside contractor. */
			
			
			/*	Eventlog begins here!	*/
			
			am.Update( // This first entry is to preset the initial state of affairs. 
				unu:22, 
				sur:6, 
				dal:34, 
				bla:1, 
				pro:34, 
				bol:2, 
				ami:20, 
				ino:12, 
				son:4000,
				v:false
			); 
			
			// NEW DAY
			setDate(stockList, day:29,month:5);
			// NEW DAY 
			
			Comment(stockList, comment:"EO contingent arrived on Eos.", time:"18:00");
			TransferResources( 
				origin:am, 
				destination:eo,
				unu:22, 
				sur:6, 
				dal:34, 
				bla:1, 
				pro:34, 
				bol:2, 
				ami:20, 
				ino:12, 
				son:3000
			);
			TransferProduct( 
				origin:icc, 
				destination:eo, 
				product:"Armour", 
				amount:3, 
				price:10, 
				time:"19:21"
			);
			eo.Sell(product:"Armour", buyer:"Najat", price:35, time:"19:23");
			eo.Buy(product:"Supply kit", preset:"portal");
			TransferProduct(
				origin:eo, 
				destination:am, 
				product:"Armour", 
				amount:2, 
				preset: "free", 
				time:"20:00"
			);
			eo.Sell(product: "Repair kit", preset: "craft");
			eo.Craft(product:"Medicare (Drug)", time:"testing the length override");
			CommissionProduct(
				client:eo,
				supplier:eo,
				crafter:am,
				product:"Supply kit",
				amount:2,
				payroll:false,
				time:"23:57");
			CommissionProduct(
				client:am,
				supplier:eo,
				crafter:eo,
				product:"Repair kit",
				amount:1,
				preset:"EO",
				time:"00:32"
			);
			
			
			// End of the log.
			
			
			// Console output! 
			PrintAll(stockList, "console", "log");
			eo.PrintProduct("Stim (Drug)");
			
			// Update all text files. 
			PrintAll(stockList, "file");		
		
			static void setDate(Stock[] list, int day, int month, int year=240) {
				foreach (var l in list) {
					l.DateHeader(day, month, year);
				}
			}
			
			static void PrintAll(Stock[] list, string target, string content="") {
				foreach (var l in list) {
					l.PrintAll(target, content);
				}
			}
			
			static void Comment(Stock[] list, string comment="", string time=""){
				foreach (var l in list) {
					l.Comment(comment, time);
				}
			}
			
			static void TransferResources(
				Stock origin, 
				Stock destination, 
				int unu=0, 
				int sur=0, 
				int dal=0, 
				int bla=0, 
				int pro=0, 
				int bol=0, 
				int ami=0, 
				int ino=0, 
				int son=0, 
				bool v=true,
				string time=""
			) {
				// Synchronise watches!
				origin.SetClock(time);
				destination.SetClock(time);
				
				// Attempt to withdraw resources from origin.
				bool result = false;
				origin.Comment($"Transferring resources to {destination.StockOwner}.");
				result = origin.Update(-unu,-sur,-dal,-bla,-pro,-bol,-ami,-ino,-son,v);
				
				// Only add resources to destination upon successful withdrawal.
				if (result) {
					destination.Comment($"Received resources from {origin.StockOwner}.");
					destination.Update(unu,sur,dal,bla,pro,bol,ami,ino,son,v);
				}
				else { 
					destination.Comment($"{origin.StockOwner} failed to transfer resource(s)."); 
				}
			}
			
			static void TransferProduct(
				Stock origin, 
				Stock destination,
				string product, 
				int amount=1, 
				int price=0, 
				string preset="",
				string time=""
			) {
				// Synchronise watches!
				origin.SetClock(time);
				destination.SetClock(time);
				
				// Set price if specified, or use default. 
				if (price==0 && preset=="") { preset = "EO"; }
				price = origin.CheckPrice(product, preset, price);
				
				// Error catching.
				if (amount <= 0) { 
					destination.Comment($"Cannot purchase 0 or less items. Could not buy {amount}x {product}."); 
					return; 
				}
				if (price < 0) { 
					destination.Comment($"Cannot purchase anything for less than 0 SON per item. Could not buy {amount}x {product}."); 
					return; 
				}
				if (destination.Son < amount*price) { 
					destination.Comment($"Insufficient funds to buy {amount}x {product}."); 
					return; 
				}
				
				// Attempt to withdraw product from origin.
				bool result=false;
				if (origin.CID != "ICC") {
					result = origin.Sell(product,destination.CID,amount,price,preset);
				}
				else { result = true; } // ICC has infinite supplies and no separate log.
				
				// Only add products to destination upon successful withdrawal. Transfers to ICC are not logged.
				if (result && destination.CID != "ICC") { destination.Buy(product,origin.CID,amount,price,preset); }
				else { destination.Comment($"{origin.StockOwner} failed to transfer {amount}x {product}."); }
			}
			
			static void CommissionProduct(
				Stock client,
				Stock supplier,
				Stock crafter,
				string product,
				int amount=1,
				int price=0,
				bool payroll=true,
				string preset="EO",
				string time=""
			) {
				// Synchronise watches!
				client.SetClock(time);
				supplier.SetClock(time);
				crafter.SetClock(time);
				
				// Override price if the source is specified.
				price = supplier.CheckPrice(product, preset, price);
				
				// Determine payment for crafter.
				int payment = 0;
				if (!payroll) { payment = crafter.CheckPrice(product, "contract") * amount; }
				
				// Error catching.
				if (amount <= 0) { 
					client.Comment($"Cannot purchase 0 or less items. Could not buy {amount}x {product}."); 
					return; 
				}
				if (price < 0) { 
					client.Comment($"Cannot purchase anything for less than 0 SON per item. Could not buy {amount}x {product}."); 
					return; 
				}
				if (client.Son < amount*price) { 
					client.Comment($"Insufficient funds to buy {amount}x {product}."); 
					return; 
				}
				
				// Attempt to craft product.
				bool result=false;
				if (supplier.CID != "ICC") { result = supplier.Craft(product,amount,payroll); }
				else { result = true; } // ICC has infinite supplies and no separate log.
				
				// Only transfer products to client & pay crafter upon success.
				if (result) { 
					if (client != supplier) { TransferProduct(supplier,client,product,amount,price,preset); }
					
					if (payment>0 && supplier != crafter) {
						supplier.Comment($"Paying {crafter.CID} for their involvement.");
						crafter.Comment($"Worked on commission to make {amount}x {product}.");
						TransferResources(supplier,crafter,son:payment);
					}
					else if (payment>0) {
						supplier.Comment("Paying contractor for their involvement.");
						supplier.Update(son:-payment);
					}
				}
				else { client.Comment($"{supplier.StockOwner} failed to create {amount}x {product}."); }
			}
		}
	}
}