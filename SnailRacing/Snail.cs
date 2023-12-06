namespace SnailRacing
{
    public class Snail
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public int FrequencyMs { get; set; } = new Random().Next(800, 1200);
        public int CurrentRaceProgression;

        public Snail(string name, int number)
        {
            Name = name;
            Number = number;
        }
    }
}