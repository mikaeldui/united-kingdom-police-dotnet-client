using System.Text.Json.Serialization;

namespace UnitedKingdom.Police
{
    public class StreetlevelCrime : Crime
    {
        /// <summary>
        /// The category and date of the latest recorded outcome for the crime
        /// </summary>
        [JsonPropertyName("outcome_status")]
        public StreetlevelCrimeOutcomeStatus OutcomeStats { get; set; }
    }
}
