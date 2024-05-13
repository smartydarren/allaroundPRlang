using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseGround
{
    public delegate float MathDelegate(float a, float b);

    public delegate void HelloFunctionDelegate(string emessage);

    public delegate bool IsPromotable(Employees empl);

    public class Employees
    {
        public int ID { get; set; }
        public string name { get; set; }
        public int salary { get; set; }
        public int experience { get; set; }
        public static float Add(float a, float b)
        {
            return a + b;
        }

        public static float Subtract(float a, float b)
        {
            return a - b;
        }

        public static float Power(float baseNumber, float exponent)
        {
            return (float)Math.Pow(baseNumber, exponent);
        }

        public static void Hello(string message)
        {
            Console.WriteLine(message);
        }

        public void PromoteEmployee(List<Employees> employees, IsPromotable IsEligible)
        {
            foreach(Employees employees1 in employees)
            if (IsEligible(employees1))
            {
                Console.WriteLine(employees1.name + " : promoted");
            }
        }

        public float Execute(MathDelegate m1, float f1, float f2)
        {
            return m1(f1,f2);
        }

        public int Calculate(Func<int, int> calc, int input, int input1)
        {
            int result = calc(input + input1);
            //print(result);
            return result;
        }
    }
}
