namespace BookRental.Logger
{
    public class ConsoleLogger : IMyLogger
    {
        public void Log(string value)
        {
            Console.WriteLine(value);
        }

        public void Log(object value)
        {
            Log(value.ToString() ?? string.Empty);
        }
    }
}