using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PractiseGround
{
    internal class TextWriter : FileWriter
    {
        public string Extension { get { return ".txt"; } }

        public void Write(string filename)
        {
            StreamWriter writer = new StreamWriter("d:\\myfile.txt");
            writer.WriteLine("first line");
            //File.WriteAllTextAsync(filename+Extension,"Some Text");
        }
    }
}
