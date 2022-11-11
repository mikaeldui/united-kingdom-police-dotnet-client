using System.Text.Json.Serialization;

namespace UnitedKingdom.Police
{
    /// <summary>
    /// Approximate location of the incident. See https://data.police.uk/about/#location-anonymisation.
    /// </summary>
    public class StreetlevelCrimeLocation
    {
        /// <summary>
        /// Latitude.
        /// </summary>
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude.
        /// </summary>
        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        /// <summary>
        /// The approximate street the crime occurred.
        /// </summary>
        [JsonPropertyName("street")]
        public StreetlevelCrimeLocationStreet Street { get; set; }
    }
}
