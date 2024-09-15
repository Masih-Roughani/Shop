using DotNetHW2;
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
        var actual = _sut.Add(new GroceryItem("Grocery Item", 50, 10));

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test_AddItem_Fail()
    {
        // Arrange
        const bool expected = false;

        // Act
        ItemService.User = new NonAdmin("username", "password", 100);
        var actual = _sut.Add(new GroceryItem("Grocery Item", 50, 10));

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test_DeleteItem_Success()
    {
        // Arrange
        const bool expected = true;

        // Act
        ItemService.User = Admin.GetAdmin();
        var actual = _sut.Delete(new GroceryItem("Grocery Item", 50, 10));

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test_DeleteItem_Fail()
    {
        // Arrange
        const bool expected = false;

        // Act
        ItemService.User = new NonAdmin("username", "password", 100);
        var actual = _sut.Delete(new GroceryItem("Grocery Item", 50, 10));

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test_PurchaseItem_Success()
    {
        // Arrange
        const bool expected = false;

        // Act
        ItemService.User = Admin.GetAdmin();
        var actual = _sut.Purchase(new GroceryItem("Grocery Item", 50, 10));

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test_PurchaseItem_Fail()
    {
        // Arrange
        const bool expected = true;

        // Act
        ItemService.User = new NonAdmin("username", "password", 100);
        var actual = _sut.Purchase(new GroceryItem("Grocery Item", 50, 10));

        // Assert
        Assert.Equal(expected, actual);
    }
}