using System.Collections;
using System.Collections.Immutable;
using Microsoft.VisualBasic;
namespace ConsoleProject.Models;

internal class CollectionsEg{

  ArrayList arrayList = new ArrayList{
    1,2,3,"Darren","Aislinn",true,false,55.12
  };

  Hashtable hashtable = new Hashtable();
  
  
  Dictionary<int,string> employee = new Dictionary<int, string>(){{1,"Darren"}, {2,"Aislinn"}};
  Dictionary<string,int> nameAge = new Dictionary<string, int> (){{"Darren",39},{"Aislinn",35}};

Stack<string> stackOfStrings = new Stack<string>();
Queue<string> queueOfStrings = new Queue<string>();


private List<AgeName> AgeNames = new List<AgeName>(){
    new AgeName(){Age = 6, Name="Roque"},
    new AgeName(){Age = 5, Name="Luiza"}
  };

  internal void arraylist(){
    foreach(var i in arrayList){
      Console.WriteLine(i);      
    }
  }

  internal void HashTable(){
    hashtable.Add("Husband","Darren");hashtable.Add("Wife","Aislinn");
    foreach(DictionaryEntry i in hashtable){
      Console.WriteLine("Key = {0}, value={1}",i.Key,i.Value);
    }
  }

  internal void DictionaryTable(){
    employee.Add(3,"Adelyn");employee.Add(4,"Denver");
    foreach(AgeName record in AgeNames){
      employee[record.Age] = record.Name;
    }    

    foreach(KeyValuePair<int,string> e in employee){
      Console.WriteLine("Key = {0}, value={1}",e.Key,e.Value);
    }
    Console.WriteLine("----------------");

    foreach(string empName in nameAge.Keys){            
      Console.WriteLine("Key = {0} : value={1}",empName,nameAge[empName]);
    }

  }

  internal void StackRef(){
    stackOfStrings.Push("Darren");
    stackOfStrings.Push("Aislinn");

    Console.WriteLine(stackOfStrings.Pop());
  }

  
  internal void QueueRef(){
    queueOfStrings.Enqueue("Darren");
    queueOfStrings.Enqueue("Aislinn");

    Console.WriteLine(queueOfStrings.Dequeue());
  }

private class AgeName{
  public int Age { get; set; }
  public string Name { get; set; }
}

}

/*
CollectionsEg ce = new CollectionsEg();
  ce.DictionaryTable();
*/