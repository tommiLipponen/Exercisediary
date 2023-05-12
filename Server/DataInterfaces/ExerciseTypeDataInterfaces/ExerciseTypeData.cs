
using Exercisediary.Shared;
using ExerciseDiary.Server.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;

namespace Exercisediary.Server.DataInterfaces.ExerciseTypeDataInterfaces;

    public class ExerciseTypeData : IExerciseTypeData
    {
        private readonly ApplicationDbContext _context;

        public ExerciseTypeData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ExerciseType>> GetExerciseTypes()
        {

            return await _context.ExerciseTypes.ToListAsync();
        }

        public async Task<ExerciseType?> GetExerciseTypeById(Guid id)
        {
            if (id != Guid.Empty)
            {
                return await _context.ExerciseTypes.FindAsync(id);
            }
            else
            {
                throw new Exception("Urheilulajia ei löydy");
            }
        }

        public async Task<ExerciseType?> UpdateExerciseType(Guid ExerciseTypeId, ExerciseType exerciseType)
        {
            var dbExerciseType = await _context.ExerciseTypes.FindAsync(ExerciseTypeId);
            if (dbExerciseType != null)
            {
                dbExerciseType.ExerciseName = exerciseType.ExerciseName;
                dbExerciseType.Exercises = exerciseType.Exercises;

                await _context.SaveChangesAsync();
            }
            return dbExerciseType;
        }

        public async Task<ExerciseType> AddExerciseType(ExerciseType exerciseType)
        {
            await _context.ExerciseTypes.AddAsync(exerciseType);
            await _context.SaveChangesAsync();
            return exerciseType;
        }

        public async Task<bool> DeleteExerciseType(Guid id)
        {
            var existingExerciseType = await _context.ExerciseTypes.FindAsync(id);

            if (existingExerciseType == null)
            {
                return false;
            }

            _context.ExerciseTypes.Remove(existingExerciseType);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool ExerciseTypeExists(Guid id)
        {
            return (_context.ExerciseTypes?.Any(e => e.ExerciseTypeId == id)).GetValueOrDefault();
        }
    }




