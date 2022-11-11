using System.Text.Json.Serialization;

namespace UnitedKingdom.Police
{
    /// <summary>
    /// Contact details for the senior officer, or ways to get in touch with the neighbourhood officers.
    /// </summary>
    public class ContactDetails
    {
        /// <summary>
        /// Email address.
        /// </summary>
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        /// <summary>
        /// Telephone number.
        /// </summary>
        [JsonPropertyName("telephone")]
        public string? Telephone { get; set; }

        /// <summary>
        /// Mobile number.
        /// </summary>
        [JsonPropertyName("mobile")]
        public string? Mobile { get; set; }

        /// <summary>
        /// Fax number.
        /// </summary>
        [JsonPropertyName("fax")]
        public string? Fax { get; set; }

        /// <summary>
        /// Website address.
        /// </summary>
        [JsonPropertyName("web")]
        public Uri? Web { get; set; }

        /// <summary>
        /// Street address.
        /// </summary>
        [JsonPropertyName("address")]
        public string? Address { get; set; }

        /// <summary>
        /// Facebook profile URL.
        /// </summary>
        [JsonPropertyName("facebook")]
        public Uri? Facebook { get; set; }

        /// <summary>
        /// Twitter profile URL.
        /// </summary>
        [JsonPropertyName("twitter")]
        public Uri? Twitter { get; set; }

        /// <summary>
        /// YouTube profile URL.
        /// </summary>
        [JsonPropertyName("youtube")]
        public Uri? Youtube { get; set; }

        /// <summary>
        /// Myspace profile URL.
        /// </summary>
        [JsonPropertyName("myspace")]
        public Uri? Myspace { get; set; }

        /// <summary>
        /// Bebo profile URL.
        /// </summary>
        [JsonPropertyName("bebo")]
        public Uri? Bebo { get; set; }

        /// <summary>
        /// Flickr profile URL.
        /// </summary>
        [JsonPropertyName("flickr")]
        public Uri? Flickr { get; set; }

        /// <summary>
        /// Google+ profile URL.
        /// </summary>
        [JsonPropertyName("google-plus")]
        public Uri? GooglePlus { get; set; }

        /// <summary>
        /// Forum URL.
        /// </summary>
        [JsonPropertyName("forum")]
        public Uri? Forum { get; set; }

        /// <summary>
        /// E-msssaging URL.
        /// </summary>
        [JsonPropertyName("e-messaging")]
        public Uri? Emessaging { get; set; }

        /// <summary>
        /// Blog URL.
        /// </summary>
        [JsonPropertyName("blog")]
        public Uri? Blog { get; set; }

        /// <summary>
        /// RSS URL.
        /// </summary>
        [JsonPropertyName("rss")]
        public Uri? Rss { get; set; }
    }
}
