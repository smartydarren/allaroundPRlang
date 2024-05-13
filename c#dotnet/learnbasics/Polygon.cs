using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseGround
{
    internal class Polygon
    {
        public int NoOfSides { get; set; }
        protected string ItsType { get; set; }
        

        public Polygon()
        {
            this.NoOfSides = 0;
            this.ItsType = "Type of Square";
        }

        public Polygon(int noOfSides)
        {
            this.NoOfSides = noOfSides;
        }
    }
}
