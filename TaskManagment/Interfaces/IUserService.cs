public interface IUserService
{
    public void addUser(User user);
    public User FindByEmail(string email);
}