// See https://aka.ms/new-console-template for more information
using PractiseGround.InterfacesDemo;
using PractiseGround.ObjectPassing;
using PractiseGround.DelegatesDemonstration;
using PractiseGround.EventsDemo;

namespace PractiseGround
{
    internal class Program
    {
        // Main Method
        static void Main(String[] args)
        {
            /*
            Console.WriteLine("Hello, World!");
            int number1 = 3;
            int number2 = 5;
            int result = Multiply(number1, number2);
            Console.WriteLine(number1 + "-" + result);
            PractiseGround.Player P1 = new PractiseGround.Player("Darren Quadros",3) {Score1 = 100 };
            PractiseGround.Player P2 = new PractiseGround.Player("Aislinn Quadros", 3);
            Console.WriteLine(P1.GetName());
            P1.AddPoints(5);
            Console.WriteLine("Inital Score is : " + P1.GetScore());
            P1.AddPoints(100);
            Console.WriteLine("Score is : " + P1.GetScore());
            Console.WriteLine("Lives Left :" + P1.GetLivesLeft());
            P1.Kill(); P1.Kill();
            Console.WriteLine("Lives Left :" + P1.GetLivesLeft());
            Console.WriteLine("Objects Created :" + Player.GetNoOfObject());
            Console.WriteLine("Objects Created :" + P1.GetHashCode() + "  -  " +P2.GetHashCode());
            int p1Score = P1.Score1;
            P1.Score1 = 50;
            int noOfObj = Player.NoOfObjs;
            Console.WriteLine(noOfObj);
            
            string C1 = new string("darren");
            int i1 = new int();

            for (int i = 1; i <= 10; i++)
            {
                double myRandom = getRandomNumber();
                Console.WriteLine(myRandom);

            }


            static double getRandomNumber()
            {
                int seed = 11;
                int randomNumber = 0;
                int randomNumberSeed = 0;
                Random random = new Random();
                Random randomSeed = new Random(seed);
                randomNumber = random.Next(6) + 1;
                randomNumberSeed = randomSeed.Next(seed);

                return randomNumberSeed;
            }

            static int Multiply(int a, int b)
            {
                a = 9;
                return a;
            }
        
                Polygon p1 = new Polygon();
                Console.WriteLine(p1.NoOfSides);
                p1.NoOfSides = 25;
                Console.WriteLine(p1.NoOfSides);

                Console.WriteLine("-----------Square Starts----------");

                Square s1 = new Square(8);
                string a = s1.GetItsType();
                s1.NoOfSides = 2;
                Console.WriteLine(a);
                Console.WriteLine(s1.NoOfSides + "--" + s1.Size);

                Polygon p2 = new Square(5);
                Console.WriteLine(p2.ToString());



                if (p1 is Square)
                {
                    Console.WriteLine("This is a square object");
                }
                else
                {
                    Console.WriteLine("Its a Ploygon");
                }

                Polygon[] lotsOfPolygon = new Polygon[3];
                lotsOfPolygon[0] = new Square(1);
                lotsOfPolygon[1] = s1;
                lotsOfPolygon[2] = new Polygon(3);

                foreach(Polygon ploygons in lotsOfPolygon)
                {
                    int c = ploygons.NoOfSides;
                    Console.WriteLine(c);
                }

                Player p3 = new Player();
                MoveDirection p3md =  p3.MakeMove();
                Console.WriteLine(p3md);

                HumanPlayer hp1 = new HumanPlayer();
                MoveDirection m1 = hp1.MakeMove();
                Console.WriteLine(m1);

                TextWriter T1 = new TextWriter();
                TextWriter T2 = new TextWriter();

                FileWriter[] lotsOfFileWriters = new FileWriter[2];
                lotsOfFileWriters[0] = T1;
                Console.WriteLine(T1.Extension);
                lotsOfFileWriters[1] = T2;
                Console.WriteLine(T2.Extension);

                List<FileWriter> lotsOfListWriters = new List<FileWriter>();
                lotsOfListWriters.Add(T1);
                lotsOfListWriters.Add(T2);

                foreach (FileWriter writers in lotsOfListWriters)
                {
                    Console.WriteLine(writers.GetType());
                    Console.WriteLine(writers.Extension);
                }

                FileStream fileStream = File.OpenWrite("D:/myfile.txt");
                using System.IO.TextWriter textWriter = new StreamWriter(fileStream);

                textWriter.Write(3);
                textWriter.Write("Hello");

                textWriter.Flush();
                textWriter.Close();

            Delegates ddl1 = new Delegates ();
            float ab = 5;
            float ba = 7;
            MathDelegate mathOperation = Delegates.Add;
            float result = mathOperation(6, 8);
            Console.WriteLine(result);

            PropertiesEg pe1 = new PropertiesEg();
            pe1.MyInt = 9;
            Console.WriteLine("Property Set is {0}",pe1.MyInt);
            int aaa = pe1.MyProperty = 9;
            Console.WriteLine(pe1.MyProperty);
            Console.WriteLine(aaa);

            Task<int> ta1 = pe1.Method1();
            Console.WriteLine(ta1);
            Task<int> ta2 = pe1.Method2();
            Console.WriteLine(ta2);

            Delegate Example, requires function to be passed
            Employee e1 = new Employee();
            e1.ID = 101; e1.name = "Darren";
            Employee e2 = new Employee();
            e2.ID = 102; e2.name = "Aislinn";
            Employee e3 = new Employee();
            e3.ID = 103; e3.name = "Adelyn";
            Employee e4 = new Employee();
            e4.ID = 104; e4.name = "Denver";

            List<Employee> employees = new List<Employee>();
            employees.Add(e1); employees.Add(e2); employees.Add(e3); employees.Add(e4);

            List<Employee> employeesRange2 = new List<Employee>() { new Employee { ID = 105, name = "Roque" } };

            employees.AddRange(employeesRange2);

            foreach (Employee emps in employees)
            {
                Console.WriteLine("ID is : {0}, Name is : {1}",emps.ID,emps.name);
            }
            HelloFunctionDelegate delg = new HelloFunctionDelegate(Employees.Hello);
            delg("Hello from delegate");
            employees.find

            List<Employees> dl1 = new List<Employees>();
            dl1.Add(new Employees() {ID=1,name="Roque",salary=5000,experience=5 });
            dl1.Add(new Employees() { ID = 1, name = "Denver", salary = 5000, experience = 3 });
            dl1.Add(new Employees() { ID = 1, name = "Darren", salary = 7000, experience = 4 });
            dl1.Add(new Employees() { ID = 1, name = "Aislinn", salary = 8000, experience = 6 });

            IsPromotable ip1 = new IsPromotable(isCheck);
                        
            Employees dle1 = new Employees();
            //dle1.PromoteEmployee(dl1,ip1);
            dle1.PromoteEmployee(dl1, e => e.salary > 6000);

            Employees eee1 = new Employees();
            dl1.Find((Employees Emp) => Emp.name == "Denver");
            Console.WriteLine("Employee name is {0}",eee1.name); 

            var cc1 = PaymentFactory.create(mode.CreditCard);
            var dc1 = PaymentFactory.create(mode.DebitCard);
            PaymentGateway p1 = new PaymentGateway(dc1);
            p1.makePayment();

            static float Plusing(float a, float b) => a + b;

            static float PlushigSimple(float a, float b)
            {
                var result = a + b;
                return result;
            }

            Employees delg1 = new Employees();
            float response = delg1.Execute(Plusing, 40, 50);
            Console.WriteLine("REsponse: {0}",response);

            var PlushingResponse = delg1.Execute(PlushigSimple, 4, 5);
            Console.WriteLine("Simple Delgate Understanding :" + PlushingResponse);

            var resp = delg1.Calculate(x => x, 7, 8);
            Console.WriteLine(resp);

            DelegatesDemo D1 = new DelegatesDemo();
            DelegatesDemo.PrintDelegate p1 = new DelegatesDemo.PrintDelegate(Printing);
            p1("Hello Darren");

            D1.Print("Hello Aislinn");

            DelegatesDemo.PrintDelegate P2 = new DelegatesDemo.PrintDelegate((x) =>
            {
                Console.WriteLine(x);
            });
            P2("Hello");

            //D1.doLongOperations(myOps);

            D1.doLongOperations(x =>
            {
                Console.WriteLine("Currently processing : {0}", x);
            }
            ); */
            EmpDetails EEE1 = new EmpDetails{EmpID = 1, EmpName = "Darren" };
            EmployeeSeperator E1 = new EmployeeSeperator(EEE1);
            IT EIT1 = new IT(E1,EEE1);
            E1.Seperate();
          

        }

        public static void myOps(string t)
        {
            Console.WriteLine("Currently processing : {0}",t);
        }

        public static void Printing(string V)
        {
            Console.WriteLine("Printing incomming string : {0}",V);
        }
        public static bool isCheck(Employees emp)
        {
            if (emp.salary > 6000)
            {
                return true;
            }
            else return false;
        }

        public class Employee
        {
            public int ID { get; set; }
            public string name { get; set; }
        }

        public class OfficeEmployee : Employee
        {
            public OfficeEmployee(Employee _employee)
            {
                Console.WriteLine("Office Employee Constructor" + _employee.name);

            }
        }
    }

}