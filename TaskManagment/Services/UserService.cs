public class UserService : IUserService
{
    private static User[] _users = new User[0];

    public void AddUser(User user)
    {
        foreach (var User in _users)
        {
            if (User.Email.Equals(user.Email,StringComparison.OrdinalIgnoreCase))
            {
                throw new ConflictException("This email is already registered.");
            }
        }

        Array.Resize(ref _users, _users.Length + 1);
        _users[^1] = user;
    }

    public User FindByEmail(string email)
    {
        foreach (var user in _users)
        {
            if (user.Email.Equals(email,StringComparison.OrdinalIgnoreCase))
            {
                return user;
            }
        }

        throw new NotFoundException($"User with email '{email}' not found.");
    }
}