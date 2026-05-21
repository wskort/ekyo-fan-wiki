using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOv2
{
    class Program
    {
        static Boolean exit;

        static void Main(string[] args)
        {
            Account eo = new Account("Executive Outcomes", "EO");
            Product supplyKit = new Products.SupplyKit();
            eo.addProduct(supplyKit, 12);
            eo.addProduct(supplyKit, -3);
            eo.addProduct(supplyKit);
            eo.addProduct(supplyKit, -10);
            eo.addProduct(supplyKit, -1);

            Console.WriteLine("Hello, world!");
            while (!exit)
            {
                string input = Console.ReadLine();
                Process(input);
            }
            
        }

        static void Process(string input)
        {
            Console.WriteLine("You typed '{0}'", input);
            if (input == "exit") { exit = true; }
        }
    }
}
