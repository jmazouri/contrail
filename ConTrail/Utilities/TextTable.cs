using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using ConTrail.Game;
using Humanizer;

namespace ConTrail.Utilities
{
    public class TextTable
    {
        public int TableWidth { get; set; }
        public int AvgColumnWidth { get; set; }

        public string HorizontalLine = ((char)205).ToString();
        public string VerticalLine = ((char)186).ToString();

        public TextTable(int tableWidth = 79)
        {
            TableWidth = tableWidth;
        }

        string Line()
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 1; i != TableWidth + 1; i++) { builder.Append(HorizontalLine); }

            return builder.ToString();
        }

        public string FromList<T>(IEnumerable<T> items, List<TableCol> columnList = null)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine();

            if (columnList == null)
            {
                columnList = new List<TableCol>();
            }

            var props = typeof(T).GetProperties();
            var Columns = new List<string>();

            for (int i = 0; i < props.Length; i++)
            {
                var prop = props[i];
                Columns.Add(prop.Name.Humanize());

                /*
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
                */
            }

            AvgColumnWidth = (TableWidth / Columns.Count);

            builder.AppendLine(Line());

            for (int i = 0; i < Columns.Count; i++)
            {
                int CurColWidth = AvgColumnWidth;

                if (columnList.ElementAtOrDefault(i) != null)
                {
                    if (columnList[i].ColumnWidth > 0)
                    {
                        CurColWidth = (int) (TableWidth*columnList[i].ColumnWidth);
                    }
                }

                builder.Append(String.Format("{0}" + (i < Columns.Count - 1 ? VerticalLine : ""), Columns[i].CenterString(CurColWidth)));
            }

            builder.AppendLine();
            builder.AppendLine(Line());

            foreach (object o in items)
            {
                for (int i = 0; i < Columns.Count; i++)
                {
                    int CurColWidth = AvgColumnWidth;

                    if (columnList.ElementAtOrDefault(i) != null)
                    {
                        if (columnList[i].ColumnWidth > 0)
                        {
                            CurColWidth = (int) (TableWidth*columnList[i].ColumnWidth);
                        }
                    }

                    var val = props.First(d => d.Name == Columns[i].Dehumanize()).GetValue(o).ToString();

                    double useless;
                    bool valIsNumeric = double.TryParse(val, out useless);

                    if ((columnList.ElementAtOrDefault(i) != null && columnList[i].CenterAlign) ||
                        (valIsNumeric))
                    {
                        builder.Append(String.Format("{0, -" + (CurColWidth - 1) + "}" + (i < Columns.Count - 1 ? VerticalLine : ""),
                                val.Truncate(CurColWidth).CenterString(CurColWidth)));
                    }
                    else
                    {
                        builder.Append(String.Format(" {0, -" + (CurColWidth - 1) + "}" + (i < Columns.Count - 1 ? VerticalLine : ""), val.Truncate(CurColWidth - 1)));
                    }
                    
                }

                builder.AppendLine();
            }

            builder.AppendLine(Line());

            return builder.ToString();
        }
    }
}
