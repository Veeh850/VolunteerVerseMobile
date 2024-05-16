using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteerVerseMobile.Models;

namespace VolunteerVerseMobile.Utils.Converters
{
    public class TaskCapacityToStringConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            TaskDetailsForEvents? taskDetails = value as TaskDetailsForEvents;

            if(taskDetails == null)
            {
                return null;
            }

            return $"Filled: {taskDetails.Taken}/{taskDetails.Capacity}";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
