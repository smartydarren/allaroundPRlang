using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseGround
{
    internal interface FileWriter
    {
        string Extension { get; }

        void Write(string filename);
    }
}
