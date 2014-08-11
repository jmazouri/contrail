using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConTrail.Importers
{
    public class ItemImporter
    {
        public static List<Item> Import()
        {
            var ret = new List<Item>();

            var JsonFile = File.ReadAllText("Data/items.json");

            return ret;
        }
    }
}
