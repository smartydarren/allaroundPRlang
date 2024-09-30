namespace ConsoleProject.Models;
abstract class Vehicle{
protected string Make { get; set; }
protected string Model { get; set; }
protected string EngineStartStop { get; set; } = "Off";

protected Vehicle(string make, string model) => 
  (this.Make, this.Model) = (make,model);

protected void EngineStart(){
  EngineStartStop = "On";
}

protected abstract void BeforeStartEngine();
protected abstract void AfterStartEngine();
public abstract void InitialState();

}

  class Bus : Vehicle
{
  internal Bus(string make, string model) : base(make,model){}

  public override void InitialState(){
    Console.WriteLine($"Engine is {base.EngineStartStop}");
  }

  protected override void AfterStartEngine()
  {
    throw new NotImplementedException();
  }

  protected override void BeforeStartEngine()
  {
    throw new NotImplementedException();
  }
}

class Car : Vehicle{

private string CarDisplay { get; set; } = "Off";
internal Car(string make, string model) : base(make,model){}

public override void InitialState(){
  Console.WriteLine($"Engine is {base.EngineStartStop}, Car Display is {CarDisplay}");
}
  protected override void AfterStartEngine()
  {
    CarDisplay = "On";
  }

  protected override void BeforeStartEngine()
  {
    CarDisplay = "On";
  }
}