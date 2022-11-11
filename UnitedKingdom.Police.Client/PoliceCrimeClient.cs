using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace UnitedKingdom.Police
{
    public class PoliceCrimeClient
    {
        private readonly HttpClient _httpClient;
        internal PoliceCrimeClient(HttpClient httpClient) => _httpClient = httpClient;

        /// <summary>
        /// Crimes at street-level within a 1 mile radius of a single point.
        /// </summary>
        /// <param name="latitude">Latitude of the requested crime area</param>
        /// <param name="longitude">Longitude of the requested crime area</param>
        /// <param name="date">Optional. (YYYY-MM) Limit results to a specific month. The latest month will be shown by default</param>
        /// <param name="category">You can provide any crime category as part of the request URL.</param>
        public async Task<StreetlevelCrime[]?> GetStreetlevelCrimeAsync(double latitude, double longitude, DateTime? date = null, string? category = "all-crime")
        {
            if (category != null)
            {
                category = "/" + category;
            }
            var url = $"crimes-street{category}?lat={latitude}&lng={longitude}";
            if (date != null)
            {
                url += $"&date={date:yyyy-MM}";
            }
            return await _httpClient.GetFromJsonAsync<StreetlevelCrime[]>(url);
        }

        /// <summary>
        /// Crimes at street-level within a custom area.
        /// </summary>
        /// <param name="polygon">The lat/lng pairs which define the boundary of the custom area</param>
        /// <param name="longitude">Longitude of the requested crime area</param>
        /// <param name="date">Optional. (YYYY-MM) Limit results to a specific month. The latest month will be shown by default</param>
        /// <param name="category">You can provide any crime category as part of the request URL.</param>
        public async Task<StreetlevelCrime[]?> GetStreetlevelCrimeAsync(IEnumerable<(double latitude, double longitude)> polygon, DateTime? date = null, string? category = "all-crime")
        {
            if (category != null)
            {
                category = "/" + category;
            }
            var url = $"crimes-street{category}?poly={string.Join(":", polygon.Select(c => $"{c.latitude},{c.longitude}"))}";
            if (date != null)
            {
                url += $"&date={date:yyyy-MM}";
            }
            return await _httpClient.GetFromJsonAsync<StreetlevelCrime[]>(url);
        }

        /// <summary>
        /// Returns a list of valid categories for a given data set date.
        /// </summary>
        /// <param name="date">Year and month.</param>
        public async Task<CrimeCategory[]?> GetCrimeCategoriesAsync(DateTime date) =>
            await _httpClient.GetFromJsonAsync<CrimeCategory[]>($"crime-categories?date={date:yyyy-MM}");

    }

    /// <summary>
    /// Valid category for a given data set date.
    /// </summary>
    public class CrimeCategory
    {
        /// <summary>
        /// Unique identifier. E.g. "all-crime".
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// Name of the crime category. E.g. "All crime and ASB".
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
