using Wellness_Score_API.Models;

namespace Wellness_Score_API.Interfaces
{
    public interface IUserRepository
    {
        //ICollection<User> GetUsers();
        //User GetUser(int id);
        bool UserExists(string email);
        //User GetUserByEmail(string email);
        User GetUser(string email);
    }
}
