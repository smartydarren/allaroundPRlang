using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseGround
{
    internal class PropertiesEg
    {
        private int rNum;
        public int MyInt {
            get
            {
                return rNum;
            } 
            set {
                rNum = value;
                if (rNum <= 1)
                {
                    this.rNum = -1;
                }
                else
                {
                    this.rNum = value;
                }
            } 
        }

        public int MyProperty { get; set; }

        public async Task<int> Method1()
        {
            await Task.Delay(500);
            Console.WriteLine("Method1 : Sleeping for 2 secs");
            return 10;
            //Thread.Sleep(2000);
        }

        public async Task<int> Method2()
        {
            await Task.Delay(100);
            Console.WriteLine("Method1 : Sleeping for 2 secs");
            return 5; 
            
        }
    }
}
