global using Xunit;
using DotNetHW2;
using DotNetHW2.Users;
using Moq;
using Service;

namespace ServiceTest;

public class ItemServiceTest
{
    private ItemService _sut = new();

    [Fact]
    public void Test_AddItem_Success()
    {
        // Arrange
        const bool expected = true;

        // Act
        ItemService.User = Admin.GetAdmin();
        var actual = _sut.Add("Grocery Item", 50, 10, "Electronic");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test_AddItem_Fail()
    {
        // Arrange
        const bool expected = false;

        // Act
        ItemService.User = Admin.GetAdmin();
        var actual = _sut.Add("Grocery Item", 50, 10, "Something");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test_DeleteItem_Success()
    {
        // Arrange
        const bool expected = true;
        var mockUser = new Mock<Item>();

        // Act
        ItemService.User = Admin.GetAdmin();
        mockUser.Setup(u => u.Name).Returns("Grocery Item");
        Item.Items.Add(mockUser.Object);
        var actual = _sut.Delete("Grocery Item");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test_DeleteItem_Fail()
    {
        // Arrange
        const bool expected = false;
        var mockUser = new Mock<Item>();

        // Act
        ItemService.User = Admin.GetAdmin();
        mockUser.Setup(u => u.Name).Returns("Grocery Item");
        Item.Items.Add(mockUser.Object);
        var actual = _sut.Delete("Something");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test_PurchaseItem_Success()
    {
        // Arrange
        const bool expected = true;

        // Act
        ItemService.User = new NonAdmin("username", "password", 100);
        var mockUser = new Mock<Item>();
        mockUser.Setup(u => u.Name).Returns("Item");
        mockUser.Setup(u => u.Price).Returns(50);
        mockUser.Setup(u => u.Quantity).Returns(10);
        Item.Items.Add(mockUser.Object);
        var actual = _sut.Purchase("Item");

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test_PurchaseItem_Fail()
    {
        // Arrange
        var mockUser = new Mock<Item>();

        // Act
        ItemService.User = new NonAdmin("username", "password", 10);
        mockUser.Setup(u => u.Name).Returns("Item");
        mockUser.Setup(u => u.Price).Returns(50);
        mockUser.Setup(u => u.Quantity).Returns(10);
        Item.Items.Add(mockUser.Object);
        var actual = _sut.Purchase("Item");

        // Assert
        Assert.False(actual);
    }
}