using DotNetHW2;
using Service;
using Xunit.Sdk;

namespace ServiceTest;

public class ItemServiceTest
{
    private ItemService _sut;

    public ItemServiceTest()
    {
        _sut = new ItemService();
    }

    [Fact]
    public void Test_AddItem_Success()
    {
        // Arrange
        bool expected = true;
        
        // Act
        ItemService.User = Admin.GetAdmin();
        bool actual = _sut.Add(new GroceryItem("Grocery Item", 50, 10));
        
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test_AddItem_Fail()
    {
        // Arrange
        bool expected = false;
        
        // Act
        ItemService.User = new NonAdmin("username", "password",100);
        bool actual = _sut.Add(new GroceryItem("Grocery Item", 50, 10));
        
        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void Test_DeleteItem_Success()
    {
        // Arrange
        bool expected = true;
        
        // Act
        ItemService.User = Admin.GetAdmin();
        bool actual = _sut.Add(new GroceryItem("Grocery Item", 50, 10));
        
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test_DeleteItem_Fail()
    {
        // Arrange
        bool expected = false;
        
        // Act
        ItemService.User = new NonAdmin("username", "password",100);
        bool actual = _sut.Add(new GroceryItem("Grocery Item", 50, 10));
        
        // Assert
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void Test_PurchaseItem_Success()
    {
        // Arrange
        bool expected = false;
        
        // Act
        ItemService.User = Admin.GetAdmin();
        bool actual = _sut.Add(new GroceryItem("Grocery Item", 50, 10));
        
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test_PurchaseItem_Fail()
    {
        // Arrange
        bool expected = true;
        
        // Act
        ItemService.User = new NonAdmin("username", "password",100);
        bool actual = _sut.Add(new GroceryItem("Grocery Item", 50, 10));
        
        // Assert
        Assert.Equal(expected, actual);
    }
}