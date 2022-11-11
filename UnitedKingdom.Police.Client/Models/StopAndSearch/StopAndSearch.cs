using System.Text.Json.Serialization;

namespace UnitedKingdom.Police
{
    public class StopAndSearch
    {
        /// <summary>
        /// Whether this was a 'Person search', a 'Vehicle search', or a 'Person and Vehicle search'.
        /// </summary>
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        /// <summary>
        /// Whether a person was searched in this incident (derived from type; true if anything but 'Vehicle search').
        /// </summary>
        [JsonPropertyName("involved_person")]
        public bool? InvolvedPerson { get; set; }

        /// <summary>
        /// When the stop and search took place. Note that some forces only provide dates for their stop and searches, so you might see a disproportionate number of incidents occuring at midnight..
        /// </summary>
        [JsonPropertyName("datetime")]
        public DateTime? DateTime { get; set; }

        /// <summary>
        /// Whether this stop and search was part of a policing operation.
        /// </summary>
        [JsonPropertyName("operation"), JsonConverter(typeof(StringOrFalseJsonConverter))]
        public string Operation { get; set; }

        /// <summary>
        /// The name of the operation this stop and search was part of.
        /// </summary>
        [JsonPropertyName("operation_name")]
        public string? OperationName { get; set; }

        /// <summary>
        /// Approximate location of the incident. See https://data.police.uk/about/#location-anonymisation.
        /// </summary>
        [JsonPropertyName("location")]
        public Location? Location { get; set; }

        /// <summary>
        /// Human-readable gender of the person stopped, if applicable and provided.
        /// </summary>
        [JsonPropertyName("gender")]
        public string? Gender { get; set; }

        /// <summary>
        /// The age range of the person stopped at the time the stop occurred.
        /// </summary>
        [JsonPropertyName("age_range")]
        public string? AgeRange { get; set; }

        /// <summary>
        /// The self-defined ethnicity of the person stopped.
        /// </summary>
        [JsonPropertyName("self_defined_ethnicity")]
        public string? SelfDefinedEthnicity { get; set; }

        /// <summary>
        /// The officer-defined ethnicity of the person stopped.
        /// </summary>
        [JsonPropertyName("officer_defined_ethnicity")]
        public string? OfficerDefinedEthnicity { get; set; }

        /// <summary>
        /// The power used to carry out the stop and search.
        /// </summary>
        [JsonPropertyName("legislation")]
        public string? Legislation { get; set; }

        /// <summary>
        /// The reason the stop and search was carried out.
        /// </summary>
        [JsonPropertyName("object_of_search")]
        public string? ObjectOfSearch { get; set; }

        /// <summary>
        /// The outcome of the stop. false if nothing was found, an empty string if no outcome was provided.
        /// </summary>
        [JsonPropertyName("outcome")]
        public string? Outcome { get; set; }
        
        /// <summary>
        /// Whether the outcome was related to the reason the stop and search was carried out, as a boolean value (or null if not provided).
        /// </summary>
        [JsonPropertyName("outcome_linked_to_object_of_search")]
        public bool? IsOutcomeLinkedToObjectOfSearch { get; set; }

        /// <summary>
        /// Whether the person searched had more than their outer clothing removed, as a boolean value (or null if not provided)
        /// </summary>
        [JsonPropertyName("removal_of_more_than_outer_clothing")]
        public bool? IsRemovalOfMoreThanOuterClothing { get; set; }
    }
}
