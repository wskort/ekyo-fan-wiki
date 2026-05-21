using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOv2
{
    internal class Account
    {
        public Resources Reserves { get; private set; }
        public string Owner { get; private set; }
        public string CID { get; private set; }

        public Dictionary<Product, int> supplies { get; private set; } = new Dictionary<Product, int>();

        public Account(string owner, string id)
        {
            Owner = owner;
            CID = id;
            Console.WriteLine("New account created: {0} ({1})", owner, id);
        }

        public void addProduct(Product item, int qty=1)
        {
            string altered = "+";
            if (qty < 0) { altered = "-"; }
            try
            {
                if (supplies.ContainsKey(item))
                {
                    supplies[item] += qty;
                    Console.WriteLine("{0}: {1}{2} {3}\n = {4} {3}.", CID, altered, Math.Abs(qty), item.Name, supplies[item]);
                }
                else
                {
                    supplies.Add(item, qty);
                    Console.WriteLine("{0}: {1}{2} {3}\n = {4} {3}.", CID, altered, Math.Abs(qty), item.Name, supplies[item]);
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
