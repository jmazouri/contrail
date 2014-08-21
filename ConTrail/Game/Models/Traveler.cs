using System.Collections.Generic;
using System.Timers;
using ConTrail.Game.Interfaces;
using ConTrail.Game.Models.ItemTypes;

namespace ConTrail.Game.Models
{
    public class Traveler : ITarget
    {
        public ITarget Owner { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        
        public Vitals Vitals { get; set; }

        public void MoveTo() { }

        public bool Use(ITarget source)
        {
            throw new System.NotImplementedException();
        }

        public ITarget GetCopy()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return string.Format("{0}, Age {1}. Stats: {2}", Name, Age, Vitals);
        }
    }
}
