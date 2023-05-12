using Exercisediary.Shared;
using ExerciseDiary.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace Exercisediary.Server.DataInterfaces.ExerciseDataInterfaces
{
    public class ExerciseData : IExerciseData
    {
        private readonly ApplicationDbContext _context;

        public ExerciseData(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Exercise>> GetAllExercises()
        {
            return await _context.Exercises
                .Include(e => e.ExerciseType)
                .Include(e => e.Location)
                .ToListAsync();
        }
        public async Task<Exercise?> GetExerciseById(Guid id)
        {
            return await _context.Exercises.FindAsync(id);
        }
        public async Task AddExercise(Exercise exercise)
        {
            await _context.Exercises.AddAsync(exercise);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateExercise(Exercise exercise)
        {
            _context.Entry(exercise).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteExercise(Guid id)
        {
            var exercise = await GetExerciseById(id);
            if(exercise != null)
            {
                _context.Exercises.Remove(exercise);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Exercise>> GetExercisesByLocationId(Guid locationId)
        {
            return await _context.Exercises.Where(e => e.LocationId == locationId).ToListAsync();
        }
        public async Task<IEnumerable<Exercise>> GetExercisesByExerciseTypeId(Guid exerciseTypeId)
        {
            return await _context.Exercises.Where(e => e.ExerciseTypeId == exerciseTypeId).ToListAsync();   
        }    
    }
}
