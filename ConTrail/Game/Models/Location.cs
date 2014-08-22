using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConTrail.Game.Models.Generators;
using ConTrail.Game.Models.ItemTypes;

namespace ConTrail.Game.Models
{
    public class Location
    {
        public string Name { get; set; }
        public List<Item> StoreInventory { get; set; }

        public LocationStats Stats { get; set; }
    }

    public enum LocationType
    {
        City,
        RestArea,
        GasStation,
        Restaurant
    }
}
