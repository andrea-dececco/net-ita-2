namespace SnailRacing.Repository.Interfaces
{
    public interface IRaceRepository
    {
        Task<List<Race>> GetRacesAsync();
        Task AddRaceAsync(Race race);
        Task SaveChangesAsync();
    }
}