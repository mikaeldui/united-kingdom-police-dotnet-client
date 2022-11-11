using System.Text.Json.Serialization;

namespace UnitedKingdom.Police
{
    /// <summary>
    /// The approximate street the crime occurred.
    /// </summary>
    public class StreetlevelCrimeLocationStreet
    {
        /// <summary>
        /// Unique identifier for the street.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Name of the location. This is only an approximation of where the crime happened. Example: "On or near Eastney Road".
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
