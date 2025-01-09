using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_patterns
{
    public class Dog : Mammal
    {
        public string Breed { get; set; }

        public Dog(string name, int age, string furColor, string breed) : base(name, age, furColor)
        {
            Breed = breed;
        }

        public override Dog Clone()
        {
            return new Dog(Name, Age, FurColor, Breed);
        }
    }

}
