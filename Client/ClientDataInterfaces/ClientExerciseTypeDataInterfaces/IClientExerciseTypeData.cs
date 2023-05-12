using Exercisediary.Shared;

namespace Exercisediary.Client.ClientDataInterfaces.ClientExerciseTypeDataInterfaces
{
    public interface IClientExerciseTypeData
    {               
        List<ExerciseType> Types { get; set; }
        Task GetExerciseTypes();
        Task<ExerciseType?> GetExerciseType(Guid id);
        Task CreateExerciseType(ExerciseType exerciseType);
        Task UpDateExerciseType(Guid id, ExerciseType exerciseType);
        Task DeleteExerciseType(Guid id);
    }
}
