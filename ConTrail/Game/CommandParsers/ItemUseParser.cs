using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ConTrail.Game.Models;
using ConTrail.Game.Models.ItemTypes;

namespace ConTrail.Game.CommandParsers
{
    public class ItemUseParser : CommandParser
    {
        public ItemUseParser()
        {
            ValidInputs = new List<string>
            {
                "use"
            };
        }

        protected override void InterperetCommand(string command)
        {
            var match = Regex.Match(command, @"^(use)\s(.*?)\s(on)\s(.*?)$");

            string itemname = match.Groups[2].Value;
            string targetname = match.Groups[4].Value;

            if (match.Groups.Count == 5)
            {
                var founditem = (Item)Program.TheGame.FindTargetFromName(itemname, Program.TheGame.Inventory);
                var target = (Traveler)Program.TheGame.FindTargetFromName(targetname, Program.TheGame.Travelers); 

                if (founditem != null)
                {
                    if (target != null)
                    {
                        founditem.Use(target);
                    }
                }
            }
            else
            {
                Program.TheGame.Output(String.Format("What? Use (x) on (y), please!"), OutputColor.White);
            }
        }
    }
}
