namespace Service;

public interface IUserService
{
    bool Login(string name, string password);
    bool Register(string name, string password, double money);
    bool ChangeInfo(string name, string password, string newName, string newPassword);
}