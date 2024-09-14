using DotNetHW2;

namespace Service;

public class UserService
{
    public void Login(string name, string password)
    {
        foreach (var user in User.AllUsers.Where(user => user.Username == name && user.Password == password))
        {
            ItemService.User = user;
        }
    }

    public void Register(string name, string password, double money)
    {
        var nonAdmin = new NonAdmin(name, password, money)
        {
            Username = name ,
            Password = password
        };
    }

    public void ChangeInfo(string name, string password, string newName, string newPassword)
    {
        foreach (var user in User.AllUsers.Where(user => user.Username == name && user.Password == password))
        {
            user.Username = newName;
            user.Password = newPassword;
        }
    }
}