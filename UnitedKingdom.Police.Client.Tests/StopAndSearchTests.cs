using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitedKingdom.Police.Tests
{
    [TestClass]
    public class StopAndSearchTests
    {
        [TestMethod]
        public async Task GetStopAndSearchesByAreaByPointAsync()
        {
            using var client = new PoliceClient();
            var result = await client.StopAndSearch.GetStopAndSearchesByAreaAsync(52.629729, -1.131592, DateTime.Now.AddMonths(-3));
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public async Task GetStopAndSearchesByAreaByAreaAsync()
        {
            var area = new (double latitude, double longitude)[]
            {
                (52.2, 0.5),
                (52.8, 0.2),
                (52.1, 0.88)
            };
            using var client = new PoliceClient();
            var result = await client.StopAndSearch.GetStopAndSearchesByAreaAsync(area, DateTime.Now.AddMonths(-3));
            Assert.IsTrue(result.Any());
        }
    }
}
