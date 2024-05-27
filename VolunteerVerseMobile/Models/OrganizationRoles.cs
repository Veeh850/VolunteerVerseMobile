using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolunteerVerseMobile.Models
{
    public enum OrganizationRoles
    {
        NoRole = -1,
        OrganizationMember = 0,
        EventAdmin = 1,
        OrganizationAdmin = 2,
        OrganizationOwner = 3,
        GlobalAdmin = 4,
    }
}
