class Tax
{

  public static readonly List<int> taxRate = new List<int> { 5, 10, 15, 20, 25 };

  public static readonly string taxName = "Sales Tax";

  public static readonly List<string> taxNameList = new List<string> { "Sales Tax" };
  public static double CalculateTax(double amount)
  {
    return amount * 1.05;
  }
}