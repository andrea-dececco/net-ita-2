using System.Collections.Concurrent;

namespace SnailRacing
{
    public class Race
    {
        public int Length { get; set; }
        public List<Snail> ParticipantSnails { get; set; }
        public ConcurrentQueue<Snail> Placing { get; set; } = new();

        public bool IsRaceFinished { get => ParticipantSnails.Count == Placing.Count; }

        public Race(int length, List<Snail> participantSnails)
        {
            Length = length;
            ParticipantSnails = participantSnails;
        }

        public void Start()
        {
            List<Task> tasks = new();
            foreach (Snail snail in ParticipantSnails)
            {
                Task t = Task.Run(async () =>
                {
                    while (snail.CurrentRaceProgression <= Length)
                    {
                        await Task.Delay(snail.FrequencyMs);
                        Interlocked.Add(ref snail.CurrentRaceProgression, ThrowDice());
                        Console.WriteLine($"Snail {snail.Name} => Progression {snail.CurrentRaceProgression}/{Length}");
                    }

                    Placing.Enqueue(snail);
                });
                tasks.Add(t);
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("Race finished");
        }

        private int ThrowDice()
        {
            return new Random().Next(1, 7);
        }
    }
}