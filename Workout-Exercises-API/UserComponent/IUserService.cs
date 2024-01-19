namespace Workout_Exercises_API.UserComponent
{
    public interface IUserService
    {
        Task<User> Create(User user);
        Task<User> Update(User user);
        Task Delete(User user);
    }
}
