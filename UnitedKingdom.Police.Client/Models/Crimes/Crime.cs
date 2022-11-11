using System.Text.Json.Serialization;

namespace UnitedKingdom.Police
{
    public class Crime
    {
        /// <summary>
        /// Category of the crime. See https://data.police.uk/docs/method/crime-categories/
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 64-character unique identifier for that crime. (This is different to the existing 'id' attribute, which is not guaranteed to always stay the same for each crime.). Example: c82dec0541dfe24ea9794a8c85aca6a7bb89dc1e3635bbc019198b9189c2e577.
        /// </summary>
        [JsonPropertyName("persistent_id")]
        public string PersistentId { get; set; }

        /// <summary>
        /// Month of the crime.
        /// </summary>
        [JsonPropertyName("month"), JsonConverter(typeof(YearMonthJsonConverter))]
        public DateTime Month { get; set; }

        /// <summary>
        /// Approximate location of the incident. See https://data.police.uk/about/#location-anonymisation.
        /// </summary>
        [JsonPropertyName("location")]
        public StreetlevelCrimeLocation Location { get; set; }

        /// <summary>
        /// Extra information about the crime (if applicable).
        /// </summary>
        [JsonPropertyName("context")]
        public string? Context { get; set; }

        /// <summary>
        /// ID of the crime.
        /// This ID only relates to the API, it is NOT a police identifier
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// The type of the location. Either Force or BTP: Force indicates a normal police force location; BTP indicates a British Transport Police location. BTP locations fall within normal police force boundaries.
        /// </summary>
        [JsonPropertyName("location_type")]
        public string LocationType { get; set; }

        /// <summary>
        /// For BTP locations, the type of location at which this crime was recorded.
        /// </summary>
        [JsonPropertyName("location_subtype")]
        public string LocationSubtype { get; set; }

        /// <summary>
        /// The category and date of the latest recorded outcome for the crime
        /// </summary>
        [JsonPropertyName("outcome_status")]
        public StreetlevelCrimeOutcomeStatus OutcomeStats { get; set; }
    }
}
