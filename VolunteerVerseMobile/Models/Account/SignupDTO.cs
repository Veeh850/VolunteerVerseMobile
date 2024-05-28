using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteerVerseMobile.Utils;

namespace VolunteerVerseMobile.Models
{
    public class SignupDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

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
