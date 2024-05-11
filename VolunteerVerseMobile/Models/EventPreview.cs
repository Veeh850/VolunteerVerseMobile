using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolunteerVerseMobile.Models
{
    public class EventPreview
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public DateTime StartTime { get; set; }

        public string ImageUri { get; set; } = string.Empty;

    }
}
