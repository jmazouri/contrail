using System;
using System.Linq;
using System.Text;
using ConTrail.Utilities;
using Humanizer;

namespace ConTrail.Game.Models
{
    public struct Vitals
    {
        public int Health { get; set; }
        public int Hunger { get; set; }
        public int Interest { get; set; }

        public static Vitals operator +(Vitals v1, Vitals v2)
        {
            return new Vitals
            {
                Health = (v1.Health + v2.Health).Clamp(0, 100),
                Hunger = (v1.Hunger + v2.Hunger).Clamp(0, 100),
                Interest = (v1.Interest + v2.Interest).Clamp(0, 100)
            };
        }

        public override string ToString()
        {
            Vitals thisVitals = this;
            return GetType().GetProperties().Select(d => String.Format("{0}: {1}", d.Name, d.GetValue(thisVitals))).Humanize();
        }
    }
}
