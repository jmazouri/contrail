using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ConTrail.Game.Models.Generators
{
    public class LocationGenerator
    {
        public static Location Generate(string itemLocationPath = "Data/locations/locationstats.json")
        {
            var newloc = new Location();

            var LocationStats = JsonConvert.DeserializeObject<List<LocationStats>>(File.ReadAllText(itemLocationPath));



            return newloc;
        }
    }
}
