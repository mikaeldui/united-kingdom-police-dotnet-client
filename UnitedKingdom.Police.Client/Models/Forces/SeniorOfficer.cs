using System.Text.Json.Serialization;

namespace UnitedKingdom.Police
{
    public class SeniorOfficer
    {
        /// <summary>
        /// Senior officer biography (if available).
        /// </summary>
        [JsonPropertyName("bio")]
        public string? Bio { get; set; }

        /// <summary>
        /// Contact details for the senior officer.
        /// </summary>
        [JsonPropertyName("contact_details")]
        public SeniorOfficerContactDetails? ContactDetails { get; set; }

        /// <summary>
        /// Name of the person.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Force rank.
        /// </summary>
        [JsonPropertyName("rank")]
        public string Rank { get; set; }
    }
}
