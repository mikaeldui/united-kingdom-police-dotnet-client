using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitedKingdom.Police.Tests
{
    [TestClass]
    public class CrimeTests
    {
        [TestMethod]
        public async Task GetStreetlevelCrimeByPointAsync()
        {
            using var client = new PoliceClient();
            var result = await client.Crimes.GetStreetlevelCrimeAsync(51.375487, -0.096780, DateTime.Now.AddMonths(-3));
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public async Task GetStreetlevelCrimeByAreaAsync()
        {
            var area = new (double latitude, double longitude)[]
            {
                (52.268, 0.543),
                (52.794, 0.238),
                (52.130, 0.478)
            };
            using var client = new PoliceClient();
            var result = await client.Crimes.GetStreetlevelCrimeAsync(area, DateTime.Now.AddMonths(-3));
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public async Task GetCrimeCategoriesAsync()
        {
            using var client = new PoliceClient();
            var result = await client.Crimes.GetCrimeCategoriesAsync(DateTime.Now.AddMonths(-3));
            Assert.IsTrue(result.Any());
            Assert.IsNotNull(result.First().Name);
            Assert.IsNotNull(result.First().Url);
        }
    }
}
