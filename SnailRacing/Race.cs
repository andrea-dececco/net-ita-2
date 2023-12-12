using System.Collections.Concurrent;
using System.Diagnostics;

namespace SnailRacing
{
    public class Race
    {
        public int Length { get; set; }
        public bool IsInProgress { get; set; }
        public List<Snail> ParticipantSnails { get; set; }
        private ConcurrentDictionary<Snail, TimeSpan> _placing { get; set; } = new();
        private ConcurrentDictionary<Snail, int> _currentRaceProgression = new();
        private Stopwatch _timer = new();
        private Func<Race, Task> _raceFinishedCallback;

        public Race() { }

        public Race(int length, List<Snail> participantSnails, Func<Race, Task> raceFinishedCallback)
        {
            Length = length;
            ParticipantSnails = participantSnails;
            _raceFinishedCallback = raceFinishedCallback;
        }

        public void Start()
        {
            _timer.Start();
            IsInProgress = true;

            foreach (Snail snail in ParticipantSnails)
            {
                _currentRaceProgression[snail] = 0;

                Task t = Task.Run(async () =>
                {
                    while (_currentRaceProgression[snail] <= Length)
                    {
                        await Task.Delay(snail.FrequencyMs);
                        _currentRaceProgression.AddOrUpdate(snail, 0, (snail, old) => old + ThrowDice());
                    }

                    //Console.WriteLine($"Snail {snail.Name} => Arrived in {_timer.Elapsed.TotalSeconds:0.000} seconds");
                    SnailArrived(snail);
                });
            }
        }

        public ConcurrentDictionary<Snail, int> GetCurrentRaceProgression()
        {
            return _currentRaceProgression;
        }

        private void SnailArrived(Snail snail)
        {
            _placing[snail] = _timer.Elapsed;

            if (_placing.Count == ParticipantSnails.Count)
            {
                RaceFinished();
            }
        }

        private void RaceFinished()
        {
            _timer.Stop();
            Console.WriteLine("Race finished, order:");

            List<Snail> orderedSnails = _placing.OrderBy(x => x.Value).Select(x => x.Key).ToList();

            for (int i = 0; i < orderedSnails.Count; i++)
            {
                var s = orderedSnails[i];
                Console.WriteLine($"pos{i + 1}: {s.Name} ({s.Number}): {_placing[s].TotalSeconds:0.000}");
            }

            _raceFinishedCallback(this);
            IsInProgress = false;
        }

        private int ThrowDice()
        {
            return new Random().Next(1, 7);
        }
    }
}