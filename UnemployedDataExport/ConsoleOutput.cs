using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schukin.UnemployedDataExport
{
    public class ConsoleOutput : IOutput
    {
        public void Write(string line)
        {
            Console.WriteLine(line);
        }

        public void Write(string[] lines)
        {
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}
