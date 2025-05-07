using Newtonsoft.Json;
using Npgsql.NameTranslation;
using System.Runtime.CompilerServices;

namespace webapiLearn.Models
{
  public class UserCar_Model
  {
    public class User
    {
      private static int ObjCount = 0;
      public int id { get; set; }
      public string name { get; set; }
      public List<UserCar> cars { get; set; }

      public User()
      {
        cars = new List<UserCar>();
        ObjCount += 1;
        Console.WriteLine($"No og objects created : {ObjCount} / {cars.Select(x => x.userId.GetValueOrDefault())}");
      }
    }

    public class UserCar
    {
      public int id_cars { get; set; }
      //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
      public int? userId { get; set; }
      public string brand { get; set; }
      public string model { get; set; }

      public UserCar()
      {

      }
    }

  }

}
