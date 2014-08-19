using System;
using System.Collections.Generic;
using System.Linq;

namespace ConTrail.Game.CommandParsers
{
    public class ItemUseParser : CommandParser
    {
        public ItemUseParser()
        {
            ValidInputs.Add("use");
        }

        protected override Command InterperetCommand(string[] args)
        {
            if (args.Count() == 4)
            {
                string itemname = args[0];
                string targetname = args[2];

                var founditem = Program.TheGame.Inventory.FirstOrDefault(d => d.Name.Equals(itemname, StringComparison.InvariantCultureIgnoreCase));
                var target = Program.TheGame.Travelers.FirstOrDefault(d=>d.Name.Equals(itemname, StringComparison.InvariantCultureIgnoreCase));

                if (founditem != null)
                {
                    if (target != null)
                    {
                        if (founditem.CanUse(target))
                        {
                            founditem.Use(target);
                        }

                        return new Command
                        {
                            Target = target,
                            Action = GameAction.Use
                        };
                    }

                    Program.TheGame.Output(String.Format("I don't know anyone named \"{0}\".", targetname));
                }
                Program.TheGame.Output(String.Format("You don't have any \"{0}\".", itemname));
            }

            return new Command
            {
                Target = null,
                Action = GameAction.Unknown
            };
        }
    }
}
