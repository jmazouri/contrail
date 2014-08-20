using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ConTrail.Game.CommandParsers
{
    public abstract class CommandParser
    {
        public List<string> ValidInputs = new List<string>();

        public GameAction Action { get; set; }

        public Command Parse(string input)
        {
            foreach (string testinput in ValidInputs)
            {
                if (input.StartsWith(testinput, StringComparison.InvariantCultureIgnoreCase))
                {
                    return InterperetCommand(input);
                }
            }

            return new Command()
            {
                Target = null,
                Action = GameAction.Unknown
            };
        }

        protected abstract Command InterperetCommand(string command);
    }
}
