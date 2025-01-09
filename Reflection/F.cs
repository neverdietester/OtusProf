using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class F
    {
        public int i1, i2, i3, i4, i5;

        public static F Get()
        {
            return new F() { i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5 };
        }

        public string Serialize()
        {
            return $"{i1},{i2},{i3},{i4},{i5}";
        }

        public static F Deserialize(string str)
        {
            var parts = str.Split(',');
            return new F
            {
                i1 = int.Parse(parts[0]),
                i2 = int.Parse(parts[1]),
                i3 = int.Parse(parts[2]),
                i4 = int.Parse(parts[3]),
                i5 = int.Parse(parts[4])
            };
        }
    }
}
