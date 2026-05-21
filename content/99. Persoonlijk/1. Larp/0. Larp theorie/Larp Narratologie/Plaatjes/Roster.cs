using System;
using System.IO;
using System.Collections.Generic;

namespace code {	
	public class Roster {
		// Corp-level data
		public string Unit
		{ get; private set; }
		public string CID
		{ get; private set; }
		
		public List<Employee> staffList = new List<Employee>();
		
		// Constructor: set the Unit data and fill roster.
		public Roster(string owner="EO") {
			switch (owner) {
				case "EO":
					Unit = "Executive Outcomes";
					break;
				case "AM":
					Unit = "Aquilan Military";
					break;
				case "ICC":
					Unit = "Portal";
					break;
				default:
					Unit = owner;
					break;
			}
			CID = owner;
			this.InitEmployees();
		}
		
		// Initialise a roster with staff.
		private void InitEmployees() {
			// EO: C-level
			staffList.Add(new Employee(
				name:"Eunomia \"Tabula\" Copia",
				faction: "Aquila",
				corp: "EO",
				oc: "Willeke",
				payroll:true
			));
			staffList.Add(new Employee(
				name:"Akshay Vivaan", 
				faction: "Sona",
				corp: "EO",
				oc:"Nicholas",
				engineer:4, 
				payroll:true
			));
			staffList.Add(new Employee(
				name:"Biki Son Teigun", 
				faction: "Dugo",
				corp: "EO",
				oc:"Marianne",
				chemist:5, 
				payroll:true
			));
			
			// EO: General staff
			staffList.Add(new Employee(
				name: "Winchester \"Winch\" Riggs",
				faction: "Pendzal",
				corp: "EO",
				oc: "Remy",
				engineer:4,
				geologist:3,
				payroll:true
			));
			staffList.Add(new Employee(
				name: "[Simone]",
				faction: "Ekanesh",
				corp: "EO",
				oc: "Simone",
				engineer:2,
				chemist:3,
				payroll:true
			));
				
			// AM: Enlisted
			staffList.Add(new Employee(
				name: "Cassius \"Bambi\" Silo",
				faction: "Aquila",
				corp: "AM",
				oc: "Rodric",
				chemist:5
			));
			
			// Unaffiliated
			staffList.Add(new Employee(
				name: "Silva \"Frigid\" Virori",
				faction: "Aquila",
				oc: "Eva"
			));
		}
		
		// Small formatting tool.
		public string LeadingSpace(string text, int maxLength=3) {
			while (text.Length < maxLength)
			{ text = $" {text}"; }
			return text;
		}
		
		// Return list of employees and their skills. 
		public string EmployeeList(string job="", int level=0) {
			string employeeList="";
			if (job=="") { employeeList=$" ---------------\n {Unit}'s Roster\n ---------------"; }
			else { employeeList=$" ---------------\n This product can be made by:"; }
			foreach (var person in this.staffList) {
				if (person.Corp == CID) {
					switch (job) {
						case "Engineer":
							if (person.EngineerLevel >= level) { 
								employeeList=$"{employeeList}\n {person.Corp}'s {person.Print()}"; 
							}
							break;
						case "Chemist":
							if (person.ChemistLevel >= level) { 
								employeeList=$"{employeeList}\n {person.Corp}'s {person.Print()}"; 
							}
							break;
						case "Geologist":
							if (person.GeologistLevel >= level) { 
								employeeList=$"{employeeList}\n {person.Corp}'s {person.Print()}"; 
							}
							break;
						case "":
							employeeList=$"{employeeList}\n {person.Print()}"; 
							break;
						default:
							break;
					}
				}
			}
			if (job=="") { employeeList = $"{employeeList}\n\n ---------------\n Outside contacts\n ---------------"; }
			foreach (var person in this.staffList) {
				if (person.Corp != CID) {
					switch (job) {
						case "Engineer":
							if (person.EngineerLevel >= level) { 
								employeeList=$"{employeeList}\n {person.Corp}'s {person.Print()}"; 
							}
							break;
						case "Chemist":
							if (person.ChemistLevel >= level) { 
								employeeList=$"{employeeList}\n {person.Corp}'s {person.Print()}"; 
							}
							break;
						case "Geologist":
							if (person.GeologistLevel >= level) { 
								employeeList=$"{employeeList}\n {person.Corp}'s {person.Print()}"; 
							}
							break;
						case "":
							employeeList=$"{employeeList}\n {person.Print()}"; 
							break;
						default:
							break;
					}
				}
			}
			employeeList = $"{employeeList}\n";
			return employeeList;
		}
		
		// Print the stafflist to the console and/or a separate .txt file
		public void PrintStaff(string target="both", string skill="", int level=0) {
			// Error catching: Portal doesn't get a stafflist.
			if (Unit == "Portal") { return; }

			if (target == "file" || target == "both") {
				string fileName = $"{CID}_Roster.txt";
				using (StreamWriter sw = new StreamWriter(fileName)) 
					{ sw.WriteLine(this.EmployeeList(skill, level)); }
			}
			if (target == "console" || target == "both") {
				Console.WriteLine(this.EmployeeList(skill, level)); 
			}
		}
	}
}