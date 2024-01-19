namespace Workout_Exercises_API.Other.Enums
{
    [Flags]
    public enum MuscleCategories
    {
        Other = 0,
        Chest = 1,
        Back = 1 << 1,
        Shoulders = 1 << 2,
        Biceps = 1 << 3,
        Triceps = 1 << 4,
        Quads = 1 << 5,
        Hamstrings = 1 << 6,
        Glutes = 1 << 7,
        Calves = 1 << 8,
        Abs = 1 << 9
    }
}
