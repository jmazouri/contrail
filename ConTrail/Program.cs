﻿using System;

namespace ConTrail
{

    public class Program
    {
        public static ConTrailGame TheGame { get; set; }

        static void Main(string[] args)
        {
            TheGame = new ConTrailGame();
            TheGame.Start();

            while (true)
            {
                TheGame.Input(Console.ReadLine());
                
            }
        }
    }
}
