using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Web.Http;
using Workout_Exercises_API.Data;
using Workout_Exercises_API.Models;

namespace Workout_Exercises_API.ExerciseComponent
{
    public class ExerciseService : IExerciseService
    {
        private readonly DataContext _context;

        public ExerciseService(DataContext context)
        {
            _context = context;
        }

        public async Task<Exercise> Create(ExerciseRequestDto exerciseRequestDto)
        {
            Exercise exercise = new(exerciseRequestDto);
            _context.Exercises.Add(exercise);
            await _context.SaveChangesAsync();
            return exercise;
        }

        public async Task<IEnumerable<ExerciseResponseDto>> Get()
        {
            var allExercises = await _context.Exercises.ToListAsync();
            var responseExercises = allExercises.Select(exercise => new ExerciseResponseDto(exercise));
            return responseExercises;
        }

        public async Task<IEnumerable<ExerciseResponseDto>> Get(string exerciseName)
        {
            var allExercises = await _context.Exercises.ToListAsync();
            var responseExercises = allExercises
                .Select(exercise => new ExerciseResponseDto(exercise))
                .Where(exercise => exercise.Name == exerciseName);
            return responseExercises;
        }

        public async Task<ExerciseResponseDto> Get(int EmpId)
        {
            var exercise = await _context.Exercises.FindAsync(EmpId);
            if(exercise == null)
                return null;
            
            var responseExercise = new ExerciseResponseDto(exercise);
            return responseExercise;

        }

        public async Task<Exercise> Update(Exercise exercise)
        {
            var existingExercise = await _context.Exercises.FindAsync(exercise.Id);
            if(existingExercise == null)
                return null;

            _context.Entry(existingExercise).CurrentValues.SetValues(exercise);
            await _context.SaveChangesAsync();
            return exercise;

        }

        public async Task Delete(int exId)
        {
            var exerciseToDelete = await _context.Exercises.FindAsync(exId);
            _context.Exercises.Remove(exerciseToDelete);
            await _context.SaveChangesAsync();
        }

    }
}
