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
        internal PoliceNeighbourhoodClient(HttpClient httpClient) => _httpClient = httpClient;

        #region Get Neighbourhoods

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

        #endregion

        #region Get Neighbourhood

        /// <summary>
        /// Specific neighbourhood.
        /// </summary>
        public async Task<Neighbourhood?> GetNeighbourhoodAsync(string forceId, string neighbourhoodId) =>
            await _httpClient.GetFromJsonAsync<Neighbourhood>(forceId + "/" + neighbourhoodId);

        /// <summary>
        /// Specific neighbourhood.
        /// </summary>
        public async Task<Neighbourhood?> GetNeighbourhoodAsync(Force force, string neighbourhoodId) =>
            await GetNeighbourhoodAsync(force.Id, neighbourhoodId);
        
        /// <summary>
        /// Specific neighbourhood.
        /// </summary>
        public async Task<Neighbourhood?> GetNeighbourhoodAsync(Force force, Neighbourhood neighbourhood) =>
            await GetNeighbourhoodAsync(force.Id, neighbourhood.Id);
        
        /// <summary>
        /// Specific neighbourhood.
        /// </summary>
        public async Task<Neighbourhood?> GetNeighbourhoodAsync(string forceId, Neighbourhood neighbourhood) =>
            await GetNeighbourhoodAsync(forceId, neighbourhood.Id);

        #endregion

        #region Get Neighbourhood Boundary

        /// <summary>
        /// A list of latitude/longitude pairs that make up the boundary of a neighbourhood.
        /// </summary>
        public async Task<Coordinate[]?> GetNeighbourhoodBoundaryAsync(string forceId, string neighbourhoodId) =>
            await _httpClient.GetFromJsonAsync<Coordinate[]>(forceId + "/" + neighbourhoodId + "/boundary");

        /// <summary>
        /// A list of latitude/longitude pairs that make up the boundary of a neighbourhood.
        /// </summary>
        public async Task<Coordinate[]?> GetNeighbourhoodBoundaryAsync(Force force, string neighbourhoodId) =>
            await GetNeighbourhoodBoundaryAsync(force.Id, neighbourhoodId);

        /// <summary>
        /// A list of latitude/longitude pairs that make up the boundary of a neighbourhood.
        /// </summary>
        public async Task<Coordinate[]?> GetNeighbourhoodBoundaryAsync(Force force, Neighbourhood neighbourhood) =>
            await GetNeighbourhoodBoundaryAsync(force.Id, neighbourhood.Id);

        /// <summary>
        /// A list of latitude/longitude pairs that make up the boundary of a neighbourhood.
        /// </summary>
        public async Task<Coordinate[]?> GetNeighbourhoodBoundaryAsync(string forceId, Neighbourhood neighbourhood) =>
            await GetNeighbourhoodBoundaryAsync(forceId, neighbourhood.Id);

        #endregion

        #region Get Neighbourhood Team

        /// <summary>
        /// Neighbourhood team
        /// </summary>
        public async Task<Person[]?> GetNeighbourhoodTeamAsync(string forceId, string neighbourhoodId) =>
            await _httpClient.GetFromJsonAsync<Person[]>(forceId + "/" + neighbourhoodId + "/team");

        /// <summary>
        /// Neighbourhood team
        /// </summary>
        public async Task<Person[]?> GetNeighbourhoodTeamAsync(Force force, string neighbourhoodId) =>
            await GetNeighbourhoodTeamAsync(force.Id, neighbourhoodId);

        /// <summary>
        /// Neighbourhood team
        /// </summary>
        public async Task<Person[]?> GetNeighbourhoodTeamAsync(Force force, Neighbourhood neighbourhood) =>
            await GetNeighbourhoodTeamAsync(force.Id, neighbourhood.Id);

        /// <summary>
        /// Neighbourhood team
        /// </summary>
        public async Task<Person[]?> GetNeighbourhoodTeamAsync(string forceId, Neighbourhood neighbourhood) =>
            await GetNeighbourhoodTeamAsync(forceId, neighbourhood.Id);

        #endregion

        #region Get Neighbourhood Events

        /// <summary>
        /// Neighbourhood events
        /// </summary>
        public async Task<NeighbourhoodEvent[]?> GetNeighbourhoodEventsAsync(string forceId, string neighbourhoodId) =>
            await _httpClient.GetFromJsonAsync<NeighbourhoodEvent[]>(forceId + "/" + neighbourhoodId + "/events");

        /// <summary>
        /// Neighbourhood events
        /// </summary>
        public async Task<NeighbourhoodEvent[]?> GetNeighbourhoodEventsAsync(Force force, string neighbourhoodId) =>
            await GetNeighbourhoodEventsAsync(force.Id, neighbourhoodId);

        /// <summary>
        /// Neighbourhood events
        /// </summary>
        public async Task<NeighbourhoodEvent[]?> GetNeighbourhoodEventsAsync(Force force, Neighbourhood neighbourhood) =>
            await GetNeighbourhoodEventsAsync(force.Id, neighbourhood.Id);

        /// <summary>
        /// Neighbourhood events
        /// </summary>
        public async Task<NeighbourhoodEvent[]?> GetNeighbourhoodEventsAsync(string forceId, Neighbourhood neighbourhood) =>
            await GetNeighbourhoodEventsAsync(forceId, neighbourhood.Id);

        #endregion

        #region Get Neighbourhood Priorities

        /// <summary>
        /// Neighbourhood priorities
        /// </summary>
        public async Task<NeighbourhoodPriority[]?> GetNeighbourhoodPrioritiesAsync(string forceId, string neighbourhoodId) =>
            await _httpClient.GetFromJsonAsync<NeighbourhoodPriority[]>(forceId + "/" + neighbourhoodId + "/priorities");

        /// <summary>
        /// Neighbourhood priorities
        /// </summary>
        public async Task<NeighbourhoodPriority[]?> GetNeighbourhoodPrioritiesAsync(Force force, string neighbourhoodId) =>
            await GetNeighbourhoodPrioritiesAsync(force.Id, neighbourhoodId);

        /// <summary>
        /// Neighbourhood priorities
        /// </summary>
        public async Task<NeighbourhoodPriority[]?> GetNeighbourhoodPrioritiesAsync(Force force, Neighbourhood neighbourhood) =>
            await GetNeighbourhoodPrioritiesAsync(force.Id, neighbourhood.Id);

        /// <summary>
        /// Neighbourhood priorities
        /// </summary>
        public async Task<NeighbourhoodPriority[]?> GetNeighbourhoodPrioritiesAsync(string forceId, Neighbourhood neighbourhood) =>
            await GetNeighbourhoodPrioritiesAsync(forceId, neighbourhood.Id);

        #endregion 

        /// <summary>
        /// Find the neighbourhood policing team responsible for a particular area.
        /// </summary>
        public async Task<(string force, string neighbourhood)> GetNeighbourhoodForLocationAsync(double latitude, double longitude)
        {
            var result = await _httpClient.GetFromJsonAsync<Dictionary<string, string>>($"locate-neighbourhood?q={latitude},{longitude}");
            return (result["force"], result["neighbourhood"]);
        }

        /// <summary>
        /// Find the neighbourhood policing team responsible for a particular area.
        /// </summary>
        public async Task<(string force, string neighbourhood)> GetNeighbourhoodForLocationAsync(Coordinate coordinate) =>
            await GetNeighbourhoodForLocationAsync(coordinate.Latitude, coordinate.Longitude);
    }
}
