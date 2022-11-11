using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace UnitedKingdom.Police
{
    public class PoliceNeighbourhoodClient
    {
        private readonly HttpClient _httpClient;
        internal PoliceNeighbourhoodClient(HttpClient httpClient) 
        { 
            _httpClient = httpClient;
        }

        /// <summary>
        /// List of neighbourhoods for a force.
        /// </summary>
        public async Task<Neighbourhood[]?> GetNeighbourhoodsAsync(string forceId) =>
            await _httpClient.GetFromJsonAsync<Neighbourhood[]>(forceId + "/neighbourhoods");

        /// <summary>
        /// List of neighbourhoods for a force.
        /// </summary>
        public async Task<Neighbourhood[]?> GetNeighbourhoodsAsync(Force force) =>
            await GetNeighbourhoodsAsync(force.Id);
    }

    public class Neighbourhood
    {
        /// <summary>
        /// Police force specific team identifier.
        /// Note: this identifier is not unique and may also be used by a different force
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Name for the neighbourhood
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
