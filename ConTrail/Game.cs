using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using ConTrail.Game;
using ConTrail.Game.Interfaces;
using ConTrail.Game.Models;
using ConTrail.Game.Models.ItemTypes;
using ConTrail.Importers;
using ConTrail.Utilities;
using Humanizer;

namespace ConTrail
{
    public class ConTrailGame
    {
        public List<Traveler> Travelers = new List<Traveler>();
        public List<Item> Inventory = new List<Item>();

        public Importer<InfiniteUseItem> InfiniteUseItemImporter = new Importer<InfiniteUseItem>();
        public Importer<ConsumableItem> ConsumableItemImporter = new Importer<ConsumableItem>(); 

        public Timer ItemTimer { get; set; }

        public OutputColor InputTextColor = OutputColor.Yellow;

        public GameStats GameStats { get; set; }

        public ConTrailGame()
        {
            Console.WindowWidth = 80;

            InfiniteUseItemImporter.DataPath = "Data/items/infiniteuse.json";
            InfiniteUseItemImporter.Import();

            ConsumableItemImporter.DataPath = "Data/items/consumables.json";
            ConsumableItemImporter.Import();

            Output(String.Format("Loaded {0} Items!", ConsumableItemImporter.Items.Count + InfiniteUseItemImporter.Items.Count));
            Output("");
        }

        public void Start()
        {
            GameStats = new GameStats()
            {
                GameName = "Jmazouri's Game",
                Money = 200.00m,
                MoneyEarned = 0,
                MoneySpent = 0,
                StartTime = DateTime.Now,
                WantedLevel = 0,
                Gas = 15.6m
            };

            Travelers.Add(new Traveler()
            {
                Name = "Jmazouri",
                Age = 18,
                Vitals = new Vitals()
                {
                    Health = 100,
                    Hunger = 50,
                    Interest = 25
                }
            });

            Travelers.Add(new Traveler()
            {
                Name = "Baylen",
                Age = 17,
                Vitals = new Vitals()
                {
                    Health = 100,
                    Hunger = 75,
                    Interest = 5
                }
            });

            Inventory.AddRange(InfiniteUseItemImporter.DumpAll());
            Inventory.AddRange(ConsumableItemImporter.DumpAll());

            ItemTimer = new Timer(1000);
            ItemTimer.Elapsed += ItemTimer_Elapsed;
            ItemTimer.Start();


            Output("Welcome to...");

            Output(@"
       _..._       .-'''-.                                                   
    .-'_..._''.   '   _    \                                           .---. 
  .' .'      '.\/   /` '.   \    _..._                             .--.|   | 
 / .'          .   |     \  '  .'     '.                           |__||   | 
. '            |   '      |  '.   .-.   .     .|  .-,.--.          .--.|   | 
| |            \    \     / / |  '   '  |   .' |_ |  .-. |    __   |  ||   | 
| |             `.   ` ..' /  |  |   |  | .'     || |  | | .:--.'. |  ||   | 
. '                '-...-'`   |  |   |  |'--.  .-'| |  | |/ |   \ ||  ||   | 
 \ '.          .              |  |   |  |   |  |  | |  '- `' __ | ||  ||   | 
  '. `._____.-'/              |  |   |  |   |  |  | |      .'.''| ||__||   | 
    `-.______ /               |  |   |  |   |  '.'| |     / /   | |_   '---' 
             `                |  |   |  |   |   / |_|     \ \._,\ '/         
                              '--'   '--'   `'-'           `--'  `'          ", OutputColor.Magenta);

            Input("status");
            Input("inventory");
        }

        void ItemTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            foreach (Item i in Inventory)
            {
                if (i.Cooldown <= i.MaxCooldown && i.Cooldown > 0)
                {
                    i.Cooldown -= 1;
                }

                if (i.Cooldown < 0)
                {
                    i.Cooldown = 0;
                }
            }
        }

        public void Input(string data)
        {
            Command.Parse(data);
        }

        public ITarget FindTargetFromName(string name, IEnumerable<ITarget> targets)
        {
            List<ITarget> found = targets.Where(d => d.Name.ToLowerInvariant().Contains(name.ToLowerInvariant())).ToList();

            if (!found.Any())
            {
                Output(String.Format("What's a \"{0}\"?", name), OutputColor.Red);
            }

            if (found.Count > 1)
            {
                Output(String.Format("Did you mean one of these? {0}", found.Humanize("or")), OutputColor.Green);
            }

            if (found.Count == 1)
            {
                return found.First();
            }

            return null;
        }

        public void Output(string data, OutputColor color = OutputColor.Gray)
        {
            Console.ForegroundColor = OutputToConsoleColor(color);
            Console.WriteLine(data);
            Console.ForegroundColor = OutputToConsoleColor(InputTextColor);
        }

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

    public enum OutputColor
    {
        White,
        Gray,
        Green,
        Blue,
        Red,
        Magenta,
        Yellow
    }
}
