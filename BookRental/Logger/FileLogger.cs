namespace BookRental.Logger
{
    public class FileLogger : IMyLogger
    {
        const string FILE_PATH = "log.txt";

        public void Log(string value)
        {
            string currentText = string.Empty;

            if (File.Exists(FILE_PATH))
            {
                currentText += File.ReadAllText(FILE_PATH) + "\n";
            }

            File.WriteAllText(FILE_PATH, currentText + value);
        }

        public void Log(object value)
        {
            Log(value.ToString() ?? string.Empty);
        }
    }
}