using DotNetHW2.Users;
using Service;

namespace UserInterface;

public abstract class Program
{
    private static readonly UserService UserService = new();
    public static ItemService ItemService = new();

    public static void Main(string[] args)
    {
        FirstScene();
    }

    private static void Effect()
    {
        Console.Clear();
        Console.Beep();
    }

    private static void FirstScene()
    {
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Effect();
        Console.WriteLine("0- Exit");
        Console.WriteLine("1- Register");
        Console.WriteLine("2- Login");
        Console.WriteLine("3- Admin Entrance");
        Console.WriteLine("Enter your choice: ");
        switch (Convert.ToInt32(Console.ReadLine()))
        {
            case 0:
                Environment.Exit(0);
                break;
            case 1:
                Register();
                break;
            case 2:
                Login();
                break;
            case 3:
                AdminEntrance();
                break;
        }
    }

    private static void Register()
    {
        Effect();
        Console.WriteLine("{name} {password} {money}");
        Console.WriteLine("Enter your info: ");
        var arr = Console.ReadLine()!.Split(" ");
        UserService.Register(arr[0], arr[1], Convert.ToDouble(arr[2]));
        Console.WriteLine("Register was successful \n Press any key to continue");
        Console.ReadKey();
        SecondScene();
    }

    private static void Login()
    {
        Effect();
        Console.WriteLine("{name} {password}");
        Console.WriteLine("Enter your info: ");
        var arr = Console.ReadLine()!.Split(" ");
        if (UserService.Login(arr[0], arr[1]))
        {
            Console.WriteLine("Login was successful \n Press any key to continue");
            Console.ReadKey();
            SecondScene();
        }

        Console.WriteLine("Login Failed \n Press any key to continue");
        Console.ReadKey();
        FirstScene();
    }

    private static void AdminEntrance()
    {
        Effect();
        Console.WriteLine("{name} {password}");
        Console.WriteLine("Enter your info: ");
        var arr = Console.ReadLine()!.Split(" ");
        if (Admin.GetAdmin().Username == arr[0] && Admin.GetAdmin().Password == arr[1])
        {
            ThirdScene();
        }

        Console.WriteLine("Login Failed \n Press any key to continue");
        Console.ReadKey();
        FirstScene();
    }

    private static void SecondScene()
    {
        Effect();
        Console.WriteLine("0- Step back");
        Console.WriteLine("1- ChangeInfo");
        Console.WriteLine("2- Purchase");
        Console.WriteLine("Enter your choice: ");
        switch (Convert.ToInt32(Console.ReadLine()))
        {
            case 1:
                ChangeInfoScene();
                break;
            case 2:
                PurchaseScene();
                break;
            case 0:
                FirstScene();
                break;
        }
    }

    private static void ChangeInfoScene()
    {
        Effect();
        Console.WriteLine("{new name} {new password}");
        Console.WriteLine("Enter your info: ");
        var arr = Console.ReadLine()!.Split(" ");
        UserService.ChangeInfo(arr[0], arr[1]);
        Console.WriteLine("Change info was successful \n Press any key to continue");
        Console.ReadKey();
        SecondScene();
    }

    private static void PurchaseScene()
    {
        Effect();
        Console.WriteLine("{Product name}");
        Console.WriteLine("Enter your product name: ");
        Console.WriteLine(ItemService.Purchase(Console.ReadLine()!)
            ? "Item was successfully purchased"
            : "Item was not purchased (not enough money) or (no left product to buy) ");

        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        SecondScene();
    }

    private static void ThirdScene()
    {
        Effect();
        Console.WriteLine("0- Step back");
        Console.WriteLine("1-Add Item");
        Console.WriteLine("2-Delete Item");
        Console.WriteLine("Enter your choice: ");
        switch (Convert.ToInt32(Console.ReadLine()))
        {
            case 1:
                AddItemScene();
                break;
            case 2:
                DeleteItemScene();
                break;
            case 0:
                FirstScene();
                break;
        }
    }

    private static void AddItemScene()
    {
        Effect();
        Console.WriteLine("{name} {price} {quantity} {type}");
        Console.WriteLine("Product Types are : (Electronic) or (Grocery)");
        Console.WriteLine("Enter product info: ");
        var arr = Console.ReadLine()!.Split(" ");
        Console.WriteLine(ItemService.Add(arr[0], Convert.ToDouble(arr[1]), Convert.ToInt32(arr[2]), arr[3])
            ? "Item added successfully"
            : "Item was not added (wrong product type)");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        ThirdScene();
    }

    private static void DeleteItemScene()
    {
        Effect();
        Console.WriteLine("Enter product name: ");
        ItemService.Delete(Console.ReadLine()!);
        Console.WriteLine("Item deleted successfully");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        ThirdScene();
    }
}