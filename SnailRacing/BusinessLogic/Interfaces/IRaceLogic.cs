namespace SnailRacing.BusinessLogic.Interfaces
{
    public interface IRaceLogic
    {
        void CreateRace();
        string GetRaceDetails();
        void StartRace();
        void ViewRaceStatus();
        void ViewResults();
    }
}