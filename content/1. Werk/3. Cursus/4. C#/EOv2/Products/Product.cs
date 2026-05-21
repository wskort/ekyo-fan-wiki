using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOv2
{
    abstract class Product
    {
        // Product information
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string Physrep { get; protected set; }
        public string Extra { get; protected set; }
        public string Category { get; protected set; }
        public int DefaultPrice { get; protected set; }
        
        // Crafting requirements
        public string Skill { get; protected set; }
        public int SkillLevel { get; protected set; }
        public Resources Materials { get; protected set; }
    }

    
}
