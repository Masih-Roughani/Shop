using DotNetHW2;

namespace Service;

public class UserService
{
    public bool Login(string name, string password)
    {
        foreach (var user in User.AllUsers.Where(user => user.Username == name && user.Password == password))
        {
            ItemService.User = user;
            return true;
        }

        return false;
    }

    public void Register(string name, string password, double money)
    {
        var nonAdmin = new NonAdmin(name, password, money);
    }

    public bool ChangeInfo(string name, string password, string newName, string newPassword)
    {
        foreach (var user in User.AllUsers.Where(user => user.Username == name && user.Password == password))
        {
            user.Username = newName;
            user.Password = newPassword;
            return true;
        }

        return false;
    }
}