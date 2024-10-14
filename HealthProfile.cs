using System.ComponentModel;

public class HealthProfile : INotifyPropertyChanged
{
    private double? _weight; 
    private double? _height;

    public event PropertyChangedEventHandler PropertyChanged;

    public double? Weight
    {
        get => _weight;
        set
        {
            if (_weight != value)
            {
                _weight = value;
                OnPropertyChanged(nameof(Weight));
                OnPropertyChanged(nameof(BMI));
            }
        }
    }

    public double? Height
    {
        get => _height;
        set
        {
            if (_height != value)
            {
                _height = value;
                OnPropertyChanged(nameof(Height));
                OnPropertyChanged(nameof(BMI));
            }
        }
    }

    public double BMI => (Height > 0) ? (Weight ?? 0) / Math.Pow((Height ?? 0) / 100, 2) : 0;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
