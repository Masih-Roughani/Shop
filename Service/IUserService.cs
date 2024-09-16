namespace Service;

public interface IUserService
{
    bool Login(string name, string password);
    void Register(string name, string password, double money);
    void ChangeInfo(string newName, string newPassword);
}