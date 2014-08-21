using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ConTrail.Game.CommandParsers
{
    public abstract class CommandParser
    {
        public List<string> ValidInputs = new List<string>();

        public bool Parse(string input)
        {
            foreach (string testinput in ValidInputs)
            {
                if (input.StartsWith(testinput, StringComparison.InvariantCultureIgnoreCase))
                {
                    InterperetCommand(input);
                    return true;
                }
            }
            return false;
        }

        protected abstract void InterperetCommand(string command);
    }
}
