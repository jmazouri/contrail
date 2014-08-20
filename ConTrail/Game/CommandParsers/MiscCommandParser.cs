using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConTrail.Game.Models;
using ConTrail.Game.Models.ItemTypes;
using Humanizer;

namespace ConTrail.Game.CommandParsers
{
    public class MiscCommandParser : CommandParser
    {
        public MiscCommandParser()
        {
            ValidInputs.Add("status");
            ValidInputs.Add("help");
            ValidInputs.Add("quit");
            ValidInputs.Add("inventory");
        }

        protected override Command InterperetCommand(string command)
        {
            switch (command.Split(" ".ToCharArray())[0])
            {
                case "help":
                    Program.TheGame.Output("Try one of these: "+Command.Parsers.SelectMany(d=>d.ValidInputs).Humanize("or"), OutputColor.Green);
                    return new Command
                    {
                        Target = null,
                        Action = GameAction.Misc
                    };
                case "status":
                    Program.TheGame.Output("Travelers' status: ", OutputColor.White);
                    foreach (Traveler t in Program.TheGame.Travelers)
                    {
                        Program.TheGame.Output(t.ToString(), OutputColor.Blue);
                    }

                    return new Command
                    {
                        Target = null,
                        Action = GameAction.Misc
                    };
                case "inventory":

                    string table = Util.ListToTextTable(Program.TheGame.Inventory.Select(d=>new
                    {
                        d.Name,
                        d.Description,
                        Qty = (d.Quantity > -1 ? d.Quantity.ToString() : "Inf")
                    }), new List<double> { 0.3, 0.6, 0.10 });

                    Program.TheGame.Output("Current Inventory: ", OutputColor.White);
                    Program.TheGame.Output(table, OutputColor.Blue);

                    return new Command
                    {
                        Target = null,
                        Action = GameAction.Misc
                    };
                case "quit":
                    Environment.Exit(0);
                    break;
            }

            return new Command
            {
                Target = null,
                Action = GameAction.Unknown
            };
        }
    }
}
