using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    public class WorkoutImageConverter : IValueConverter
    {
        private Dictionary<string, string> workoutImages = new Dictionary<string, string>
        {
            { "Кардио", "cardio.jpg" },
            { "Силовая тренировка", "strength.jpg" },
            { "Йога", "ioga.jpg" },
            { "Бег", "beg.jpg" },
            { "Кроссфит", "crossfit.png" }
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string workoutName)
            {
                return workoutImages.ContainsKey(workoutName) ? workoutImages[workoutName] : null;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
