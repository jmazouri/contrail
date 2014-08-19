using System;
using ConTrail.Game.Interfaces;

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

            traveler.Vitals += VitalMod;

            Program.TheGame.Output(String.Format("{0} a \"{1}\"!", Verb, Name));
            Program.TheGame.Output(String.Format("Stat Change: {0}", VitalMod));

            return true;
        }
    }
}
