using Is_This_Vegan__Net_.Enums;
using Is_This_Vegan__Net_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Is_This_Vegan__Net_.Backend.Interfaces
{
    public interface IPipeline
    {
        PipelineResultModel Execute<T>(ref T input, DataCleanEnum? type, float? meanConfidence);
    }
}
