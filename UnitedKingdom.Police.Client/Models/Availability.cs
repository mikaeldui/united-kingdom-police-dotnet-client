using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UnitedKingdom.Police
{
    public class Availability
    {
        /// <summary>
        /// Year and month of all available street level crime data.
        /// </summary>
        [JsonPropertyName("date"), JsonConverter(typeof(YearMonthJsonConverter))]
        public DateTime Date { get; set; }

        /// <summary>
        /// A list of force IDs for forces that have provided stop and search data for this month
        /// </summary>
        [JsonPropertyName("stop-and-search")]
        public string[] StopAndSearch { get; set; }
    }
}
