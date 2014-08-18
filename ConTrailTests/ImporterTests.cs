using System.Linq;
using ConTrail.Importers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConTrailTests
{
    [TestClass]
    public class ImporterTests
    {
        [TestMethod]
        public void TestItemImport()
        {
            ItemImporter.Import();
            
            Assert.IsNotNull(ItemImporter.Items);
            Assert.IsTrue(ItemImporter.Items.Any());
        }
    }
}
