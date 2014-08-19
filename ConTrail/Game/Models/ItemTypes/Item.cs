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

        [DefaultValue("Used")]
        public string Verb { get; set; }

        public int MaxCooldown { get; set; }
        public int Cooldown { get; set; }

        public Vitals VitalMod { get; set; }

        public ItemType Type { get; set; }

        public abstract void MoveTo();

        public virtual bool CanUse(ITarget source)
        {
            return Cooldown == 0;
        }

        public virtual bool Use(ITarget source)
        {
            if (CanUse(source))
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
    }

    public enum ItemType
    {
        Standard,
        Drug
    }
}