using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using ConTrail.Game;
using ConTrail.Game.Interfaces;
using ConTrail.Game.Models;
using ConTrail.Game.Models.ItemTypes;
using ConTrail.Importers;
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

        public ConTrailGame()
        {
            InfiniteUseItemImporter.DataPath = "Data/items/infiniteuse.json";
            InfiniteUseItemImporter.Import();

            ConsumableItemImporter.DataPath = "Data/items/consumables.json";
            ConsumableItemImporter.Import();

            Output(String.Format("Loaded {0} Items!", ConsumableItemImporter.Items.Count + InfiniteUseItemImporter.Items.Count));
            Output("");
        }

        public void Start()
        {
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

            Inventory.Add(InfiniteUseItemImporter.GetInstanceOfItem("Power Inverter"));
            Inventory.Add(ConsumableItemImporter.GetInstanceOfItem("Grass"));
            Inventory.Add(ConsumableItemImporter.GetInstanceOfItem("Coke"));
            Inventory.Add(ConsumableItemImporter.GetInstanceOfItem("Burrito"));

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
            var found = targets.Where(d => d.Name.ToLowerInvariant().Contains(name.ToLowerInvariant()));

            if (!found.Any())
            {
                Output(String.Format("What's a \"{0}\"?", name), OutputColor.White);
            }

            if (found.Count() > 1)
            {
                Output("Did you mean one of these? "+found.Humanize("or"), OutputColor.White);
            }

            if (found.Count() == 1)
            {
                return found.First();
            }

            return null;
        }

        public void Output(string data, OutputColor color = OutputColor.Gray)
        {
            Console.ForegroundColor = Util.OutputToConsoleColor(color);
            Console.WriteLine(data);
            Console.ForegroundColor = Util.OutputToConsoleColor(InputTextColor);
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
