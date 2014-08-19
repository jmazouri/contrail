using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConTrail.Game.Interfaces;

namespace ConTrail.Game.Models.ItemTypes
{
    public class ConsumableItem : Item
    {
        public int Uses { get; set; }

        public override void MoveTo()
        {
            throw new NotImplementedException();
        }

        public override bool CanUse(ITarget source)
        {
            return base.CanUse(source) && (Uses > 0);
        }

        public override bool Use(ITarget source)
        {
            if (!base.Use(source)) return false;

            if (Uses > 0)
            {
                if (!(source is Traveler)) return false;

                var traveler = (Traveler)source;

                traveler.Vitals += VitalMod;
                Uses -= 1;

                Program.TheGame.Output(String.Format("{0} a \"{1}\"! Uses left: {2}", Verb, Name, Uses));

                return true;
            }

            Program.TheGame.Output(String.Format("You don't have any more uses of \"{0}\"", Name));
            return false;
        }
    }
}
