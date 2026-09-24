using TaskManagment.Exceptions;
using TaskManagment.Interfaces;
using TaskManagment.Models;

namespace TaskManagment.Services
{
    public class UserService : IUserService
    {
        private readonly List<User> _users = new();

        public void AddUser(User user)
        {
            bool exists = _users.Any(x =>
                x.Email.Equals(user.Email, StringComparison.OrdinalIgnoreCase));

            if (exists)
            {
                throw new ConflictException(
                    $"User with email {user.Email} already exists.");
            }

            _users.Add(user);
        }

        public User FindByEmail(string email)
        {
            User? user = _users.FirstOrDefault(x =>
                x.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            if (user == null)
            {
                throw new NotFoundException(
                    $"No user found with email: {email}");
            }

            return user;
        }

        public User GetById(int id)
        {
            User? user = _users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                throw new NotFoundException(
                    $"No user found with ID: {id}");
            }

            return user;
        }

        public List<User> GetAll()
        {
            return _users;
        }
    }
}