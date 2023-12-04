namespace BookRental.Logger
{
    public interface IMyLogger
    {
        void Log(string value);
        void Log(object value);
    }
}