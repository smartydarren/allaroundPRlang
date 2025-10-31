
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using Npgsql.Replication;

namespace ConsoleProject.Models
{
  internal enum FoodILike
  {
    ramen, noodles, friedrice, soups
  }
  public abstract class Users
  {
    public int Id { get; set; }
    public string? Email { get; set; }
    public string Password { get; set; } = string.Empty;
    public readonly string Org;
    public string? FullName
    {
      get
      {
        return FirstName + " " + LastName;
      }
    }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public Users()
    {
    }

    public Users(string org)
    {
      this.Org = org;
    }

    ~Users()
    {
      Console.WriteLine("Destructing users class");
    }


    public override string ToString()
    {
      return base.ToString();
    }

    /* public override int GetHashCode(){          
     var rrr = new Random();
     return rrr.Next(500,900);
    }  */

    public string userDetails()
    {
      string res = whoAmI();

      return string.Concat(this.FullName, "-", Org, res);
    }

    public virtual string whoAmI()
    {
      return "I am a Virtual Base User";
    }

  }

  public class User : Users
  {
    public User()
    {
      Console.WriteLine("Constructing user class");
    }
    ~User()
    {
      Console.WriteLine("Destructing user class");
    }
    public User(string org) : base(org)
    {
      // other stuff here
      Console.WriteLine($"printing org - {this.Org}");
    }
    public override string whoAmI()
    {
      return "I am a Base User";
    }

  }

  public class Student : Users
  {
    ~Student()
    {
      Console.WriteLine("Destructing student class");
    }
    public override string whoAmI()
    {
      return "I am a Student";
    }
  }

  public class Teacher : Users
  {

    public override string whoAmI()
    {
      return "I am a Teacher";
    }

  }

  public class DataForTesting
  {
    public List<Users> users { get; set; } = new List<Users>();

    public DataForTesting()
    {
      Console.WriteLine(users.GetHashCode());
      users = new List<Users>();
      Console.WriteLine(users.GetHashCode());
    }
    private List<Users> GetUsers()
    {
      Users u1 = new User { FirstName = "Darren", LastName = "Quadros" };
      Users u2 = new Teacher { FirstName = "Aislinn", LastName = "Quadros" };
      Users u3 = new Student { FirstName = "Adelyn", LastName = "Quadros" };

      users.Add(u1);
      users.Add(u2);
      users.Add(u3);

      return users;
    }

    private void printUsers()
    {
      var firstName = new List<string> { "Darren", "Aislinn", "Denver", "Adelyn" };
      var lastName = "Quadros";
      var ids = new List<int> { 1, 1, 2, 3 };
      var emails = new List<string> { "s@gmail.com", "s@gmail.com", "g@gmail.com", "z@gmail.com" };
      var passws = new List<string> { "123", "123", "xyz", "5hu" };

      List<Users> users = new List<Users>();

      for (int i = 0; i < ids.Count; i++)
      {
        var u = new Student();
        u.FirstName = firstName[i]; u.LastName = lastName;
        u.Id = ids[i]; u.Email = emails[i]; u.Password = passws[i];
        users.Add(u);
      }

      foreach (Users u in users)
      {
        System.Console.WriteLine(u.FullName);
        System.Console.WriteLine(u.userDetails());
        Console.WriteLine($"obj: {u.ToString()}");
        Console.WriteLine(u.GetHashCode());
        Console.WriteLine("-----Next User---------");
      }

      string foodilike = "soups";
      var test = Enum.IsDefined(typeof(FoodILike), foodilike.ToLower());
      Console.WriteLine(test);

    }

    public void PrintUserType()
    {
      var listOfUsers = GetUsers();
      foreach (Users u in listOfUsers)
      {
        Console.WriteLine($"Ex of Polymorphism - {u.userDetails()} - {u.GetType()}");
      }
    }

  }

  public struct StructUser
  {
    public string Name { get; set; }


    public void changeUser(StructUser su)
    {
      Console.WriteLine(su.Name = "structuser");
    }

    /*
    --value type its pass by copy--------
    StructUser u = new StructUser();
    u.Name = "darren";
    u.changeUser(u);
    Console.WriteLine(u.Name);
    */
  }

  public interface IFood
  {
    public void FoodColor(string color)
    {
      Console.WriteLine("Default Color is White");
    }
    void FoodQuantity(int qty)
    {
      qty = 1;
    }
  }

  public class Biryani : IFood
  {
    public void FoodColor(string color)
    {
      Console.WriteLine($"Default Color is {color}");
    }
  }

  public class Pulao : IFood
  {
    public void FoodColor(string color)
    {
      Console.WriteLine($"Default Color is {color}");
    }
  }

  public delegate void WriteToConsole();

  public class DelegateEg
  {
    WriteToConsole write;

    public void WriteMessageToConsole()
    {
      Console.WriteLine("Hello from function");
    }

    private void CallDelegate()
    {
      write = () =>
      {
        Console.WriteLine("Hello from lamda");
      };
      write += WriteMessageToConsole;
      write();

    }

  }
  public class EventEg
  {
    public event Action OnShouting;

    internal void Shout()
    {
      OnShouting?.Invoke();
    }
  }

  public class ShouldAtKids
  {
    public ShouldAtKids(EventEg eventEg)
    {
      eventEg.OnShouting += () =>
      {
        Console.WriteLine("Shouting at kids");
      };

    }

    //EventEg eeg = new EventEg();
    //ShouldAtKids she = new ShouldAtKids(eeg);
    //eeg.Shout();
  }

  public class GenericEg<T> where T : class
  {

    public T TestFunction(T par)
    {
      Console.WriteLine(par);
      return par;
    }
  }

  public class SingletonPattern
  {
    private SingletonPattern instance { get; set; }
    public static string Name { get; set; } = "Darren";
    private SingletonPattern()
    {
      this.instance = new SingletonPattern();
    }

    public static SingletonPattern Rrr()
    {
      return new SingletonPattern();
    }
  }

  public class ReflectionEg
  {
    public int MyProperty { get; set; }
    public void Message()
    {
      Debug.Assert(MyProperty > 0);
      Console.WriteLine("Hello");
    }
    /*  ReflectionEg re = new ReflectionEg();
     MethodInfo myFunctionMethodInfo = typeof(ReflectionEg).GetMethod("Message");
     myFunctionMethodInfo.Invoke(re, new object[] { }); */
  }




}// namespace closing


