using System.Collections.Generic;
using System.Linq;

namespace ConTrail.Game.CommandParsers
{
    public class MovementParser : CommandParser
    {
        public MovementParser()
        {
            ValidInputs.AddRange(new []
            {
                "move to",
                "go to",
                "move",
                "go",
                "drive to",
                "travel to"
            });
        }
        protected override Command InterperetCommand(string command)
        {
            Program.TheGame.Output("You can't go anywhere yet! Soon(tm)!");
            return new Command()
            {
                Target = null,
                Action = GameAction.Unknown
            };
        }
    }
}
