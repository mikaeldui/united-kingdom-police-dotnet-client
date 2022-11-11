using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace UnitedKingdom.Police
{
    public class PoliceStopAndSearchClient
    {
        private readonly HttpClient _httpClient;
        internal PoliceStopAndSearchClient(HttpClient httpClient) => _httpClient = httpClient;

        /// <summary>
        /// Stop and searches at street-level within a 1 mile radius of a single point.
        /// </summary>
        /// <param name="latitude">Latitude of the centre of the desired area</param>
        /// <param name="longitude">Longitude of the centre of the desired area</param>
        /// <param name="date">Optional. (YYYY-MM) Limit results to a specific month. The latest month will be shown by default</param>
        public async Task<StopAndSearch[]?> GetStopAndSearchesByAreaAsync(double latitude, double longitude, DateTime? date)
        {
            var url = $"stops-street?lat={latitude}&lng={longitude}";

            if (date != null)
            {
                url += $"&date={date:yyyy-MM}";
            }

            return await _httpClient.GetFromJsonAsync<StopAndSearch[]>(url);
        }

        /// <summary>
        /// Stop and searches at street-level within a 1 mile radius of a single point.
        /// </summary>
        /// <param name="coordinate">Coordinate of the centre of the desired area</param>
        /// <param name="date">Optional. (YYYY-MM) Limit results to a specific month. The latest month will be shown by default</param>
        public async Task<StopAndSearch[]?> GetStopAndSearchesByAreaAsync(Coordinate coordinate, DateTime? date) =>
            await GetStopAndSearchesByAreaAsync(coordinate.Latitude, coordinate.Longitude, date);

    }
}
