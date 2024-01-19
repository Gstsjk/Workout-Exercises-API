using Microsoft.EntityFrameworkCore;
using Workout_Exercises_API.Data;

namespace Workout_Exercises_API.UserComponent
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<User> Create(User user)
        {
           _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Update(User user)
        {
            var existingUser = await _context.Users.FindAsync(user.Username);
            if (existingUser == null)
                return null;

            _context.Entry(existingUser).CurrentValues.SetValues(user);
            return user;
        }

        public async Task Delete(User user)
        {
            var userToDelete = await _context.Users.FindAsync(user.Username);
            _context.Users.Remove(userToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
