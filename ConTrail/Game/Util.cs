using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Humanizer;

namespace ConTrail
{
    public static class Util
    {
        public static T Clamp<T>(this T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }

        public static string CenterString(this string stringToCenter, int totalLength)
        {
            return stringToCenter.PadLeft(((totalLength - stringToCenter.Length) / 2)
                                + stringToCenter.Length)
                       .PadRight(totalLength);
        }

        static string Line(int ColumnWidths, int TableWidth)
        {
            StringBuilder builder = new StringBuilder();
            if (ColumnWidths % 2 > 0)
            {
                builder.Append("-");
            }

            for (int i = 1; i != TableWidth; i++) { builder.Append("-"); }

            return builder.ToString();
        }

        public static string ListToTextTable<T>(IEnumerable<T> items, List<double> percentColWidths = null)
        {
            StringBuilder builder = new StringBuilder();

            var props = typeof(T).GetProperties();
            var Columns = new List<string>();

            foreach (var prop in props)
            {
                var displayname = prop.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                if (displayname.Length > 0)
                {
                    var displayNameAttribute = displayname[0] as DisplayNameAttribute;
                    if (displayNameAttribute != null)
                        Columns.Add(displayNameAttribute.DisplayName);
                }
                else
                {
                    Columns.Add(prop.Name);
                }
            }

            int TableWidth = 78;
            int ColumnWidths = (TableWidth / Columns.Count) - 1;

            builder.AppendLine(Line(ColumnWidths, TableWidth));

            builder.Append("|");
            foreach (var col in Columns)
            {
                int CurColWidth = ColumnWidths;

                if (percentColWidths != null)
                {
                    CurColWidth = (int)(TableWidth * percentColWidths[Columns.IndexOf(col)]) - 1;
                }

                builder.Append(String.Format("{0}|", col.CenterString(CurColWidth)));
            }

            builder.AppendLine();
            builder.AppendLine(Line(ColumnWidths, TableWidth));

            foreach (object o in items)
            {
                foreach (var col in Columns)
                {
                    int CurColWidth = ColumnWidths;

                    if (percentColWidths != null)
                    {
                        CurColWidth = (int)(TableWidth*percentColWidths[Columns.IndexOf(col)]) - 1;
                    }

                    if (Columns.IndexOf(col) == 0)
                    {
                        builder.Append("|");
                    }

                    var val = props.First(d => d.Name == col).GetValue(o).ToString();

                    builder.Append(String.Format(" {0, -" + (CurColWidth - 2) + "} |", val.Truncate(CurColWidth - 2)));
                }

                builder.AppendLine();
            }

            builder.AppendLine(Line(ColumnWidths, TableWidth));

            return builder.ToString();
        }

        //This whole thing exists so we can do colors in a non-console environment without find/replacing all instances of consolecolor
        public static ConsoleColor OutputToConsoleColor(OutputColor color)
        {
            switch (color)
            {
                case OutputColor.Blue:
                    return ConsoleColor.Cyan;
                case OutputColor.Gray:
                    return ConsoleColor.Gray;
                case OutputColor.Green:
                    return ConsoleColor.Green;
                case OutputColor.Red:
                    return ConsoleColor.Red;
                case OutputColor.White:
                    return ConsoleColor.White;
                case OutputColor.Yellow:
                    return ConsoleColor.Yellow;
                case OutputColor.Magenta:
                    return ConsoleColor.Magenta;
                default:
                    return ConsoleColor.Gray;
            }
        }
    }
}
