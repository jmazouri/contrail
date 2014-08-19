﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConTrail.Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConTrailTests
{
    [TestClass]
    public class CommandTests
    {
        [TestMethod]
        public void TestMoveInput()
        {
            string[] Tests = 
            {
                "go to Detroit",
                "move to New York",
                "move LA",
                "go Boston"
            };

            foreach (string command in Tests)
            {
                Command.Parse(command);
            }
        }
    }
}
