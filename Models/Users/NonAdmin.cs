namespace DotNetHW2;

public class NonAdmin : User
{
    public double Money { get; set; }

    public NonAdmin(string username, string password, double money)
    {
        Username = username;
        Password = password;
        Money = money;
        AllUsers.Add(this);
    }
}