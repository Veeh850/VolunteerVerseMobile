using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteerVerseMobile.Models;

namespace VolunteerVerseMobile.Utils
{
    public static class RoleHelper
    {
        public static bool IsOwner(int? roleInOrganization)
        {
            return roleInOrganization == (int)OrganizationRoles.OrganizationOwner;
        }

        public static bool IsOrgAdmin(int? roleInOrganization)
        {
            return roleInOrganization == (int)OrganizationRoles.OrganizationAdmin;
        }

        public static bool IsMinOrgAdmin(int? roleInOrganization)
        {
            return (roleInOrganization ?? -1) >= (int)OrganizationRoles.OrganizationAdmin;
        }

        public static bool IsMaxEventAdmin(int? roleInOrganization)
        {
            return (roleInOrganization ?? -1) <= (int)OrganizationRoles.EventAdmin;
        }

        public static bool IsMinOrgMember(int? roleInOrganization)
        {
            return (roleInOrganization ?? -1) >= (int)OrganizationRoles.OrganizationMember;
        }

        public static bool IsMinEventAdmin(int? roleInOrganization)
        {
            return (roleInOrganization ?? -1) >= (int)OrganizationRoles.EventAdmin;
        }

        public static string GetRoleName(int? roleInOrganization)
        {
            return roleInOrganization switch
            {
                (int)OrganizationRoles.OrganizationMember => "Member",
                (int)OrganizationRoles.EventAdmin => "Event Admin",
                (int)OrganizationRoles.OrganizationAdmin => "Org. Admin",
                (int)OrganizationRoles.OrganizationOwner => "Owner",
                (int)OrganizationRoles.GlobalAdmin => "Global Admin",
                _ => "No Role",
            };
        }
    }
}
