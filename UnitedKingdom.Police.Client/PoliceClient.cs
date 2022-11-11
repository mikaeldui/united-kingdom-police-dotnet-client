using System.Net.Http.Json;

namespace UnitedKingdom.Police
{
    public class PoliceClient : IDisposable
    {
        private HttpClient _httpClient;
        private PoliceForceClient? _forceClient;
        private PoliceCrimeClient? _crimeClient;

        public PoliceClient()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://data.police.uk/api/", UriKind.Absolute)
            };
        }

        /// <summary>
        /// Return a list of available data sets.
        /// </summary>
        public async Task<Availability[]?> GetAvailabilityAsync() => await _httpClient.GetFromJsonAsync<Availability[]>("crimes-street-dates");

        /// <summary>
        /// Force related.
        /// </summary>
        public PoliceForceClient Forces => _forceClient ??= new PoliceForceClient(_httpClient);
        
        /// <summary>
        /// Crime related.
        /// </summary>
        public PoliceCrimeClient Crimes => _crimeClient ??= new PoliceCrimeClient(_httpClient);

        public void Dispose() => ((IDisposable)_httpClient).Dispose();
    }
}