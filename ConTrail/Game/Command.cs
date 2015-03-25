using System.Collections.Generic;
using System.Linq;
using ConTrail.Game.CommandParsers;

namespace ConTrail.Game
{
    public class Command
    {
        public static List<CommandParser> Parsers = new List<CommandParser> { new ItemUseParser(), new MovementParser(), new MiscCommandParser() }; 

        public static void Parse(string input)
        {
            if (Parsers.Select(p => p.Parse(input)).Any(result => result))
            {
                return;
            }

            Program.TheGame.Output("I didn't catch that.");
        }
    }
}
