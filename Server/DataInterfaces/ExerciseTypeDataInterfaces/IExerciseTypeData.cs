using Exercisediary.Shared;

namespace Exercisediary.Server.DataInterfaces.ExerciseTypeDataInterfaces;

public interface IExerciseTypeData
{
    Task<List<ExerciseType>>GetExerciseTypes();
    Task<ExerciseType?>GetExerciseTypeById(Guid id);
    Task<ExerciseType?> UpdateExerciseType(Guid id, ExerciseType exerciseType);
    Task<ExerciseType> AddExerciseType(ExerciseType exerciseType);
    Task<bool> DeleteExerciseType(Guid id);
    

}
