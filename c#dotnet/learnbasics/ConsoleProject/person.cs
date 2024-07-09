using System;
namespace ConsoleProject{

  public class Person{

    string _middleName = "Roque";
    internal string FirstName { get; set; }
    internal string LastName { get; set; }

    public string GetFullName(){
      return $"{FirstName} {_middleName} {LastName}";      
    }
  }
}
