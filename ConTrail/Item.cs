using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ConTrail
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Value { get; set; }

        public int Uses { get; set; }

        public int MaxCooldown { get; set; }
        public int Cooldown { get; set; }

        public Vitals VitalMod { get; set; }

        public UseTypes UseType
        {
            get { return (Uses >= 0 ? UseTypes.Consumable : UseTypes.Infinite); }
        }

        public bool CanUse
        {
            get { return (UseType == UseTypes.Infinite || (Uses > 0)); }
        }
    }

    public enum UseTypes
    {
        Consumable,
        Infinite
    }

    public enum ItemTypes
    {
        Standard
    }
}