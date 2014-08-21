using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConTrail.Game.Interfaces;
using Humanizer;

namespace ConTrail.Game.Models.ItemTypes
{
    public class ConsumableItem : Item
    {
        public override void MoveTo()
        {
            throw new NotImplementedException();
        }

        public override bool Use(ITarget source)
        {
            if (!base.Use(source)) return false;

            if (!(source is Traveler)) return false;

            var traveler = (Traveler)source;

            traveler.Vitals += VitalMod;
            Quantity -= 1;

            Program.TheGame.Output(String.Format("{0} {1}! {2} left.", String.Format(Verb, source.Name), Name, Name.ToQuantity(Quantity)), OutputColor.Green);
            Program.TheGame.Output(String.Format("New Stats: {0}", traveler.Vitals), OutputColor.Green);

            if (Quantity == 0)
            {
                Program.TheGame.Output(String.Format("You ran out of {0}!", Name.Pluralize(false)), OutputColor.Red);
                Program.TheGame.Inventory.Remove(this);
                return false;
            }

            return true;
        }
    }
}
