using System.Text.Json.Serialization;

namespace UnitedKingdom.Police
{
    public class NeighbourhoodEvent
    {
        /// <summary>
        /// Contact details for the event (if available).
        /// </summary>
        [JsonPropertyName("contact_details")]
        public ContactDetails? ContactDetails { get; set; }

        /// <summary>
        /// Description of the event.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Title of the event.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// Address of the event.
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; }

        /// <summary>
        /// Type of event
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Start of the event.
        /// </summary>
        [JsonPropertyName("start_date")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End of the event.
        /// </summary>
        [JsonPropertyName("end_date")]
        public DateTime EndDate { get; set; }
    }
}
