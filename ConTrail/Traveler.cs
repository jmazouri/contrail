using System.Collections.Generic;

namespace ConTrail
{
    public class Traveler
    {
        public string Name { get; set; }
        public List<Item> Inventory = new List<Item>();

        public Vitals Vitals { get; set; }
    }
}
