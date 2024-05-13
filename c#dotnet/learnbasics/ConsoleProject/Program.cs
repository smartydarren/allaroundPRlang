using System; // using declaration
namespace ConsoleProject; // a namespae - used for organisation simply to group classes

class Program // as class - has members (such as a properties and method)
{
    //Console.WriteLine(); // this code wont work as it needs to be in a method.
    static void Main(string[] args) // a method - contains a block of code
    {
        Program p = new Program();
        p.print();        
        Console.WriteLine(args[0]); //dotnet run tacos - this will print tacos
                
    }

    void print(){
        System.Console.WriteLine("Hello, Darren"); // a statement
        Console.Write(7.58);
        Console.WriteLine("Hello");
        string ttl = Console.Title = "MyTitle";
        Console.WriteLine(ttl);
        Console.BackgroundColor = ConsoleColor.Black;
        object test = new object();
        Console.WriteLine(test.GetType());                
    }
}
// namespace -> classes -> members -> method -> statements