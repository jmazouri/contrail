using System;
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
            var Items = ItemImporter.Import();
            Assert.IsNotNull(Items);
            Assert.IsTrue(Items.Count > 0);

            foreach (var Category in Items)
            {
                Assert.IsTrue(Category.Value.Count > 0);
            }
        }
    }
}
