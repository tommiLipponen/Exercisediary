
using Exercisediary.Server.DataInterfaces.ExerciseTypeDataInterfaces;
using Exercisediary.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exercisediary.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrheilulajitController : ControllerBase
    {
        private readonly IExerciseTypeData _exerciseTypeData;
        public UrheilulajitController(IExerciseTypeData exerciseTypeData)
        {
            _exerciseTypeData = exerciseTypeData;
        }

        [HttpGet]
        public async Task<List<ExerciseType>> GetExerciseTypes()
        {
            return await _exerciseTypeData.GetExerciseTypes();
        }
        [HttpGet("{id}")]
        public async Task<ExerciseType?> GetExerciseTypeById(Guid id)
        {
            return await _exerciseTypeData.GetExerciseTypeById(id);
        }
        [HttpPost]
        public async Task<ExerciseType?> CreateExerciseType(ExerciseType exerciseType)
        {
            return await _exerciseTypeData.AddExerciseType(exerciseType);
        }
        [HttpPut("{id}")]
        public async Task<ExerciseType?> UpdateExerciseType(Guid id, ExerciseType exerciseType)
        {
            return await _exerciseTypeData.UpdateExerciseType(id, exerciseType);
        }
        [HttpDelete("{id}")]
        public async Task<bool> DeleteExercisetype(Guid id)
        {
            return await _exerciseTypeData.DeleteExerciseType(id);
        }
    }
}
