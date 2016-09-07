using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapstoneV2.BLL;
using NUnit.Framework;

namespace CapstoneV2.Tests
{
    [TestFixture]
    class BeerTests
    {
        private BeerOperations bops = new BeerOperations();

        [Test]
        public void GetBeerOnTap()
        {
            var beerOnTap = bops.GetBeerOnTap();

            foreach (var beer in beerOnTap)
            {
                Assert.AreEqual(beer.IsAvailable, true);
            }
        }
    }
}
