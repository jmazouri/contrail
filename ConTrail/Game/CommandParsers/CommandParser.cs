using System;
using System.Collections.Generic;
using System.Linq;

namespace ConTrail.Game.CommandParsers
{
    public abstract class CommandParser
    {
        public List<string> ValidInputs = new List<string>();

        public bool Parse(string input)
        {
            if (!ValidInputs.Any(testinput => input.StartsWith(testinput, StringComparison.InvariantCultureIgnoreCase)))
                return false;

            InterperetCommand(input);
            return true;
        }

        protected abstract void InterperetCommand(string command);
    }
}
