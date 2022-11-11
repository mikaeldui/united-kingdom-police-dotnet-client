using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace UnitedKingdom.Police
{
    public class Force
    {
        /// <summary>
        /// Unique force identifier.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Force name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        #region Details

        /// <summary>
        /// Description, with formatting.
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// Force website URL.
        /// </summary>
        [JsonPropertyName("url")]
        public Uri? Url { get; set; }

        /// <summary>
        /// Ways to keep informed.
        /// </summary>
        [JsonPropertyName("engagement_methods")]        
        public EngagementMethod[]? EngagementMethods { get; set; }

        /// <summary>
        /// Force telephone number.
        /// </summary>
        [JsonPropertyName("telephone")]
        public string? Telephone { get; set; }

        #endregion
    }

    public class EngagementMethod
    {
        /// <summary>
        /// Method website URL.
        /// </summary>
        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        /// <summary>
        /// Method description.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Method title.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
