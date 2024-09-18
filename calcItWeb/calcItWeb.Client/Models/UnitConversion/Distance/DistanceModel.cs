using System.ComponentModel;

namespace calcItWeb.Client.Models.UnitConversion.Distance
{
    public class DistanceModel : INotifyPropertyChanged
    {
        public ImperialUnits ImperialUnits { get; set; }
        public MetricUnits MetricUnits { get; set; }
        public string ConversionType { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public DistanceModel()
        {
            MetricUnits = new MetricUnits();
            ImperialUnits = new ImperialUnits();
            ConversionType = "from metric";
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
