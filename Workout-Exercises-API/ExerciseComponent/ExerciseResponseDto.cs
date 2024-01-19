using System.Data;
using Workout_Exercises_API.Common.Other;
using Workout_Exercises_API.Models;

namespace Workout_Exercises_API.ExerciseComponent
{
    public class ExerciseResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string WorkoutType { get; set; }

        public string Description { get; set; }

        public List<string> MuscleCategories { get; set; }

        public ExerciseResponseDto(Exercise exercise)
        {
            Id = exercise.Id;
            Name = exercise.Name;
            WorkoutType = Enum.GetName(exercise.WorkoutType.GetType(), exercise.WorkoutType)!;
            Description = exercise.Description;
            MuscleCategories = EnumConvert.ConvertFlagEnumToStringList(exercise.MuscleCategories);
        }
    }
}
