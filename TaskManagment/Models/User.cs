public class User
{
    private static int Count = 0;
    public int Id {get; set;}
    public string Name {get; set;} = null!;
    public string Email {get; set;} = null!;
    public User(int id, string name, string email)
    {
        Count++;
        Id = Count;
        Name = name;
        Email = email;
    }
    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Email: {Email}";
    }

}