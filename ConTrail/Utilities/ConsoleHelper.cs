using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConTrail.Utilities
{
    public static class ConsoleHelper
    {
        //This whole thing exists so we can do colors in a non-console environment without find/replacing all instances of consolecolor
        public static ConsoleColor OutputToConsoleColor(OutputColor color)
        {
            switch (color)
            {
                case OutputColor.Blue:
                    return ConsoleColor.Cyan;
                case OutputColor.Gray:
                    return ConsoleColor.Gray;
                case OutputColor.Green:
                    return ConsoleColor.Green;
                case OutputColor.Red:
                    return ConsoleColor.Red;
                case OutputColor.White:
                    return ConsoleColor.White;
                case OutputColor.Yellow:
                    return ConsoleColor.Yellow;
                case OutputColor.Magenta:
                    return ConsoleColor.Magenta;
                default:
                    return ConsoleColor.Gray;
            }
        }
    }
}
