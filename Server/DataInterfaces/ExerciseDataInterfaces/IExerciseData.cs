using Exercisediary.Shared;

namespace Exercisediary.Server.DataInterfaces.ExerciseDataInterfaces
{
    public interface IExerciseData
    {
        Task<IEnumerable<Exercise>> GetAllExercises();
        Task<Exercise?> GetExerciseById(Guid id);
        Task AddExercise(Exercise exercise);
        Task UpdateExercise(Exercise exercise);
        Task DeleteExercise(Guid id);
        Task<IEnumerable<Exercise>> GetExercisesByLocationId(Guid locationId);
        Task<IEnumerable<Exercise>> GetExercisesByExerciseTypeId(Guid exerciseTypeId);        
    }
}
