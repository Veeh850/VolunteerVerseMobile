using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteerVerseMobile.Models;

namespace VolunteerVerseMobile.Utils.Converters
{
    public class TaskButtonTextConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            TaskDetailsForEvents? taskDetails = value as TaskDetailsForEvents;

            if(taskDetails == null)
            {
                return null;
            }

            if(taskDetails.IsApplied == false)
            {
                return "Apply";
            }
            else if(taskDetails.IsApplied && taskDetails.NeedApproval == false)
            {
                return "Resign";
            }
            else if(taskDetails.IsApplied && taskDetails.NeedApproval && taskDetails.IsApproved == false)
            {
                return "Revoke Apply";
            }
            else
            {
                return "Resign";
            }

        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
