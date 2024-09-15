namespace DotNetHW2;

public class Admin : User
{
    private static Admin MyAdmin { get; } = new("admin", "admin");

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