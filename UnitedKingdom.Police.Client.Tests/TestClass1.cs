using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitedKingdom.Police.Tests
{
    [TestClass]
    public class TestClass1
    {
        [TestMethod]
        public async Task GetAvailabilityAsync()
        {
            using var client = new PoliceClient();
            var result = await client.GetAvailabilityAsync();
            Assert.IsTrue(result.Any());
        }
    }
}
