using Exercisediary.Server.DataInterfaces.ExerciseDataInterfaces;
using Exercisediary.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exercisediary.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HarjoitteetController : ControllerBase
    {
        private readonly IExerciseData _exerciseData;
        public HarjoitteetController(IExerciseData exerciseData)
        {
            _exerciseData = exerciseData;
        }
        [HttpGet]
        public async Task<IEnumerable<Exercise>> GetAllExercises()
        {
            var exercises = await _exerciseData.GetAllExercises();
            if (exercises == null || !exercises.Any())
            {
                return (IEnumerable<Exercise>)NotFound();
            }
            return exercises;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Exercise>> GetExerciseById(Guid id)
        {
            var exercise = await _exerciseData.GetExerciseById(id);
            if (exercise == null)
            {
                return NotFound();
            }
            return exercise;
        }
        [HttpPost]
        public async Task<ActionResult> AddExercise(Exercise exercise)
        {
            await _exerciseData.AddExercise(exercise);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpDateExercise(Guid id, Exercise exercise)
        {
            if(id != exercise.ExerciseId)
            {
                return BadRequest();
            }
            await _exerciseData.UpdateExercise(exercise);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercise(Guid id)
        {
            await _exerciseData.DeleteExercise(id);
            return NoContent();
        }
        [HttpGet("location/{locationId}")]
        public async Task<ActionResult<IEnumerable<Exercise>>> GetExercisesByLocation(Guid locationId)
        {
            var exercises = await _exerciseData.GetExercisesByLocationId(locationId);
            if(exercises == null || !exercises.Any())
            {
                return NotFound();
            }
            return exercises.ToList();
        }
        [HttpGet("type/{exerciseTypeId}")]
        public async Task<ActionResult<IEnumerable<Exercise>>> GetExerciseByExerciseTypeId(Guid exerciseTypeId)
        {
            var exercises = await _exerciseData.GetExercisesByExerciseTypeId(exerciseTypeId);
            if (exercises == null || !exercises.Any())
            {
                return NotFound();
            }
            return exercises.ToList();

        }
    }
}
