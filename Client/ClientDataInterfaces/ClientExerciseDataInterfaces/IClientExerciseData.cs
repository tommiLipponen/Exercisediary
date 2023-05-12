using Exercisediary.Shared;

namespace Exercisediary.Client.ClientDataInterfaces.ClientExerciseDataInterfaces
{
    public interface IClientExerciseData
    {
        Task<IEnumerable<Exercise>> GetAllExercisesAsync();
        Task<Exercise> GetExerciseByIdAsync(Guid id);
        Task AddExerciseAsync(Exercise exercise);
        Task UpdateExerciseAsync(Guid id, Exercise exercise);
        Task DeleteExerciseByIdAsync(Guid id);
        Task<IEnumerable<Exercise>> GetExerciseByLocationIdAsync(Guid locationId);
        Task<IEnumerable<Exercise>> GetExerciseByExerciseTypeIdAsync(Guid exerciseTypeId);        
    }
}
