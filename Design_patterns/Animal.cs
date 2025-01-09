using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_patterns
{
    public class Animal : IMyCloneable<Animal>, ICloneable
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Animal()
        {
        }

        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public virtual Animal Clone()
        {
            return new Animal(Name, Age);
        }

        object ICloneable.Clone()
        {
            return Clone();
        }
    }
}
