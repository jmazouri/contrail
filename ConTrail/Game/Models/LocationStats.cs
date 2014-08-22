﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConTrail.Game.Models.ItemTypes;

namespace ConTrail.Game.Models
{
    public class LocationStats
    {
        public LocationType LocationType { get; set; }
        public int Quality { get; set; }
        public double PoliceChance { get; set; }
        public List<ItemType> PossibleItemTypes { get; set; }
    }
}
