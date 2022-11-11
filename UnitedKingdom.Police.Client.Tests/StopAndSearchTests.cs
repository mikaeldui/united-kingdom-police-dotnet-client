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
    }
}
