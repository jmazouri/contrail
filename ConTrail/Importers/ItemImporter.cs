using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ConTrail.Importers
{
    public static class ItemImporter
    {
        public static List<Item> Items = new List<Item>();

        public static Item GetInstanceOfItem(string name)
        {
            var firstOrDefault = Items.FirstOrDefault(d => d.Name == name);

            if (firstOrDefault != null)
            {
                return firstOrDefault.GetCopy();
            }
            
            throw new ArgumentException(String.Format("Item \"{0}\" doesn't exist.", name));
        }

        public static void Import(string datapath = "Data/items.json")
        {
            var JsonFile = File.ReadAllText(datapath);
            Items = JsonConvert.DeserializeObject<List<Item>>(JsonFile);
        }
    }
}
