using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_patterns
{
    public interface IMyCloneable<T>
    {
        T Clone();
    }
}
