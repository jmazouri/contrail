using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ConTrail.Game.Models.ItemTypes;
using ConTrail.Importers;

namespace ConTrailThingGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Importer<InfiniteUseItem> InfiniteUseItemImporter = new Importer<InfiniteUseItem>();
        public Importer<ConsumableItem> ConsumableItemImporter = new Importer<ConsumableItem>(); 
        
        public List<Item> Items { get; set; } 

        public MainWindow()
        {
            InitializeComponent();

            Items = new List<Item>();

            InfiniteUseItemImporter.DataPath = "../../../ConTrail/Data/items/infiniteuse.json";
            InfiniteUseItemImporter.Import();

            ConsumableItemImporter.DataPath = "../../../ConTrail/Data/items/consumables.json";
            ConsumableItemImporter.Import();

            Items.AddRange(InfiniteUseItemImporter.DumpAll());
            Items.AddRange(ConsumableItemImporter.DumpAll());

            ItemList.DataContext = Items;
        }

        void m_grid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (((PropertyDescriptor)e.PropertyDescriptor).IsBrowsable == false)
                e.Cancel = true;
        }
    }
}
