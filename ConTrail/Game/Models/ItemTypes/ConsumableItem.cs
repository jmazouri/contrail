using System;
using ConTrail.Game.Interfaces;
using ConTrail.Utilities;
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

            Vitals oldVitals = traveler.Vitals;
            traveler.Vitals += VitalMod;
            Quantity -= 1;

            Program.TheGame.Output(String.Format("{0} {1}! {2} left.", String.Format(Verb, source.Name), Name, Name.ToQuantity(Quantity)), OutputColor.Green);
            Program.TheGame.Output(ReflectionHelper.ComparedTo(oldVitals, traveler.Vitals), OutputColor.Green);

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
