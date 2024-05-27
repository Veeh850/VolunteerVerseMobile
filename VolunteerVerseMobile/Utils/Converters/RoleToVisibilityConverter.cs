using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteerVerseMobile.Models;

namespace VolunteerVerseMobile.Utils.Converters
{
    public class RoleToVisibilityConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            OrganizationRoles? organizationRole = value as OrganizationRoles?;

            OrganizationRoles? requiredRole = parameter as OrganizationRoles?;

            if (organizationRole == null)
            {
                return false;
            }
            
            if (organizationRole >= requiredRole)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
