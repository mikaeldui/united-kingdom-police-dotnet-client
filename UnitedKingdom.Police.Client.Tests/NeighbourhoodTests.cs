using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitedKingdom.Police.Tests
{
    [TestClass]
    public class NeighbourhoodTests
    {
        [TestMethod]
        public async Task GetNeighbourhoodsAsync()
        {
            using var client = new PoliceClient();
            var result = await client.Neighbourhoods.GetNeighbourhoodsAsync("leicestershire");
            Assert.IsTrue(result.Any());        
            Assert.IsNotNull(result.First().Id);        
            Assert.IsNotNull(result.First().Name);        
        }

        [TestMethod]
        public async Task GetNeighbourhoodAsync()
        {
            using var client = new PoliceClient();
            var neighbourhoods = await client.Neighbourhoods.GetNeighbourhoodsAsync("leicestershire");

            var result = await client.Neighbourhoods.GetNeighbourhoodAsync("leicestershire", neighbourhoods.First());

            Assert.IsNotNull(result.Id);
            Assert.IsNotNull(result.Name);
        }

        [TestMethod]
        public async Task GetNeighbourhoodBoundaryAsync()
        {
            using var client = new PoliceClient();
            var neighbourhoods = await client.Neighbourhoods.GetNeighbourhoodsAsync("leicestershire");

            var result = await client.Neighbourhoods.GetNeighbourhoodBoundaryAsync("leicestershire", neighbourhoods.First());

            Assert.IsTrue(result.Any());
        }
    }
}
