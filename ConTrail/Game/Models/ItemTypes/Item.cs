using System;
using System.ComponentModel;
using ConTrail.Game.Interfaces;

namespace ConTrail.Game.Models.ItemTypes
{
    public abstract class Item : ITarget
    {
        public Item ActiveItem { get; set; }
        public ITarget Owner { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Value { get; set; }

        public int Quantity { get; set; }

        [DefaultValue("Used a")]
        public string Verb { get; set; }

        public int MaxCooldown { get; set; }
        public int Cooldown { get; set; }

        public Vitals VitalMod { get; set; }

        public ItemType Type { get; set; }

        public abstract void MoveTo();

        public virtual bool Use(ITarget source)
        {
            //don't worry about the cooldown if the max is 0
            if (Cooldown == 0 | MaxCooldown == 0)
            {
                Cooldown = MaxCooldown;
                return true;
            }

            Program.TheGame.Output(String.Format("\"{0}\" is still on cooldown for {1} more seconds.", Name, Cooldown));
            return false;
        }

        ITarget ITarget.GetCopy()
        {
            return (Item)MemberwiseClone();
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public enum ItemType
    {
        Standard,
        Drug,
        Food
    }
}