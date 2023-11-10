using System;
using System.Collections.Generic;

namespace Ereditarieta
{
    public class Dog : Animal
    {
        public Dog(string Name, int Age) : base(Name, Age)
        {
        }


        public override void Speak()
        {
            Console.WriteLine($"{Name} of {Age} years ago woof woof");
        }
    }
}
