using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolunteerVerseMobile.Models.VolunteerDTOs
{
    public class VolunteerBasicDetailsDTO
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>Gets or sets the interests.</summary>
        /// <value>The interests.</value>
        public List<InterestResponseDTO> Interests { get; set; }

        /// <summary>Gets or sets the skills.</summary>
        /// <value>The skills.</value>
        public List<SkillResponseDTO> Skills { get; set; }
    }
}
