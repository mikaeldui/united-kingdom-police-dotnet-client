using Microsoft.VisualBasic;
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
        public async Task<Crime[]?> GetStreetlevelCrimesAsync(double latitude, double longitude, string category, DateTime? date = null)
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
            return await _httpClient.GetFromJsonAsync<Crime[]>(url);
        }

        /// <summary>
        /// Crimes at street-level within a 1 mile radius of a single point.
        /// </summary>
        /// <param name="latitude">Latitude of the requested crime area</param>
        /// <param name="longitude">Longitude of the requested crime area</param>
        /// <param name="date">Optional. (YYYY-MM) Limit results to a specific month. The latest month will be shown by default</param>
        public async Task<Crime[]?> GetStreetlevelCrimesAsync(double latitude, double longitude, DateTime? date = null) =>
            await GetStreetlevelCrimesAsync(latitude, longitude, ALL_CRIME, date);

        /// <summary>
        /// Crimes at street-level within a 1 mile radius of a single point.
        /// </summary>
        /// <param name="latitude">Latitude of the requested crime area</param>
        /// <param name="longitude">Longitude of the requested crime area</param>
        /// <param name="category">You can provide any crime category as part of the request URL.</param>
        /// <param name="date">Optional. (YYYY-MM) Limit results to a specific month. The latest month will be shown by default</param>
        public async Task<Crime[]?> GetStreetlevelCrimesAsync(double latitude, double longitude, CrimeCategory category, DateTime? date = null) =>
            await GetStreetlevelCrimesAsync(latitude, longitude, category.Url, date);

        #endregion Point

        #region Area

        /// <summary>
        /// Crimes at street-level within a custom area. If a custom area contains more than 10,000 crimes, the API will return a 503 status code.
        /// </summary>
        /// <param name="polygon">The lat/lng pairs which define the boundary of the custom area</param>
        /// <param name="longitude">Longitude of the requested crime area</param>
        /// <param name="category">You can provide any crime category as part of the request URL.</param>
        /// <param name="date">Optional. (YYYY-MM) Limit results to a specific month. The latest month will be shown by default</param>
        public async Task<Crime[]?> GetStreetlevelCrimesAsync(IEnumerable<(double latitude, double longitude)> polygon, string category, DateTime? date = null)
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
            return await _httpClient.GetFromJsonAsync<Crime[]>(url);
        }

        /// <summary>
        /// Crimes at street-level within a custom area. If a custom area contains more than 10,000 crimes, the API will return a 503 status code.
        /// </summary>
        /// <param name="polygon">The lat/lng pairs which define the boundary of the custom area</param>
        /// <param name="longitude">Longitude of the requested crime area</param>
        /// <param name="date">Optional. (YYYY-MM) Limit results to a specific month. The latest month will be shown by default</param>
        public async Task<Crime[]?> GetStreetlevelCrimesAsync(IEnumerable<(double latitude, double longitude)> polygon, DateTime? date = null) =>
            await GetStreetlevelCrimesAsync(polygon, ALL_CRIME, date);

        /// <summary>
        /// Crimes at street-level within a custom area. If a custom area contains more than 10,000 crimes, the API will return a 503 status code.
        /// </summary>
        /// <param name="polygon">The lat/lng pairs which define the boundary of the custom area</param>
        /// <param name="longitude">Longitude of the requested crime area</param>
        /// <param name="category">You can provide any crime category as part of the request URL.</param>
        /// <param name="date">Optional. (YYYY-MM) Limit results to a specific month. The latest month will be shown by default</param>
        public async Task<Crime[]?> GetStreetlevelCrimesAsync(IEnumerable<(double latitude, double longitude)> polygon, CrimeCategory category, DateTime? date = null) =>
            await GetStreetlevelCrimesAsync(polygon, category.Url, date);

        #endregion Area

        #endregion GetStreetlevelCrimeAsync

        #region GetStreetlevelOutcomesAsync

        /// <summary>
        /// Outcomes at street-level at a specific location.
        /// </summary>
        /// <param name="date">Year and month.</param>
        /// <param name="locationId">Crimes and outcomes are mapped to specific locations on the map. Valid IDs are returned by other methods which return location information.</param>
        public async Task<Outcome[]?> GetStreetlevelOutcomesAsync(DateTime date, int locationId) =>
            await _httpClient.GetFromJsonAsync<Outcome[]>($"outcomes-at-location?date={date:yyyy-MM}&location_id={locationId}");

        /// <summary>
        /// Outcomes at street-level within a 1 mile radius of a single point.
        /// </summary>
        /// <param name="date">Year and month.</param>
        /// <param name="latitude">Latitude of the requested crime area</param>
        /// <param name="longitude">Longitude of the requested crime area</param>
        public async Task<Outcome[]?> GetStreetlevelOutcomesAsync(DateTime date, double latitude, double longitude) =>
            await _httpClient.GetFromJsonAsync<Outcome[]>($"outcomes-at-location?date={date:yyyy-MM}&lat={latitude}&lng={longitude}");

        /// <summary>
        /// Outcomes at street-level within a custom area. The area must contain no more than 10,000 outcomes. Otherwise, the API will return a 503 status code.
        /// </summary>
        /// <param name="date">Year and month.</param>
        /// <param name="polygon">The lat/lng pairs which define the boundary of the custom area</param>
        public async Task<Outcome[]?> GetStreetlevelOutcomesAsync(DateTime date, IEnumerable<(double latitude, double longitude)> polygon) =>
            await _httpClient.GetFromJsonAsync<Outcome[]>($"outcomes-at-location?date={date:yyyy-MM}&poly={string.Join(":", polygon.Select(c => $"{c.latitude},{c.longitude}"))}");

        #endregion GetStreetLevelOutcomesAsync

        #region GetCrimesAtLocation

        /// <summary>
        /// Returns just the crimes which occurred at the specified location, rather than those within a radius.
        /// </summary>
        /// <param name="date">Year and month.</param>
        /// <param name="locationId"> Crimes and outcomes are mapped to specific locations on the map. Valid IDs are returned by other methods(new and existing) which return location information.</param>
        public async Task<Crime[]?> GetCrimesAtLocationAsync(DateTime date, int locationId) =>
            await _httpClient.GetFromJsonAsync<Crime[]>($"crimes-at-location?date={date:yyyy-MM}&location_id={locationId}");

        /// <summary>
        /// Returns just the crimes which occurred at the specified location, rather than those within a radius. Given latitude and longitude, finds the nearest pre-defined location and returns the crimes which occurred there.
        /// </summary>
        /// <param name="date">Year and month.</param>
        /// <param name="latitude">Latitude of the requested crime area.</param>
        /// <param name="longitude">Longitude of the requested crime area.</param>
        public async Task<Crime[]?> GetCrimesAtLocationAsync(DateTime date, double latitude, double longitude) =>
            await _httpClient.GetFromJsonAsync<Crime[]>($"crimes-at-location?date={date:yyyy-MM}&lat={latitude}&lng={longitude}");

        #endregion GetCrimesAtLocation

        #region GetCrimesNoLocation

        /// <summary>
        /// Returns a list of crimes that could not be mapped to a location.
        /// </summary>
        /// <param name="category">The category of the crimes. See https://data.police.uk/docs/method/crime-categories/</param>
        /// <param name="force">Specific police force.</param>
        /// <param name="date">Optional. (YYYY-MM) Limit results to a specific month. The latest month will be shown by default</param>
        public async Task<Crime[]?> GetCrimesNoLocationAsync(string category, string force, DateTime? date = null)
        {
            var url = $"crimes-no-location?category={category}&force={force}";
            if (date != null)
                url += $"&date={date:yyyy-MM}";
            return await _httpClient.GetFromJsonAsync<Crime[]>(url);
        }

        /// <summary>
        /// Returns a list of crimes that could not be mapped to a location.
        /// </summary>
        /// <param name="category">The category of the crimes.</param>
        /// <param name="force">Specific police force.</param>
        /// <param name="date">Optional. (YYYY-MM) Limit results to a specific month. The latest month will be shown by default</param>
        public async Task<Crime[]?> GetCrimesNoLocationAsync(CrimeCategory category, string force, DateTime? date = null) =>
            await GetCrimesNoLocationAsync(category.Url, force, date);

        /// <summary>
        /// Returns a list of crimes that could not be mapped to a location.
        /// </summary>
        /// <param name="category">The category of the crimes.</param>
        /// <param name="force">Specific police force.</param>
        /// <param name="date">Optional. (YYYY-MM) Limit results to a specific month. The latest month will be shown by default</param>
        public async Task<Crime[]?> GetCrimesNoLocationAsync(CrimeCategory category, Force force, DateTime? date = null) =>
            await GetCrimesNoLocationAsync(category.Url, force.Id, date);

        /// <summary>
        /// Returns a list of crimes that could not be mapped to a location.
        /// </summary>
        /// <param name="category">The category of the crimes.</param>
        /// <param name="force">Specific police force.</param>
        /// <param name="date">Optional. (YYYY-MM) Limit results to a specific month. The latest month will be shown by default</param>
        public async Task<Crime[]?> GetCrimesNoLocationAsync(string category, Force force, DateTime? date = null) =>
            await GetCrimesNoLocationAsync(category, force.Id, date);

        #endregion GetCrimesNoLocation

        /// <summary>
        /// Returns a list of valid categories for a given data set date.
        /// </summary>
        /// <param name="date">Year and month.</param>
        public async Task<CrimeCategory[]?> GetCrimeCategoriesAsync(DateTime date) =>
            await _httpClient.GetFromJsonAsync<CrimeCategory[]>($"crime-categories?date={date:yyyy-MM}");

        /// <summary>
        /// Crime data in the API is updated once a month. Find out when it was last updated.
        /// </summary>
        public async Task<DateTime?> GetLastUpdatedAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<Dictionary<string, DateTime>>("crime-last-updated");
            return result.First().Value;
        }

        /// <summary>
        /// Returns the outcomes (case history) for the specified crime. Crime ID is 64-character identifier, as returned by other API methods.
        /// </summary>
        /// <param name="persistentId">Crime ID (persistent ID) is 64-character identifier, as returned by other API methods. E.g. "590d68b69228a9ff95b675bb4af591b38de561aa03129dc09a03ef34f537588c".</param>
        /// <returns></returns>
        public async Task<OutcomesForCrime?> GetOutcomesForCrimeAsync(string persistentId) =>
            await _httpClient.GetFromJsonAsync<OutcomesForCrime>("outcomes-for-crime/" + persistentId);
    }

    /// <summary>
    /// Returns the outcomes (case history) for the specified crime. Crime ID is 64-character identifier, as returned by other API methods.
    /// </summary>
    public class OutcomesForCrime
    {
        /// <summary>
        /// Crime information.
        /// </summary>
        [JsonPropertyName("crime")]
        public Crime Crime { get; set; }

        /// <summary>
        /// A list of categories and dates of each outcome.
        /// </summary>
        [JsonPropertyName("outcomes")]
        public Outcome[] Outcomes { get; set; }
    }
}
