// using declaration
using System.Data;
using ConsoleProject.Models;
using System.Globalization;
using LoggingNamespace;

namespace ConsoleProject; // a namespace - used to simply group classes

// namespace -> classes -> members -> method -> statements
internal class Program // as class - has members (such as a properties and method)
{
  //Console.WriteLine(); // this code wont work as it needs to be in a method.
  static async Task Main(string[] args) // a method - contains a block of code
  {
    Program p = new Program();
    //p.dataTypes();
    //Console.WriteLine(args[0]); //dotnet run tacos - this will print tacos
    //Person person = new Person { FirstName = "Darren", LastName = "Q-Classes" };
    //System.Console.WriteLine(person.GetFullName());
    //p.linq();
    //var ll = new linqlearn();
    //ll.printCategories1();    
    //Person p1 = new Person("Darren","Quadros");
    //string fullName = p1.GetFullName();
    //Console.WriteLine(fullName);

    //p.classesAndObjects();
    NloggerClass nloggerClass = new NloggerClass();


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
  public void dataTypes()
  {
    //Value Types - [Simple Types, enum types, struct types and nullable]
    char singleCharacter = 'c';
    string nosOfCharacters = "Darren";
    double e = 5.5;
    bool boolDtype = true;
    int valueTypeA = 4;
    Int32 valueTypeB = valueTypeA; // in value types the value will be copied not referenced.
    System.Console.WriteLine($"valueTypeA = {valueTypeB}");
    valueTypeB = 7;
    System.Console.WriteLine($"valueTypeA = {valueTypeA} & valueTypeB = {valueTypeB}");
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
  public void arrays()
  {
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
      if (grade == 3)
      {
        System.Console.WriteLine($"found {grade} in the list");
        break;
      }
      else
      {
        System.Console.WriteLine("Not Found");
      }
    }

    int[,] twoDArray = new int[3, 2];
    twoDArray[0, 0] = 11;
    twoDArray[0, 1] = 12;
    twoDArray[1, 0] = 21;
    twoDArray[1, 1] = 22;

    int[,] twoDArraysimple = {
      {11,12},{21,22},{31,32}
    };

    System.Console.WriteLine(twoDArraysimple.GetLength(1));

    for (int i = 0; i < twoDArraysimple.GetLength(0); i++)
    {
      for (int j = 0; j < twoDArraysimple.GetLength(1); j++)
      {
        System.Console.WriteLine($"2D Array at [{i}],[{j}] is  {twoDArraysimple[i, j]}");
      }
    }

    int[][] jaggedArray = {
      [11,12,13]
      ,new int[] {21,22}
      ,new int[] {31,32,33}
    };
    System.Console.WriteLine(jaggedArray[0][1]);
    System.Console.WriteLine(jaggedArray[1].Length);
    for (int i = 0; i < jaggedArray.GetLength(0); i++)
    {
      for (int j = 0; j < jaggedArray[i].Length; j++)
      {
        System.Console.WriteLine($"jagged Array at [{i}],[{j}] is {jaggedArray[i][j]}");
      }
    }
    List<int> myList = new List<int> { 10, 20, 30 };
    var newlist = myList.Append(45);

    System.Console.WriteLine(newlist.ElementAt(3));
    if (myList.SequenceEqual(newlist))
    {
      System.Console.WriteLine("true");
    }
    else
    {
      System.Console.WriteLine("List do not match");
    }

    var toArray = myList.ToArray<int>();
    Console.WriteLine($"Converted list to Array - {toArray[0]}");

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
  public void linq()
  {
    int[] numbers = { 2, 3, 4, 5 };
    var squaredNumbers = numbers.Select(x => x * x);
    Console.WriteLine(string.Join(" ", squaredNumbers));
  }
  public void operators()
  {
    Console.WriteLine("Enter a number");
    int myNumber = Int32.Parse(Console.ReadLine());
    if (!(myNumber > 12))
    {
      Console.WriteLine($"If Clause - {myNumber}");
    }
    else
    {
      Console.WriteLine($"Else clause - {myNumber}");
    }
  }
  public void switchStatements()
  {
    Console.WriteLine("Enter your age for drinking");
    int age = Int32.Parse(Console.ReadLine());
    switch (age)
    {
      case <= 0:
        Console.WriteLine("Input your correct age!");
        //switchStatements();
        return; //return from this and outer code will never run.       
      case <= 18:
        Console.WriteLine("you are under age!");
        break;
      case <= 45:
        Console.WriteLine("you are at your legal age!");
        break;
      case <= 60:
        Console.WriteLine("you are at your legal age! but take care !");
        break;
      default:
        Console.WriteLine("you are too old! consume limited drinks!");
        break;
    }
    Console.WriteLine("outside of switch !");
  }
  public void classesAndObjects()
  {

    DataForTesting DataForTesting = new();
    DataForTesting.PrintUserType();

  }
  public void constantsReadOnly()
  {

    const int t1 = 52;
    Console.WriteLine(t1);
    Users u1 = new User("ssspl");
  }
  public void Enumss(FoodILike foodI)
  {
    Console.WriteLine(typeof(FoodILike));
    Console.WriteLine(foodI);
    var frice = FoodILike.friedrice;
    Console.WriteLine((int)frice);
    Console.WriteLine(Enum.Parse<FoodILike>("soups"));

    foreach (FoodILike f1 in Enum.GetValues(typeof(FoodILike)))
    {
      Console.WriteLine($"---{f1}");
    }

  }
  public int RecurssionTest(int number)
  {
    if (number < 5)
    {
      Console.WriteLine($"Number is : {number}");
      return RecurssionTest(number + 1);
    }
    else
    {
      Console.WriteLine($"Else Number is : {number}");
      return number;
    }
  }

  public void StringFormat()
  {
    DateTime date1 = new DateTime(2019, 11, 11);
    date1 = DateTime.Now;

    // Converts the object to string 
    string s1 = string.Format("{0:f}", date1);
    Console.WriteLine("formattedDateTime : {0}", s1);

    CultureInfo currentCulture = CultureInfo.CurrentCulture;
    Console.WriteLine(currentCulture);

    CultureInfo spanishCulture = new CultureInfo("es-ES");
    String formattedDateInSpanish = date1.ToString("D", spanishCulture);
    Console.WriteLine("formattedDateInSpanish : {0}", formattedDateInSpanish);

  }
}


