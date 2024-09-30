using System.Collections;

namespace ConsoleProject.Models;

class CollectionsEg{

  ArrayList arrayList = new ArrayList{
    1,2,3,"Darren","Aislinn",true,false,55.12
  };

  Hashtable hashtable = new Hashtable();
  

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


}