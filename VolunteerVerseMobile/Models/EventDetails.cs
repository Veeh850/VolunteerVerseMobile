using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VolunteerVerseMobile.Models
{
    public class EventDetails
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the organization.
        /// </summary>
        /// <value>
        /// The organization.
        /// </value>
        public OrganizationPreview Organization { get; set; }

        /// <summary>
        /// Gets or sets the role in event.
        /// </summary>
        /// <value>
        /// Integer value, representing Role in the event. Ex: EventAdmin = 1, OrganizationMember = 0, NoRole = -1.
        /// </value>
        public int RoleInEvent { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is organizer.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is applied; otherwise, <c>false</c>.
        /// </value>
        public bool IsJoined { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>
        /// The phone.
        /// </value>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        /// <value>
        /// The start time.
        /// </value>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        /// <value>
        /// The end time.
        /// </value>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Gets or sets the manpower.
        /// </summary>
        /// <value>
        /// The manpower.
        /// </value>
        public int Manpower { get; set; }

        /// <summary>
        /// Gets or sets the applied.
        /// </summary>
        /// <value>
        /// Number of applied volunteers.
        /// </value>
        public int Applied { get; set; }

        /// <summary>
        /// Gets or sets the image URI.
        /// </summary>
        /// <value>
        /// The image URI.
        /// </value>
        public string ImageUri { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether this instance has ended.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has ended; otherwise, <c>false</c>.
        /// </value>
        public bool HasEnded { get; set; }

        /// <summary>
        /// Gets or sets the task details.
        /// </summary>
        /// <value>
        /// List of task details.
        /// </value>
        [JsonPropertyName("tasks")]
        public List<TaskDetailsForEvents> TaskDetails { get; set; }
    }
}
