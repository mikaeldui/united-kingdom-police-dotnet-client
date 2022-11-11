using System.Text.Json.Serialization;

namespace UnitedKingdom.Police
{
    public class Neighbourhood
    {
        /// <summary>
        /// Police force specific team identifier.
        /// Note: this identifier is not unique and may also be used by a different force
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Name for the neighbourhood.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// URL for the neighbourhood on the Force's website.
        /// </summary>
        [JsonPropertyName("url_force")]
        public Uri? ForceUrl { get; set; }

        /// <summary>
        /// Ways to get in touch with the neighbourhood officers.
        /// </summary>
        [JsonPropertyName("contact_details")]
        public ContactDetails? ContactDetails { get; set; }

        [JsonPropertyName("links")]
        public Link[]? Links { get; set; }

        /// <summary>
        /// Centre point locator for the neighbourhood. Note: This may not be exactly in the centre of the neighbourhood
        /// </summary>
        [JsonPropertyName("centre")]
        public Coordinate? Centre { get; set; }

        /// <summary>
        /// Any associated locations with the neighbourhood, e.g. police stations.
        /// </summary>
        [JsonPropertyName("locations")]
        public NeighbourhoodLocation[]? Locations { get; set; }

        /// <summary>
        /// Description (if available).
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// An introduction message for the neighbourhood.
        /// </summary>
        [JsonPropertyName("welcome_message")]
        public string? WelcomeMessage { get; set; }

        /// <summary>
        /// Population of the neighbourhood.
        /// </summary>
        [JsonPropertyName("population")]
        public string? Population { get; set; }
    }
}
