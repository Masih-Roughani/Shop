using DotNetHW2;
using DotNetHW2.Users;

namespace Service;

public class UserService : IUserService
{
    private static User User { get; set; }

    public bool Login(string name, string password)
    {
        foreach (var user in User.AllUsers.Where(user => user.Username == name && user.Password == password))
        {
            ItemService.User = user;
            User = user;
            return true;
        }

        return false;
    }

    public void Register(string name, string password, double money)
    {
        var nonAdmin = new NonAdmin(name, password, money);
        ItemService.User = nonAdmin;
        User = nonAdmin;
    }

    public void ChangeInfo(string newName, string newPassword)
    {
        User.Username = newName;
        User.Password = newPassword;
    }
}