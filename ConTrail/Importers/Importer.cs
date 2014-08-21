using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConTrail.Game.Interfaces;
using Newtonsoft.Json;

namespace ConTrail.Importers
{
    public class Importer<T> where T : ITarget
    {
        public List<T> Items = new List<T>();
        public string DataPath;

        public T GetInstanceOfItem(string name)
        {
            var firstOrDefault = Items.FirstOrDefault(d => d.Name == name);

            if (firstOrDefault != null)
            {
                return (T)firstOrDefault.GetCopy();
            }
            
            throw new ArgumentException(String.Format("Item \"{0}\" doesn't exist.", name));
        }

        public List<T> DumpAll()
        {
            var ret = new List<T>();

            foreach (var item in Items)
            {
                ret.Add((T)item.GetCopy());
            }

            return ret;
        }

        public void Import()
        {
            var jsonFile = File.ReadAllText(DataPath);
            Items = JsonConvert.DeserializeObject<List<T>>(jsonFile);
        }
    }
}
