using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ConTrail.Importers
{
    public static class ItemImporter
    {
        public static Dictionary<ItemTypes, List<Item>> Import(string datapath = "Data/items.json")
        {
            var JsonFile = File.ReadAllText(datapath);
            return JsonConvert.DeserializeObject<Dictionary<ItemTypes, List<Item>>>(JsonFile);
        }
    }
}
