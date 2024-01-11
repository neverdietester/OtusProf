using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtusProf
{
    interface IRandomNumberGenerator
    {
        int Generate(int minValue, int maxValue);
    }
}
