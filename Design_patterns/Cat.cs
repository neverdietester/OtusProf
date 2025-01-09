using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_patterns
{
    public class Cat : Mammal
    {
        public double WhiskerLength { get; set; }

        public Cat(string name, int age, string furColor, double whiskerLength) : base(name, age, furColor)
        {
            WhiskerLength = whiskerLength;
        }

        public override Cat Clone()
        {
            return new Cat(Name, Age, FurColor, WhiskerLength);
        }
    }
}
