using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolunteerVerseMobile.Models
{
    public class ProfileEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public OrganizationPreview Organization { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ImageUri { get; set; }
        public bool HasEnded { get; set; }
        public List<TaskPreview> Tasks { get; set; }
    }
}
