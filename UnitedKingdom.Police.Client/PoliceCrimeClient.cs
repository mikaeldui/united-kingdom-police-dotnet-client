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
        private const string ALL_CRIME = "all-crime";
        internal PoliceCrimeClient(HttpClient httpClient) => _httpClient = httpClient;

        #region GetStreetlevelCrimeAsync

        #region Point

        /// <summary>
        /// Crimes at street-level within a 1 mile radius of a single point.
        /// </summary>
        /// <param name="latitude">Latitude of the requested crime area</param>
        /// <param name="longitude">Longitude of the requested crime area</param>
        /// <param name="category">You can provide any crime category as part of the request URL.</param>
        /// <param name="date">Optional. (YYYY-MM) Limit results to a specific month. The latest month will be shown by default</param>
        public async Task<StreetlevelCrime[]?> GetStreetlevelCrimeAsync(double latitude, double longitude, string category, DateTime? date = null)
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
        /// Crimes at street-level within a 1 mile radius of a single point.
        /// </summary>
        /// <param name="latitude">Latitude of the requested crime area</param>
        /// <param name="longitude">Longitude of the requested crime area</param>
        /// <param name="date">Optional. (YYYY-MM) Limit results to a specific month. The latest month will be shown by default</param>
        public async Task<StreetlevelCrime[]?> GetStreetlevelCrimeAsync(double latitude, double longitude, DateTime? date = null) =>
            await GetStreetlevelCrimeAsync(latitude, longitude, ALL_CRIME, date);

        /// <summary>
        /// Crimes at street-level within a 1 mile radius of a single point.
        /// </summary>
        /// <param name="latitude">Latitude of the requested crime area</param>
        /// <param name="longitude">Longitude of the requested crime area</param>
        /// <param name="category">You can provide any crime category as part of the request URL.</param>
        /// <param name="date">Optional. (YYYY-MM) Limit results to a specific month. The latest month will be shown by default</param>
        public async Task<StreetlevelCrime[]?> GetStreetlevelCrimeAsync(double latitude, double longitude, CrimeCategory category, DateTime? date = null) =>
            await GetStreetlevelCrimeAsync(latitude, longitude, category.Url, date);

        #endregion Point

        #region Area

        /// <summary>
        /// Crimes at street-level within a custom area.
        /// </summary>
        /// <param name="polygon">The lat/lng pairs which define the boundary of the custom area</param>
        /// <param name="longitude">Longitude of the requested crime area</param>
        /// <param name="category">You can provide any crime category as part of the request URL.</param>
        /// <param name="date">Optional. (YYYY-MM) Limit results to a specific month. The latest month will be shown by default</param>
        public async Task<StreetlevelCrime[]?> GetStreetlevelCrimeAsync(IEnumerable<(double latitude, double longitude)> polygon, string category, DateTime? date = null)
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
        /// Crimes at street-level within a custom area.
        /// </summary>
        /// <param name="polygon">The lat/lng pairs which define the boundary of the custom area</param>
        /// <param name="longitude">Longitude of the requested crime area</param>
        /// <param name="date">Optional. (YYYY-MM) Limit results to a specific month. The latest month will be shown by default</param>
        public async Task<StreetlevelCrime[]?> GetStreetlevelCrimeAsync(IEnumerable<(double latitude, double longitude)> polygon, DateTime? date = null) =>
            await GetStreetlevelCrimeAsync(polygon, ALL_CRIME, date);

        /// <summary>
        /// Crimes at street-level within a custom area.
        /// </summary>
        /// <param name="polygon">The lat/lng pairs which define the boundary of the custom area</param>
        /// <param name="longitude">Longitude of the requested crime area</param>
        /// <param name="category">You can provide any crime category as part of the request URL.</param>
        /// <param name="date">Optional. (YYYY-MM) Limit results to a specific month. The latest month will be shown by default</param>
        public async Task<StreetlevelCrime[]?> GetStreetlevelCrimeAsync(IEnumerable<(double latitude, double longitude)> polygon, CrimeCategory category, DateTime? date = null) =>
            await GetStreetlevelCrimeAsync(polygon, category.Url, date);

        #endregion Area

        #endregion GetStreetlevelCrimeAsync

        /// <summary>
        /// Returns a list of valid categories for a given data set date.
        /// </summary>
        /// <param name="date">Year and month.</param>
        public async Task<CrimeCategory[]?> GetCrimeCategoriesAsync(DateTime date) =>
            await _httpClient.GetFromJsonAsync<CrimeCategory[]>($"crime-categories?date={date:yyyy-MM}");

    }
}
