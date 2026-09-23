public interface IUserService
{
    public void AddUser(User user);
    public User FindByEmail(string email);
}