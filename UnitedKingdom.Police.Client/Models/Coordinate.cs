using System.Text.Json.Serialization;

namespace UnitedKingdom.Police
{
    public class Coordinate
    {
        /// <summary>
        /// Latitude
        /// </summary>
        [JsonPropertyName("latitude")]
        public double? Latitude { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        [JsonPropertyName("longitude")]
        public double? Longitude { get; set;}
    }
}
