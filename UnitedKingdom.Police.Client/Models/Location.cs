using System.Text.Json.Serialization;

namespace UnitedKingdom.Police
{
    /// <summary>
    /// Approximate location of the incident. See https://data.police.uk/about/#location-anonymisation.
    /// </summary>
    public class Location : Coordinate
    {
        /// <summary>
        /// The approximate street the crime occurred.
        /// </summary>
        [JsonPropertyName("street")]
        public Street Street { get; set; }
    }
}
