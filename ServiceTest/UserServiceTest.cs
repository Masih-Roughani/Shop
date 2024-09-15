global using Xunit;
using DotNetHW2;
using Service;
using Moq;

namespace ServiceTest;

public class UserServiceTest
{
    private UserService _sut = new();

    [Fact]
    public void Test_Register_Success()
    {
        // Arrange
        // Nothing to arrange

        // Act
        _sut.Register("username", "password", 100.0);

        // Assert
        Assert.Contains(User.AllUsers, u => u.Username == "username");
    }

    [Fact]
    public void Test_Login_Success()
    {
        // Arrange
        var mockUser = new Mock<User>();

        // Act
        mockUser.Setup(u => u.Username).Returns("username");
        mockUser.Setup(u => u.Password).Returns("password");
        User.AllUsers.Add(mockUser.Object);
        var result = _sut.Login("username", "password");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_ChangeInfo_Success()
    {
        // Arrange
        var mockUser = new Mock<User>();

        // Act
        mockUser.Setup(u => u.Username).Returns("username");
        mockUser.Setup(u => u.Password).Returns("password");
        User.AllUsers.Add(mockUser.Object);
        var result = _sut.ChangeInfo("username", "password", "newUsername", "newPassword");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Test_Login_Fail()
    {
        // Arrange
        var mockUser = new Mock<User>();

        // Act
        mockUser.Setup(u => u.Username).Returns("username");
        mockUser.Setup(u => u.Password).Returns("password");
        User.AllUsers.Add(mockUser.Object);
        var result = _sut.Login("user", "password");

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Test_ChangeInfo_Fail()
    {
        // Arrange
        var mockUser = new Mock<User>();

        // Act
        mockUser.Setup(u => u.Username).Returns("username");
        mockUser.Setup(u => u.Password).Returns("password");
        User.AllUsers.Add(mockUser.Object);
        var result = _sut.ChangeInfo("name", "password", "newUsername", "newPassword");

        // Assert
        Assert.False(result);
    }
}