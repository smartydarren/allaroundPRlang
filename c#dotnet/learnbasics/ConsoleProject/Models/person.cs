namespace ConsoleProject{

  public class Person{
   
    internal string FirstName { get; set; }
    internal string LastName { get; set; }
    private string _fullName = null;

      public Person(string firstName, string lastName)
      {
        this.FirstName = firstName;
        this.LastName = lastName;
      }

    public string GetFullName(){
      _fullName = FirstName + " " + LastName;
      return _fullName;      
    }

  }
}
