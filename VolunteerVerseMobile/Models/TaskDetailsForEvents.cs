using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VolunteerVerseMobile.Models
{
    public class TaskDetailsForEvents
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>Gets or sets the description.</summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>Gets or sets the capacity.</summary>
        /// <value>The capacity.</value>
        public int Capacity { get; set; }

        /// <summary>Gets or sets the taken.</summary>
        /// <value>Number of takened task.</value>
        public int Taken { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is applied.</summary>
        /// <value>
        ///   <c>true</c> if this instance is applied; otherwise, <c>false</c>.</value>
        public bool IsApplied { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is approved.</summary>
        /// <value>
        ///   <c>true</c> if this instance is approved; otherwise, <c>false</c>.</value>
        public bool IsApproved { get; set; }

        /// <summary>Gets or sets a value indicating whether is need approval for joining.</summary>
        /// <value>
        ///   <c>true</c> if need approval; otherwise, <c>false</c>.</value>
        public bool NeedApproval { get; set; }

        /// <summary>Gets or sets the skill responses.</summary>
        /// <value>The skill responses.</value>
        [JsonPropertyName("skills")]
        public List<SkillResponseDTO> Skills { get; set; }
    }
}
