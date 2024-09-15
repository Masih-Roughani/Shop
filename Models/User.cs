using System.Collections;

namespace DotNetHW2;

public abstract class User
{
    public virtual string? Username { get; set; }
    public virtual string? Password { get; set; }
    public static List<User> AllUsers { get; } = new List<User>();
}