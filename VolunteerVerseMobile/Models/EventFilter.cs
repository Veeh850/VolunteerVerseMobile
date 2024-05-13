using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolunteerVerseMobile.Models
{
    public class EventFilter
    {
        public EventFilter(string name)
        {
            Name = name;
            OrganizationName = string.Empty;
            Location = string.Empty;
            StartDate = null;
            EndDate = null;
            SkillIds = null;
            PageSize = null;
            PageNumber = null;
        }

        public EventFilter(string name, string organizationName, string location, DateTime? startDate, DateTime? endDate, List<int> requiredSkillIds)
        {
            Name = name;
            OrganizationName = organizationName;
            Location = location;
            StartDate = startDate;
            EndDate = endDate;
            SkillIds = requiredSkillIds;
            PageSize = null;
            PageNumber = null;
        }
  
        public EventFilter(string name, string organizationName, string location, DateTime? startDate, DateTime? endDate, List<int> requiredSkillIds, int pageNumber, int pageSize)
        {
            Name = name;
            OrganizationName = organizationName;
            Location = location;
            StartDate = startDate;
            EndDate = endDate;
            SkillIds = requiredSkillIds;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>Gets or sets the name of the organization.</summary>
        /// <value>The name of the organization.</value>
        public string OrganizationName { get; set; }

        /// <summary>Gets or sets the location.</summary>
        /// <value>The location.</value>
        public string Location { get; set; }

        /// <summary>Gets or sets the start date.</summary>
        /// <value>The start date.</value>
        public DateTime? StartDate { get; set; }

        /// <summary>Gets or sets the end date.</summary>
        /// <value>The end date.</value>
        public DateTime? EndDate { get; set; }

        /// <summary>Gets or sets the required skill ids.</summary>
        /// <value>The required skill ids.</value>
        public List<int>? SkillIds { get; set; }

        /// <summary>Gets or sets the size of the page.</summary>
        /// <value>The size of the page.</value>
        public int? PageSize { get; set; }

        /// <summary>Gets or sets the page number.</summary>
        /// <value>The page number.</value>
        public int? PageNumber { get; set; }
    }
}
