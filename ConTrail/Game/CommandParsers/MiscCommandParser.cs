using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConTrail.Game.Models;
using ConTrail.Game.Models.ItemTypes;
using ConTrail.Utilities;
using Humanizer;

namespace ConTrail.Game.CommandParsers
{
    public class MiscCommandParser : CommandParser
    {
        public MiscCommandParser()
        {
            ValidInputs = new List<string>
            {
                "status",
                "?",
                "help",
                "quit",
                "inventory",
                "inv"
            };
        }

        protected override void InterperetCommand(string command)
        {
            switch (command.Split(" ".ToCharArray())[0])
            {
                case "?":
                case "help":
                    Program.TheGame.Output("Try one of these: "+Command.Parsers.SelectMany(d=>d.ValidInputs).Humanize("or"), OutputColor.Green);
                    break;
                case "status":
                    Program.TheGame.Output("Travelers' status: ", OutputColor.Blue);

                    var statusTable = new TextTable();

                    string statTable = statusTable.FromList(Program.TheGame.Travelers.Select(d => new
                    {
                        d.Name,
                        d.Age,
                        d.Vitals.Health,
                        d.Vitals.Hunger,
                        d.Vitals.Interest
                    }));

                    Program.TheGame.Output(statTable, OutputColor.White);
                    break;
                case "inv":
                case "inventory":
                    var invTable = new TextTable();

                    string table = invTable.FromList(Program.TheGame.Inventory.Select(d => new
                    {
                        d.Name,
                        d.Description,
                        Qty = (d.Quantity > -1 ? d.Quantity.ToString() : "Inf")
                    }), new List<TableCol>
                    {
                        new TableCol()
                        {
                            ColumnWidth = 0.3
                        },
                        new TableCol()
                        {
                            ColumnWidth = 0.6
                        },
                        new TableCol()
                        {
                            CenterAlign = true,
                            ColumnWidth = 0.1
                        }
                    });

                    Program.TheGame.Output("Current Inventory: ", OutputColor.Blue);
                    Program.TheGame.Output(table, OutputColor.White);
                    break;
                case "quit":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
