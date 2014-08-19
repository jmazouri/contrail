using System;
using System.Collections.Generic;
using ConTrail.Game.CommandParsers;
using ConTrail.Game.Interfaces;
using ConTrail.Game.Models;

namespace ConTrail.Game
{
    public class Command
    {
        public ITarget Target { get; set; }
        public GameAction Action { get; set; }

        public static List<CommandParser> Parsers = new List<CommandParser> { new ItemUseParser(), new MovementParser() }; 

        public static void Parse(string input)
        {
            foreach (CommandParser p in Parsers)
            {
                var result = p.Parse(input);
                if (result.Action != GameAction.Unknown)
                {
                    return;
                }
            }

            Program.TheGame.Output("I didn't catch that.");
        }
    }

    public enum GameAction
    {
        Move,
        Use,
        Unknown
    }
}
