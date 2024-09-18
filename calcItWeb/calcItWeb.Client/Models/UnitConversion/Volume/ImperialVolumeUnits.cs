
using System.ComponentModel;

namespace calcItWeb.Client.Models.UnitConversion.Volume
{
    public class ImperialVolumeUnits : INotifyPropertyChanged
    {
        public int Gallon { get; set; }
        public int Quart { get; set; }
        public int Pint { get; set; }
        public double FluidOunce { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        // Convert all to fluid ounces
        public double ToFluidOunce()
        {
            return Gallon * 128 + Quart * 32 + Pint * 16 + FluidOunce;
        }

        // Convert all to gallons
        public double ToGallon()
        {
            return ToFluidOunce() / 128.0;
        }

        // Convert to metric
        public MetricVolumeUnits ToMetric()
        {
            double totalFluidOunces = ToFluidOunce();
            double totalLiters = totalFluidOunces * 0.0295735; // Convert fluid ounces to liters

            // Convert liters to milliliters
            double milliliters = totalLiters * 1000;

            return new MetricVolumeUnits
            {
                Liter = (int)totalLiters,
                Milliliter = milliliters % 1000
            };
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
