using Wellness_Score_API.DataContext;
using Wellness_Score_API.Interfaces;
using Wellness_Score_API.Models;

namespace Wellness_Score_API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool UserExists(string userName)
        {
            return _context.Users.Any(p => p.Username == userName);
        }
        public User GetUser(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Username == email);
        }



    }
}
