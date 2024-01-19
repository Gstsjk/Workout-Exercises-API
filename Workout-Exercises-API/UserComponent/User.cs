using System.ComponentModel.DataAnnotations;

namespace Workout_Exercises_API.UserComponent
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
