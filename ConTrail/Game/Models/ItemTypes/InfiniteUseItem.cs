using System;
using ConTrail.Game.Interfaces;
using ConTrail.Utilities;

namespace ConTrail.Game.Models.ItemTypes
{
    public class InfiniteUseItem : Item
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

            Program.TheGame.Output(String.Format(String.Format(Verb, source.Name), Name), OutputColor.Green);
            Program.TheGame.Output(ReflectionHelper.ComparedTo(oldVitals, traveler.Vitals), OutputColor.Green);

            return true;
        }
    }
}
