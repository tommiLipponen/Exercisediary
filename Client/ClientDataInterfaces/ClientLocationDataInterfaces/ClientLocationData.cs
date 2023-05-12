using Exercisediary.Shared;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;

namespace Exercisediary.Client.ClientDataInterfaces.ClientLocationDataInterfaces
{
    public class ClientLocationData : IClientLocationData
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        public ClientLocationData(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }
        public List<Location> Paikat { get; set; } = new List<Location>();
        public async Task GetLocations()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Location>>("api/suorituspaikat");
            if(result != null)
            {
                Paikat = result;
            }
        }
        public async Task<Location?> GetLocationById(Guid id)
        {
            var result = await _httpClient.GetAsync($"api/suorituspaikat/{id}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<Location>();
            }
            return null;
        }

        public async Task CreateLocation(Location location)
        {
            await _httpClient.PostAsJsonAsync("api/suorituspaikat", location);
            _navigationManager.NavigateTo("suorituspaikat");
        }

        public async Task UpdateLocation(Guid id, Location location)
        {
            await _httpClient.PutAsJsonAsync($"api/suorituspaikat/{id}", location);
            _navigationManager.NavigateTo("suorituspaikat");
        }
        public async Task DeleteLocation(Guid id)
        {
            await _httpClient.DeleteAsync($"api/suorituspaikat/{id}");
            _navigationManager.NavigateTo("suorituspaikat");
        }
    }
}
