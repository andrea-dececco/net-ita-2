

namespace Inhertiance
{
    internal class Cat : Animal
    {
        public Cat(string Name, int Age) : base(Name, Age)
        {
        }

        public override void Speak()
        {
            Console.WriteLine($"{Name} of {Age} years ago meow meow");
        }
    }
}
