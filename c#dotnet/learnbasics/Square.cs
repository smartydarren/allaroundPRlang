using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseGround
{
    internal class Square : Polygon
    {
        public float Size { get; set; }

        public Square(float size)
               :base(4)
        {
            this.Size = size;
        }

        public string GetItsType()
        {
            ItsType = "Its a type of string";
            string a = ItsType;
            return a;
        }
    }

}
