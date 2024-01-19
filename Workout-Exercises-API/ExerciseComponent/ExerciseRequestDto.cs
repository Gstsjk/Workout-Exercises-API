using System.ComponentModel;
using Workout_Exercises_API.Models;
using Workout_Exercises_API.Common.Other;
using Workout_Exercises_API.Other.Enums;

namespace Workout_Exercises_API.ExerciseComponent
{
    public class ExerciseRequestDto
    {
        public string Name { get; set; }

        public WorkoutType WorkoutType { get; set; }

        public string Description { get; set; }

        public MuscleCategories MuscleCategories { get; set; }
    }
}
