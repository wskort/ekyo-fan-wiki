using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_probeersels
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Animal d = new Dog();
            d.Speak();
            Animal c = new Cat();
            c.Speak();
        }
    }
    abstract class Animal
    {
        public Animal()
        {
            Console.WriteLine("Animal created");
        }
        ~Animal()
        {
            Console.WriteLine("Animal deleted");
        }
        public abstract void Speak();
    }
    class Dog: Animal 
    {
        public Dog()
        {
            Console.WriteLine("Dog created");
        }
        ~Dog()
        {
            Console.WriteLine("Dog deleted");
        }
        public override void Speak()
        {
            Console.WriteLine("Woof!");
        }
    }
    class Cat: Animal
    {
        public Cat()
        {
            Console.WriteLine("Cat created");
        }
        ~Cat()
        {
            Console.WriteLine("Cat deleted");
        }
        public override void Speak()
        {
            Console.WriteLine("Meow!");
        }
    }
}
