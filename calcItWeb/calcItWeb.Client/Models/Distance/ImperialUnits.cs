using System.ComponentModel;

namespace calcItWeb.Client.Models.Distance
{
    public class ImperialUnits : INotifyPropertyChanged
    {
        public int Inches { get; set; }
        public int Feet { get; set; }
        public int Yards { get; set; }
        public int Miles { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;


        // Convert all to inches
        public int ToInches()
        {
            return (Miles * 63360) + (Yards * 36) + (Feet * 12) + Inches;
        }

        // Convert all to feet
        public double ToFeet()
        {
            return ToInches() / 12.0;
        }

        // Convert all to yards
        public double ToYards()
        {
            return ToInches() / 36.0;
        }

        // Convert all to miles
        public double ToMiles()
        {
            return ToInches() / 63360.0;
        }

        public MetricUnits ToMetric()
        {
            // First, convert everything to inches
            int totalInches = ToInches();

            // Convert inches to meters
            double totalMeters = totalInches * 0.0254;

            // Convert meters to kilometers, meters, centimeters, and millimeters
            double kilometers = totalMeters / 1000.0;
            totalMeters %= 1000;
            double meters = totalMeters;
            double centimeters = meters * 100;
            double millimeters = meters * 1000;

            return new MetricUnits
            {
                Kilometer = (int)kilometers,
                Meter = meters,
                Centimeter = centimeters % 100,
                Milimeter = millimeters % 1000
            };
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
