using System.Text.Json.Serialization;

namespace UnitedKingdom.Police
{
    /// <summary>
    /// The category and date of the latest recorded outcome for the crime.
    /// </summary>
    public class CrimeOutcomeStatus
    {
        /// <summary>
        /// Category of the outcome.
        /// The full category name is returned.
        /// IMPORTANT NOTE: This element may not be present for all crimes.
        /// See: https://data.police.uk/docs/method/crime-street/. Example: "Investigation complete; no suspect identified".
        /// </summary>
        [JsonPropertyName("category")]
        public string? Category { get; set; }

        /// <summary>
        /// Date of the outcome. Example: "2022-09".
        /// </summary>
        [JsonPropertyName("date"), JsonConverter(typeof(YearMonthJsonConverter))]
        public DateTime? Date { get; set; }
    }
}
