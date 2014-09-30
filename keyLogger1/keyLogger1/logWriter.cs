using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text;
using System.IO;

namespace keyLogger1
{
    class logWriter
    {
        Encoding sjisEnc;
        StreamWriter writer;

        public void init()
        {
            sjisEnc = Encoding.GetEncoding("Shift_JIS");
            writer =
              new StreamWriter(@"logs.txt", true, sjisEnc);
            
            
        }

        public void write(string message)
        {
            writer.WriteLine(message);
        }

        public void close()
        {
            writer.Close();
        }
    }
}
