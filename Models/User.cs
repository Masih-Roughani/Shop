namespace DotNetHW2;

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public int Id { get; set; }
    public double Money { get; set; }

    public User(string username, string password, int id, double money)
    {
        Username = username;
        Password = password;
        Id = id;
        Money = money;
    }
}