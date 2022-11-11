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
            var result = await client.Crimes.GetStreetlevelCrimesAsync(51.375487, -0.096780, DateTime.Now.AddMonths(-3));
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
            var result = await client.Crimes.GetStreetlevelCrimesAsync(area, DateTime.Now.AddMonths(-3));
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public async Task GetStreetlevelOutcomesByLocationAsync()
        {
            using var client = new PoliceClient();
            var outcomes = await client.Crimes.GetStreetlevelOutcomesAsync(DateTime.Now.AddMonths(-3), 51.375487, -0.096780);

            var result = await client.Crimes.GetStreetlevelOutcomesAsync(DateTime.Now.AddMonths(-3), outcomes.First().Crime.Location.Street.Id);
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public async Task GetStreetlevelOutcomesByPointAsync()
        {
            using var client = new PoliceClient();
            var result = await client.Crimes.GetStreetlevelOutcomesAsync(DateTime.Now.AddMonths(-3), 51.375487, -0.096780);
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public async Task GetStreetlevelOutcomesByAreaAsync()
        {
            var area = new (double latitude, double longitude)[]
            {
                (52.268, 0.543),
                (52.794, 0.238),
                (52.130, 0.478)
            };
            using var client = new PoliceClient();
            var result = await client.Crimes.GetStreetlevelOutcomesAsync(DateTime.Now.AddMonths(-3), area);
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public async Task GetCrimesAtLocationByIdAsync()
        {
            using var client = new PoliceClient();
            var crimes = await client.Crimes.GetStreetlevelCrimesAsync(51.375487, -0.096780, DateTime.Now.AddMonths(-3));

            var result = await client.Crimes.GetCrimesAtLocationAsync(DateTime.Now.AddMonths(-3), crimes.First().Location.Street.Id);
            Assert.IsTrue(result.Any());
        }


        [TestMethod]
        public async Task GetCrimesAtLocationByCoordinatesAsync()
        {
            using var client = new PoliceClient();
            var crimes = await client.Crimes.GetStreetlevelCrimesAsync(51.375487, -0.096780, DateTime.Now.AddMonths(-3));

            var result = await client.Crimes.GetCrimesAtLocationAsync(DateTime.Now.AddMonths(-3), crimes.First().Location.Latitude, crimes.First().Location.Longitude);
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public async Task GetCrimesNoLocationAsync()
        {
            var client = new PoliceClient();
            var result = await client.Crimes.GetCrimesNoLocationAsync("all-crimes", "leicestershire", DateTime.Now.AddMonths(-3));
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

        [TestMethod]
        public async Task GetLastUpdatedAsync()
        {
            using var client = new PoliceClient();
            var result = await client.Crimes.GetLastUpdatedAsync();
            Assert.IsTrue(result > DateTime.Now.AddMonths(-4));
        }

        [TestMethod]
        public async Task GetOutcomesForCrimeAsync()
        {
            using var client = new PoliceClient();
            var crimes = await client.Crimes.GetStreetlevelCrimesAsync(51.375487, -0.096780, DateTime.Now.AddMonths(-3));
            var result = await client.Crimes.GetOutcomesForCrimeAsync(crimes.First(c => c.OutcomeStats != null).PersistentId);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Outcomes.Any());
            Assert.IsNotNull(result.Crime);
            Assert.IsNotNull(result.Crime.Category);
        }
    }
}
