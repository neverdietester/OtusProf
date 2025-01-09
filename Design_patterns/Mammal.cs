using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_patterns
{
    public class Mammal : Animal
    {
        public string FurColor { get; set; }

        public Mammal(string name, int age, string furColor) : base(name, age)
        {
            FurColor = furColor;
        }

        public override Mammal Clone()
        {
            return new Mammal(Name, Age, FurColor);
        }
    }

}
