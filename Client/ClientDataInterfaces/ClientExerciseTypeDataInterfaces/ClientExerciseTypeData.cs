using Exercisediary.Shared;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;

namespace Exercisediary.Client.ClientDataInterfaces.ClientExerciseTypeDataInterfaces
{
    public class ClientExerciseTypeData : IClientExerciseTypeData
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        public ClientExerciseTypeData(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public List<ExerciseType> Types { get; set; } = new List<ExerciseType>();

        public async Task GetExerciseTypes()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ExerciseType>>("api/urheilulajit");

            if(result != null) 
            {
                Types = result;
            }
        }
        public async Task<ExerciseType?> GetExerciseType(Guid id)
        {
            var result = await _httpClient.GetAsync($"api/urheilulajit/{id}");
            if(result.StatusCode == HttpStatusCode.OK) 
            {
                return await result.Content.ReadFromJsonAsync<ExerciseType>();
            }
            return null;
        }

        public async Task CreateExerciseType(ExerciseType exerciseType)
        {
            await _httpClient.PostAsJsonAsync("api/urheilulajit", exerciseType);
            _navigationManager.NavigateTo("urheilulajit");
        }

        public async Task UpDateExerciseType(Guid id, ExerciseType exerciseType)
        {
            await _httpClient.PutAsJsonAsync($"api/urheilulajit/{id}", exerciseType);
            _navigationManager.NavigateTo("urheilulajit");
        }

        public async Task DeleteExerciseType(Guid id)
        {
            var result = await _httpClient.DeleteAsync($"api/urheilulajit/{id}");            
            _navigationManager.NavigateTo("urheilulajit");
        }

    }
}
