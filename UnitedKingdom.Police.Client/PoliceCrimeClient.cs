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
        internal PoliceCrimeClient(HttpClient httpClient) 
        { 
            _httpClient = httpClient;
        }

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
    }
}
