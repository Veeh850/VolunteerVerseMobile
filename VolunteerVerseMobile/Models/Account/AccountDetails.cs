using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using VolunteerVerseMobile.Models.VolunteerDTOs;

namespace VolunteerVerseMobile.Models.Account
{
    public class AccountDetails
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>Gets or sets the email.</summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>Gets or sets the first name.</summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }

        /// <summary>Gets or sets the last name.</summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }

        /// <summary>Gets or sets the phone.</summary>
        /// <value>The phone.</value>
        public string Phone { get; set; }

        /// <summary>Gets or sets the profile picture URI.</summary>
        /// <value>The profile picture URI.</value>
        public string ProfilePictureUri { get; set; }

        /// <summary>Gets or sets the cover image URI.</summary>
        /// <value>The cover image URI.</value>
        public string CoverImageUri { get; set; }

        /// <summary>Gets or sets a value indicating whether this account has password.</summary>
        /// <value>
        ///   <c>true</c> if this instance has password; otherwise, <c>false</c>.</value>
        public bool HasPassword { get; set; }

        /// <summary>Gets or sets the volunteer basic details.</summary>
        /// <value>The volunteer basic details.</value>
        [JsonPropertyName("volunteer")]
        public VolunteerBasicDetailsDTO VolunteerBasicDetails { get; set; }
    }
}
