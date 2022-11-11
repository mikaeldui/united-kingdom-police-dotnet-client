using System.Text.Json.Serialization;

namespace UnitedKingdom.Police
{
    /// <summary>
    /// Category of the outcome. See https://data.police.uk/docs/method/outcomes-at-location/.
    /// </summary>
    public class OutcomeCategory
    {
        /// <summary>
        /// Internal code. E.g. "under-investigation".
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// Human-readable name. E.g. "Under investigation".
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
