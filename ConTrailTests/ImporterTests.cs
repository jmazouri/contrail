using System.Linq;
using ConTrail.Game.Models.ItemTypes;
using ConTrail.Importers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConTrailTests
{
    [TestClass]
    public class ImporterTests
    {
        [TestMethod]
        public void TestConsumableItemImport()
        {
            Importer<ConsumableItem> Importer = new Importer<ConsumableItem>();
            Importer.DataPath = "Data/items/consumables.json";
            Importer.Import();

            Assert.IsNotNull(Importer.Items);
            Assert.IsTrue(Importer.Items.Any());
        }
    }
}
