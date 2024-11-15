using Azure.Identity;

namespace LoggingNamespace;

public class NloggerClass
{
  int start = 1;
  string userName = "dquadros";
  public NloggerClass()
  {
    while (start <= 50)
    {
      Console.WriteLine("Hello Darren");
      var logger = NLog.LogManager.GetCurrentClassLogger();
      logger.Info("App Started {start_Var} {username_Var} ", start, userName);
      start++;
    }

    NLog.LogManager.Shutdown();
  }

}