﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ConTrail.Game.Models;
using ConTrail.Game.Models.ItemTypes;

namespace ConTrail.Game.CommandParsers
{
    public class ItemUseParser : CommandParser
    {
        public ItemUseParser()
        {
            ValidInputs.Add("use");
        }

        protected override Command InterperetCommand(string command)
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

                        return new Command
                        {
                            Target = target,
                            Action = GameAction.Use
                        };
                    }

                    return new Command
                    {
                        Target = null,
                        Action = GameAction.Use
                    };
                }

                return new Command
                {
                    Target = null,
                    Action = GameAction.Use
                };
            }

            Program.TheGame.Output(String.Format("What? Use (x) on (y), please."), OutputColor.White);

            return new Command
            {
                Target = null,
                Action = GameAction.Unknown
            };
        }
    }
}
