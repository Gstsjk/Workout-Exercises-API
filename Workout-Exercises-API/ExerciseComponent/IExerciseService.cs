using Workout_Exercises_API.Models;

namespace Workout_Exercises_API.ExerciseComponent
{
    public interface IExerciseService
    {
        Task<Exercise> Create(ExerciseRequestDto exerciseRequestDto);
        Task<IEnumerable<ExerciseResponseDto>> Get();
        Task<IEnumerable<ExerciseResponseDto>> Get(string exerciseName);
        Task<ExerciseResponseDto> Get(int EmpId);
        Task<Exercise> Update(Exercise exercise);
        Task Delete(int exId);
    }
}
