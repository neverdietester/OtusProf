using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtusProf
{
    class GameSettings :IGameSettings
    {
        public int NumberOfAttempts { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
    }
}
