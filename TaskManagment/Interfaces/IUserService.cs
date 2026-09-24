using TaskManagment.Models;

namespace TaskManagment.Interfaces
{
    public interface IUserService
    {
        void AddUser(User user);

        User FindByEmail(string email);
    }
}