using System.Text.Json.Serialization;

namespace UnitedKingdom.Police
{
    public class NeighbourhoodPriority
    {
        /// <summary>
        /// An issue raised with the police. Formatted.
        /// </summary>
        [JsonPropertyName("issue")]
        public string Issue { get; set; }

        /// <summary>
        /// When the priority was agreed upon.
        /// </summary>
        [JsonPropertyName("issue-date")]
        public DateTime IssueDate { get; set; }

        /// <summary>
        /// Action taken to adress the priority. Formatted.
        /// </summary>
        [JsonPropertyName("action")]
        public string? Action { get; set; }

        /// <summary>
        /// When action was last taken.
        /// </summary>
        [JsonPropertyName("action-date")]
        public DateTime? ActionDate { get; set; }
    }
}
