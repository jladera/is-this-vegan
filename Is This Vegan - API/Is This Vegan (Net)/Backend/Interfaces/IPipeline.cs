using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Is_This_Vegan__Net_.Backend.Interfaces
{
    interface IPipeline
    {
        bool Execute<T>(ref T input);
    }
}
