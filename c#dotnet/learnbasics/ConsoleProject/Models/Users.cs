
using System.ComponentModel.DataAnnotations;

namespace ConsoleProject.Models
{
  public abstract class Users
  {
    public int Id { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
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

      return string.Concat(this.FullName, "-", res);
    }

    public virtual string whoAmI()
    {
      return "I am a Virtual Base User";
    }

  }

  public class User : Users
  {    
    public override string whoAmI()
    {
      return "I am a Base User";
    }
  }

  public class Student : Users
  {   
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

}
