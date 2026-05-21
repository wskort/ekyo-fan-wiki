using System;
using System.Collections.Generic;

namespace code
{	
	public class Product
	{
		// Product information
		public string Name
		{ get; private set; }
		public string Description
		{ get; private set; }
		public string Physrep
		{ get; private set; }
		public string Extra
		{ get; private set; }
		public string Category
		{ get; private set; }
		public int Qty
		{ get; private set; }
		
		// Prices
		public int DefaultPrice
		{ get; private set; }
		public int OurPrice
		{ get; private set; }
		
		// Crafting requirements		
		public string Skill
		{ get; private set; }
		public int SkillLevel
		{ get; private set; }
		
		// Material cost		
		public int MatUnu //Unubtanium
		{ get; private set; }
		public int MatSur //Surilium
		{ get; private set; }
		public int MatDal //Dalium
		{ get; private set; }
		public int MatBla //Blarnium
		{ get; private set; }
		public int MatPro //Propanisatol
		{ get; private set; }
		public int MatBol //Bolinogeen
		{ get; private set; }
		public int MatAmi //Aminoterazine
		{ get; private set; }
		public int MatIno //Inositoprinofaat
		{ get; private set; }
		
		// Initialise product.
		public Product(
			string name = "Unknown", 
			string category = "Unknown",
			string skill = "Varies",
			int skillLevel=0,
			int defaultPrice=0,
			int ourPrice=0,
			int matUnu=0,
			int matSur=0,
			int matDal=0,
			int matBla=0,
			int matPro=0,
			int matBol=0,
			int matAmi=0,
			int matIno=0,
			string description="",
			string physrep="",
			string extra=""
			) {
				Name = name;
				Category = category;
				Skill = skill;
				SkillLevel = skillLevel;
				DefaultPrice = defaultPrice;
				OurPrice = ourPrice;
				MatUnu = matUnu;
				MatSur = matSur;
				MatDal = matDal;
				MatBla = matBla;
				MatPro = matPro;
				MatBol = matBol;
				MatAmi = matAmi;
				MatIno = matIno;
				Description = description;
				Physrep = physrep;
				Extra = extra;
		}
		
		public void BuyProduct(int amount) {
			Qty += amount;
			return;
		}
		
		// Calculate material cost.
		public int MatCost(int perMat=15) {
			int matSum = MatUnu+MatSur+MatDal+MatBla+MatPro+MatBol+MatAmi+MatIno;
			return matSum*perMat;
		}
		
		public string Print(bool EO=false) {
			string text = $"{Name}: ";
			string price;
			if (EO==true) { price = $"{OurPrice} SON"; } else { price = $"{DefaultPrice} SON"; } 
			while (text.Length < (42-price.Length)) {
				text = $"{text} ";
			}
			text = $"{text}{price}";
			if (Qty>0) {
				text = $"{text} ({Qty} in stock) ";
			} 
			else {
				text = $"{text}              ";
			}
			return text;
		}
	}
}