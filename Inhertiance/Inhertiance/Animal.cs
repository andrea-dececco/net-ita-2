using System;

namespace Inhertiance
{
    public class Animal
    {

        public string Name { get; set; }
        public int Age { get; set; }


        public Animal(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }

        public virtual void Speak()
        {
            Console.WriteLine($"Verso del {Name}");
        }
    }
}
