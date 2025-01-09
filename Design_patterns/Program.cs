using System;
using System.Collections.Generic;
using System.Linq;
using Design_patterns;

class Program
{
    static void Main(string[] args)
    {
        Dog dog = new Dog("Buddy", 3, "Brown", "Labrador");
        Cat cat = new Cat("Whiskers", 2, "Black", 5.0);

        Dog clonedDog = dog.Clone();
        Cat clonedCat = cat.Clone();

        Console.WriteLine($"Original Dog: {dog.Name}, Age: {dog.Age}, FurColor: {dog.FurColor}, Breed: {dog.Breed}");
        Console.WriteLine($"Cloned Dog: {clonedDog.Name}, Age: {clonedDog.Age}, FurColor: {clonedDog.FurColor}, Breed: {clonedDog.Breed}");

        Console.WriteLine($"Original Cat: {cat.Name}, Age: {cat.Age}, FurColor: {cat.FurColor}, WhiskerLength: {cat.WhiskerLength}");
        Console.WriteLine($"Cloned Cat: {clonedCat.Name}, Age: {clonedCat.Age}, FurColor: {clonedCat.FurColor}, WhiskerLength: {clonedCat.WhiskerLength}");
    }
}