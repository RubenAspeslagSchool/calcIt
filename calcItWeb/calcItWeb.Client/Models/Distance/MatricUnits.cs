using System.ComponentModel;

namespace calcItWeb.Client.Models.Distance
{
    public class MetricUnits : INotifyPropertyChanged
    {
        public double Milimeter { get; set; }
        public double Centimeter { get; set; }
        public double Decimeter { get; set; }
        public double Meter { get; set; }
        public double Kilometer { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;


        // Convert all to milimeters
        public double ToMilimeter()
        {
            return (Kilometer * 1000000) + (Meter * 1000) + (Decimeter * 100) + (Centimeter * 10) + Milimeter;
        }

        // Convert all to centimeters
        public double ToCentimeter()
        {
            return ToMilimeter() / 10.0;
        }

        // Convert all to decimeters
        public double ToDecimeter()
        {
            return ToMilimeter() / 100.0;
        }

        // Convert all to meters
        public double ToMeter()
        {
            return ToMilimeter() / 1000.0;
        }

        // Convert all to kilometers
        public double ToKilometer()
        {
            return ToMilimeter() / 1000000.0;
        }
        public ImperialUnits ToImperial()
        {
            // First, convert the entire metric unit to meters
            double totalMeters = ToMeter();

            // Convert meters to inches, feet, yards, and miles
            double totalInches = totalMeters * 39.3701;
            int miles = (int)(totalInches / 63360);
            totalInches %= 63360;
            int yards = (int)(totalInches / 36);
            totalInches %= 36;
            int feet = (int)(totalInches / 12);
            totalInches %= 12;
            int inches = (int)totalInches;

            return new ImperialUnits
            {
                Miles = miles,
                Yards = yards,
                Feet = feet,
                Inches = inches
            };
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
