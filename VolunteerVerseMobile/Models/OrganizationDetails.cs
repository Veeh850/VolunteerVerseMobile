using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VolunteerVerseMobile.Models
{
    public class OrganizationDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Availability { get; set; }
        public string ImageUri { get; set; }
        public double? Rating { get; set; }
        public int RoleInOrganization { get; set; }

        [JsonPropertyName("events")]
        public List<EventPreview> EventPreviews { get; set; }

        [JsonPropertyName("members")]
        public List<OrganizationUser> OrganizationUsers { get; set; }
    }
}
