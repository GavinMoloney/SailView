namespace SailView.Data
{
    public class TimeHelpers
    {
        public static TimeSpan CalculateCorrectedTime(string boatType, TimeSpan timingRecord)
        {
            double pyNumber;

            switch (boatType)
            {
                case "Sloop":
                    pyNumber = 1300;
                    break;
                case "1720":
                    pyNumber = 850;
                    break;
                default:
                    throw new ArgumentException($"Unknown boat type: {boatType}");
            }

            double elapsedTimeInSeconds = timingRecord.TotalSeconds;
            double correctedTimeInSeconds = elapsedTimeInSeconds * 1000 / pyNumber;
            TimeSpan correctedTime = TimeSpan.FromSeconds(correctedTimeInSeconds);

            return correctedTime;
        }
    }
}