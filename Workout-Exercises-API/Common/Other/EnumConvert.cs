using Workout_Exercises_API.Models;

namespace Workout_Exercises_API.Common.Other
{
    public class EnumConvert
    {
        public static List<string> ConvertFlagEnumToStringList(Enum enumValue)
        {
            var result = Enum.GetValues(enumValue.GetType())
                    .Cast<Enum>()
                    .Where(value => enumValue.HasFlag(value) && Convert.ToInt64(value) != 0)
                    .Select(value => value.ToString())
                    .ToList();

            if (result.Count == 0)
            {
                result.Add(Enum.GetName(enumValue.GetType(), enumValue) ?? "");
            }

            return result;
        }
    }
}
