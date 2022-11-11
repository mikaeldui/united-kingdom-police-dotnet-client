using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace UnitedKingdom.Police
{
    public class PoliceForceClient
    {
        private readonly HttpClient _httpClient;
        internal PoliceForceClient(HttpClient httpClient) 
        { 
            _httpClient = httpClient;
        }

        /// <summary>
        /// A list of all the police forces available via the API except the British Transport Police, which is excluded from the list returned. 
        /// Unique force identifiers obtained here are used in requests for force-specific data via other methods.
        /// </summary>
        public async Task<Force[]?> GetForcesAsync() =>
            await _httpClient.GetFromJsonAsync<Force[]>("forces");

        public async Task<Force?> GetForceAsync(string id) =>
            await _httpClient.GetFromJsonAsync<Force>($"forces/{id}");

        public async Task<Force?> GetForceAsync(Force force) => await GetForceAsync(force.Id);

        public async Task<SeniorOfficer[]?> GetSeniorOfficersAsync(string forceId) =>
            await _httpClient.GetFromJsonAsync<SeniorOfficer[]>($"forces/{forceId}/people");

        public async Task<SeniorOfficer[]?> GetSeniorOfficersAsync(Force force) => await GetSeniorOfficersAsync(force.Id);
    }
}
