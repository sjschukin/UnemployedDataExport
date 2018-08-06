using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schukin.UnemployedDataExport
{
    public interface IOutput
    {
        void Write(string line);
        void Write(string[] lines);
    }
}
