
namespace ConsoleProject.Models;

class AsyncAwait
{

  public async Task CookEggs()
  {
    Console.WriteLine("Start Cooking Eggs......");
    await Task.Delay(3000);
    Console.WriteLine("Eggs Cooked !");
  }

  public async Task CookBacon()
  {
    Console.WriteLine("Start Cooking Bacons......");
    await Task.Delay(9000);
    Console.WriteLine("Bacons Cooked !");
  }

  public async Task<string> ContactServer()
  {
    Console.WriteLine("Contacting Server......");
    await Task.Delay(4000);
    Console.WriteLine("Returning Data !");
    return "Data";
  }
}
/* 
    AsyncAwait asyncAwait = new AsyncAwait();

    string data = await asyncAwait.ContactServer();
    Console.WriteLine(data);

    Task cookEggs = asyncAwait.CookEggs();
    Task cookBacon = asyncAwait.CookBacon();

    await Task.WhenAll(cookEggs, cookBacon);
    Console.WriteLine("Breakfast Ready !!!"); */