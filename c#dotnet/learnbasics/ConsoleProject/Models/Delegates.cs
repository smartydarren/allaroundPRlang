using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Models
{
  delegate void SavesDataDelegate(string text);

  class DelegateEx{
    public SavesDataDelegate saveToConsole = (string text) => {
      Console.WriteLine(text);
    };  

    public SavesDataDelegate saveToFile = (string text) => {          
      File.AppendAllText("./ref.log",text);
    };   
    
  };
}


// DelegateEx sd1 = new DelegateEx();
//   sd1.saveToConsole("Hello Darren");
//   //File.Delete("./ref.log");
//   for(int i = 0; i<=11; i++){
//     Console.WriteLine($"Writting Line no {i}");
//     sd1.saveToFile($"Line {i} - Hello Darren\n");