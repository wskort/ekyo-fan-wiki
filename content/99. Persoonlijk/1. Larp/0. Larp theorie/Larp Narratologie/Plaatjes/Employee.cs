using System;
using System.Collections.Generic;

namespace code
{	
	public class Employee
	{
		public string Name
		{ get; private set; }
		public string OC
		{ get; private set; }
		public string Faction
		{ get; private set; }
		public string Corp
		{ get; private set; }
		public bool IsOnPayroll
		{ get; private set; }
		public int EngineerLevel
		{ get; private set; }
		public int ChemistLevel
		{ get; private set; }
		public int GeologistLevel
		{ get; private set; }
		
		// Initialise employee record.
		public Employee(
			string name = "Unknown", 
			string faction = "",
			string corp = "Unknown",
			string oc = "Unknown",
			bool payroll = false,
			int engineer = 0,
			int chemist = 0,
			int geologist = 0
			) {
				Name = name;
				Corp = corp;
				OC = oc;
				EngineerLevel = engineer;
				ChemistLevel = chemist;
				GeologistLevel = geologist;
				IsOnPayroll = payroll;
				
				// If 'corp' is EO, set payroll to true.
				if (Corp == "EO") { IsOnPayroll = true; }
				
				// If 'faction' is not one of the known factions, set to 'Unknown'.
				Faction = faction;
				List<string> factions = new List<string>() {
					"Aquila",
					"Dugo",
					"Ekanesh",
					"Pendzal",
					"Sona"};
				if (!factions.Contains(faction)) { Faction = "Unknown"; }
		}
		
		// Print employee record.
		public string Print() {
			string text = $"{Name}";
			while (text.Length < 30) { text = $"{text} "; }
			text = $"{text} ({Faction})";
			while (text.Length < 42) { text = $"{text} "; }
			if (EngineerLevel>0) { text = $"{text}eng{EngineerLevel}"; }
			while (text.Length < 50) { text = $"{text} "; }
			if (ChemistLevel>0) { text = $"{text}chm{ChemistLevel}"; }
			while (text.Length < 58) { text = $"{text} "; }
			if (GeologistLevel>0) { text = $"{text}geo{GeologistLevel}"; }
			return text;
		}
	}
}