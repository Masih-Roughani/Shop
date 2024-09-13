using System.Collections;

namespace DotNetHW2;

public abstract class User
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}

public class Admin : User
{
    private static Admin MyAdmin { get; } = new("admin", "admin")
    {
        Username = "Masih",
        Password = "123456"
    };

    private Admin(string username, string password)
    {
        Username = username;
        Password = password;
    }

    public static Admin GetAdmin()
    {
        return MyAdmin;
    }
}

public class NonAdmin : User
{
    public double Money { get; set; }
    public NonAdmin(string username, string password, double money)
    {
        Username = username;
        Password = password;
        Money = money;
    }
}