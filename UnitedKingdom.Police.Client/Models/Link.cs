using System.Text.Json.Serialization;

namespace UnitedKingdom.Police
{
    public class Link
    {
        /// <summary>
        /// URL.
        /// </summary>
        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        /// <summary>
        /// Description of the link (if available).
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// Title of the link.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
