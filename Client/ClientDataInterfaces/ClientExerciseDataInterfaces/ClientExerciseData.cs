using Exercisediary.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Exercisediary.Client.ClientDataInterfaces.ClientExerciseDataInterfaces
{
    public class ClientExerciseData : IClientExerciseData
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
      
        public ClientExerciseData(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }
        
        public async Task<IEnumerable<Exercise>> GetAllExercisesAsync()
        {
            var exercises = await _httpClient.GetFromJsonAsync<IEnumerable<Exercise>>("api/harjoitteet");
            if (exercises == null)
            {
                return Enumerable.Empty<Exercise>();
            }
            return exercises;
        }
        public async Task<Exercise> GetExerciseByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"/api/harjoitteet/{id}");
            response.EnsureSuccessStatusCode();

            if (response.Content == null)
            {
                return null;
            }

            var exercise = await response.Content.ReadFromJsonAsync<Exercise>();

            return exercise;
        }
        public async Task AddExerciseAsync(Exercise exercise)
        {
            await _httpClient.PostAsJsonAsync("api/harjoitteet", exercise);
            _navigationManager.NavigateTo("harjoitteet");
        }
        public async Task UpdateExerciseAsync(Guid id, Exercise exercise)
        {
            await _httpClient.PutAsJsonAsync($"api/harjoitteet/{id}", exercise);
            _navigationManager.NavigateTo("harjoitteet");           
        }

        public async Task DeleteExerciseByIdAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"api/harjoitteet/{id}");
            _navigationManager.NavigateTo("harjoitteet");

        }
        public  Task<IEnumerable<Exercise>> GetExerciseByLocationIdAsync(Guid locationId)
        {
            throw new NotImplementedException();
        }
        public  Task<IEnumerable<Exercise>> GetExerciseByExerciseTypeIdAsync(Guid exerciseTypeId)
        {
            throw new NotImplementedException();
        }

       

  

      
    }
}
