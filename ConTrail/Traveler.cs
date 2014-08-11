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

        public Vitals RawVitals { get; set; }

        public Vitals Vitals
        {
            get
            {
                return new Vitals()
                {
                    Health = RawVitals.Health + Inventory.Sum(d => d.VitalMod.Health),
                    Hunger = RawVitals.Hunger + Inventory.Sum(d => d.VitalMod.Hunger),
                    Interest = RawVitals.Interest + Inventory.Sum(d => d.VitalMod.Interest)
                };
            }
        }
    }
}
