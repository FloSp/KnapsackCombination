using Combination.Test.Framework;
using Framework.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combination.Test
{
    [TestClass]
    public class KnappsackCombinerTest
    {
        [TestMethod]
        public void testme()
        {

            var combini = ItemCombination.Empty();
            var item1 = new Item(1, 2);
            Length totalLength = 3;
            var itemMethods = new ItemUtilsProvider();
            

           var rest= KnappsackCombiner.CompleteCombination(combini, item1.ToSequence(2), itemMethods, totalLength);
            Assert.IsFalse(false);
        }
    }
}
