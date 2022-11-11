using System.Text.Json.Serialization;

namespace UnitedKingdom.Police
{
    /// <summary>
    /// Valid category for a given data set date.
    /// </summary>
    public class CrimeCategory
    {
        /// <summary>
        /// Unique identifier. E.g. "all-crime".
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// Name of the crime category. E.g. "All crime and ASB".
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
