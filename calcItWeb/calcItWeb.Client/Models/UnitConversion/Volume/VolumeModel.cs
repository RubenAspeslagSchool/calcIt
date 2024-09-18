using System.ComponentModel;

namespace calcItWeb.Client.Models.UnitConversion.Volume
{
    public class VolumeModel : INotifyPropertyChanged
    {
        public ImperialVolumeUnits ImperialUnits { get; set; }
        public MetricVolumeUnits MetricUnits { get; set; }
        public string ConversionType { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public VolumeModel()
        {
            MetricUnits = new MetricVolumeUnits();
            ImperialUnits = new ImperialVolumeUnits();
            ConversionType = "from metric";
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
