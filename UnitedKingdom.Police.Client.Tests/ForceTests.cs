using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitedKingdom.Police.Tests
{
    [TestClass]
    public class ForceTests
    {
        [TestMethod]
        public async Task GetForcesAsync()
        {
            using var client = new PoliceClient();
            var result = await client.Forces.GetForcesAsync();
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public async Task GetForceAsync()
        {
            using var client = new PoliceClient();
            var forces = await client.Forces.GetForcesAsync();
            var result = await client.Forces.GetForceAsync(forces.Skip(3).First().Id);
            Assert.IsNotNull(result.Description);
            Assert.IsTrue(result.EngagementMethods.Any());
        }


        [TestMethod]
        public async Task GetPeopleAsync()
        {
            using var client = new PoliceClient();
            var result = await client.Forces.GetSeniorOfficersAsync("leicestershire"); // barely any have listed senior officers...
            Assert.IsTrue(result.Any());
            Assert.IsNotNull(result.First().Rank);
        }
    }
}
