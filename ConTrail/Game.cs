using System;
using System.Collections.Generic;
using System.Timers;
using ConTrail.Game;
using ConTrail.Game.Models;
using ConTrail.Game.Models.ItemTypes;
using ConTrail.Importers;

namespace ConTrail
{
    public class ConTrailGame
    {
        public List<Traveler> Travelers = new List<Traveler>();
        public List<Item> Inventory = new List<Item>();

        public Importer<InfiniteUseItem> InfiniteUseItemImporter = new Importer<InfiniteUseItem>();
        public Importer<ConsumableItem> ConsumableItemImporter = new Importer<ConsumableItem>(); 

        public Timer ItemTimer { get; set; }

        public ConTrailGame()
        {
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
                              '--'   '--'   `'-'           `--'  `'          ");

            InfiniteUseItemImporter.DataPath = "Data/items/infiniteuse.json";
            InfiniteUseItemImporter.Import();

            ConsumableItemImporter.DataPath = "Data/items/consumables.json";
            ConsumableItemImporter.Import();

            Output(String.Format("Loaded {0} Items!", ConsumableItemImporter.Items.Count + InfiniteUseItemImporter.Items.Count));

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

            ItemTimer = new Timer(1000);
            ItemTimer.Elapsed += ItemTimer_Elapsed;
            ItemTimer.Start();
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

        public void Output(string data)
        {
            Console.WriteLine(data);
        }
    }
}
