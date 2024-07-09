using ConsoleProject.LinqLearn;

 // using declaration
namespace ConsoleProject; // a namespace - used for organisation simply to group classes

// namespace -> classes -> members -> method -> statements
public class Program // as class - has members (such as a properties and method)
{
  //Console.WriteLine(); // this code wont work as it needs to be in a method.
  static void Main(string[] args) // a method - contains a block of code
  {
    //Program p = new Program();
    //p.dataTypes();
    //Console.WriteLine(args[0]); //dotnet run tacos - this will print tacos
    //Person person = new Person { FirstName = "Darren", LastName = "Q-Classes" };
    //System.Console.WriteLine(person.GetFullName());
    //p.linq();
    var ll = new linqlearn();
    ll.printCategories1();
  }


  void basicsAndVariables()
  {
    System.Console.WriteLine("Hello, Darren"); // a statement
    Console.Write(7.58);
    Console.WriteLine("Hello");
    string ttl = Console.Title = "MyTitle";
    Console.WriteLine(ttl);
    Console.BackgroundColor = ConsoleColor.Black;
    object test = new object();
    Console.WriteLine(test.GetType());
    string x = "Darren";
    Console.WriteLine(x + " is wiered");
    int declarationAndInitialization = 5; //declaration and initialization
    int declaration; //declaration only, its undeclared and will thow a compile error
    int? declareWithNull = null;
    System.Console.WriteLine($"Its a null : {declareWithNull}");

  }
  void dataTypes()
  {
    //Value Types - [Simple Types, enum types, struct types and nullable]
    char singleCharacter = 'c';
    string nosOfCharacters = "Darren";
    double e = 5.5;
    bool boolDtype = true;
    int valueTypeA = 4;
    Int32 valueTypeB = valueTypeA; // in value types the value will be copied not referenced.
    valueTypeB = 7;
    System.Console.WriteLine($"varA = {valueTypeA} & varB = {valueTypeB}");
    double dec2 = Math.Round(10.556, 3);
    char asciTable = (char)61; // = symbol as per Ascii table

    //Reference Types - 
    int[] referenceTypeArrayA = { 5 };
    int[] referenceTypeArrayB = referenceTypeArrayA;
    referenceTypeArrayB[0] = 6;
    System.Console.WriteLine($"varreferenceTypeArrayA = {referenceTypeArrayA[0]} & referenceTypeArrayB = {referenceTypeArrayB[0]}");
    decimal dec = 10.5M;
    double dec1 = double.Parse("5.55566589637888888888888949859784578479384793847953845");

    //string data types - Reference DataType
    string myName = "Hello my name is Darren     Aislinn  / 	e";
    string[] splitString = myName.Split("/", StringSplitOptions.RemoveEmptyEntries);
    Console.WriteLine(splitString[0]);
  }

  public void switchStatements()
  {
    string name = "Aislinn";
    switch (name)
    {
      case "Darren":
        Console.WriteLine("cased on Darren");
        break;
      case "Aislinn":
        System.Console.WriteLine("cased on Aislinn");
        break;
      default:
        Console.WriteLine("other cased");
        break;
    }
  }

  public void loops()
  {
    //while loop
    int i = 0;
    while (i < 11)
    {
      System.Console.WriteLine($"While Loop - {i}");
      i++;
    }

    int doWhile = 0;
    do
    {
      System.Console.WriteLine($"Do While Loop - {doWhile}");
      doWhile++;
    } while (doWhile <= 11);

    for (int i2 = 12; i2 > 10; i2--)
    {
      System.Console.WriteLine($"for loop : {i2}");
    }

    for (int i3 = 9; i3 > 0; i3--)
    {
      System.Console.Write($"{i3}th time - ");
      for (int k3 = 9; k3 > 0; k3--)
      {
        Console.Write($"{k3} ");
      }
      System.Console.WriteLine();
    }
    System.Console.WriteLine("While Nested Loop");
    int w1 = 100;
    while (w1 > 0)
    {
      System.Console.Write($"{w1}th time - ");
      int w2 = w1;
      while (w2 > 0)
      {
        Console.Write($"{w2} ");
        w2--;
      }
      System.Console.WriteLine();
      w1--;
    }
  }
  public void arrays(){
    int[] grades = new int[6];
    for (int i = 0; i < grades.Length; i++)
    {
      grades[i] = i;
    }

    foreach (var item in grades)
    {
      System.Console.Write($"{item} ");      
    }

     foreach (var grade in grades)
    {
      if(grade == 3){
        System.Console.WriteLine($"found {grade} in the list");
        break;    
      }else{
        System.Console.WriteLine("Not Found");
      }      
    }
    
    int[,] twoDArray = new int[3,2]; 
      twoDArray[0,0] = 11;
      twoDArray[0,1] = 12;
      twoDArray[1,0] = 21;
      twoDArray[1,1] = 22;      
    
    int[,] twoDArraysimple = {
      {11,12},{21,22},{31,32}
    };

    System.Console.WriteLine(twoDArraysimple.GetLength(1));
    
    for (int i =0; i < twoDArraysimple.GetLength(0); i++)
    {
      for (int j = 0; j < twoDArraysimple.GetLength(1); j++)
      {
        System.Console.WriteLine($"2D Array at [{i}],[{j}] is  {twoDArraysimple[i,j]}");
      }
    }

    int[][] jaggedArray = {
      [11,12,13] 
      ,new int[] {21,22} 
      ,new int[] {31,32,33}
    };
    System.Console.WriteLine(jaggedArray[0][1]);
    System.Console.WriteLine(jaggedArray[1].Length);
    for (int i =0; i < jaggedArray.GetLength(0); i++)
    {
      for (int j = 0; j < jaggedArray[i].Length; j++)
      {
        System.Console.WriteLine($"jagged Array at [{i}],[{j}] is {jaggedArray[i][j]}");
      }
    }
    List<int> myList = new List<int> {10,20,30};
    var newlist = myList.Append(45);
    System.Console.WriteLine(newlist.ElementAt(3));
    if(myList.SequenceEqual(newlist)){
      System.Console.WriteLine("true");
    }else{
      System.Console.WriteLine("List do not match");
    }

    List<List<int>> studentGrades = new List<List<int>>{
      new List<int>{1,4,3,6},
      new List<int>{25,26,16,85,96}
    };

    foreach (List<int> sGrades in studentGrades)
    {
      sGrades.Sort();
      foreach (int grade in sGrades)
      {        
        System.Console.Write($"{grade} \t");
      }
      Console.WriteLine();
    }
  }

  public void linq(){
    int[] numbers = { 2, 3, 4, 5 };
    var squaredNumbers = numbers.Select(x => x * x);
    Console.WriteLine(string.Join(" ", squaredNumbers));
  }
}


