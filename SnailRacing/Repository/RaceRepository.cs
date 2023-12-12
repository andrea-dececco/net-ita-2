using System.Text.Json;
using SnailRacing.Repository.Interfaces;

namespace SnailRacing.Repository
{
    public class RaceRepository : IRaceRepository
    {
        private const string FILE_NAME = "races.json";
        private List<Race> _racesToAdd = new();

        public async Task AddRaceAsync(Race race)
        {
            _racesToAdd.Add(race);
        }

        public async Task<List<Race>> GetRacesAsync()
        {
            if (File.Exists(FILE_NAME))
            {
                string fileContent = await File.ReadAllTextAsync(FILE_NAME);
                return JsonSerializer.Deserialize<List<Race>>(fileContent) ?? new();
            }

            return new();
        }

        public async Task SaveChangesAsync()
        {
            List<Race> currentRaces = new();
            if (File.Exists(FILE_NAME))
            {
                Console.WriteLine("File exists");
                string fileContent = await File.ReadAllTextAsync(FILE_NAME);
                Console.WriteLine("File content: " + fileContent);
                try
                {
                    List<Race>? fileRaces = JsonSerializer.Deserialize<RaceJson>(fileContent)?.Races;

                    if (fileRaces != null)
                    {
                        Console.WriteLine("File races is not null " + fileRaces.Count);
                        currentRaces.AddRange(fileRaces);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine("CurrentRaces " + currentRaces.Count);
            Console.WriteLine("RacesToAdd " + _racesToAdd.Count);
            currentRaces.AddRange(_racesToAdd);
            _racesToAdd = new();
            await File.WriteAllTextAsync(FILE_NAME, JsonSerializer.Serialize(new RaceJson() { Races = currentRaces }));
        }
    }
}