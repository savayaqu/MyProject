using System.ComponentModel;

namespace MyProject
{
    public class HealthProfile : INotifyPropertyChanged
    {
        private double weight;
        private double height;
        private double bmi;

        public double Weight
        {
            get => weight;
            set
            {
                weight = value;
                OnPropertyChanged(nameof(Weight));
                OnPropertyChanged(nameof(BMI)); // Обновляем BMI при изменении веса
            }
        }

        public double Height
        {
            get => height;
            set
            {
                height = value;
                OnPropertyChanged(nameof(Height));
                OnPropertyChanged(nameof(BMI)); // Обновляем BMI при изменении роста
            }
        }

        public double BMI
        {
            get
            {
                if (Height > 0)
                {
                    return Weight / ((Height / 100) * (Height / 100)); // Приводим рост к метрам
                }
                return 0;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
