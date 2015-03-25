using System;
using System.Collections.Generic;
using System.Linq;
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
                "info",
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
                case "info":
                case "status":
                    var statusTable = new TextTable();

                    string statTable = "Travelers' Status:" + statusTable.FromList(Program.TheGame.Travelers.Select(d => new
                    {
                        d.Name,
                        d.Age,
                        d.Vitals.Health,
                        d.Vitals.Hunger,
                        d.Vitals.Interest
                    }));

                    Program.TheGame.Output(statTable, OutputColor.White);

                    var gameStatTable = new TextTable();

                    string gameStatTableOut = "Game Stats:" + gameStatTable.FromList(new[]
                    {
                        new
                        {
                            SessionTime = Program.TheGame.GameStats.SessionTime.Humanize(),
                            Program.TheGame.GameStats.Money,
                            Program.TheGame.GameStats.MoneyEarned,
                            Program.TheGame.GameStats.MoneySpent,
                            Program.TheGame.GameStats.Gas
                        }
                    }, new List<TableCol>
                    {
                        new TableCol
                        {
                            CenterAlign = true
                        }
                    });

                    Program.TheGame.Output(gameStatTableOut, OutputColor.White);

                    break;
                case "inv":
                case "inventory":
                    var invTable = new TextTable();

                    string table = "Current Inventory: "+ invTable.FromList(Program.TheGame.Inventory.Select(d => new
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

                    Program.TheGame.Output(table, OutputColor.White);
                    break;
                case "quit":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
