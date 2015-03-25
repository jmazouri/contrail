using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConTrail.Game.Models;

namespace ConTrail.Utilities
{
    public static class ReflectionHelper
    {
        public static Dictionary<String, T> PropertiesAsType<T>(object o) 
        {
            Dictionary<String, T> ret = o.GetType().GetProperties()
                .Where(d => d.PropertyType.IsAssignableFrom(typeof (T)))
                .ToDictionary(entry => entry.Name, entry => (T) entry.GetValue(o));

            return ret;
        }

        public static string ComparedTo(object first, object comp)
        {
            var cur = PropertiesAsType<int>(first);
            var compare = PropertiesAsType<int>(comp);

            var merged = cur.Join(compare, d => d.Key, v => v.Key,
                (old, unold) => new { current = old, tocompare = unold, change = unold.Value - old.Value })
                .Where(d=>d.current.Value - d.tocompare.Value != 0);

            var displayResults = merged.Select(d =>
                    String.Format("{0}: {1}({2}){3}", d.current.Key, d.current.Value,
                    (d.change >= 0 ? "+" + d.change : d.change.ToString()), d.tocompare.Value));

            return displayResults.Aggregate((c, n) => c + ", " + n);
        }
    }
}
