using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteerVerseMobile.Models;

namespace VolunteerVerseMobile.Utils.Converters
{
    public class EventJoinButtonTextConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            EventDetails? eventDetails = value as EventDetails;

            if (eventDetails == null)
            {
                return null;
            }

            if (eventDetails.IsJoined)
            {
                return "Resign";
            }

            return "Join";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
