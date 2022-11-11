using System.Text.Json.Serialization;

namespace UnitedKingdom.Police
{
    /// <summary>
    /// Outcomes at street-level; either at a specific location, within a 1 mile radius of a single point, or within a custom area.
    /// </summary>
    public class Outcome
    {
        /// <summary>
        /// Category of the outcome. See https://data.police.uk/docs/method/outcomes-at-location/.
        /// </summary>
        [JsonPropertyName("category")]
        public OutcomeCategory Category { get; set; }

        /// <summary>
        /// Date of the outcome
        /// </summary>
        [JsonPropertyName("date"), JsonConverter(typeof(YearMonthJsonConverter))]
        public DateTime Date { get; set; }

        /// <summary>
        /// An identifier for the suspect/offender, where available.
        /// </summary>
        [JsonPropertyName("person_id")]
        public int? PersonId { get; set; }

        /// <summary>
        /// Crime information. Not set for the endpoint "outcomes for crime".
        /// </summary>
        [JsonPropertyName("crime")]
        public Crime? Crime { get; set; }
    }
}
