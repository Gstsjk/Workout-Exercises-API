using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Workout_Exercises_API.ExerciseComponent;
using Workout_Exercises_API.Other.Enums;

namespace Workout_Exercises_API.Models
{
    public class Exercise
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        public WorkoutType WorkoutType { get; set; } 

        public string Description { get; set; }

        public MuscleCategories MuscleCategories { get; set; }

        public Exercise()
        {

        }

        public Exercise(ExerciseRequestDto exerciseRequestDto)
        {
            Name = exerciseRequestDto.Name;
            WorkoutType = exerciseRequestDto.WorkoutType;
            Description = exerciseRequestDto.Description;
            MuscleCategories = exerciseRequestDto.MuscleCategories;
        }

    }
}
