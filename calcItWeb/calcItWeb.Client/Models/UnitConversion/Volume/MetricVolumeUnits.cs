using System.ComponentModel;

namespace calcItWeb.Client.Models.UnitConversion.Volume
{
    public class MetricVolumeUnits : INotifyPropertyChanged
    {
        public double Liter { get; set; }
        public double Milliliter { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        // Convert all to milliliters
        public double ToMilliliter()
        {
            return Liter * 1000 + Milliliter;
        }

        // Convert all to liters
        public double ToLiter()
        {
            return ToMilliliter() / 1000.0;
        }

        // Convert to imperial
        public ImperialVolumeUnits ToImperial()
        {
            double totalLiters = ToLiter();
            double totalGallons = totalLiters * 0.264172; // Convert liters to gallons

            // Convert into gallons, quarts, pints, and fluid ounces
            int gallons = (int)totalGallons;
            double remainingGallons = totalGallons - gallons;
            int quarts = (int)(remainingGallons * 4);
            remainingGallons = remainingGallons * 4 - quarts;
            int pints = (int)(remainingGallons * 2);
            remainingGallons = remainingGallons * 2 - pints;
            double fluidOunces = remainingGallons * 16;

            return new ImperialVolumeUnits
            {
                Gallon = gallons,
                Quart = quarts,
                Pint = pints,
                FluidOunce = fluidOunces
            };
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
