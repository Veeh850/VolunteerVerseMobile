using System.ComponentModel.DataAnnotations;
using VolunteerVerseMobile.Utils;

namespace VolunteerVerseMobile.Models.Account
{
    public class LoginWithEmailDTO
    {
        /// <summary>Gets or sets the email.</summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>Gets or sets the password.</summary>
        /// <value>The password.</value>
        public string Password { get; set; }

        /// <summary>Validates the dto.</summary>
        /// <returns>
        ///   Error Response DTO.
        /// </returns>
        public ErrorResponseDTO ValidateDTO()
        {
            ErrorResponseDTO errorResponse = new ErrorResponseDTO();

            var emailValidation = new EmailAddressAttribute();

            if (!emailValidation.IsValid(Email))
            {
                errorResponse.Errors.Add(ErrorMessages.InvalidEmailFormat);
            }

            return errorResponse;
        }
    }
}
