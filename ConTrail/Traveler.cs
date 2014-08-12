using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConTrail
{
    public class Traveler
    {
        public string Name { get; set; }
        public List<Item> Inventory = new List<Item>();

        public Vitals Vitals { get; set; }
    }
}
