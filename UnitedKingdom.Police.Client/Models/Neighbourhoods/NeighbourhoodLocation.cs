using System.Text.Json.Serialization;

namespace UnitedKingdom.Police
{
    /// <summary>
    /// Any associated locations with the neighbourhood, e.g. police stations.
    /// </summary>
    public class NeighbourhoodLocation : Coordinate
    {
        /// <summary>
        /// Name (if available).
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Postcode.
        /// </summary>
        [JsonPropertyName("postcode")]
        public string Postcode { get; set; }

        /// <summary>
        /// Location address.
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; }

        /// <summary>
        /// Telephone number.
        /// </summary>
        [JsonPropertyName("telephone")]
        public string Telephone { get; set; }

        /// <summary>
        /// Type of location, e.g. 'station' (police station).
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
